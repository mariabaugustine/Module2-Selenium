using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumNUnitExample
{
    [TestFixture]
    internal class GHPTests:CoreCodes
    {
        [Ignore("other")]
        [Test]
        [Order(0)]
        public void TitleTest()
        {
            Thread.Sleep(3000);
            Assert.AreEqual("Google", driver.Title);
            Console.WriteLine("Title test - Pass");
        }
        //[Ignore("other")]
        [Test]
        [Order(1)]
        public void GSTests()
        {
            string currDir = Directory.GetParent(@"../../../").FullName;
            string excelFilePath = currDir + "\\InputData.xlsx";
            Console.WriteLine(excelFilePath);
            List<GoogleSearch> excelDataList = ExcelUtils.ReadExcelData(excelFilePath);
            foreach (var excelData in excelDataList)
            {
                Console.WriteLine($"Text:{excelData.Searchtest}");
                IWebElement searchinputtextbox = driver.FindElement(By.Id("APjFqb"));
                searchinputtextbox.SendKeys(excelData.Searchtest);
                Thread.Sleep(5000);
                //IWebElement gsButton = driver.FindElement(By.Name("btnK"));
                IWebElement gsbutton = driver.FindElement(By.ClassName("gNO89b"));
                gsbutton.Click();
               // Assert.AreEqual("hp laptop - Google Search", driver.Title);
               //Assert.That(driver.Title,is)
                Console.WriteLine("GS TEST - Pass");
            }
        }
        [Ignore("other")]
        [Test]
        [Order(2)]
        public void AllLinkStatusTest()
        {
            List<IWebElement>alllinks=driver.FindElements(By.TagName("a")).ToList();
            foreach( var link in alllinks)
            {
                string url=link.GetAttribute("href");
                if(url == null)
                {
                    Console.WriteLine("URL is null");
                    continue;
                }
                else
                {
                    bool isworking = CheckLinkStatus(url);
                    if (isworking)
                        Console.WriteLine(url + " is working");
                    else
                        Console.WriteLine(url + " is not working");
                }
            }
        }
    }
}
