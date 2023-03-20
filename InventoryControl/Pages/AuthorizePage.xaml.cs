using InventoryControl.BdWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace InventoryControl.Pages
{
    /// <summary>
    /// Логика взаимодействия для AuthorizePage.xaml
    /// </summary>
    public partial class AuthorizePage : Page
    {
      

        public AuthorizePage()
        {
            InitializeComponent();
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            bool result = Service.UserService.LoginUser(txbLogin.Text, txbPassword.Password, IsRememberMe.IsChecked.Value);

            if(result == true)
            {
                MessageBox.Show("Авторизация прошла успешно");
               
                Classes.Frame.FrameOBJ.Navigate(new HomePage());
              
            }
            else
            {
                MessageBox.Show("Логин или пароль введен не верно");
            }
        }
    }
}
