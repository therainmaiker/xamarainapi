using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ComsumeApi.Models;
using ComsumeApi.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ComsumeApi.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Products : ContentPage
    {
        CategoryService _service;
        public Products()
        {
            InitializeComponent();
            _service = new();
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            GetAllProducts();
        }

        public async void GetAllProducts()
        {
            var prod =  _service.GetAll().Result;
            //if (prod != null && prod.Count() > 0)
            //{
            //    lblInfo.Text = $"Total {prod.Count().ToString()} record(s) found";
            //}
            //else
            //{
            //    lblInfo.Text = "No product records found. Please add one";
            //}
            lstProduct.ItemsSource = prod;
        }

        private void BtnAddProduct_OnClicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddProduct());
        }

        private async void LstProduct_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                Product products = (Product)e.SelectedItem;
                var action = await DisplayActionSheet("Operation", "Cancel", null, "Update");

                if (action == "Update")
                {
                    await this.Navigation.PushAsync(new AddProduct(products));
                }
                //else if (action == "Delete")
                //{
                //    await _service.DeleteProduct(products);
                //}

                //lstProduct.SelectedItem = null;
            }
        }
    }
}