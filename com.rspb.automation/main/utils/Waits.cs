using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace com.rspb.automation.main.utils
{
    public class Waits
    {
        IWebDriver driver;

        public Waits(IWebDriver driver)
        {
            this.driver = driver;
        }

        public WebDriverWait GetWaitInstance()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            return wait;
        }

        public void WaitForElementClikable(By ele)
        {
            GetWaitInstance().Until(ExpectedConditions.ElementToBeClickable(ele));
        }

        public void WaitForElementVisibility(By ele)
        {
            GetWaitInstance().Until(ExpectedConditions.ElementIsVisible(ele));
        }

        public void WaitForElementDisplayed(By ele)
        {
            GetWaitInstance().Until(d => d.FindElement(ele).Displayed);
        }

        public void WaitForPageLoad()
        {
            driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(5);
        }
    }
}
