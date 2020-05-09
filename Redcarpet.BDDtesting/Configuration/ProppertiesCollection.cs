using OpenQA.Selenium;
using Redcarpet.BDDtesting.Interfaces;

namespace Redcarpet.BDDtesting.Configuration
{
    enum PropertyType
    {
        Id,
        Name,
        LinkText,
        CssName,
        ClassName,
        Xpath
    }
    class PropertiesCollection
    {
        public static IConfig Config { get; set; }
        //Auto-implemented Property
        public static IWebDriver Driver { get; set; }
    }
}
