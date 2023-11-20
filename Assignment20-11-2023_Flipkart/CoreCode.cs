using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment20_11_2023_Flipkart
{
    public class CoreCode
    {
        public IWebDriver driver;
        public Dictionary<string, string> Properties;
        public void ReadConfigurationFile()
        {
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            Properties= new Dictionary<string, string>();
            string path = currentDirectory + "/configsettings/config.properties";
            string[] file=File.ReadAllLines(path);
            foreach (string line in file) 
            {
                if(!string.IsNullOrWhiteSpace(line)&&line.Contains("="))
                {
                    string[] parts = line.Split('=');
                    string key = parts[0];
                    string value = parts[1];
                    Properties[key] = value;
                }
            }

        }
        [OneTimeSetUp]
        public void InitializeBrowser()
        {
            ReadConfigurationFile();
            if (Properties["browser"].ToLower()=="chrome")
            {
                driver=new ChromeDriver();
            }
            driver.Url = Properties["baseurl"];
            driver.Manage().Window.Maximize();
        }
        [OneTimeTearDown] 
        public void Exit()
        {
            driver.Quit();
        }
    }
}
