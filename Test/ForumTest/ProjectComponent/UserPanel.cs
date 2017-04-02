using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumTest.SeleniumComponent;

namespace ForumTest.ProjectComponent
{
    public class UserPanel : Panel
    {
        public static void ProfilulMeu_Click()
        {
            SeleniumGetMethods.GetWebElementInnerHTML("Profilul meu").Click();
        }
    }
}
