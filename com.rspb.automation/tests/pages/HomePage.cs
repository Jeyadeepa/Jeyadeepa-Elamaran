using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using com.rspb.automation.main.utils;
using com.rspb.automation.tests.uiTests;
using OpenQA.Selenium;

namespace com.rspb.automation.tests.pages
{
    public class HomePage
    {
        ElementMethods em = new ElementMethods(TestConfig.driver);
        Waits wait = new Waits(TestConfig.driver);
        BrowserActions browserActions = new BrowserActions(TestConfig.driver);
        IWebDriver driver = TestConfig.driver;

        By signUpLink = By.CssSelector(".login-register-separator + a");

        

        By JoinAndDonateLink = By.XPath("//a[contains(@href,'join-and-donate/')]");
        By LoginLink = By.XPath("//a[@href='/account/login']");
        public string GoToSignup()
        {
            em.ClickOnElement(signUpLink);
            wait.WaitForPageLoad();
            return browserActions.GetCurrentURL();
        }

        public string GoToLogin()
        {
            em.ClickOnElement(LoginLink);
            wait.WaitForPageLoad();
            return browserActions.GetCurrentURL();
        }
        public string GoToJoinAndDonate()
        {
            
            em.ClickOnElement(JoinAndDonateLink);
            wait.WaitForPageLoad();
            return browserActions.GetCurrentURL();
        }
    }
}
