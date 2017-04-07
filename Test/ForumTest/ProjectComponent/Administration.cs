using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumTest.SeleniumComponent;
using ForumTest.Common;
using ForumTest.Models;


namespace ForumTest.ProjectComponent
{
    public class Administration
    {
        internal enum Role
        {
            Membru,
            Moderator,
            Admin
        }

        public static void GetRole(UserRole userRole)
        {
            const int SELECT_ROLE_INDEX_IN_DOM = 4;
            const int SAVE_BUTTON_INDEX_IN_DOM = 5;
            var tr = SeleniumGetMethods.Parent(SeleniumGetMethods.Parent(SeleniumGetMethods.GetWebElementInnerHTML(userRole.Username)));
            var select = SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetChild(SELECT_ROLE_INDEX_IN_DOM, tr));
            SeleniumSetMethods.SelectDropDown(select, userRole.Role);
            Sincronize.Wait(2000);
            var save = SeleniumGetMethods.GetFirstChild(SeleniumGetMethods.GetChild(SAVE_BUTTON_INDEX_IN_DOM, tr));
            save.Click();
        }
    }
}
