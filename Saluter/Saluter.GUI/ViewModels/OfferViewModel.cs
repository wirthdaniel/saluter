using AutoMapper;
using Prism.Commands;
using Saluter.Data;
using Saluter.GUI.Models;
using Saluter.Models;
using Saluter.Models.Enums;
using Saluter.Services.EventAggregatorService;
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

        private readonly ICustomerData customerData;

        private readonly IMapper mapper;

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

        private ObservableCollection<Customer> _customers;

        public ObservableCollection<Customer> Customers
        {
            get { return _customers; }
            set
            {
                _customers = value;
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

        private Customer _selectedCustomer;

        public Customer SelectedCustomer
        {
            get { return _selectedCustomer; }
            set
            {
                _selectedCustomer = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public DelegateCommand SearchCommand { get; set; }

        public DelegateCommand CloseOfferViewCommand { get; set; }

        #endregion

        #region Constructor

        public OfferViewModel(IProductData productData, ICustomerData customerData, IMapper mapper, SelectedProductsViewModel selectedProductsViewModel)
        {
            this.productData = productData;

            this.customerData = customerData;

            this.mapper = mapper;

            SearchCommand = new DelegateCommand(Search);

            CloseOfferViewCommand = new DelegateCommand(CloseOfferView);

            foreach (var value in Enum.GetValues(typeof(SearchType)))
            {
                SearchTypes.Add(value.ToString());
            }

            _cbSearchTypeSelectedItem = SearchTypes.First();

            _content = selectedProductsViewModel;

            _customers = new ObservableCollection<Customer>();

            customerData.GetAllCustomers().ForEach(x => _customers.Add(x));
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

        public void AddProduct(Product selectedProduct)
        {
            var selectedProductDisplayModel = mapper.Map<Product, SelectedProductDisplayModel>(selectedProduct);

            if (Content.Items == null)
                Content.Items = new ObservableCollection<SelectedProductDisplayModel>();

            Content.Items.Add(selectedProductDisplayModel);
        }

        private void CloseOfferView()
        {
            ClearViewModel();

            EventAggregatorService.GetInstance().GetEvent<CloseOfferViewEvent>().Publish();
        }

        private void ClearViewModel()
        {
            Items?.Clear();
            SearchText = string.Empty;
            Content.Items?.Clear();
        }

        #endregion

    }
}
