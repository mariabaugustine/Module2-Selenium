using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace BunnyCart
{
    internal class CoreCodes
    {
        Dictionary<string, string>? properties;
        public IWebDriver driver;
        public void ReadConfigSettings()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            properties= new Dictionary<string, string>();
            string fileName = currDir + "/configsettings/config.properties";
            string[] lines= File.ReadAllLines(fileName);
            foreach (string line in lines)
            { 
                if(!string.IsNullOrWhiteSpace(line) && line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0].Trim();
                    string value = parts[1].Trim();
                    properties[key] = value;
                }
            }
        }
        public bool CheckLinkStatus(string url)
        {
            try
            {
                var request = (System.Net.HttpWebRequest)
                    System.Net.WebRequest.Create(url);
                request.Method = "HEAD";
                using (var response = request.GetResponse())
                {
                    return true;
                }
            }
            catch 
            { 
                return false;
            }
        }
        [OneTimeSetUp]
        public void InitializeBrowser()
        {
            ReadConfigSettings();
            if (properties["browser"].ToLower() == "chrome") 
            {
                driver=new ChromeDriver();
            }
            else if (properties["browser"].ToLower()=="edge")
            {
                driver=new EdgeDriver();
            }
            driver.Url = properties["baseUrl"];
            driver.Manage().Window.Maximize();

        }
        public void TakeScreenShot()
        {
            ITakesScreenshot screenshot = (ITakesScreenshot)driver;
            Screenshot ss = screenshot.GetScreenshot();
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            string filepath = currentDirectory + "/Screenshots/screenshot_" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".png";
            ss.SaveAsFile(filepath);
            Console.WriteLine("Take screenshot");

        }
        public static void ScrollIntoView(IWebDriver driver, IWebElement element)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            js.ExecuteScript("arguments[0].scrollIntoView(true);", element);
        }
        [OneTimeTearDown]
        public void Cleanup() 
        {
            driver.Quit();
        }
    }
}
