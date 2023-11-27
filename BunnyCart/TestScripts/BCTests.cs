using AventStack.ExtentReports.Model;
using BunnyCart.PageObjects;
using BunnyCart.Utilities;
using OpenQA.Selenium;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Log = Serilog.Log;

namespace BunnyCart.TestScripts
{
    internal class BCTests:CoreCodes
    {
        [Test,Order(2)]
        [TestCase("Water",2)]
        public void SearchProductAndAddToCart(string searchtext,int count)
        {
            BCHP bchp = new(driver);
            var searchResultPage=bchp?.TypeSearchInput(searchtext);
            CoreCodes.ScrollIntoView(driver, driver.FindElement(By.XPath("//*[@id=\'amasty-shopby-product-list\']/div[2]/ol/li[1]")));
            Assert.That(searchtext.Contains(searchResultPage?.GetFirstProductLInk()));
            var productPage=searchResultPage?.ClickFirstProductLink(count);
            Assert.That(searchtext.Equals(productPage?.GetProductTitleLabel()));
            productPage?.ClickIncQty();
            productPage?.ClickAddToCartBtn();
            Thread.Sleep(1000);

        }

        [Test,Order(1)]
        public void  SignUpTest()
        {
            string currentDirectory = Directory.GetParent(@"../../../").FullName;
            string logfilepath = currentDirectory + "/Logs/log_" + DateTime.Now.ToString("yyyy-MM-dd_HHmmss") + ".txt";

            Log.Logger = new LoggerConfiguration().WriteTo.Console().WriteTo.
                File(logfilepath, rollingInterval: RollingInterval.Day).CreateLogger();



            BCHP bchp = new BCHP(driver);
            Log.Information("Create account started");
            bchp.ClickCreateAccount();

            Log.Information("Create account test clicked");
           Thread.Sleep(1000);
            try
            {
                Assert.True(driver.FindElement(By.XPath("//div[\" + \"@class='modal-inner-wrap']//following::h1[2]")).Text
                    == "Create an Account", $"Test failed for create account");
                Log.Information("Test passed for Create Account");
                test = extent.CreateTest("Create Account Link Test");
                test.Pass("Create account link success");
            }
            catch(AssertionException ex)
            {
                Log.Error($"Test failed for create account.\nException:{ex.Message}");
                test = extent.CreateTest("Create Account Test");
                test.Fail("Creat account link failed");
            }
            Assert.That(driver?.FindElement(By.XPath("//div[\" + \"@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));

            string? currDir = Directory.GetParent(@"../../../")?.FullName;

            string? excelFilePath = currDir + "/TestData/InputData.xlsx";

            string? sheetName = "CreateAccount";



            List<SignUpData> excelDataList = ExcelUtilities.ReadExcelData(excelFilePath, sheetName);



            foreach (var excelData in excelDataList)

            {



                string? firstName = excelData?.FirstName;

                string? lastName = excelData?.LastName;

                string? email = excelData?.Email;

                string? pwd = excelData?.Password;

                string? conpwd = excelData?.ConfirmPassword;

                string? mbno = excelData?.MobileNumber;



                Console.WriteLine($"First Name: {firstName}, Last Name: {lastName}, Email: {email}, Password: {pwd}, Confirm Password: {conpwd}, Mobile Number: {mbno}");





                bchp.SignUpButton(firstName, lastName, email, pwd, conpwd, mbno);
                try
                {
                    Assert.That(driver?.FindElement(By.XPath("//div[" + "@class='modal-inner-wrap']//following::h1[2]")).Text,

                     Is.EqualTo("Create an Account"));

                    test = extent.CreateTest("Create Account Link Test - Pass");

                    test.Pass("Create Account Link success");

                    Console.WriteLine("ERCP");

                }
                catch(AssertionException)
                {
                    test = extent.CreateTest("Create Account Link Test - Fail");

                    test.Fail("Create Account Link failed");

                    Console.WriteLine("ERCF");
                }

                // Assert.That(""."")



            }
            //try
            //{
            //    Assert.That(driver.FindElement(By.XPath("//div["+"@class='modal-inner-wrap']//following::h1[2]")).Text, Is.EqualTo("Create an Account"));
            //}
            //catch(AssertionException) 
            //{
            //    Console.WriteLine("Create account modal not present");
            //}
            //bchp.SignUpButton("Abc", "Def", "ghi@gmail.com", "12345", "12345", "9876543210");
        }
    }
}
