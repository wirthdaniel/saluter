using Prism.Commands;
using Saluter.GUI.Models;
using Saluter.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.GUI.ViewModels
{
    public class SelectedProductsViewModel : ViewModelBase
    {
        private ObservableCollection<SelectedProductDisplayModel> _items;

        public ObservableCollection<SelectedProductDisplayModel> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public static DelegateCommand<string> DeleteProductCommand { get; set; }

        public SelectedProductsViewModel()
        {
            DeleteProductCommand = new DelegateCommand<string>(DeleteProduct);
        }

        private void DeleteProduct(string id)
        {
            Items.Remove(Items.Single(x => x.Id == id));
        }

    }
}
