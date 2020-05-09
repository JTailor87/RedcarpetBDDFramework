using OpenQA.Selenium;
using Redcarpet.BDDtesting.ComponentHelper;
using Redcarpet.BDDtesting.Configuration;
using SeleniumExtras.PageObjects;

namespace Redcarpet.BDDtesting.PageObjects
{
    public class LoginPage
    {
        public LoginPage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary']")]
        private IWebElement btnLogin;
        [FindsBy(How = How.Id, Using = "Username")]
        private IWebElement txtUserName;
        [FindsBy(How = How.Id, Using = "Password")]
        private IWebElement txtPassword;
        [FindsBy(How = How.Id, Using = "")]
        private IWebElement lnkForgotPassword;
        [FindsBy(How = How.Id, Using = "AccessToken")]
        private IWebElement txtOTP;
        #endregion

        #region Actions
        public void CaptureUserName(string username)
        {
            txtUserName.SendKeys(username);
        }

        public void CapturePassword(string password)
        {
            txtPassword.SendKeys(password);
            btnLogin.Click();
        }

        public void CaptureOTP(string username)
        {
            txtOTP.SendKeys(GetOTPHelper.GetOtpForUser(username));
            btnLogin.Click();
        }
        #endregion

        #region Navigation
        public void NavigateToLogin()
        {
            //string url = ConfigurationManager.AppSettings["devURL"];
            string url = GetMethods.getEnvironment();
            PropertiesCollection.Driver.Navigate().GoToUrl(url);
        }

        #endregion

    }
}
