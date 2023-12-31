﻿using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium.Edge;

namespace SeleniumExample
{
    internal class GHPTests
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
           driver = new EdgeDriver();
           driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();

        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest()
        {
            Thread.Sleep(3000);

            //string title = driver.Title;
            Console.WriteLine("Title:"+driver.Title);
            Console.WriteLine("Title Length:"+driver.Title.Length);

            Assert.AreEqual("Google",driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        public void PageSourceandURLTests()
        {
           // Console.WriteLine("Page Source:"+driver.PageSource);
            Console.WriteLine("Page source Length:"+driver.PageSource.Length);
            Console.WriteLine("URL:"+driver.Url);
            Console.WriteLine("URL Length:"+driver.Url.Length);
            Assert.AreEqual("https://www.google.com/", driver.Url);
            Console.WriteLine("Page source and url test - Pass");
        }
        public void GSTests()
        {
            IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
            searchinputtextbox.SendKeys("hp laptop");
            Thread.Sleep(5000);
            //IWebElement gsButton = driver.FindElement(By.Name("btnK"));
            IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
            gsbutton.Click();
            Assert.AreEqual("hp laptop - Google Search", driver.Title);
            Console.WriteLine("GS TEST - Pass");
        }
        public void GMailLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.LinkText("Gmail")).Click();
            Thread.Sleep(3000);
            //Assert.AreEqual("Gmail", driver.Title);
            // Assert.That(driver.Title.Contains("Gmail"));
            Assert.That(driver.Url.Contains("gmail"));
            Console.WriteLine("Gmail Link Test - Pass");
        }
        public void ImagesLinkTest()
        {
            driver.Navigate().Back();
            driver.FindElement(By.PartialLinkText("mag")).Click();
            Thread.Sleep(3000);
            Assert.That(driver.Title.Contains("Images"));
            Console.WriteLine("Image link test - Pass");
        }
        public void YoutubeLinkTest()
        {
                driver.FindElement(By.ClassName("gb_d")).Click();

            // Thread.Sleep(1000);
            // driver.FindElement(By.XPath("//*[@id='yDmH0d']/c-wiz/div/div/c-wiz/div/div/div[2]/div[2]/div[1]/ul/li[4]/a")).Click();
            driver.FindElement(By.XPath("(//span[@class='Rq5Gcb'])[5]")).Click();


        }
        public void LocationTest()
        {
            driver.Navigate().Back();
            string location = driver.FindElement(By.XPath("/html/body/div[1]/div[6]/div[1]")).Text;
            Thread.Sleep(3000);
            Assert.That(location.Equals("India"));
            Console.WriteLine("Loc - Pass");
        }
        public void Destruct()

        {
            driver.Close();
        }
    }
}
