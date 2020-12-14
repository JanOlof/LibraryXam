using LibraryXam.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LibraryXam.ViewModel
{
    public class BookViewModel: INotifyPropertyChanged
    {
        public ObservableCollection<Book> BookList { get; set; } = new ObservableCollection<Book>();

        internal async System.Threading.Tasks.Task LoadBooksAsync()
        {
                try
                {
                    string apiURL = @"http://193.10.202.70/BookApi/api/BooksSimple";
                    HttpClient httpClient = new HttpClient();
                    HttpResponseMessage response = await httpClient.GetAsync(new Uri(apiURL));

                    if (response.IsSuccessStatusCode)
                    {
                        string content = await response.Content.ReadAsStringAsync();
                        BookList = JsonConvert.DeserializeObject<ObservableCollection<Book>>(content);
                        await CheckIfIsFavourite();
                        RaisePropertyChanged("BookList");
                    }
                else
                        await Application.Current.MainPage.DisplayAlert("Error", "We are sorry, the internet connection is not available", "OK");
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert("Error", "We are sorry, the internet connection is not available. (" + ex.Message + ")", "OK");
                }
        }

        private async Task CheckIfIsFavourite()
        {
            foreach (var book in BookList)
            {
                Favourite inDB = await App.Database.IsFavouriteAsync(book.Id);
                if (inDB != null)
                    book.IsFavourite = true;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
