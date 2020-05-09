using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using Redcarpet.BDDtesting.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Redcarpet.BDDtesting.ComponentHelper
{
    public static class SetMethods
    {
        //Enter Test
        public static void EnterText(this IWebElement element, String value)
        {
            element.SendKeys(value);
        }
        //Click on to a Button, Checkbox, Option etc.
        public static void Clicks(this IWebElement element)
        {
            element.Click();
        }
        //Selecting a Drop Down Controls
        public static void SlectDropDown(this IWebElement element, String value)
        {
            new SelectElement(element).SelectByText(value);
        }
        //SwitchTo is Seleniums InBuilt Code and Driver is WebDriver 
        public static void SwitchtoCurrentWindow()
        {
            PropertiesCollection.Driver.SwitchTo().Window(PropertiesCollection.Driver.WindowHandles.Last());
        }
        public static void HowmanyIFrames()
        {
            List<IWebElement> frames = new List<IWebElement>(PropertiesCollection.Driver.FindElements(By.TagName("iframe")));
            Console.WriteLine("Number of Frames: " + frames.Count);
            for (int i = 0; i < frames.Count; i++)
            {
                Console.WriteLine("frame[" + i + "]: " + frames[i].GetAttribute("id").ToString());
            }
        }
        public static void ScrollById(String ID)
        {
            var element = PropertiesCollection.Driver.FindElement(By.Id(ID));
            Actions actions = new Actions(PropertiesCollection.Driver);
            actions.MoveToElement(element);
            actions.Perform();
        }
    }
}
