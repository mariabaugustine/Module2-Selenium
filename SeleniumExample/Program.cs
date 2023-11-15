using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V117.WebAuthn;
using SeleniumExample;
using System.Runtime.InteropServices;
//GHPTests gHPTests = new GHPTests();
//List<string>drivers= new List<string>();
//drivers.Add("Edge");
//drivers.Add("Chrome");
//foreach (var item in drivers)
//{
//    switch (item)
//    {
//        case "Edge": gHPTests.InitializeEdgeDriver(); break;
//        case "Chrome": gHPTests.InitializeChromeDriver(); break;
//    }


    //Console.WriteLine("Enter th choice:\n1.Edge Driver\n2.Chrome Driver");
    //switch(Convert.ToInt32(Console.ReadLine()))
    //{
    //    case 1:
    //        gHPTests.InitializeEdgeDriver(); break;
    //    case 2:
    //        gHPTests.InitializeChromeDriver(); break;
    //    default:
    //        Console.WriteLine("Invalid Entry");
    //        break;

    //}


    //try
    //{
        //gHPTests.TitleTest();
        //gHPTests.PageSourceandURLTests();
        //gHPTests.GSTests();
        //gHPTests.GMailLinkTest();
        //gHPTests.ImagesLinkTest();
        //gHPTests.LocationTest();
        //gHPTests.YoutubeLinkTest();

//    }
//    catch (AssertionException)
//    {
//        Console.WriteLine("Fail");
//    }
//    gHPTests.Destruct();
//}
 /************************************************15/11/2023**************************************/
 List<string>drivers=new List<string>();
drivers.Add("Chrome");
AmazonTests amazonTests = new AmazonTests();
foreach(var driver in drivers)
{
    switch(driver)
    {
        case "Chrome":amazonTests.InitializeChromeDriver();
            break;
    }
    try
    {
        //amazonTests.TitleTest();
        //amazonTests.LogoClickTest();
        //amazonTests.SerachProductTest();
        //amazonTests.ReloadHomePageTest();
        //amazonTests.TodaysDealsTest();
        //amazonTests.SignInAccListTest();
        //amazonTests.SearchAndFilterProductByBrandTest();
        amazonTests.SortBySelectTest();
    }
    catch(AssertionException) 
    {
        Console.WriteLine("Fail");
    }
    catch(NoSuchElementException nse)
    {
        Console.WriteLine(nse.Message);
    }
    amazonTests.Destruct();
}
