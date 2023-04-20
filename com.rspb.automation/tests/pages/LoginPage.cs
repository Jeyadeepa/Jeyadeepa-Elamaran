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
    public class LoginPage
    {
        ElementMethods em = new ElementMethods(TestConfig.driver);
        IWebDriver driver = TestConfig.driver;

        By emailTextBox = By.CssSelector("#email");
        By passWordTextBox = By.CssSelector("#password");      
        By LoginBtn = By.XPath("//button[@value='login']");

        public void LoginAccount(dynamic testData)
        {
            em.ClearAndEnterText(emailTextBox, testData["email"].ToString());
            em.ClearAndEnterText(passWordTextBox, testData["password"].ToString());            
            em.ClickUsingJs(LoginBtn);
        }
    }
}
