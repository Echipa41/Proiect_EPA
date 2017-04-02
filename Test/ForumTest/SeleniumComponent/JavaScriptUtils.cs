using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace ForumTest.SeleniumComponent
{
    public class JavaScriptUtils
    {
        public static void ExecuteScript(string script)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertiesCollection.Driver;
            executor.ExecuteScript(script);
        }

        public static void SetAttribute(IWebElement webElement, String attributeName, String attributeValue)
        {
            IJavaScriptExecutor executor = (IJavaScriptExecutor)PropertiesCollection.Driver;
            String scriptSetAttrValue = "arguments[0].setAttribute(arguments[1],arguments[2])";
            executor.ExecuteScript(scriptSetAttrValue, webElement, attributeName, attributeValue);
        }

        public static void AlertAccept()
        {
            try
            {
                IAlert alert = PropertiesCollection.Driver.SwitchTo().Alert();
                alert.Accept();
            }
            catch(NoAlertPresentException alertException)
            {

            }
        }

        public static String GetAlertText()
        {
            IAlert alert = PropertiesCollection.Driver.SwitchTo().Alert();
            String textAlert = alert.Text;

            alert.Accept();
            return textAlert;
        }
    }
}
