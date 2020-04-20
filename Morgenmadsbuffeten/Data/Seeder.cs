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
        public static void SeedAdmin(UserManager<IdentityUser> userManager)
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
                    var claimResult = userManager.AddClaimAsync(user, adminClaim);
                    claimResult.Wait();
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


        public static void SeedServer(UserManager<IdentityUser> userManager)
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
                    var serverClaimResult = userManager.AddClaimAsync(user, serverClaim);
                    serverClaimResult.Wait();

                    var cookClaim = new Claim(HotelClaims.Cook, HotelClaims.False);
                    var cookClaimResult = userManager.AddClaimAsync(user, cookClaim);
                    cookClaimResult.Wait();

                    var receptionistClaim = new Claim(HotelClaims.Receptionist, HotelClaims.False);
                    var receptionistClaimResult = userManager.AddClaimAsync(user, receptionistClaim);
                    receptionistClaimResult.Wait();
                }
            }
        }

        public static void SeedCook(UserManager<IdentityUser> userManager)
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
                    var serverClaimResult = userManager.AddClaimAsync(user, serverClaim);
                    serverClaimResult.Wait();

                    var cookClaim = new Claim(HotelClaims.Cook, HotelClaims.True);
                    var cookClaimResult = userManager.AddClaimAsync(user, cookClaim);
                    cookClaimResult.Wait();

                    var receptionistClaim = new Claim(HotelClaims.Receptionist, HotelClaims.False);
                    var receptionistClaimResult = userManager.AddClaimAsync(user, receptionistClaim);
                    receptionistClaimResult.Wait();
                }
            }
        }

        public static void SeedReceptionist(UserManager<IdentityUser> userManager)
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
                    var serverClaimResult = userManager.AddClaimAsync(user, serverClaim);
                    serverClaimResult.Wait();

                    var cookClaim = new Claim(HotelClaims.Cook, HotelClaims.False);
                    var cookClaimResult = userManager.AddClaimAsync(user, cookClaim);
                    cookClaimResult.Wait();

                    var receptionistClaim = new Claim(HotelClaims.Receptionist, HotelClaims.True);
                    var receptionistClaimResult = userManager.AddClaimAsync(user, receptionistClaim);
                    receptionistClaimResult.Wait();
                }
            }
        }

        public static void SeedSuperUser(UserManager<IdentityUser> userManager)
        {
            const string SuperUserEmail = "SuperUser@Hotel";
            const string SuperUserPassword = "Lukmigind1!";

            if (userManager.FindByNameAsync(SuperUserEmail).Result == null)
            {
                var user = new IdentityUser
                {
                    UserName = SuperUserEmail,
                    Email = SuperUserEmail,
                    EmailConfirmed = true
                };
                IdentityResult result = userManager.CreateAsync
                    (user, SuperUserPassword).Result;
                if (result.Succeeded)
                {
                    var adminClaim = new Claim(HotelClaims.Admin, HotelClaims.True);
                    var claimResult = userManager.AddClaimAsync(user, adminClaim);
                    claimResult.Wait();

                    var serverClaim = new Claim(HotelClaims.Server, HotelClaims.True);
                    var serverClaimResult = userManager.AddClaimAsync(user, serverClaim);
                    serverClaimResult.Wait();

                    var cookClaim = new Claim(HotelClaims.Cook, HotelClaims.True);
                    var cookClaimResult = userManager.AddClaimAsync(user, cookClaim);
                    cookClaimResult.Wait();

                    var receptionistClaim = new Claim(HotelClaims.Receptionist, HotelClaims.True);
                    var receptionistClaimResult = userManager.AddClaimAsync(user, receptionistClaim);
                    receptionistClaimResult.Wait();
                }
            }
        }
    }
}
