using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//https://gist.github.com/roydekleijn/3976589

namespace ForumTest.SeleniumComponent
{
    public class SessionStorage
    {
        private IJavaScriptExecutor js;

        public SessionStorage(IWebDriver driver)
        {
            this.js = (IJavaScriptExecutor)driver;
        }

        public void removeItemFromSessionStorage(String item)
        {
            js.ExecuteScript(String.Format(
                    "window.sessionStorage.removeItem('%s');", item));
        }

        public bool isItemPresentInSessionStorage(String item)
        {
            if (js.ExecuteScript(String.Format(
                    "return window.sessionStorage.getItem('%s');", item)) == null)
                return false;
            else
                return true;
        }

        public String getItemFromSessionStorage(String key)
        {
            return (String)js.ExecuteScript(String.Format(
                    "return window.sessionStorage.getItem('%s');", key));
        }

        public String getKeyFromSessionStorage(int key)
        {
            return (String)js.ExecuteScript(String.Format(
                    "return window.sessionStorage.key('%s');", key));
        }

        public long getSessionStorageLength()
        {
            return (long)js.ExecuteScript("return window.sessionStorage.length;");
        }

        public void setItemInSessionStorage(String item, String value)
        {
            js.ExecuteScript(String.Format(
                    "window.sessionStorage.setItem('%s','%s');", item, value));
        }

        public void clearSessionStorage()
        {
            js.ExecuteScript(String.Format("window.sessionStorage.clear();"));
        }
    }
}
