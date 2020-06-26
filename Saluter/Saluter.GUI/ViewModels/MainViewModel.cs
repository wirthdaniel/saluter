using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Saluter.Services.EventAggregatorService;

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

        public StartViewModel StartViewModel { get; set; }

        public OfferViewModel OfferViewModel { get; set; }

        #endregion

        #region Commands

        public DelegateCommand NewOfferCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel(StartViewModel startViewModel, OfferViewModel offerViewModel)
        {            
            NewOfferCommand = new DelegateCommand(NewOffer);

            StartViewModel = startViewModel;

            OfferViewModel = offerViewModel;

            Content = startViewModel;

            EventAggregatorService.GetInstance().GetEvent<CloseOfferViewEvent>().Subscribe(CloseOfferView);
        }

        #endregion

        #region Methods

        private void NewOffer()
        {
            Content = OfferViewModel;
        }

        private void CloseOfferView()
        {
            Content = StartViewModel;
        }

        #endregion


    }
}
