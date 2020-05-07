using FoodDeliveryAppByManuel.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace FoodDeliveryAppByManuel.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductDetailPage : ContentPage
    {
        public ProductDetailPage(int productId)
        {
            InitializeComponent();
            GetProductDetails(productId);
        }

        private async void GetProductDetails(int productId)
        {
            var product = await ApiService.GetProductById(productId);
            LblName.Text = product.name;
            LblDetail.Text = product.detail;
            ImgProduct.Source = product.FullImageUrl;
            LblPrice.Text = product.price.ToString();
            LblTotalPrice.Text = LblPrice.Text;
        }

        private void TapIncrement_Tapped(object sender, EventArgs e)
        {
            var i = Convert.ToInt16(LblQty.Text);
            i++;
            LblQty.Text = i.ToString();
            LblTotalPrice.Text = (Convert.ToInt16(LblQty.Text) * Convert.ToInt16(LblPrice.Text)).ToString();
        }

        private void TapDecrement_Tapped(object sender, EventArgs e)
        {
            var i = Convert.ToInt16(LblQty.Text);
            i--;
            if(i < 1)
            {
                return;
            }
            LblQty.Text = i.ToString();
            LblTotalPrice.Text = (Convert.ToInt16(LblQty.Text) * Convert.ToInt16(LblPrice.Text)).ToString();
        }

        private void TapBack_Tapped(object sender, EventArgs e)
        {
            Navigation.PopModalAsync();
        }
    }
}