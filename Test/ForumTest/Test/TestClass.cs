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
        public void TestSignUp()
        {
            try
            {
                const String INPUT_FILE = "SignUpTest.xml";
                SignUpUser user = XML.DeserializeObject<SignUpUser>(FileUtils.CreateInputPath(INPUT_FILE));

                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Log_Click();
                SeleniumGetMethods.GetWebElementInnerHTML("Inregistrati-va").Click();
                Authentication.SignUp(user);
            }
            catch(Exception ex)
            {
                Logger.LogException("", ex);
                Assert.Fail(ex.Message);
            }
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
                Authentication.Login(user);
                Sincronize.Wait(6000);
                ForumTest.ProjectComponent.Authentication.LogOff();
            }
            catch (Exception ex)
            {
                Assert.Fail();
                Logger.LogException("", ex);
            }
        }

        [TestMethod]
        public void TestUserStory2()
        {
            try
            {
                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Galerie_CLick();
                Sincronize.Wait(5000);
            }
            catch(Exception e)
            {
                Logger.LogException("", e);
                Assert.Fail(e.Message);
            }
        }
    }
}
