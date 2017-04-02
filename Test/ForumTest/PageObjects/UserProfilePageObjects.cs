using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;
using ForumTest.SeleniumComponent;
using OpenQA.Selenium;

namespace ForumTest.PageObjects
{
    public class UserProfilePageObjects
    {
        public UserProfilePageObjects()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }

        [FindsBy(How = How.Id, Using = "MainContent_NumeTB")]
        public IWebElement FirstName
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_PrenumeTB")]
        public IWebElement LastName
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_DataNasteriiTB")]
        public IWebElement BirthDate
        {
            get;
            set;
        }                

        [FindsBy(How = How.Id, Using = "MainContent_SexRBL_0")]
        public IWebElement SexM
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_SexRBL_1")]
        public IWebElement SexF
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_OrasTB")]
        public IWebElement City
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_SemnaturaTB")]
        public IWebElement Signature
        {
            get;
            set;
        }

        [FindsBy(How = How.Id, Using = "MainContent_PozaFU")]
        public IWebElement Photo
        {
            get;
            set;
        }

        [FindsBy(How = How.Name, Using = "ctl00$MainContent$SaveProfileButton")]
        public IWebElement Save
        {
            get;
            set;
        }


        [FindsBy(How = How.Name, Using = "ctl00$MainContent$CancelSaveProfileButton")]
        public IWebElement Cancel
        {
            get;
            set;
        }        
    }
}
