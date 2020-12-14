using LibraryXam.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibraryXam
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BookPage : ContentPage
    {
        public BookPage()
        {
            InitializeComponent();
        }

        private async void ImageButton_Clicked(object sender, EventArgs e)
        {
            Book currentBook = BindingContext as Book;
            if (currentBook.IsFavourite)
            {
                currentBook.IsFavourite = false;
                await App.Database.DeleteFavouriteAsync(currentBook.Id);
            }
            else
            {
                currentBook.IsFavourite = true;
                await App.Database.SaveFavouriteAsync(currentBook.Id);
            }
        }
    }
}