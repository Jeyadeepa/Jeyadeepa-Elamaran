using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using java.sql;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools;
using OpenQA.Selenium.DevTools.V101.Emulation;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;
using DriverManager = WebDriverManager.DriverManager;

namespace com.rspb.automation.main.utils
{
    /// <summary>
    /// This class will contain methods to initialize browser and driver instance/s
    /// </summary>
    class BrowserConfig
    {

        public IWebDriver driver;
        protected IDevToolsSession session;

        protected void setDriver(dynamic _driver)
        {
            this.driver = _driver;
        }

        public dynamic getDriver()
        {
            return this.driver;
        }

        public async void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "chrome":
                    //Add chrome options depending on requirement
                    driver = new ChromeDriver();
                    break;
                 
                case "Emulator":
                    var iniPath = FileOperations.GetFilePathFromResources("sample.ini");
                    Ini iniFile = new Ini(iniPath);
                    string deviceName = iniFile.IniReadValue("env", "device");
                    await DeviceModeTest(deviceName);
                    break;

            }
            //return driver;
            setDriver(driver);
        }

        public async Task DeviceModeTest(string deviceName)
        {
            Dictionary<string, object> emulatorConfig = JSONUtils.ReadDataFromFile("EmulatorConfig.json");
            dynamic deviceConf = emulatorConfig[deviceName];
            int heightVal = Convert.ToInt32(JSONUtils.GetDataValue(deviceConf, "height"));
            int widthVal = Convert.ToInt32(JSONUtils.GetDataValue(deviceConf, "width"));
            new DriverManager().SetUpDriver(new ChromeConfig());
            ChromeOptions chromeOptions = new ChromeOptions();
            //Set chromDriver
            driver = new ChromeDriver();
            //Get DevTools
            IDevTools devTools = driver as IDevTools;
            //DevTools Session
            session = devTools.GetDevToolsSession();

            var deviceModeSetting = new SetDeviceMetricsOverrideCommandSettings();
            deviceModeSetting.Width = heightVal;
            deviceModeSetting.Height = widthVal;
            deviceModeSetting.Mobile = true;
            deviceModeSetting.DeviceScaleFactor = 50;

            await session
                .GetVersionSpecificDomains<OpenQA.Selenium.DevTools.V101.DevToolsSessionDomains>()
                .Emulation
                .SetDeviceMetricsOverride(deviceModeSetting);

        }

        public IWebDriver LaunchBrowser()
        {
            var iniPath = FileOperations.GetFilePathFromResources("sample.ini");
            Ini iniFile = new Ini(iniPath);
            string browser = iniFile.IniReadValue("env", "browser");
             InitBrowser(browser);
            return getDriver();
        }
    }
}
