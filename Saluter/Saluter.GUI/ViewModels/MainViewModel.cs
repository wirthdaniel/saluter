using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;

namespace Saluter.GUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private ViewModelBase _content;

        #endregion

        #region Properties

        public ViewModelBase Content
        {
            get { return _content; }
            set
            {
                _content = value;
                OnPropertyChanged();
            }
        }

        public OfferViewModel OfferViewModel { get; set; }

        #endregion

        #region Commands

        public DelegateCommand NewOfferCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel(StartViewModel startViewModel, OfferViewModel offerViewModel)
        {            
            NewOfferCommand = new DelegateCommand(NewOffer);

            OfferViewModel = offerViewModel;

            Content = startViewModel;
        }

        #endregion

        #region Methods

        private void NewOffer()
        {
            Content = OfferViewModel;
        }

        #endregion


    }
}
