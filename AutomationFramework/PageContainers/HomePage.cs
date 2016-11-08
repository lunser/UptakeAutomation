using AutomationFramework.Constants;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System.Diagnostics.CodeAnalysis;

namespace AutomationFramework.PageContainers
{
    [ExcludeFromCodeCoverage]
    public class HomePage : UptakeBasePage
    {
        #region DOM elements
        [FindsBy(How = How.Id, Using = "callout")]
        private IWebElement CalloutSection { get; set; }

        [FindsBy(How = How.Id, Using = "data")]
        private IWebElement DataSection { get; set; }

        [FindsBy(How = How.Id, Using = "answers")]
        private IWebElement AnswersSection { get; set; }

        [FindsBy(How = How.Id, Using = "actions")]
        private IWebElement ActionsSection { get; set; }
        #endregion

        public HomePage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            Assert.IsTrue(IsAt(), "Home Page elements are missing");
        }

        private bool IsAt()
        {
            return CalloutSection.Displayed &&
                 DataSection.Displayed &&
                 AnswersSection.Displayed &&
                 ActionsSection.Displayed;
        }

        public void NavigateToPage(HeaderMenu item)
        {
            foreach (var link in HeaderNavElements)
            {
                var linkText = link.FindElement(By.XPath("a")).Text.Replace(" ", "");
                if (!linkText.Equals(item.ToString()))
                    continue;
                link.Click();
                break;
            }
        }
    }
}
