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
            HomePage.NavigateToPage(HeaderMenu.Approach);
            ApproachPage = new ApproachPage(Driver);

            Assert.IsTrue(ApproachPage.HeaderMenuItemsMatchExpected(), "Validation of Header menu items failed, please verify results manually!");

        }
    }
}
