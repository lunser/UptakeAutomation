using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using System;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;


namespace AutomationFramework
{
    [ExcludeFromCodeCoverage]
    public static class DriverFactory
    {
        private static IWebDriver _driver;

        private static string Browser => ConfigurationManager.AppSettings["browser"];
        private static int ImplicitTimeout => int.Parse(ConfigurationManager.AppSettings["implicitTimeout"]);

        public static IWebDriver Instance
        {
            get
            {
                if (_driver != null)
                {
                    return _driver;
                }

                switch (Browser.ToLower())
                {
                    case "chrome":
                        _driver = new ChromeDriver(".\\Webdrivers\\");
                        break;
                    case "firefox":
                        _driver = new FirefoxDriver();
                        break;
                    case "internetexplorer":
                        _driver = new InternetExplorerDriver(".\\Webdrivers\\");
                        break;
                    default:
                        throw new PlatformNotSupportedException($"Invalid browser: {Browser}");
                }
                //set implicit timeout based on app.config value
                _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(ImplicitTimeout));
                _driver.Manage().Window.Maximize();
                return _driver;
            }

            set { _driver = value; }
        }

        public static void Close()
        {
            if (_driver == null)
            {
                return;
            }
            _driver.Quit();
            _driver = null;
        }

        public static int GetImplicitTimeoutValue()
        {
            return ImplicitTimeout;
        }
    }
}
