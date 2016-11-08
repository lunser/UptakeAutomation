using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationFramework.PageContainers
{
    public class ApproachPage : UptakeBasePage
    {
        [FindsBy(How = How.Id, Using = "how")]
        private IWebElement HowContainer { get; set; }

        [FindsBy(How = How.Id, Using = "whynow")]
        private IWebElement WhyNowContainer { get; set; }

        [FindsBy(How = How.Id, Using = "testimonial")]
        private IWebElement HowTestimonialContainer { get; set; }

        public ApproachPage(IWebDriver driver) : base(driver)
        {
            PageFactory.InitElements(driver, this);
            Assert.IsTrue(IsAt(), "Home Page elements are missing");
        }

        private bool IsAt()
        {
            return HowContainer.Displayed &&
                   WhyNowContainer.Displayed &&
                   HowTestimonialContainer.Displayed;
        }
    }
}
