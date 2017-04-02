using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumTest.SeleniumComponent;

namespace ForumTest.ProjectComponent
{
    public class Panel
    {   
        internal static void Log_Click()
        {
            SeleniumGetMethods.GetWebElementById("LoginView1_HeadLoginStatus").Click();
        }

        public static void Acasa_Click()
        {
            throw new NotImplementedException();
        }

        public static void Galerie_CLick()
        {
            SeleniumGetMethods.GetWebElementInnerHTML("Galerie").Click();
        }

        public static void Cautare_CLick()
        {
            throw new NotImplementedException();
        }

        public static void Contact_CLick()
        {
            throw new NotImplementedException();
        }
    }
}
