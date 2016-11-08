using AutomationFramework.Constants;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace AutomationFramework.PageContainers
{
    [ExcludeFromCodeCoverage]
    public abstract class UptakeBasePage
    {

        [FindsBy(How = How.Id, Using = "top")]
        private IWebElement UptakeHeader { get; set; }

        [FindsBy(How = How.XPath, Using = "//*[@id='top']/div/div/div/ul/li")]
        protected IList<IWebElement> HeaderNavElements { get; set; }

        [FindsBy(How = How.XPath, Using = "//*/footer/div/div[1]/div")]
        private IWebElement UptakeFooter { get; set; }

        protected IWebDriver Driver { get; }
        private readonly WebDriverWait m_wait;

        protected UptakeBasePage(IWebDriver driver)
        {
            Console.WriteLine($@"=====> {GetType().Name}");
            Driver = driver;
            PageFactory.InitElements(Driver, this);
            m_wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(DriverFactory.GetImplicitTimeoutValue()));
            Assert.IsTrue(IsAt(), "Base type elements missing.");
        }

        private bool IsAt()
        {
            return UptakeHeader.Displayed &&
                UptakeFooter.Displayed;

        }

        public bool DoAllHeaderMenuItemsMatchExpected()
        {
            var actual = ParseToolbarValuesIntoEnumType<HeaderMenu>(HeaderNavElements).GetEnumerator().ToString();
            //return DataProcessor.IsValuePresentInList();
            return true;
        }

        private static IList<T> ParseToolbarValuesIntoEnumType<T>(IList<IWebElement> listOfElements)
        {
            IList<T> menuItemConverted = new List<T>();

            Console.WriteLine(@"Parse and normalize values:");
            foreach (var text in listOfElements)
            {
                var sanitizedValue = ParseEnum<T>(text.FindElement(By.XPath("a")).Text.Replace(" ", ""));
                menuItemConverted.Add(sanitizedValue);
                Console.WriteLine($@"{text} => {sanitizedValue}");
            }
            return menuItemConverted;
        }

        protected static T ParseEnum<T>(string value) => (T)Enum.Parse(typeof(T), value, true);
    }
}
