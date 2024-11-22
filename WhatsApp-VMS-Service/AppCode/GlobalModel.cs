using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WhatsApp_VMS_Service.AppCode
{
    public class GlobalModel
    {
        //public static string SecretKey { get; set; } = Convert.ToString(Environment.GetEnvironmentVariable("SecretKey"));
        public static string SecretKey { get; set; } = "Admin@123";
        public static string WUserId { get; set; } = "2000241495";//Convert.ToString(Environment.GetEnvironmentVariable("WUserId"));
        public static string WPassword { get; set; } = "nB$yvp4U";//Convert.ToString(Environment.GetEnvironmentVariable("WPassword"));

        //public static string WUserId { get; set; } = "2000241495";//Convert.ToString(Environment.GetEnvironmentVariable("WUserId"));
        //public static string WPassword { get; set; } = "nB$yvp4U";//Convert.ToString(Environment.GetEnvironmentVariable("WPassword"));

        //public static string JWTSecret { get; set; } = "1234567890123456789123456789012345678912345678901234567890";
        //public static string JWTValidIssuer { get; set; } = "admin";
        //public static string JWTValidAudience { get; set; } = "admin";
        //public static string WUserId { get; set; } = "2000241495";//Convert.ToString(Environment.GetEnvironmentVariable("WUserId"));
        //public static string WPassword { get; set; } = "nB$yvp4U";

        public static bool IsCronJobRunning { get; set; } = false;

        public static string MobileNumber { get; set; } = "919109190390";

        public static string MobileNumber2 { get; set; } = "919424495391";
        public static string MobileNumber3 { get; set; } = "918982842284";
    }
}
