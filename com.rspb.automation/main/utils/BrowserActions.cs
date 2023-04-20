using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace com.rspb.automation.main.utils
{
    /// <summary>
    /// This class will hold all actions related to browser
    /// </summary>
    public class BrowserActions
    {
        IWebDriver driver;

        private string imageName;
        public string base64Img;

        public BrowserActions(IWebDriver driver)
        {
            this.driver = driver;
        }

        public void GoToURL(string url)
        {
            driver.Url = url;
        }

        public void RefreshPage()
        {
            driver.Navigate().Refresh();
        }

        public void GoBackWard()
        {
            driver.Navigate().Back();
        }

        public void GoForward()
        {
            driver.Navigate().Forward();
        }

        public string GetCurrentURL()
        {
            return driver.Url;
        }

        public void MaximizeWindow()
        {
            driver.Manage().Window.Maximize();
        }

        
        public void SetImageName()
        {
            imageName = DateTime.Now.ToString("yyyy_MM_dd_mm_ss_H") + ".png";
        }

        
        public string GetImageName()
        {
            return imageName;
        }

        public void TakeScreenshot()
        {
            SetImageName();
            Screenshot scr = ((ITakesScreenshot)driver).GetScreenshot();
            scr.SaveAsFile(FileOperations.GetScreenshotsFilePath(GetImageName()), ScreenshotImageFormat.Png);
            base64Img = ImageToBase64(GetImageName());   
        }

        public static string ImageToBase64(string imageName)
        {
            string _imagePath = FileOperations.GetScreenshotsFilePath(imageName);
            string _base64String = null;

            using (System.Drawing.Image _image = System.Drawing.Image.FromFile(_imagePath))
            {
                using (MemoryStream _mStream = new MemoryStream())
                {
                    _image.Save(_mStream, _image.RawFormat);
                    byte[] _imageBytes = _mStream.ToArray();
                    _base64String = Convert.ToBase64String(_imageBytes);

                    return "data:image/jpg;base64," + _base64String;
                }
            }
        }

    }
}
