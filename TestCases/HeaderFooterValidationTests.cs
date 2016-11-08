using AutomationFramework;
using AutomationFramework.Constants;
using AutomationFramework.PageContainers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestCases
{
    [TestClass]
    public class HeaderFooterValidationTests : UptakeBaseTest
    {
        [TestMethod]
        public void HomePage_VerifyHeaderMenuItems()
        {
            HomePage = new HomePage(Driver);
            Assert.IsTrue(DataProcessor.VerifyValuesMatch(ExpectedHeaderMenuOptions, HomePage.GetAllAvailableHeaderMenuItems()),
                "Validation of Header menu items failed, please verify results manually!");
        }

        [TestMethod]
        public void HomePage_VerifyFooterMenuItems()
        {
            HomePage = new HomePage(Driver);
            Assert.IsTrue(DataProcessor.VerifyValuesMatch(ExpectedFootefMenuOptions, HomePage.GetAllAvailableFooterMenuItems()),
                "Validation of Footer menu items failed, please verify results manually!");
        }

        [TestMethod]
        public void ApproachPage_VerifyHeaderMenuItems()
        {
            HomePage = new HomePage(Driver);
            HomePage.NavigateToPage(HeaderMenu.Approach);
            ApproachPage = new ApproachPage(Driver);
            Assert.IsTrue(DataProcessor.VerifyValuesMatch(ExpectedHeaderMenuOptions, ApproachPage.GetAllAvailableHeaderMenuItems()),
                "Validation of Header menu items failed, please verify results manually!");
        }

        [TestMethod]
        public void ApproachPage_VerifyFooterMenuItems()
        {
            HomePage = new HomePage(Driver);
            HomePage.NavigateToPage(HeaderMenu.Approach);
            ApproachPage = new ApproachPage(Driver);
            Assert.IsTrue(DataProcessor.VerifyValuesMatch(ExpectedFootefMenuOptions, HomePage.GetAllAvailableFooterMenuItems()),
                "Validation of Footer menu items failed, please verify results manually!");
        }
    }
}
