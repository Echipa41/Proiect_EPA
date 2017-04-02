using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumTest.SeleniumComponent;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium;


namespace ForumTest.PageObjects
{
    public class SignUpPageObjects
    {
        public SignUpPageObjects()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "MainContent_RegisterUser_CreateUserStepContainer_UserName")]
        public IWebElement User
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_RegisterUser_CreateUserStepContainer_Email")]
        public IWebElement Email
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_RegisterUser_CreateUserStepContainer_Password")]
        public IWebElement Password
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_RegisterUser_CreateUserStepContainer_ConfirmPassword")]
        public IWebElement ConfirmPassword
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_RegisterUser_CreateUserStepContainer_CreateUserButton")]
        public IWebElement CreateUserButton
        {
            get;
            set;
        }
    }
}
