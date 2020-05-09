using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using Redcarpet.BDDtesting.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;


namespace Redcarpet.BDDtesting.ComponentHelper
{
    public class GenericHelper
    {
        private static Func<IWebDriver, bool> WaitForWebElementFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return true;
                return false;
            });
        }

        private static Func<IWebDriver, IList<IWebElement>> GetAllElements(By locator)
        {
            return ((x) =>
            {
                return x.FindElements(locator);
            });
        }

        private static Func<IWebDriver, IWebElement> WaitForWebElementInPageFunc(By locator)
        {
            return ((x) =>
            {
                if (x.FindElements(locator).Count == 1)
                    return x.FindElement(locator);
                return null;
            });
        }

        public static void SelecFromAutoSuggest(By autoSuggesLocator, string initialStr, string strToSelect,
            By autoSuggestistLocator)
        {
            var autoSuggest = PropertiesCollection.Driver.FindElement(autoSuggesLocator);
            autoSuggest.SendKeys(initialStr);
            Thread.Sleep(1000);

            var wait = GenericHelper.GetWebdriverWait(TimeSpan.FromSeconds(40));
            var elements = wait.Until(GetAllElements(autoSuggestistLocator));
            var select = elements.First((x => x.Text.Equals(strToSelect, StringComparison.OrdinalIgnoreCase)));
            select.Click();
            Thread.Sleep(1000);
        }

        public static WebDriverWait GetWebdriverWait(TimeSpan timeout)
        {
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            WebDriverWait wait = new WebDriverWait(PropertiesCollection.Driver, timeout)
            {
                PollingInterval = TimeSpan.FromMilliseconds(500),
            };
            wait.IgnoreExceptionTypes(typeof(NoSuchElementException), typeof(ElementNotVisibleException));
            return wait;
        }
        public static bool IsElemetPresent(By locator)
        {
            try
            {
                //return PropertiesCollection.Driver.FindElements(locator).Count == 1
                return PropertiesCollection.Driver.FindElement(locator).Displayed;
            }
            catch (Exception)
            {
                return false;
            }

        }

        public static IWebElement GetElement(By locator)
        {
            if (IsElemetPresent(locator))
                return PropertiesCollection.Driver.FindElement(locator);
            else
                throw new NoSuchElementException("Element Not Found : " + locator.ToString());
        }

        public static bool WaitForWebElement(By locator, TimeSpan timeout)
        {
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(WaitForWebElementFunc(locator));
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(PropertiesCollection.Config.GetElementLoadTimeOut()));
            return flag;
        }

        public static void WaitForWebElement(IWebElement webElement, TimeSpan timeout)
        {
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            var wait = GetWebdriverWait(timeout);
            wait.Until(ExpectedConditions.ElementToBeClickable(webElement));
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(PropertiesCollection.Config.GetElementLoadTimeOut()));
        }

        public static IWebElement WaitForWebElementVisisble(By locator, TimeSpan timeout)
        {
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(PropertiesCollection.Config.GetElementLoadTimeOut()));
            return flag;
        }

        public static IWebElement WaitForWebElementInPage(By locator, TimeSpan timeout)
        {
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(WaitForWebElementInPageFunc(locator));
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(PropertiesCollection.Config.GetElementLoadTimeOut()));
            return flag;
        }

        public static IWebElement Wait(Func<IWebDriver, IWebElement> conditions, TimeSpan timeout)
        {
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(1));
            var wait = GetWebdriverWait(timeout);
            var flag = wait.Until(conditions);
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitWait = (TimeSpan.FromSeconds(PropertiesCollection.Config.GetElementLoadTimeOut()));
            return flag;
        }

    }
}
