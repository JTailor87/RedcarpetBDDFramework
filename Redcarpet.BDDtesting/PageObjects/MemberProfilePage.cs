using OpenQA.Selenium;
using Redcarpet.BDDtesting.ComponentHelper;
using Redcarpet.BDDtesting.Configuration;
using SeleniumExtras.PageObjects;

namespace Redcarpet.BDDtesting.PageObjects
{
    public class MemberProfilePage
    {
        public MemberProfilePage()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }

        #region WebElements
        [FindsBy(How = How.Id, Using = "dark-layer")]
        private IWebElement ProfileIntro;
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'GOT IT')]")]
        private IWebElement btnGotIt;
        [FindsBy(How = How.XPath, Using = "//button[contains(text(),'EXPLORE PROFILE')]")]
        private IWebElement btnExplore;
        #endregion

        #region Actions
        public void profileIntro()
        {
            GenericHelper.IsElemetPresent(By.Id("ark-layer"));
        }

        #endregion
        public void navigateToProfile()
        {
            btnGotIt.Click();
            btnGotIt.Click();
            btnExplore.Click();
        }
    }
}
