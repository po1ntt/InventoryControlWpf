using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControl.BdWork;
using InventoryControl.Pages;

namespace InventoryControl.Service
{
    internal class UserService
    {
        public static Users userToSave;
        public static string UserName { get; set; } 
        public static string UserPassword { get; set; } 
        public static string UserRole { get; set; } 
        public static bool LoginUser(string Login, string Passoword, bool IsRemember)
        {

            InventoryСontrolEntities1 context = new InventoryСontrolEntities1();
            var user = context.Users.FirstOrDefault(p => p.Login == Login && p.Password == Passoword);
            if(user != null)
            {
                if(IsRemember == true)
                {
                    Properties.Settings.Default.UserName = user.Login;
                    Properties.Settings.Default.UserPassword = user.Password;
                    Properties.Settings.Default.UserRole = user.Role;
                    Properties.Settings.Default.Save();
                    UserName = user.Login;
                    UserPassword = user.Password;
                    UserRole = user.Role;
                }
                else
                {
                    UserName = user.Login;
                    UserPassword = user.Password;
                    UserRole = user.Role;
                }
            }
            return (user != null);
        }

    }
}
