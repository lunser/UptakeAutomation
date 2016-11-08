using AutomationFramework;
using AutomationFramework.PageContainers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;

namespace TestCases
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public abstract class UptakeBaseTest
    {
        protected IWebDriver Driver { get; private set; }
        private static string HomePageUrl => ConfigurationManager.AppSettings["homepageUrl"];
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
