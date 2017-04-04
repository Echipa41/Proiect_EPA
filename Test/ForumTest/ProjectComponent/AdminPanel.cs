using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ForumTest.SeleniumComponent;

namespace ForumTest.ProjectComponent
{
    public class AdminPanel : UserPanel
    {
        public static void Administrare_Click()
        {
            SeleniumGetMethods.GetWebElementInnerHTML("Administrare").Click();
        }
    }
}
