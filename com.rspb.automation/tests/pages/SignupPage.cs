using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using com.rspb.automation.main.utils;
using com.rspb.automation.tests.uiTests;
using OpenQA.Selenium;

namespace com.rspb.automation.tests.pages
{
    public class SignupPage
    {
        ElementMethods em = new ElementMethods(TestConfig.driver);
        IWebDriver driver = TestConfig.driver;

        By emailTextBox = By.CssSelector("#User_Email");
        By passWordTextBox = By.CssSelector("#User_Password");
        By titleDpDwn = By.CssSelector("#ContactDetails_Title");
        By firstNameTextBox = By.CssSelector("#ContactDetails_FirstName");
        By lastNameTextBox = By.CssSelector("#ContactDetails_LastName");
        By yesRadioBtn = By.XPath("//input[@type='radio' and @value='no']/../label");
        By homePhoneTextBox = By.CssSelector("#ContactDetails_HomePhone");
        By mobilePhoneTextBox = By.CssSelector("#ContactDetails_MobilePhone");
        By postalCodeTextBox = By.CssSelector("#Address_PostcodeLookup");
        By lookupAddressBtn = By.CssSelector("#FindAddresses");
        By selectAddressDpDwn= By.CssSelector("#Address_AddressId");
        By registrationBtn = By.CssSelector("#Registration");
        By noContacyByPostLabel = By.XPath("//label[@for='ContactByPost.No']");
        By noContacyByPhoneLabel = By.XPath("//label[@for='ContactByPhone.No']");
        By noContacyByEmailLabel = By.XPath("//label[@for='ContactByEmail.No']");
        By noContacyByTextLabel = By.XPath("//label[@for='ContactByText.No']");
        By paragraphText = By.Id("Address_PostcodeLookup-error");

        public void SignupAccount(dynamic testData)
        {
            em.ClearAndEnterText(emailTextBox, testData["email"].ToString());
            em.ClearAndEnterText(passWordTextBox, testData["password"].ToString());
            em.SelectByText(titleDpDwn, JSONUtils.GetDataValue(testData, "title"));
            em.ClearAndEnterText(firstNameTextBox, JSONUtils.GetDataValue(testData, "firstName"));
            em.ClearAndEnterText(lastNameTextBox, JSONUtils.GetDataValue(testData, "lastName"));
            em.ClickUsingJs(yesRadioBtn);
            em.ClearAndEnterText(homePhoneTextBox, JSONUtils.GetDataValue(testData, "phoneNumber"));
            em.ClearAndEnterText(mobilePhoneTextBox, JSONUtils.GetDataValue(testData, "mobileNumber"));
            em.ClearAndEnterText(postalCodeTextBox, JSONUtils.GetDataValue(testData, "postcode"));
            em.ClickOnElement(lookupAddressBtn);
         
            em.SelectByIndex(selectAddressDpDwn, 2);
            em.ClickUsingJs(noContacyByPostLabel);
            em.ClickUsingJs(noContacyByEmailLabel);
            em.ClickUsingJs(noContacyByPhoneLabel);
            em.ClickUsingJs(noContacyByTextLabel);
            em.ClickUsingJs(registrationBtn);
        }

        public bool VerifyErrorMessage(String text)
        {
            return em.GetElementText(paragraphText).Contains(text);
        }
    }
}
