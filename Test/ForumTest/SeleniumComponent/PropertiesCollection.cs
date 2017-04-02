using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support;
using System.Collections;
using System.Linq;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
using System.Web;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Safari;
using OpenQA.Selenium.Opera;
using OpenQA.Selenium.IE;
using ForumTest.Common;
using OpenQA.Selenium.Edge;

namespace ForumTest.SeleniumComponent
{
    enum Identifiers { Id, Name, ClassName, LinkText, CssName, TagName, XPath }
    class PropertiesCollection
    {
        private static IWebDriver mDriver = null;

        public static IWebDriver Driver
        {
            get
            {
                return mDriver;
            }
            set
            {
                mDriver = value;
            }
        }      

        public static void OpenURL(String URL)
        {
            mDriver.Navigate().GoToUrl(URL);
        }

        private static void ChoseDriver(ref IWebDriver webDriver, BrowserType.Browser type)
        {
            switch (type)
            {
                case BrowserType.Browser.Chrome:
                    webDriver = new ChromeDriver();
                    break;
                case BrowserType.Browser.Edge:
                    webDriver = new EdgeDriver();
                    break;
                case BrowserType.Browser.InternetExplorer:
                    webDriver = new InternetExplorerDriver();
                    break;
                default:
                    webDriver = new FirefoxDriver();
                    break;
            }
        }

        public static void OpenNewBroser(String URL, BrowserType.Browser type)
        {
            IWebDriver webDriver = null;
            ChoseDriver(ref webDriver, type);
            webDriver.Navigate().GoToUrl("http://www.pushmodelslocal.ro:8081/arizona-promo-models.php");
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5000));
            webDriver.Navigate().GoToUrl(URL);
            Sincronize.Wait(3200);
            mDriver = webDriver;
        }

        //Same method but close first brower
        public static void OpenAnotherBroser(String URL, BrowserType.Browser type)
        {
            IWebDriver webDriver = null;
            ChoseDriver(ref webDriver, type);
            webDriver.Navigate().GoToUrl("http://www.pushmodelslocal.ro:8081/arizona-promo-models.php");
            webDriver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5000));
            webDriver.Navigate().GoToUrl(URL);
            Sincronize.Wait(3200);
            mDriver.Quit();
            mDriver = webDriver;
        }

        public void QuitBroser()
        {
            mDriver.Quit();
        }

        public void CloseBrowser()
        {
            mDriver.Close();
        }

        public static void Refresh()
        {
            mDriver.Navigate().Refresh();
        }

        public static void ChromeMobileDeviceStart(String device)
        {            
            ChromeOptions chromeOptions = new ChromeOptions();
            chromeOptions.EnableMobileEmulation(device);
            PropertiesCollection.Driver = new ChromeDriver(chromeOptions);
        }

        
        private static int GetIndexOfCurrentWindow()
        {
            return mDriver.WindowHandles.IndexOf(Driver.CurrentWindowHandle);
        }

        public static void MoveNextWindow()
        {
            mDriver.SwitchTo().Window(GetWindow(GetIndexOfCurrentWindow() + 1));
        }

        private static String GetWindow(int index)
        {
            return mDriver.WindowHandles[index];
        }
    }
}