using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForumTest.Models
{
    public class SignUpUser : User
    {
        public String Email
        {
            get;
            set;
        }

        public String ConfirmPassword
        {
            get;
            set;
        }
    }
}
