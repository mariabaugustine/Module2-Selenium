using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment1_14_11_2023
{
    internal class AmazonTests
    {
        IWebDriver? driver;
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com/";
            driver.Manage().Window.Maximize();
        }
        public void TitleTests()
        {
            Console.WriteLine("Title:"+driver.Title);
            Assert.That(driver.Title == "Amazon.com. Spend less. Smile more.");
            Console.WriteLine("Title test - Pass");


        }
        public void OrganizationType()
        {
            Assert.That(driver.Url.Contains(".com"));
            Console.WriteLine("Organisation type test - Pass ");
        }
        public void Exit()
        {
            driver.Close();
        }
    }
}
