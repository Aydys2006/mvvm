using MVVM.Models;
using System.Windows;

namespace MVVM.Views
{
    public partial class EditProductWindow : Window
    {
        public EditProductWindow(ProductModel product)
        {
            InitializeComponent();
            DataContext = product;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = true;
            Close();
        }
    }
}
