using OpenQA.Selenium;
using Redcarpet.BDDtesting.ComponentHelper;
using Redcarpet.BDDtesting.Configuration;
using Redcarpet.BDDtesting.PageObjects;
using System;
using TechTalk.SpecFlow;

namespace Redcarpet.BDDtesting.StepDefinitions
{
    [Binding]
    public sealed class LoginCorporateSteps
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext context;

        public LoginCorporateSteps(ScenarioContext injectedContext)
        {
            context = injectedContext;
        }
        readonly string username = "3cd25333c7@emailtown.club";
        readonly string password = "Rubb3r@Mat";

        #region Given
        [Given(@"User is already on Login page")]
        public void GivenUserIsAlreadyOnLoginPage()
        {
            //PropertiesCollection.Driver = new BaseClass().
            LoginPage loginPage = new LoginPage();
            loginPage.NavigateToLogin();
        }

        #endregion

        #region When
        [When(@"Title of Login page is ""(.*)""")]
        public void WhenTitleOfLoginPageIs(string pTitle)
        {
            AssertHelper.AreEqual(pTitle, PropertiesCollection.Driver.Title);
        }

        #endregion

        #region And

        [When(@"Only enter email and click on LOG IN")]
        public void WhenOnlyEnterEmailAndClickOnLOGIN()
        {
            LoginPage lPage = new LoginPage();
            //string username = "";
            lPage.CaptureUserName(username);

        }
        [When(@"Only enter pasword and click on LOG IN")]
        public void WhenOnlyEnterPaswordAndClickOnLOGIN()
        {
            LoginPage lPage = new LoginPage();
            //string password = "";
            lPage.CapturePassword(password);
        }
        [When(@"User enters valid ""(.*)"" and ""(.*)"" and click LOGIN")]
        public void WhenUserEntersValidAndAndClickLOGIN(string Email, string Password)
        {
            LoginPage lPage = new LoginPage();
            PropertiesCollection.Driver.Manage()
                 .Timeouts().ImplicitWait = TimeSpan.FromSeconds(PropertiesCollection.Config.GetElementLoadTimeOut());
            string pTitle = "Profile Login";
            lPage.CaptureUserName(Email);
            AssertHelper.AreEqual(pTitle, PropertiesCollection.Driver.Title);
            lPage.CapturePassword(Password);
        }

        [When(@"User clicks on LOG IN")]
        public void WhenUserClicksOnLOGIN()
        {

        }
        [When(@"User is on Verify Code page")]
        public void WhenUserIsOnVerifyCodePage()
        {

        }
        [When(@"User enters OTP and click on LOG IN")]
        public void WhenUserEntersOTPAndClickOnLOGIN()
        {
            string pTitle = "Complete Login";
            AssertHelper.AreEqual(pTitle, PropertiesCollection.Driver.Title);
            LoginPage lPage = new LoginPage();
            lPage.CaptureOTP(username);
        }
        [Then(@"User clicks on ""(.*)""")]
        public void ThenUserClicksOn(string CompanyDetails)
        {
            IWebElement webElement = GenericHelper.GetElement(By.XPath("//b[contains(text()," + CompanyDetails + ")]"));
            webElement.Click();
        }

        #endregion

        #region Then
        [Then(@"User is on the ""(.*)"" page")]
        public void ThenUserIsOnThePage(string Landing)
        {
            //string pTitle = "Home";
            AssertHelper.AreEqual(Landing, PropertiesCollection.Driver.Title);
        }

        [Then(@"The the user is redirected to the correct ""(.*)""")]
        public void ThenTheTheUserIsRedirectedToTheCorrect(string Dashboard, Table table)
        {
            IWebElement webElement = GenericHelper.GetElement(By.XPath("//b[contains(text()," + Dashboard + ")]"));
            AssertHelper.AreEqual(Dashboard, webElement.GetText());
        }

        #endregion
    }
}
