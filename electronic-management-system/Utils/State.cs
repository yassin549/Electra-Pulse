using itcrafts.BL;
using itcrafts.UI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace itcrafts.Utils
{
    internal class State
    {
        static User? CurrentUser;
        static Form CurrentForm = new Home();

        public static User? GetCurrentUser()
        {
            return CurrentUser;
        }

        public static void SetCurrentUser(User? user)
        {
            CurrentUser = user;
        }

        public static Form GetCurrentForm()
        {
            return CurrentForm;
        }

        public static void SetCurrentForm(Form form)
        {
            CurrentForm = form;
            CurrentForm.Show();
        }
    }
}
