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
    public class SignUpTest
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
        public void Signuptest_WE_T15()
        {
            test = TestConfig.extent.CreateTest("Signuptest_WE_T15");
            string actUrl = PageLibrary.Home.GoToSignup();
            string expUrl = "/account/register";
            Assert.IsTrue(actUrl.Contains(expUrl));

            dynamic testData = TestConfig.testData["signupTestData"]["SuccsefulUserRegistration"];
            PageLibrary.Signup.SignupAccount(testData);
            actUrl = browser.GetCurrentURL();
            string expUrlAfterSignUp = "/almost-done/";
            Thread.Sleep(3000);
            Assert.IsTrue(actUrl.Contains(expUrlAfterSignUp));
        }

        [Test]
        public void SetInvalidDataVerifyErrorMsg_WE_T16()
        {

            test = TestConfig.extent.CreateTest("SetInvalidDataVerifyErrorMsg_WE_T16");

            string actUrl = PageLibrary.Home.GoToSignup();
            string expUrl = "/account/register";
            Assert.IsTrue(actUrl.Contains(expUrl));

            dynamic testData = TestConfig.testData["signupTestData"]["UnSuccsefulUserRegistration"];
            PageLibrary.Signup.SignupAccount(testData);
           
            Thread.Sleep(3000);
            Assert.IsTrue(PageLibrary.Signup.VerifyErrorMessage("Oops! We couldn't find that UK postcode. " +
                "Can you check it's correct? If it's not in our list, or not in the UK, you can type in the whole address yourself. Thanks!"));
        }


        [Test]
        public void SetInvalidData_WE_T17()
        {
           
            test = TestConfig.extent.CreateTest("SetInvalidData_WE_T17");

            string actUrl = PageLibrary.Home.GoToSignup();
            string expUrl = "/account/register";
            Assert.IsTrue(actUrl.Contains(expUrl));

            dynamic testData = TestConfig.testData["signupTestData"]["UnSuccsefulUserRegistration"];
            PageLibrary.Signup.SignupAccount(testData);
          
            Thread.Sleep(3000);
            Assert.IsFalse(PageLibrary.Signup.VerifyErrorMessage("Oops! We couldn't find that UK postcode. Can you check it's correct? If it's not in our list, " +
                "or not in the UK, you can type in the whole address yourself. Thanks!"));
        }       

        [Test]
        public void Login_WE_T18()
        {

            test = TestConfig.extent.CreateTest("Login_WE_T18");

            string actUrl =  PageLibrary.Home.GoToLogin();            
            string expUrl = "/Account/Login";
            Assert.IsTrue(actUrl.Contains(expUrl));
            

            dynamic testData = TestConfig.testData["loginTestData"]["SuccessfulUserLogin"];
            PageLibrary.Login.LoginAccount(testData);
            Thread.Sleep(3000);            
            actUrl = browser.GetCurrentURL();
            string expUrlAfterLogin = "/profile";
            Thread.Sleep(3000);
            Assert.IsTrue(actUrl.Contains(expUrlAfterLogin));
        }       

        [TearDown]

    public void afterTestRun()
        {
            if(TestContext.CurrentContext.Result.Outcome != NUnit.Framework.Interfaces.ResultState.Success)
            {
                browser.TakeScreenshot();
                var base64Img = browser.base64Img;
                test.Warning("Failed At-> ", MediaEntityBuilder.CreateScreenCaptureFromPath(FileOperations.GetScreenshotsFilePath(browser.GetImageName())).Build());
            }
        }
    }
}
