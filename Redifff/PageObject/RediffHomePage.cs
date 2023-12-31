﻿using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Redifff.PageObject
{
    internal class RediffHomePage
    {
        IWebDriver driver;
        public RediffHomePage(IWebDriver? driver) 
        {
          this.driver = driver??throw new ArgumentException(nameof(driver));
            PageFactory.InitElements(driver, this);
        }
        //Arranage
        [FindsBy(How =How.LinkText,Using = "Create Account")]
        public IWebElement? CreateAccountLink { get; set; }

        [FindsBy(How=How.LinkText,Using = "Sign in")]
        public IWebElement? SignInLink { get; set; }


        //Act
        //public void CreateAccountLinkClick()
        //{
        //    CreateAccountLink?.Click();
        //}
        //public void SignInLinkClick() 
        //{
        //    SignInLink?.Click(); 
        //}
        //public CreateAccountClass CreateAccountClick()
        //{
        //    CreateAccountLink?.Click();
        //    return new CreateAccountClass(driver);
        //}
        public SignInPage SignInClick()
        {
            SignInLink.Click();
            return new SignInPage(driver);
        }
    }
}
