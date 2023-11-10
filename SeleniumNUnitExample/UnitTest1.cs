using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SeleniumNUnitExample


{
    public class Tests
    {
        IWebDriver driver;
        [SetUp]
        public void Setup()
        {
             driver = new ChromeDriver();
            driver.Url = "https://www.google.com";
        }

        [Test]
        public void CheckForTitle()
        {
           
            Thread.Sleep(10000);
            string title=driver.Title;
            //Assert.That(title == "Google");
            Assert.AreEqual("Google", title);
            

        }
        [TearDown]
        public void TearDown()
        {
            driver.Close();
        }
    }
}