using Prism.Commands;
using Saluter.Data;
using Saluter.Models;
using Saluter.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.GUI.ViewModels
{
    public class OfferViewModel : ViewModelBase
    {

        #region Fields

        private readonly IProductData productData;

        private ObservableCollection<Product> _items;

        private string _searchText;

        private string _cbSearchTypeSelectedItem;

        private SelectedProductsViewModel _content;

        #endregion

        #region Properties

        public ObservableCollection<Product> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public string SearchText
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        private string _searchMessage;

        public string SearchMessage
        {
            get { return _searchMessage; }
            set
            {
                _searchMessage = value;
                OnPropertyChanged();
            }
        }

        public List<string> SearchTypes { get; set; } = new List<string>();

        public string CbSearchTypeSelectedItem
        {
            get { return _cbSearchTypeSelectedItem; }
            set
            {
                _cbSearchTypeSelectedItem = value;
                OnPropertyChanged();
            }
        }

        public SelectedProductsViewModel Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public DelegateCommand SearchCommand { get; set; }

        #endregion

        #region Constructor

        public OfferViewModel(IProductData productData, SelectedProductsViewModel selectedProductsViewModel)
        {
            this.productData = productData;

            SearchCommand = new DelegateCommand(Search);

            foreach (var value in Enum.GetValues(typeof(SearchType)))
            {
                SearchTypes.Add(value.ToString());
            }

            CbSearchTypeSelectedItem = SearchTypes.First();

            Content = selectedProductsViewModel;
            
        }

        #endregion

        #region Methods

        private void Search()
        {            
            if (!string.IsNullOrEmpty(SearchText))
            {
                var products = CbSearchTypeSelectedItem == SearchType.Id.ToString() ? productData.GetProductsById(SearchText) : productData.GetProductsByName(SearchText);

                if (products != null && products.Count > 0)
                {
                    Items = new ObservableCollection<Product>(products);
                    SearchMessage = string.Empty;
                }
                else
                {
                    SearchMessage = "There is no match!";
                    Items?.Clear();
                }
            }          
        }

        public void ProductSelected(Product selectedProduct)
        {
            Content.Items.Add(selectedProduct);
        }

        #endregion

    }
}
