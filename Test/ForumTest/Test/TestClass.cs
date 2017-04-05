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
using ForumTest.Test;


namespace ForumTest.Test
{
    [TestClass]
    public class TestClass
    {   
        [AssemblyInitialize]
        public static void AssemblyInit(TestContext context)
        {

        }

        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            //PropertiesCollection.Driver = new InternetExplorerDriver();
            //PropertiesCollection.Driver = new FirefoxDriver();
            PropertiesCollection.Driver = new ChromeDriver();
            //PropertiesCollection.Driver = new EdgeDriver();           

            Sincronize.SetImplicitWait(60);
            Sincronize.SetPageLoad(60);
        }

        [TestInitialize]
        public void TestInit()
        {

        }
        
        [TestCleanup]
        public void TestCleanup()
        {

        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
            if (PropertiesCollection.Driver != null)
                PropertiesCollection.Driver.Quit();
        }

        [AssemblyCleanup]
        public static void AssemblyCleanup()
        {

        }

        [TestMethod]
        public void TestUserStory1()
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
            catch (Exception ex)
            {
                Logger.LogException("", ex);
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void TestUserStory3()
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
                Panel.Galerie_Click();
                Sincronize.Wait(5000);
            }
            catch (Exception e)
            {
                Logger.LogException("", e);
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestUserStory4()
        {
            try
            {
                const string INPUT_FILE = "UserProfile.xml";
                const string USER_CREDENTIAL_FILE = "User.xml";
                User user = XML.DeserializeObject<User>(FileUtils.CreateInputPath(USER_CREDENTIAL_FILE));
                UserProfile userProfile = XML.DeserializeObject<UserProfile>(FileUtils.CreateInputPath(INPUT_FILE));

                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Log_Click();
                Authentication.Login(user);
                UserPanel.ProfilulMeu_Click();
                var editButton = SeleniumGetMethods.GetWebElementById("MainContent_EditProfileButton");
                editButton.Click();
                // SeleniumGetMethods.GetWebElementInnerHTML("Editeaza").Click();
                Authentication.EditeProfile(userProfile);
            }
            catch (Exception e)
            {
                Logger.LogException("", e);
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestUserStory5()
        {
            try
            {
                const String INPUT_FILE = "User.xml";
                User user = XML.DeserializeObject<User>(FileUtils.CreateInputPath(INPUT_FILE));

                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Log_Click();
                Authentication.Login(user);
                Panel.Galerie_Click();
                Sincronize.Wait(5000);
            }
            catch (Exception e)
            {
                Logger.LogException("", e);
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestUserStory7()
        {
            try
            {
                const String INPUT_FILE = "User.xml";
                User user = XML.DeserializeObject<User>(FileUtils.CreateInputPath(INPUT_FILE));


                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Log_Click();
                Authentication.Login(user);
                Panel.Galerie_Click();

                var title = SeleniumGetMethods.Parent(SeleniumGetMethods.GetParentNode(SeleniumGetMethods.GetWebElementInnerHTML("Fractali Turtle")));
                SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetChild(2, title)).Click();
                SeleniumGetMethods.Parent(SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML("Covor Sierpinski"))).Click();
                var citeaza = SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$MessageListView$ctrl0$QuoteLoginView$QuoteMessageButton");
                citeaza.Click();
                Sincronize.Wait(5000);
            }
            catch (Exception e)
            {
                Logger.LogException("", e);
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestUserStory6()
        {
            try
            {
                const String INPUT_FILE = "User.xml";
                User user = XML.DeserializeObject<User>(FileUtils.CreateInputPath(INPUT_FILE));
                const String COMM = "HEheheh";

                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Log_Click();
                Authentication.Login(user);
                Panel.Galerie_Click();

                var title = SeleniumGetMethods.Parent(SeleniumGetMethods.GetParentNode(SeleniumGetMethods.GetWebElementInnerHTML("Fractali Turtle")));
                SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetChild(2, title)).Click();
                SeleniumGetMethods.Parent(SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML("Covor Sierpinski"))).Click();
               // SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$MessageListView$ctrl0$QuoteLoginView$QuoteMessageButton").Click();
                var textarea = SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$AddMessageLoginView$MessageTB");
                textarea.SendKeys(COMM);
                SeleniumGetMethods.GetWebElementByAttribut("value", "Adauga comentariu").Click();
                Sincronize.Wait(5000);
                var commRootElem = SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML(COMM));
                var childs = SeleniumGetMethods.GetChilds(commRootElem);               
                var editeButton = SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetFirstChild((IWebElement)childs[3]));              
                editeButton.Click();
                var delete = SeleniumGetMethods.GetNextSibling(editeButton);
                delete.Click();
            }
            catch (Exception e)
            {
                Logger.LogException("", e);
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestUserStory8()
        {
            try
            {
                const String INPUT_FILE = "User.xml";
                User user = XML.DeserializeObject<User>(FileUtils.CreateInputPath(INPUT_FILE));
                const String COMM = "HEheheh";

                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Log_Click();
                Authentication.Login(user);
                Panel.Galerie_Click();

                var title = SeleniumGetMethods.Parent(SeleniumGetMethods.GetParentNode(SeleniumGetMethods.GetWebElementInnerHTML("Fractali Turtle")));
                SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetChild(2, title)).Click();
                SeleniumGetMethods.Parent(SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML("Covor Sierpinski"))).Click();

                SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$MessageUserTB").SendKeys("Alex");
                SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$Button2").Click();

                SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$MessageDescriptionTB").SendKeys("Foarte");
                SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$Button2").Click();
}
            catch (Exception e)
            {
                Logger.LogException("", e);
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestUserStory10()
        {
            try
            {
                const String INPUT_FILE = "User.xml";
                User user = XML.DeserializeObject<User>(FileUtils.CreateInputPath(INPUT_FILE));
                const String COMM = "HEheheh";

                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Log_Click();
                Authentication.Login(user);
                Panel.Galerie_Click();

                var title = SeleniumGetMethods.Parent(SeleniumGetMethods.GetParentNode(SeleniumGetMethods.GetWebElementInnerHTML("Fractali Turtle")));
                SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetChild(2, title)).Click();
                SeleniumGetMethods.Parent(SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML("Covor Sierpinski"))).Click();
                var textarea = SeleniumGetMethods.GetWebElementByName("ctl00$MainContent$AddMessageLoginView$MessageTB");
                textarea.SendKeys(COMM);
                SeleniumGetMethods.GetWebElementByAttribut("value", "Adauga comentariu").Click();
                Sincronize.Wait(5000);
                var commRootElem = SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML(COMM));
                var childs = SeleniumGetMethods.GetChilds(commRootElem);
                var editeButton = SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetFirstChild((IWebElement)childs[3]));                
                var delete = SeleniumGetMethods.GetNextSibling(editeButton);
                delete.Click();
            }
            catch (Exception e)
            {
                Logger.LogException("", e);
                Assert.Fail(e.Message);
            }
        }

        [TestMethod]
        public void TestUserStory11()
        {
            Logger.LogInfo("Test Login:");
            try
            {
                const String INPUT_FILE = "User.xml";
                const String USER_ROLE_FILE = "UserRole.xml";
                const int SELECT_ROLE_INDEX = 4;
                const int SAVE_BUTTON_INDEX = 5;
                User user = XML.DeserializeObject<User>(FileUtils.CreateInputPath(INPUT_FILE));
                UserRole userRole = XML.DeserializeObject<UserRole>(FileUtils.CreateInputPath(USER_ROLE_FILE));

                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Log_Click();
                Authentication.Login(user);
                AdminPanel.ProfilulMeu_Click();
                AdminPanel.Administrare_Click();
                var tr = SeleniumGetMethods.Parent(SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML(userRole.Username)));
                var select = SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetChild(SELECT_ROLE_INDEX, tr));
                SeleniumSetMethods.SelectDropDown(select, userRole.Role);                
                Sincronize.Wait(2000);
                var save = SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetChild(SAVE_BUTTON_INDEX, tr));
                save.Click();
            }
            catch (Exception ex)
            {
                Assert.Fail();
                Logger.LogException("", ex);
            }
        }

        [TestMethod]
        public void TestUserStory9()
        {            
            try
            {
                const String INPUT_FILE = "User.xml";
                User user = XML.DeserializeObject<User>(FileUtils.CreateInputPath(INPUT_FILE));

                PropertiesCollection.OpenURL(Constants.START_URL);
                Panel.Log_Click();
                Authentication.Login(user);
                UserPanel.Contact_Click();
            }
            catch (Exception ex)
            {
                Assert.Fail();
                Logger.LogException("", ex);
            }
        }
    }
}
