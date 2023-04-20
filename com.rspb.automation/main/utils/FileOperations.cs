using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace com.rspb.automation.main.utils
{
    class FileOperations
    {
        /// <summary>
        /// This method will return the current directory path
        /// </summary>
        /// <returns></returns>
        public static string GetFolderDirectory()
        {
            string directory = Directory.GetCurrentDirectory().ToString();
            string[] finaldirectoryPath = directory.Split("bin");
            return finaldirectoryPath[0];
        }

        /// <summary>
        /// This method willl return the tests folder path
        /// </summary>
        /// <returns></returns>
        public static string GetTestsFolderPath()
        {
            var filePath = GetFolderDirectory() + @"tests\";
            return filePath;
        }

        /// <summary>
        /// This method willl return the main folder path
        /// </summary>
        /// <returns></returns>
        public static string GetMainFolderPath()
        {
            var filePath = GetFolderDirectory() + @"main\";
            return filePath;
        }

        /// <summary>
        /// This method willl return the file path from resources for a given file name
        /// </summary>
        /// <returns></returns>
        public static string GetFilePathFromResources(string filename)
        {
            var filePath = GetMainFolderPath() + @"resources\" + filename;
            return filePath;
        }

        /// <summary>
        /// This method will return the file path from screenshots folder for given file name
        /// </summary>
        /// <returns></returns>
        public static string GetScreenshotsFilePath(string filename)
        {
            var filePath = GetTestsFolderPath() + @"screenshots\" + filename;
            return filePath;
        }

        public static string GetScreenshotsFolder()
        {
            var folderPath = GetTestsFolderPath() + @"screenshots\";
            return folderPath;
        }

        public static void ClearScreenshotsFolder()
        {
            Directory.GetFiles(GetScreenshotsFolder()).ToList().ForEach(File.Delete);
        }

        public static string GetReportsFilePath(string filename)
        {
            var filePath = GetTestsFolderPath() + @"reports\" + filename;
            return filePath;
        }
        /// <summary>
        /// This method will return the URL from the ini file
        /// </summary>
        /// <returns></returns>
        public static string GetURLFromIni(string urlName)
        {
            var iniPath = FileOperations.GetFilePathFromResources("sample.ini");
            Ini iniFile = new Ini(iniPath);
            string url = iniFile.IniReadValue("AppCreds", urlName);
            return url;
        }

        public static dynamic GetTestdatJSONFilesFromResources()
        {
            var filePath = GetMainFolderPath() + @"resources\";
            //Extracting the list of json files from resources folder that are with *Data.json format
            var jsonFiles = new DirectoryInfo(filePath).GetFiles("*Data.json");
            List<string> fileNames = new List<string>();
            foreach (var jsonFile in jsonFiles)
            {
                fileNames.Add(jsonFile.Name);
            }

            return fileNames;
        }

        public static dynamic GetEmlatorConfig()
        {
            var filePath = GetMainFolderPath() + @"resources\";
           
            var jsonFiles = new DirectoryInfo(filePath).GetFiles("EmulatorConfig.json");
            List<string> fileNames = new List<string>();
            foreach (var jsonFile in jsonFiles)
            {
                fileNames.Add(jsonFile.Name);
            }

            return fileNames;
        }

        public static string ConvertImageToBase64(string filepath)
        {
            byte[] imageArray = System.IO.File.ReadAllBytes(filepath);
            return Convert.ToBase64String(imageArray);

        }
    }
}
