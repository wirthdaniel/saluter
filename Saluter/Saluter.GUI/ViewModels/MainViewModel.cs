using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleInjector;
using Saluter.Services.EventAggregatorService;
using Saluter.Services.PdfServices;
using Saluter.Models;
using AutoMapper;
using Saluter.GUI.Models;
using System.Windows;
using Microsoft.Win32;

namespace Saluter.GUI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Fields

        private ViewModelBase _content;

        private readonly IMapper mapper;

        private readonly IPdfExporter pdfExporter;

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

        public DelegateCommand ExportOfferToPdfCommand { get; set; }

        #endregion

        #region Constructor

        public MainViewModel(StartViewModel startViewModel, OfferViewModel offerViewModel, IMapper mapper, IPdfExporter pdfExporter)
        {
            this.mapper = mapper;

            this.pdfExporter = pdfExporter;

            NewOfferCommand = new DelegateCommand(NewOffer);

            ExportOfferToPdfCommand = new DelegateCommand(ExportOfferToPdf);

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

        private void ExportOfferToPdf()
        {
            var offerContent = new OfferContent()
            {
                OfferId = "SAH001",
                Customer = (Content as OfferViewModel).SelectedCustomer,
                SelectedProducts = GetSelectedProducts()
            };

            if (ValidateOfferContent(offerContent))
            {
                SaveFileDialog saveFileDialog = new SaveFileDialog
                {
                    Filter = "pdf files (*.pdf)|*.pdf",
                    FilterIndex = 2,
                    RestoreDirectory = true
                };

                bool? result = saveFileDialog.ShowDialog();

                if (result.Value)
                    pdfExporter.Export(offerContent, saveFileDialog.FileName);
            }                                           
        }

        private bool ValidateOfferContent(OfferContent content)
        {            
            if (content.Customer == null)
            {
                MessageBox.Show("Please select a customer!", "Missing customer", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }
            else if (content.SelectedProducts == null || content.SelectedProducts.Count == 0)
            {
                MessageBox.Show("Please add products to the offer!", "Missing products", MessageBoxButton.OK, MessageBoxImage.Warning);
                return false;
            }

            return true;
        }

        private List<SelectedProduct> GetSelectedProducts()
        {
             var selectedProducts = new List<SelectedProduct>();

            var displayedSelectedProducts = (Content as OfferViewModel).Content.Items;
            
            foreach (var product in displayedSelectedProducts)
            {
                selectedProducts.Add(mapper.Map<SelectedProductDisplayModel, SelectedProduct>(product));
            }

            return selectedProducts;
        }

        #endregion


    }
}
