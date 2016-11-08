using AutomationFramework;
using AutomationFramework.PageContainers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using AutomationFramework.Constants;

namespace TestCases
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public abstract class UptakeBaseTest
    {
        protected IWebDriver Driver { get; private set; }
        private static string HomePageUrl => ConfigurationManager.AppSettings["homepageUrl"];
        protected IList<string> ExpectedHeaderMenuOptions => Enum.GetValues(typeof(HeaderMenu)).Cast<HeaderMenu>().Select(x => x.ToString()).ToList();
        protected IList<string> ExpectedFootefMenuOptions => Enum.GetValues(typeof(FooterMenu)).Cast<FooterMenu>().Select(x => x.ToString()).ToList();
        
        //Page declaration
        protected HomePage HomePage { get; set; }
        protected ApproachPage ApproachPage { get; set; }

        [TestInitialize]
        public void BaseTestInit()
        {
            Console.WriteLine(@"...call for BaseTestInit()");
            Driver = DriverFactory.Instance;
            Console.WriteLine($@"Navigate to {HomePageUrl}");
            Driver.Navigate().GoToUrl(HomePageUrl);
        }

        [TestCleanup]
        public void BaseTestCleanup()
        {
            Console.WriteLine(@"...call for BaseTestCleanup()");
            DriverFactory.Close();
        }
    }
}
