using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace com.rspb.automation.main.utils
{
    /// <summary>
    /// This class will contain reuseable methods for json data accessing
    /// </summary>
    class JSONUtils
    {
        public static dynamic data;

        public static dynamic ReadDataFromFile(string fileName) {
            var path = FileOperations.GetFilePathFromResources(fileName);
            var jsonData = File.ReadAllText(path);
            data = new Dictionary<string, object>();
            data = JsonConvert.DeserializeObject<Dictionary<string, object>>(jsonData);
            return data;
        }

        public static dynamic GetTestCaseDataSet(string testcaseName)
        {
            return data[testcaseName];
        }

        public static dynamic GetTestCaseData(string testcaseName, string key)
        {
            return GetTestCaseDataSet(testcaseName)[key].ToString();
        }

        public static dynamic GetDataValue(dynamic testData, string key)
        {
            return testData[key].ToString();
        }
    }
}
