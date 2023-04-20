using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using AventStack.ExtentReports.Reporter;
using com.rspb.automation.main.utils;
using NUnit.Framework;
using OpenQA.Selenium;

namespace com.rspb.automation.tests.uiTests
{
    [SetUpFixture]
     public class TestConfig
    {
      //invoke browser and reporte utils here
        BrowserConfig bConfig = new BrowserConfig();
        public static IWebDriver driver;
        BrowserActions browserActions;
        dynamic signupTestData;
        dynamic loginTestData;
        public static Dictionary<string, dynamic> testData;
        public static ExtentTest test;
        public static ExtentReports extent;

        public void LoadTestData()

        {
            testData = new Dictionary<string, dynamic>();
            var jsonFileNames = FileOperations.GetTestdatJSONFilesFromResources();
            foreach (string jsonFile in jsonFileNames)
            {
                testData.Add(jsonFile.Replace(".json", ""), JSONUtils.ReadDataFromFile(jsonFile));
            }
        }

        [OneTimeSetUp]
        public void BeforeTests()
        {
            FileOperations.ClearScreenshotsFolder();
            extent = new ExtentReports();
            var fileName = DateTime.Now.ToString("yyyy_MM_dd_mm_ss_H") + ".html";
            var htmlFilePath = FileOperations.GetReportsFilePath(fileName);
            var htmlReporter = new ExtentHtmlReporter(htmlFilePath);
            extent.AttachReporter(htmlReporter);
            LoadTestData();
            driver = (IWebDriver)bConfig.LaunchBrowser();
            browserActions = new BrowserActions(driver);
            browserActions.MaximizeWindow();
            browserActions.GoToURL(FileOperations.GetURLFromIni("UAT_URL"));

        }

        [OneTimeTearDown]
        public void AfterTests()
        {
            extent.Flush();
            driver.Quit();
           // FileOperations.ClearScreenshotsFolder();
        }
    }
}
