using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using MVVM.Models;
using MVVM.Views;

namespace MVVM.ViewModels
{
    public class ProductViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<ProductModel> products;
        public ObservableCollection<ProductModel> Products
        {
            get { return products; }
            set
            {
                products = value;
                OnPropertyChanged();
            }
        }

        private ProductModel selectedProduct;
        public ProductModel SelectedProduct
        {
            get { return selectedProduct; }
            set
            {
                selectedProduct = value;
                OnPropertyChanged();
            }
        }

        public ICommand AddCommand { get; set; }
        public ICommand EditCommand { get; set; }
        public ICommand DeleteCommand { get; set; }

        public ProductViewModel()
        {
            Products = new ObservableCollection<ProductModel>();

            AddCommand = new RelayCommand(AddProduct);
            EditCommand = new RelayCommand(EditProduct);
            DeleteCommand = new RelayCommand(DeleteProduct);
        }

        private void AddProduct(object parameter)
        {
            var product = new ProductModel();
            Products.Add(product);
            SelectedProduct = product;
        }

        private void EditProduct(object parameter)
        {
            if (SelectedProduct != null)
            {
                var editWindow = new EditProductWindow(SelectedProduct);
                if (editWindow.ShowDialog() == true)
                {
                    // Обновить данные товара
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            }
        }

        private void DeleteProduct(object parameter)
        {
            if (SelectedProduct != null)
            {
                Products.Remove(SelectedProduct);
                SelectedProduct = null;
            }
        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
