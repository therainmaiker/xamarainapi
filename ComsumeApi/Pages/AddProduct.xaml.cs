using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComsumeApi.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComsumeApi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {
        public AddProduct()
        {
            InitializeComponent();
        }

        public AddProduct(Product product)
        {
            //if (product != null)
            //{
            //    prodId = product.Id;
            //    name.Text = product.Name;
            //    description.Text = product.LongDescription;
            //    quantity.Text = product.Quantity.ToString();
            //    price.Text = product.Price.ToString();
            //    disImage.Source = ImageSource.FromFile(product..Remove(0, 6));
            //    _inUpdate = true;
            //}
        }

        private void BtnSave_OnClicked(object sender, EventArgs e)
        {
            
        }

        private void BtnClear_OnClicked(object sender, EventArgs e)
        {
            
        }

        private void Image_OnClicked(object sender, EventArgs e)
        {
            
        }

        private void TakeImage_OnClicked(object sender, EventArgs e)
        {
            
        }
    }
}