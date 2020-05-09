using OpenQA.Selenium;
using Redcarpet.BDDtesting.Configuration;
using SeleniumExtras.PageObjects;

namespace Redcarpet.BDDtesting.PageObjects
{
    public class CorporatesPage
    {
        public CorporatesPage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }

        #region WebElements
        [FindsBy(How = How.XPath, Using = "//b[contains(text(),'Corporates')]")]
        private IWebElement lblCorporates;

        #endregion

        #region Actions
        public void CorporatesDashboard()
        {

        }

        #endregion
    }
}
