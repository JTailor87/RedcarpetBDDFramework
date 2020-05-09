using Redcarpet.BDDtesting.Interfaces;
using System;
using System.Configuration;

namespace Redcarpet.BDDtesting.Configuration
{
    public class AppConfigReader : IConfig
    {
        public BrowserType? GetBrowser()
        {
            string browser = ConfigurationManager.AppSettings["Browser"];
            try
            {
                return (BrowserType)Enum.Parse(typeof(BrowserType), browser);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public string GetEnvironment()
        {
            return ConfigurationManager.AppSettings["Environment"];
        }

        public int GetElementLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings["ElementLoadTimeout"];
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }

        public int GetPageLoadTimeOut()
        {
            string timeout = ConfigurationManager.AppSettings["PageLoadTimeout"];
            if (timeout == null)
                return 30;
            return Convert.ToInt32(timeout);
        }
        public string GetPassword()
        {
            return ConfigurationManager.AppSettings["Password"];
        }

        public string GetUsername()
        {
            return ConfigurationManager.AppSettings["Username"];
        }
        public string GetDevUrl()
        {
            return ConfigurationManager.AppSettings["devURL"];
        }
        public string GetQaUrl()
        {
            return ConfigurationManager.AppSettings["qaURL"];
        }

        public string GetTokenDev()
        {
            return ConfigurationManager.AppSettings["devToken"];
        }

        public string GetTokenQA()
        {
            return ConfigurationManager.AppSettings["qaToken"];
        }
    }
}
