using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

/// <summary>
/// This class will contain different reuseable elemnt action utils
/// </summary>
namespace com.rspb.automation.main.utils
{
    class ElementMethods
    {
        IWebDriver driver;
        Waits waits;
        Actions action;

        public ElementMethods(IWebDriver driver)
        {
            this.driver = driver;
            waits = new Waits(driver);
            action = new Actions(driver);
        }

        /// <summary>
        /// This method will attempt to perform a click on element for given locator
        /// </summary>
        /// <param name="ele"></param>
        public void ClickOnElement(By ele)
        {
            try
            {
                waits.WaitForElementClikable(ele);
                GetWebElement(ele).Click();
            }catch(Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// This method will attempt to perform an action to clear and enter text into a text field
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="inputText"></param>
        public void ClearAndEnterText(By ele, String inputText)
        {
            try
            {
                waits.WaitForElementVisibility(ele);
                GetWebElement(ele).Clear();
                GetWebElement(ele).SendKeys(inputText);
            }catch(Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// This method will attempt to perform an action enter text into a text field
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="inputText"></param>
        public void EnterText(By ele, String inputText)
        {
            try
            {
                waits.WaitForElementVisibility(ele);
                GetWebElement(ele).SendKeys(inputText);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ele"></param>
        /// <param name="dropdownValue"></param>
        public void SelectByValue(By ele, string dropdownValue)
        {
            try
            {
                waits.WaitForElementVisibility(ele);
                SelectElement selectEle = new SelectElement(GetWebElement(ele));
                selectEle.SelectByValue(dropdownValue);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public void SelectByText(By ele, string dropdownText)
        {
            try
            {
                waits.WaitForElementVisibility(ele);
                SelectElement selectEle = new SelectElement(GetWebElement(ele));
                selectEle.SelectByText(dropdownText);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public void SelectByIndex(By ele, int index)
        {
            try
            {
                waits.WaitForElementVisibility(ele);
                SelectElement selectEle = new SelectElement(GetWebElement(ele));
                selectEle.SelectByIndex(index);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public bool IsElementDisplayed(By ele)
        {
            bool isElemDisplayed = false;

            try
            {
                waits.WaitForElementVisibility(ele);
                isElemDisplayed = GetWebElement(ele).Displayed;
            }catch(Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }

            return isElemDisplayed;
        }

        public string GetElementText(By ele)
        {
            string actText = "";

            try
            {
                waits.WaitForElementVisibility(ele);
                actText = GetWebElement(ele).Text;
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            return actText;
        }

        public string GetElementAttribute(By ele, string expAttribute)
        {
            string expAttrValue = "";

            try
            {
                waits.WaitForElementVisibility(ele);
                expAttrValue = GetWebElement(ele).GetAttribute(expAttribute);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            return expAttrValue;
        }

        public string GetElementCssValue(By ele, string expCss)
        {
            string expCssValue = "";

            try
            {
                waits.WaitForElementVisibility(ele);
                expCssValue = GetWebElement(ele).GetCssValue(expCss);
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            return expCssValue;
        }

        public IList<IWebElement> GetWebElements(By locator)
        {
            return driver.FindElements(locator);
        }

        public IWebElement GetWebElement(By locator)
        {
            return driver.FindElement(locator);
        }

        public IJavaScriptExecutor GetJavaScriptExecutor()
        {
            IJavaScriptExecutor jse = (IJavaScriptExecutor)driver;
            return jse;
        }

        public void ScrollToElement(By ele)
        {
            GetJavaScriptExecutor().ExecuteScript("arguments[0].scrollIntoView(true);", GetWebElement(ele));
        }

        public void ClickUsingJs(By ele)
        {
            GetJavaScriptExecutor().ExecuteScript("arguments[0].click();", GetWebElement(ele));
        }

        public void PerformDoubleClick(By ele)
        {
            try
            {
                waits.WaitForElementClikable(ele);
                action.DoubleClick(GetWebElement(ele)).Build().Perform();
            }
            catch(Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public void PerformRightClick(By ele)
        {
            try
            {
                waits.WaitForElementClikable(ele);
                action.ContextClick(GetWebElement(ele)).Build().Perform();
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
        }

        public void MoveToAnElement(IWebElement ele)
        {
            action.MoveToElement(ele).Build().Perform();
        }

       
    }
}
