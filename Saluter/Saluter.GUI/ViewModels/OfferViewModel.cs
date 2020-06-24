using Prism.Commands;
using Saluter.Data;
using Saluter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.GUI.ViewModels
{
    public class OfferViewModel : ViewModelBase
    {

        #region Fields

        private readonly IProductData productData;

        private List<Product> _items;

        private string _searchText;

        #endregion

        #region Properties

        public List<Product> Items
        {
            get { return _items; }
            set
            {
                _items = value;
                OnPropertyChanged();
            }
        }

        public string MyPropSearchTexterty
        {
            get { return _searchText; }
            set
            {
                _searchText = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public DelegateCommand SearchCommand { get; set; }

        #endregion

        #region Constructor

        public OfferViewModel(IProductData productData)
        {
            this.productData = productData;

            SearchCommand = new DelegateCommand(Search);
        }

        #endregion

        #region Methods

        private void Search()
        {
            throw new NotImplementedException();
        }


        #endregion

    }
}
