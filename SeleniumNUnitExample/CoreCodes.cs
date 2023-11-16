using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
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
        [OneTimeTearDown]
        public void Cleanup() 
        {
            driver.Quit();
        }
    }
}
