using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Morgenmadsbuffeten.Models
{
    public class HotelClaims
    {
        public static string Admin => "Admin";
        public static string Receptionist => "Receptionist";
        public static string Server => "Server";
        public static string Cook => "Cook";

        public static string True => "true";
        public static string False => "false";

        public static List<string> GetUserAvailableClaims()
        {
            return new List<string>
            {
                Receptionist,
                Server,
                Cook
            };
        }
    }
}
