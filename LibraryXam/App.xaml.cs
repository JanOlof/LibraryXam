using LibraryXam.Database;
using LibraryXam.ViewModel;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LibraryXam
{
    public partial class App : Application
    {
        static BookFavouritesConnection _db;
        public static BookFavouritesConnection Database
        {
            get
            {
                if (_db == null)
                {
                    _db = new BookFavouritesConnection(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Favourites.db3"));
                }
                return _db;
            }
        }

        static public BookViewModel Books { get; set; } = new BookViewModel();
        public App()
        {
            InitializeComponent();
            NavigationPage page = new NavigationPage(new MainPage());
            page.BarBackgroundColor = (Color)Application.Current.Resources["Green"];
            page.BarTextColor = (Color)Application.Current.Resources["Grey"];
            MainPage = page;
        }

        protected override async void OnStart()
        { 
            await Books.LoadBooksAsync();
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
