using Saluter.GUI.ViewModels;
using Saluter.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saluter.GUI.Models
{
    public class SelectedProductDisplayModel : ViewModelBase
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<int> Prices { get; set; }

        private int _price;

        public int Price
        {
            get { return _price; }
            set
            {
                _price = value;
                CalculateTotalPrice();
                OnPropertyChanged();
            }
        }

        public List<Product> Accessories { get; set; }

        //public SelectedProductDisplayModel()
        //{

        //}

        //public SelectedProductDisplayModel(string id, string name, int price, List<Product> accessories = null)
        //{
        //    Id = id;
        //    Name = name;
        //    Prices = new List<int>() { price, price * 2 };

        //    if (accessories != null)
        //    {
        //        Accessories = new List<Product>();
        //        Accessories.AddRange(accessories);
        //    }
        //}

        private double _multiplier;

        public double Multiplier
        {
            get { return _multiplier; }
            set
            {
                _multiplier = value;
                CalculateTotalPrice();
                OnPropertyChanged();
            }
        }

        private int _quantity;

        public int Quantity
        {
            get { return _quantity; }
            set
            {
                _quantity = value;
                CalculateTotalPrice();
                OnPropertyChanged();
            }
        }

        private double _totalPrice;

        public double TotalPrice
        {
            get { return _totalPrice; }
            set
            {
                _totalPrice = value;
                OnPropertyChanged();
            }
        }

        private void CalculateTotalPrice()
        {
            if (Multiplier > 0)
                TotalPrice = Quantity * Price * Multiplier;
            else if (Multiplier == 0)
                TotalPrice = Quantity * Price;
        }
    }
}
