using System;
using System.Linq;
using System.Net;

namespace Redcarpet.BDDtesting.ComponentHelper
{
    class GetOTPHelper
    {
        public static string GetOtpForUser(string username)
        {
            //string url = PropertiesCollection.Config.GetTokenDev(); //@"https://accesstokenapi-dev.azurewebsites.net/email2sv.txt";
            string url = GetMethods.getOTPfile();
            var wc = new WebClient();
            var textFile = wc.DownloadString(url);
            var lines = textFile.Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            var userOtp = lines.Last(x => x.Contains(username));
            return userOtp.Substring(userOtp.LastIndexOf(' ') + 1);
        }
    }
}
