using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Assignment21_11_2023_Naptol
{
    [TestFixture]
    public class Naptol:CoreCodes

    {
        [Test]
        [Order(0)]
        public void SerachProduct()
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fwait.Message = "Element not found";
            IWebElement searchelement = fwait.Until(d => d.FindElement(By.XPath("//input[@id='header_search_text']")));
            searchelement.SendKeys("eyewear");
            searchelement.SendKeys(Keys.Enter);
            Assert.That(driver.Url.Contains("eyewear"));
        }
        [Test]
        [Order(1)]
        [TestCase(5)]
        public void SelectFifthProduct(int pid)
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fwait.Message = "Element not found";
            string path = "//div[@id='productItem" + pid + "']";
            IWebElement fifthelement = fwait.Until(d => d.FindElement(By.XPath(path)));
            Actions actions = new Actions(driver);
            Action moveto = () => actions.MoveToElement(fifthelement).Click().Build().Perform();

            moveto.Invoke();
            Thread.Sleep(6000);

            List<string> nextTab = driver.WindowHandles.ToList();
            driver.SwitchTo().Window(nextTab[1]);
            
            
        }
        [Test]
        [Order(3)]
        //[TestCase("Black",2.50)]
        public void AddProductToCart()
        {
            DefaultWait<IWebDriver> fwait = new DefaultWait<IWebDriver>(driver);
            fwait.Timeout = TimeSpan.FromSeconds(5);
            fwait.PollingInterval = TimeSpan.FromMilliseconds(5);
            fwait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            fwait.Message = "Element not found";
            //string path = color + "-" + size;
            IWebElement selectsize = fwait.Until(d => d.FindElement(By.XPath("//a[text()='Black-2.50']")));
            
            selectsize.Click();
            IWebElement submitbutton = fwait.Until(d => d.FindElement(By.XPath("//*[@id=\"cart-panel-button-0\"]/span")));
            submitbutton.Click();
            IWebElement status = fwait.Until(d => d.FindElement(By.XPath("//*[text()='My Shopping Cart: ']")));
            Assert.That(status.Text.Contains("cart"));


        }

    }
}