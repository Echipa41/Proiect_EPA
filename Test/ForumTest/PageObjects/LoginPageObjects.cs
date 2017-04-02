using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumTest.SeleniumComponent;

namespace ForumTest.PageObjects
{
    public class LoginPageObjects
    {
        public LoginPageObjects()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_UserName")]
        public IWebElement Username
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_Password")]
        public IWebElement Password
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_LoginUser_LoginButton")]
        public IWebElement LoginButton
        {
            get;
            set;
        }
    }
}
