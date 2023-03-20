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
using InventoryControl.Pages;
using InventoryControl.Service;

namespace InventoryControl
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Classes.Frame.FrameOBJ = MainFrame;
            if(Properties.Settings.Default.UserName != string.Empty)
            {

                UserService.UserName = Properties.Settings.Default.UserName;
                UserService.UserPassword = Properties.Settings.Default.UserPassword;
                UserService.UserRole = Properties.Settings.Default.UserRole;
                Classes.Frame.FrameOBJ.Navigate(new HomePage());

            }
            else
            {
                Classes.Frame.FrameOBJ.Navigate(new AuthorizePage());

            }
        }
    }
}
