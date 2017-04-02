using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//https://gist.github.com/roydekleijn/5073579
//http://stackoverflow.com/questions/27565416/test-sessionstorage-with-selenium-webdriver


namespace ForumTest.SeleniumComponent
{
    public class LocalStorage
    {
        private IJavaScriptExecutor js;


        public LocalStorage(IWebDriver webDriver)
        {
            this.js = (IJavaScriptExecutor)webDriver;
        }

        public void removeItemFromLocalStorage(String item)
        {

            js.ExecuteScript(String.Format(
                "window.localStorage.removeItem('%s');", item));
        }

        public bool isItemPresentInLocalStorage(String item)
        {
            return !(js.ExecuteScript(String.Format(
                "return window.localStorage.getItem('%s');", item)) == null);
        }

        public String getItemFromLocalStorage(String key)
        {
            return (String)js.ExecuteScript(String.Format(
                "return window.localStorage.getItem('%s');", key));
        }

        public String getKeyFromLocalStorage(int key)
        {
            return (String)js.ExecuteScript(String.Format(
                "return window.localStorage.key('%s');", key));
        }

        public long getLocalStorageLength()
        {
            return (long)js.ExecuteScript("return window.localStorage.length;");
        }

        public void setItemInLocalStorage(String item, String value)
        {
            js.ExecuteScript(String.Format(
                "window.localStorage.setItem('%s','%s');", item, value));
        }

        public void clearLocalStorage()
        {
            js.ExecuteScript(String.Format("window.localStorage.clear();"));
        }
    }
}
