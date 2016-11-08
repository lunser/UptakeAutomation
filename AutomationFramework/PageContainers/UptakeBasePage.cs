using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

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

        [FindsBy(How = How.XPath, Using = "//*/footer/div/div[1]/div/ul/li")]
        protected IList<IWebElement> FooterNavElements { get; set; }

        protected IWebDriver Driver { get; }

        protected UptakeBasePage(IWebDriver driver)
        {
            Console.WriteLine($@"=====> {GetType().Name}");
            Driver = driver;
            PageFactory.InitElements(Driver, this);
            Assert.IsTrue(IsAt(), "Base type elements missing.");
        }

        private bool IsAt()
        {
            return UptakeHeader.Displayed &&
                   UptakeFooter.Displayed;
        }

        public IEnumerable<string> GetAllAvailableHeaderMenuItems() =>
            HeaderNavElements.Select(option => option.FindElement(By.XPath("a")).Text.Replace(" ", "")).ToList();

        public IEnumerable<string> GetAllAvailableFooterMenuItems() => 
            FooterNavElements.Select(option => option.FindElement(By.XPath("a")).Text.Replace(" ", "")).ToList();
    }
}

