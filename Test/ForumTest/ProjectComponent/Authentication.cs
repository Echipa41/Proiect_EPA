using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumTest.Models;
using ForumTest.PageObjects;
using ForumTest.SeleniumComponent;
using System.Globalization;
using OpenQA.Selenium;
using ForumTest.Common;
using ForumTest.ProjectComponent;
using ForumTest.Test;

namespace ForumTest.ProjectComponent
{
    internal class Authentication
    {
        public static void Login(User user)
        {
            LoginPageObjects loginPageObject = new LoginPageObjects();
            loginPageObject.Username.SendKeys(user.Username);
            loginPageObject.Password.SendKeys(user.Password);
            loginPageObject.LoginButton.Click();
        }

        public static void LogOff()
        {
            const string LOGOFF_BUTTON_TEXT = "Deconectare";
            var logOffButton = SeleniumGetMethods.GetWebElementById("LoginView1_HeadLoginStatus");

            if (!logOffButton.Text.Equals(LOGOFF_BUTTON_TEXT))
            {
                throw new Exception("User is not loged");
            }
            else
            {
                logOffButton.Click();
            }
        }

        public static void SignUp(SignUpUser user)
        {
            SignUpPageObjects signUpPageObjects = new SignUpPageObjects();
            signUpPageObjects.User.SendKeys(user.Username);
            signUpPageObjects.Password.SendKeys(user.Password);
            signUpPageObjects.ConfirmPassword.SendKeys(user.ConfirmPassword);
            signUpPageObjects.Email.SendKeys(user.Email);
            signUpPageObjects.CreateUserButton.Click();
        }

        public static void EditeProfile(UserProfile user)
        {
            UserProfilePageObjects userProfilePageObjects = new UserProfilePageObjects();
            SeleniumSetMethods.ChangeTextForWebElement(userProfilePageObjects.FirstName, user.FirstName);
            SeleniumSetMethods.ChangeTextForWebElement(userProfilePageObjects.LastName, user.LastName);
            SeleniumSetMethods.ChangeTextForWebElement(userProfilePageObjects.BirthDate, GetDate(user.BirthDate));
            SelectSex(user.Sex, userProfilePageObjects);
            SeleniumSetMethods.ChangeTextForWebElement(userProfilePageObjects.City, user.City);
            SeleniumSetMethods.ChangeTextForWebElement(userProfilePageObjects.Signature, user.Signature);

            if(ImageUtils.IsValidImage(FileUtils.CreateInputPath(user.Photo)))
                userProfilePageObjects.Photo.SendKeys(FileUtils.CreateInputPath(user.Photo));
            userProfilePageObjects.Save.Click();
           // userProfilePageObjects.Cancel.Click(); daca vreau sa renunt 
        }

        private static void SelectSex(string sex, UserProfilePageObjects userProfilePageObjects)
        {
            if (sex.Equals("F"))
                userProfilePageObjects.SexF.Click();
            else
                userProfilePageObjects.SexM.Click();
        }

        private static bool CheckDate(string date)
        {
            DateTime Test;
            if (DateTime.TryParseExact(date, "MM/dd/yyyy", null, DateTimeStyles.None, out Test) == true)
                return true;
            else
                return false;
        }

        private static String GetDate(string date)
        {
            if (CheckDate(date))
                return date;
            else
                return "";
        }
    }
}
