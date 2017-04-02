﻿using System;
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
    public class SeleniumGetMethods
    {
        public static string GetText(IWebElement element)
        {
            return element.GetAttribute("value");           
        }

        public static string GetTextFromDropDown(IWebElement element)
        {
            return new SelectElement(element).AllSelectedOptions.SingleOrDefault().Text;                       
        }

        public static IWebElement GetWebElementByXPath(String XPath)
        {            
            return PropertiesCollection.Driver.FindElement(By.XPath(XPath));
        }

        public static IWebElement GetWebElementById(String id)
        {
            return PropertiesCollection.Driver.FindElement(By.Id(id));
        }

        public static IList GetWebElementsById(String id)
        {
            return PropertiesCollection.Driver.FindElements(By.Id(id));
        }

        public static IWebElement GetWebElementByName(String name)
        {
            return PropertiesCollection.Driver.FindElement(By.Name(name));
        }

        public static IWebElement GetWebElementInnerHTML(String Text)
        {
            return PropertiesCollection.Driver.FindElement(By.XPath("//*[contains(text(), '" + Text + "')]"));           
        }

        public static IWebElement GetParentNode(IWebElement webElement)
        {
            IJavaScriptExecutor executorJS = (IJavaScriptExecutor)PropertiesCollection.Driver;
            return (IWebElement)executorJS.ExecuteScript("return arguments[0].parentNode;", webElement);
        }

        public static IWebElement GetLastChild(IWebElement webElement)
        {
            IJavaScriptExecutor executorJS = (IJavaScriptExecutor)PropertiesCollection.Driver;
            IWebElement tempElem = (IWebElement)executorJS.ExecuteScript("return arguments[0].lastChild;", webElement);
            return tempElem;
        }

        public static IWebElement GetFirstChild(IWebElement webElement)
        {
            IJavaScriptExecutor executorJS = (IJavaScriptExecutor)PropertiesCollection.Driver;
            IWebElement tempElem = (IWebElement)executorJS.ExecuteScript("return arguments[0].firstChild;", webElement);
            return tempElem;
        }

        public static IWebElement GetWebElementByAttribut(String attribut, String value)
        {           
            return PropertiesCollection.Driver.FindElement(By.XPath("//*[contains(@" + attribut +", '" + value + "')]"));
        }

        public static IList GetWebElementsByAttribut(String attribut, String value)
        {
            return PropertiesCollection.Driver.FindElements(By.XPath("//*[contains(@" + attribut + ", '" + value + "')]"));
        }

        public static String GetValuForAttribut(IWebElement webElement, String attributeName)
        {
            return webElement.GetAttribute(attributeName);
        }
    }
}
