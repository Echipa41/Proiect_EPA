using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Timers;
using ForumTest.SeleniumComponent;

namespace ForumTest.Common
{
    class Sincronize
    {
        private static WebDriverWait mWait = new WebDriverWait(PropertiesCollection.Driver, new TimeSpan(0, 0, 10));

        public static void SetImplicitWait(int seconds)
        {
            PropertiesCollection.Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(seconds));
        }

        public static void SetPageLoad(int seconds)
        {
            PropertiesCollection.Driver.Manage().Timeouts().SetPageLoadTimeout(TimeSpan.FromSeconds(seconds));
        }

        public static void SetScriptTimeout(int seconds)
        {
            PropertiesCollection.Driver.Manage().Timeouts().SetScriptTimeout(TimeSpan.FromSeconds(seconds));
        }

        public static void WaitLoadElement(String XPath)
        {
            mWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            mWait.Until(ExpectedConditions.ElementIsVisible(By.XPath(XPath)));
        }

        public static void WaitLoadElementByInnerHTML(String innerHTML)
        {
            mWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            mWait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//*[contains(text(), '" + innerHTML + "')]")));           
        }

        public static void WaitLoadElementByName(String name)
        {
            mWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            mWait.Until(ExpectedConditions.ElementIsVisible(By.Name(name)));
        }

        public static void WaitLoadElementById(String id)
        {
            mWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            mWait.Until(ExpectedConditions.ElementIsVisible(By.Id(id)));
        }

        public static void WaitLoadElementByClassName(String className)
        {
            mWait.IgnoreExceptionTypes(typeof(NoSuchElementException));
            mWait.Until(ExpectedConditions.ElementIsVisible(By.ClassName(className)));
        }

        public static void Wait(int miliSeconds)
        {
            System.Threading.Thread.Sleep(miliSeconds);
        }

        //For FireFox 
        public static void WaitLoadElementByInnerHTML(String innerHTML, int seconds)
        {
            int time = 0;            
            try
            {
                var element = SeleniumGetMethods.GetWebElementInnerHTML(innerHTML);
            }
            catch(NoSuchElementException ex)
            {
                time = time + 600;
                System.Threading.Thread.Sleep(100);
                if(time < seconds)
                    WaitLoadElementByInnerHTML(innerHTML, seconds);        
            }
        }
    }
}
