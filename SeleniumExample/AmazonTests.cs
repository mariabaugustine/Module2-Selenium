using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace SeleniumExample
{
    internal class AmazonTests
    {
        IWebDriver? driver;
        public void InitializeEdgeDriver()
        {
            driver = new EdgeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();

        }
        public void InitializeChromeDriver()
        {
            driver = new ChromeDriver();
            driver.Url = "https://www.amazon.com";
            driver.Manage().Window.Maximize();
        }
        public void TitleTest()
        {
            Thread.Sleep(3000);

            //string title = driver.Title;
            Console.WriteLine("Title:" + driver.Title);
            //Console.WriteLine("Title Length:" + driver.Title.Length);

            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        public void LogoClickTest()
        {
            driver.FindElement(By.Id("nav-logo-sprites")).Click();
            Assert.AreEqual("Amazon.com. Spend less. Smile more.", driver.Title);
            Console.WriteLine("Logo Click Test - Pass");
        }
        public void SerachProductTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobiles");
            Thread.Sleep(3000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            Assert.That(("Amazon.com : mobiles".Equals(driver.Title) && (driver.Url.Contains("mobiles"))));
            Console.WriteLine("Search Product Test : Pass");
        }
        public void ReloadHomePageTest()
        {
            driver.Navigate().GoToUrl("https://amazon.com/");
            Thread.Sleep(3000);
        }
        public void TodaysDealsTest()
        {
            IWebElement todaydeals = driver.FindElement(By.LinkText("Today's Deals"));
            if(todaydeals == null) 
            {
                throw new NoSuchElementException("Today's link not present");
            }
            todaydeals.Click();
            Assert.That(driver.FindElement(By.TagName("h1")).Text.Equals("Today's Deals"));
            Console.WriteLine("TodaysDealsTest - Pass");
        }
        public void SignInAccListTest()
        {
            IWebElement hellosignin = driver.FindElement(By.Id("nav-link-accountList-nav-line-1"));
            if(hellosignin == null)
            {
                throw new NoSuchElementException("Hello,Signin is not present");
            }
            IWebElement accountandlists = driver.FindElement(By.XPath("//*[@id=\"nav-link-accountList\"]/span"));
            if(accountandlists == null)
            {
                throw new NoSuchElementException("Hello, Account and List is not present");
            }
            Assert.That(hellosignin.Text.Equals("Hello, sign in"));
            Console.WriteLine("Hello, Sign in present - pass");
            Assert.That(accountandlists.Text.Equals("Account & Lists"));
            Console.WriteLine("Account and List is present - Pass");
        }
        public void SearchAndFilterProductByBrandTest()
        {
            driver.FindElement(By.Id("twotabsearchtextbox")).SendKeys("mobile phones");
            Thread.Sleep(5000);
            driver.FindElement(By.Id("nav-search-submit-button")).Click();
            driver.FindElement(By.XPath("//*[@id=\"p_89/Nokia\"]/span/a/div/label/i")).Click();
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Nokia\"]/span/a/div/label/input")).Selected);
            Thread.Sleep(3000);
           // nokiacheckbox.Click();
            //Thread.Sleep(3000);
           // Assert.True(nokiacheckbox.Selected);
            Console.WriteLine("Nokia is selected");
            driver.FindElement(By.ClassName("a-expander-prompt")).Click() ;
            driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/i")).Click();
            //Thread.Sleep(2000);
            Assert.True(driver.FindElement(By.XPath("//*[@id=\"p_89/Apple\"]/span/a/div/label/input")).Selected);
            //applecheckbox.Click();
            //Assert.True(applecheckbox.Selected);
            Thread.Sleep(2000);
            Console.WriteLine("Apple is selected");
        }
        public void Destruct()

        {
            driver.Close();
        }
    }
}
