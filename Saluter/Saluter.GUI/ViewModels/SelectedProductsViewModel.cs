using Saluter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.GUI.ViewModels
{
    public class SelectedProductsViewModel : ViewModelBase
    {
        private ObservableCollection<Product> _items;

        public ObservableCollection<Product> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }
        
        public SelectedProductsViewModel()
        {
            Items = new ObservableCollection<Product>();
        }

    }
}
