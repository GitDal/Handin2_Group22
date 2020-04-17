using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Morgenmadsbuffeten.Models;

namespace Morgenmadsbuffeten.Data
{
    public class Seeder
    {
        // Should maybe be async, with awaits?
        public static async void SeedAdmin(UserManager<IdentityUser> userManager)
        {
            const string adminEmail = "Admin@Hotel";
            const string adminPassword = "Lukmigind1!";

            if (userManager.FindByNameAsync(adminEmail).Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = adminEmail,
                    Email = adminEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, adminPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim(HotelClaims.Admin, HotelClaims.True);
                    await userManager.AddClaimAsync(user, adminClaim);
                }
            }
        }

        public static void UnSeedAdmin(UserManager<IdentityUser> userManager)
        {
            const string adminEmail = "Admin@Hotel";

            // Find admin user
            var findUserTask = userManager.FindByNameAsync(adminEmail);

            if (findUserTask.Result != null)
            {
                var admin = findUserTask.Result;

                userManager.DeleteAsync(admin);
            }

        }


        public static async void SeedServer(UserManager<IdentityUser> userManager)
        {
            const string serverEmail = "Server@Hotel";
            const string serverPassword = "Lukmigind1!";

            if (userManager.FindByNameAsync(serverEmail).Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = serverEmail,
                    Email = serverEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, serverPassword).Result;
                if (result.Succeeded)
                {
                    var serverClaim = new Claim(HotelClaims.Server, HotelClaims.True);
                    await userManager.AddClaimAsync(user, serverClaim);

                    var cookClaim = new Claim(HotelClaims.Cook, HotelClaims.False);
                    await userManager.AddClaimAsync(user, cookClaim);

                    var receptionistClaim = new Claim(HotelClaims.Receptionist, HotelClaims.False);
                    await userManager.AddClaimAsync(user, receptionistClaim);
                }
            }
        }

        public static async void SeedCook(UserManager<IdentityUser> userManager)
        {
            const string cookEmail = "Cook@Hotel";
            const string cookPassword = "Lukmigind1!";

            if (userManager.FindByNameAsync(cookEmail).Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = cookEmail,
                    Email = cookEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, cookPassword).Result;
                if (result.Succeeded)
                {
                    var serverClaim = new Claim(HotelClaims.Server, HotelClaims.False);
                    await userManager.AddClaimAsync(user, serverClaim);

                    var cookClaim = new Claim(HotelClaims.Cook, HotelClaims.True);
                    await userManager.AddClaimAsync(user, cookClaim);

                    var receptionistClaim = new Claim(HotelClaims.Receptionist, HotelClaims.False);
                    await userManager.AddClaimAsync(user, receptionistClaim);
                }
            }
        }

        public static async void SeedReceptionist(UserManager<IdentityUser> userManager)
        {
            const string receptionistEmail = "Receptionist@Hotel";
            const string receptionistPassword = "Lukmigind1!";

            if (userManager.FindByNameAsync(receptionistEmail).Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = receptionistEmail,
                    Email = receptionistEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, receptionistPassword).Result;
                if (result.Succeeded)
                {
                    var serverClaim = new Claim(HotelClaims.Server, HotelClaims.False);
                    await userManager.AddClaimAsync(user, serverClaim);

                    var cookClaim = new Claim(HotelClaims.Cook, HotelClaims.False);
                    await userManager.AddClaimAsync(user, cookClaim);

                    var receptionistClaim = new Claim(HotelClaims.Receptionist, HotelClaims.True);
                    await userManager.AddClaimAsync(user, receptionistClaim);
                }
            }
        }
    }
}
