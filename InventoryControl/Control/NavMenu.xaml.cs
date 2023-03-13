using InventoryControl.Classes;
using InventoryControl.Pages;
using InventoryControl.Pages.Windows.Add;
using InventoryControl.Service;
using System;
using System.Collections.Generic;
using System.Linq;
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

namespace InventoryControl.Control
{
    /// <summary>
    /// Логика взаимодействия для NavMenu.xaml
    /// </summary>
    public partial class NavMenu : UserControl
    {
        public NavMenu()
        {
            InitializeComponent();
        }
        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            InfoAboutUser.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
            ButtonCloseMenu.Visibility = Visibility.Visible;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            InfoAboutUser.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
        }

        private void Logs_Click(object sender, MouseButtonEventArgs e)
        {
            if (UserService.userToSave.Role == "Admin")
            {
                Classes.Frame.FrameOBJ.Navigate(new LoggerPage());
            }
            else
            {
                MessageBox.Show("Доступ к логам есть только у администратора");
            }
        }
        private void Property_Click(object sender, MouseButtonEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new PropertiesPage());
        }
        private void Documents_Click(object sender, MouseButtonEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new Documents());
        }
        private void Orders_Click(object sender, MouseButtonEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new OrdersPage());
        }
        private void NewTechnika_Click(object sender, MouseButtonEventArgs e)
        {
            Base.OpenCenterPosAndOpen(new AddToWareHouseEquip());

        }
        private void Departaments_Click(object sender, MouseButtonEventArgs e)
        {
            Classes.Frame.FrameOBJ.Navigate(new DepartamentPage());
        }
        private void OutAppClick_Click(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        private void Logout_Click(object sender, MouseButtonEventArgs e)
        {
            Service.UserService.userToSave = null;
            Classes.Frame.FrameOBJ.Navigate(new AuthorizePage());
        }
    }
}
