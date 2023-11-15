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
    internal class NavigationTests
    {
        IWebDriver? driver;
        public void InitiallizeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com/";
            driver.Manage().Window.Maximize();
        }
        public void NavigateToYahoo()
        {
            
            driver.Navigate().GoToUrl("https://www.yahoo.com");
            Thread.Sleep(2000);
            Console.WriteLine("Go to yahoo test:Pass");
        }
        public void BackToGoogleTest()
        {
            driver.Navigate().Back();
            Thread.Sleep(2000);
            Console.WriteLine("Back to google test - pass");
        }
        public void BackToYahooTests()
        {
            driver.Navigate().Forward();
            Thread.Sleep(2000);
            Console.WriteLine("Back to yahoo test - pass");
        }
        public void BackToGoogleAgainTests()
        {
            driver.Navigate().Back();
            Thread.Sleep(1000);
            Console.WriteLine("Back to google again test - pass");
        }
        public void GSTests()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("what's new for Diwali 2023");
            Thread.Sleep(5000);
            //IWebElement gsButton = driver.FindElement(By.Name("btnK"));
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
            gsbutton.Click();
            //Console.WriteLine("Title:"+driver.Title);
            Assert.AreEqual("what's new for Diwali 2023 - Google Search", driver.Title);
            Console.WriteLine("Google Search Test - Pass");
        }
        public void refreshTest()
        {
            driver.Navigate().Refresh();
            Thread.Sleep(3000);
            Console.WriteLine("Refresh test:Pass");
        }
        public void Exit()
        {
            driver.Close();
        }
    }
}
