using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumTest.Models;
using ForumTest.PageObjects;
using ForumTest.SeleniumComponent;


namespace ForumTest.ProjectComponent
{
    internal class LoginClass
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
    }
}
