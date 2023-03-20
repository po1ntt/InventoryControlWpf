using InventoryControl.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace InventoryControl.Control.ViewModels
{
    public class VMNavMeny : INotifyPropertyChanged
    {
        public string UserName { get; set; }
        public string UserRole { get; set; }
        public VMNavMeny()
        {
            UserName = UserService.UserName;
            UserRole = UserService.UserRole;
            GridWidth = 60;
        }

        private double _GridWidth;
       
        public double GridWidth
        {
            get { return _GridWidth; }
            set { _GridWidth = value;
                OnPropertyChanged();
            }
        }
       
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
}
