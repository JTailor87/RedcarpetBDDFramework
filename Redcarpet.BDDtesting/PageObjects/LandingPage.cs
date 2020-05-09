using OpenQA.Selenium;
using Redcarpet.BDDtesting.Configuration;
using SeleniumExtras.PageObjects;

namespace Redcarpet.BDDtesting.PageObjects
{
    public class LandingPage
    {
        public LandingPage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//div[contains(text(),'Company')]")]
        private IWebElement linkCompanyDetails;

        #endregion

        #region Actions
        public void ClickCompanyDetails()
        {
            linkCompanyDetails.Click();
        }

        #endregion

        #region Navigation


        #endregion

    }
}
