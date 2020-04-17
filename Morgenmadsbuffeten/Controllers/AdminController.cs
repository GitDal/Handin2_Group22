using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Controllers
{
    [Authorize("IsAdmin")]
    public class AdminController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public AdminController(UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: ManageUsers
        public IActionResult ManageUsers()
        {
            var users = new List<KeyValuePair<string, string>>();

            foreach (var user in _userManager.Users.ToList())
            {
               users.Add(new KeyValuePair<string, string>(user.Id, user.UserName));
            }

            return View(users);
        }

        public IActionResult EditUserClaims(string userId)
        {
            var user = _userManager.FindByIdAsync(userId).Result;

            if (user == null)
            {
                return NotFound();
            }

            var claimsPrincipal = _signInManager.CreateUserPrincipalAsync(user).Result;

            var listOfClaims = new List<HotelAvailableClaims>();

            foreach (var ctype in HotelClaims.GetUserAvailableClaims())
            {
                var claim = claimsPrincipal.FindFirst(c => c.Type == ctype);
                if (claim != null)
                    listOfClaims.Add(new HotelAvailableClaims()
                    {
                        ClaimType = claim.Type,
                        HasClaim = claim.Value == HotelClaims.True
                    });
            }

            HotelClaimsViewModel userClaims = new HotelClaimsViewModel()
            {
                UserId = userId,
                UserName = user.UserName,
                UserOwnedClaims = listOfClaims
            };

            return View(userClaims);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditUserClaims(HotelClaimsViewModel userClaims)
        {
            var user = _userManager.FindByIdAsync(userClaims.UserId).Result;
            var cp = _signInManager.CreateUserPrincipalAsync(user).Result;

            if(userClaims.UserOwnedClaims != null) //In case someone tries to edit a user with no editable claims, UserOwnedClaims becomes null
            {
                foreach (var e in userClaims.UserOwnedClaims)
                {
                    var oldClaim = cp.FindFirst(c =>
                        c.Type == e.ClaimType);

                    if (oldClaim != null)
                    {
                        var newClaim = new Claim(e.ClaimType, e.HasClaim ? HotelClaims.True : HotelClaims.False);

                        await _userManager.ReplaceClaimAsync(user, oldClaim, newClaim);
                    }
                }
            }

            return RedirectToAction(nameof(ManageUsers));
        }
    }
}