using Saluter.GUI.ViewModels;
using Saluter.Models;
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

namespace Saluter.GUI.Views
{
    /// <summary>
    /// Interaction logic for OfferView.xaml
    /// </summary>
    public partial class OfferView : UserControl
    {
        public OfferView()
        {
            InitializeComponent();
        }

        private void DataGridRow_PreviewMouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var product = (sender as DataGridRow).Item;

            (DataContext as OfferViewModel).ProductSelected((Product)product);
        }

        //private void Row_Loaded(object sender, RoutedEventArgs e)
        //{
        //    var row = sender as DataGridRow;

        //    var binding = new MouseBinding((DataContext as OfferViewModel).ProductSelectedCommand,
        //            new MouseGesture() { MouseAction = MouseAction.LeftDoubleClick });

        //    binding.CommandParameter = (DataContext as OfferViewModel).CurrentItem;

        //    row.InputBindings.Add(binding);
        //}
    }
}
