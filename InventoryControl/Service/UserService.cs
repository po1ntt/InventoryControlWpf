using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryControl.BdWork;

namespace InventoryControl.Service
{
    internal class UserService
    {
        public static Users userToSave;
        public static bool LoginUser(string Login, string Passoword)
        {
            InventoryСontrolEntities context = new InventoryСontrolEntities();
            var user = context.Users.FirstOrDefault(p => p.Login == Login && p.Password == Passoword);
            if(user != null)
            {
                userToSave = user;
            }
            return (user != null);
        }

    }
}
