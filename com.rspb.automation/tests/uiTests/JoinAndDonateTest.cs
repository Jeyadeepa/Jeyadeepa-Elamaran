using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using com.rspb.automation.main.utils;
using com.rspb.automation.tests.pages;
using NUnit.Framework;
using OpenQA.Selenium;

namespace com.rspb.automation.tests.uiTests
{
    [TestFixture]
    public class JoinAndDonateTest
    {

        IWebDriver driver = TestConfig.driver;
        public BrowserActions browser = new BrowserActions(TestConfig.driver);
        public static ExtentTest test;

        [SetUp]
        public void ClearTests()
        {
            test = null;
            test = TestConfig.test;
        }
        [Test]
        public void ClickJoinAndDonate_WE_T14()
        {

            test = TestConfig.extent.CreateTest("ClickJoinAndDonate_WE_T14");
            string actUrl = PageLibrary.Home.GoToJoinAndDonate();
            string expUrl = "/join-and-donate/";
            Assert.IsTrue(actUrl.Contains(expUrl));
        }
        [TearDown]

        public void afterTestRun()
        {
            if (TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
            {
                browser.TakeScreenshot();
                var base64Img = browser.base64Img;
                test.Warning("Failed At-> ", MediaEntityBuilder.CreateScreenCaptureFromPath(FileOperations.GetScreenshotsFilePath(browser.GetImageName())).Build());
            }
        }
    }
}
