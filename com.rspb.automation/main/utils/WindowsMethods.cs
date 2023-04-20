using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace com.rspb.automation.main.utils
{
    class WindowsMethods
    {
        IWebDriver driver;

        public WindowsMethods(IWebDriver driver)
        {
            this.driver = driver;
        }

        public int GetWindows()
        {
            var windows = driver.WindowHandles;
            return windows.Count;
        }

        public void SwitchToWindow(string windowName)
        {
            driver.SwitchTo().Window(windowName);
        }

        public void CloseWindow()
        {
            driver.Close();
        }

        public void AcceptAlert()
        {
            driver.SwitchTo().Alert().Accept();
        }

        public void DismissAlert()
        {
            driver.SwitchTo().Alert().Dismiss();
        }

        public string GetAlertText()
        {
            return driver.SwitchTo().Alert().Text;
        }
    }
}
