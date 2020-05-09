using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Redcarpet.BDDtesting.Configuration;
using System.Linq;

namespace Redcarpet.BDDtesting.ComponentHelper
{
    public static class GetMethods
    {
        public static string GetText(this IWebElement element)
        {
            return element.GetAttribute("value");
        }

        public static string GetTextFromDropDownList(this IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;
        }
        public static string getEnvironment()
        {
            PropertiesCollection.Config = new AppConfigReader();
            //string env = PropertiesCollection.Config.GetEnvironment();
            if (PropertiesCollection.Config.GetEnvironment() == "DEV")
            {
                string url = PropertiesCollection.Config.GetDevUrl();
                return url;
            }
            else if (PropertiesCollection.Config.GetEnvironment() == "QA")
            {
                string url = PropertiesCollection.Config.GetQaUrl();
                return url;
            }
            else
            {
                throw new NoSutiableDriverFound("Environment Not Found : " + PropertiesCollection.Config.GetEnvironment().ToString());
            }
        }
        public static string getOTPfile()
        {
            PropertiesCollection.Config = new AppConfigReader();
            //string env = PropertiesCollection.Config.GetEnvironment();
            if (PropertiesCollection.Config.GetEnvironment() == "DEV")
            {
                string url = PropertiesCollection.Config.GetTokenDev();
                return url;
            }
            else if (PropertiesCollection.Config.GetEnvironment() == "QA")
            {
                string url = PropertiesCollection.Config.GetTokenQA();
                return url;
            }
            else
            {
                throw new NoSutiableDriverFound("Token file Not Found : " + PropertiesCollection.Config.GetEnvironment().ToString());
            }

        }

    }
}
