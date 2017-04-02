using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using ForumTest.Common;
using OpenQA.Selenium;
using OpenQA.Selenium.IE;
using ForumTest.Models;
using System.IO;
using ForumTest.PageObjects;
using ForumTest.SeleniumComponent;
using ForumTest.ProjectComponent;



namespace ForumTest.Test
{
    [TestClass]
    public class TestClass
    {
        [ClassInitialize]
        public static void SetUp(TestContext context)
        {
            //PropertiesCollection.Driver = new InternetExplorerDriver();
            //PropertiesCollection.Driver = new FirefoxDriver();
            PropertiesCollection.Driver = new ChromeDriver();
            //PropertiesCollection.Driver = new EdgeDriver();           

            Sincronize.SetImplicitWait(60);
            Sincronize.SetPageLoad(60);
        }

        [ClassCleanup]
        public static void Close()
        {
            if (PropertiesCollection.Driver != null)
                PropertiesCollection.Driver.Quit();
        }

        [TestMethod]
        public void TestLogin()
        {
            Logger.LogInfo("Test Login:");
            try
            {
                const String INPUT_FILE = "User.xml";
                User user = XML.DeserializeObject<User>(FileUtils.CreateInputPath(INPUT_FILE));

                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Log_Click();
                LoginClass.Login(user);
                Sincronize.Wait(6000);
                ForumTest.ProjectComponent.LoginClass.LogOff();
            }
            catch (Exception ex)
            {
                Assert.Fail();
                Logger.LogException("", ex);
            }
        }
    }
}
