using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Web;
using System.Threading;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.IE;

namespace ForumTest.SeleniumComponent
{
    class SeleniumSetMethods
    {
        public static void ChangeTextForWebElement(IWebElement element, string value)
        {
            element.Clear();
            element.SendKeys(value);
        }

        public static void EnterText(IWebElement element, string givenValue)
        {
            element.SendKeys(givenValue); 
        }

        public static void Click(IWebElement element)
        {
            element.Click();
        }

        public static void LinkClick(string identifierValue, Identifiers identifierName)
        {
            PropertiesCollection.Driver.FindElement(By.LinkText(identifierValue)).Click();
        }

        public static void ClickElement(string identifierValue, Identifiers identifierName)
        {
            PropertiesCollection.Driver.FindElement(By.Name(identifierValue)).Click();
        }

        public static void Submit(string identifierValue, Identifiers identifierName)
        {
            PropertiesCollection.Driver.FindElement(By.XPath(identifierValue)).Submit();
        }

        public static void SelectDropDown(IWebElement element,string givenValue)
        {
            new SelectElement(element).SelectByText(givenValue);          
        }

        public static void SelectDropDownByIndex(IWebElement element, int index)
        {
            SelectElement select = new SelectElement(element);
            select.SelectByIndex(index);
        }

        public static void SetWebElementById(String id, String value)
        {
            SeleniumGetMethods.GetWebElementById(id).SendKeys(value);
        }

        public static void SetWebElementByName(String name, String value)
        {
            SeleniumGetMethods.GetWebElementByName(name).SendKeys(value);
        }

        public static void SetWebElement(IWebElement webElement, String value)
        {
            webElement.SendKeys(value);
        }        
    }
}
