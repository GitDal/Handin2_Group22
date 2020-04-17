using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten.Models
{
    public class HotelClaimsViewModel
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public List<HotelAvailableClaims> UserOwnedClaims { get; set; }
    }

    public class HotelAvailableClaims
    {
        public string ClaimType { get; set; }
        public bool HasClaim { get; set; }
    }
}
