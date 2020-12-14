using LibraryXam.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LibraryXam
{
    public partial class MainPage : ContentPage
    {
        public  MainPage()
        {
            InitializeComponent();
            BindingContext = App.Books;
        }

        private async void lstBooks_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            BookPage newPage = new BookPage();
            newPage.BindingContext = e.Item;
            await Navigation.PushAsync(newPage);
        }
    }
}
