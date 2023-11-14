using Assignment1_14_11_2023;
using NUnit.Framework;

//AmazonTests amazonTests = new AmazonTests();
//amazonTests.InitializeChromeDriver();
//try
//{
//    amazonTests.TitleTests();
//    amazonTests.OrganizationType();
//}
//catch(AssertionException)
//{
//    Console.WriteLine("Failed");
//}
//amazonTests.Exit();
NavigationTests navigationTests=new NavigationTests();

navigationTests.InitiallizeChromeDriver();
try
{
    navigationTests.NavigateToYahoo();
    navigationTests.BackToGoogleTest();
    navigationTests.BackToYahooTests();
    navigationTests.BackToGoogleAgainTests();
    navigationTests.GSTests();

}
catch(AssertionException)
{
    Console.WriteLine("fail");
}
navigationTests.Exit();

