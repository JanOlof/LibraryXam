using LibraryXam.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LibraryXam.Database
{
    public class BookFavouritesConnection
    {
        readonly SQLiteAsyncConnection _database;
        public BookFavouritesConnection(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Favourite>().Wait();
        }

        //Create
        public async Task<int> SaveFavouriteAsync(int bookId)
        {
            //Check if it alread exists
            Favourite favourite = await _database.Table<Favourite>().Where(i => i.BookId == bookId).FirstOrDefaultAsync();

            if (favourite == null)
                return await _database.InsertAsync(new Favourite { BookId = bookId });
            else
                return favourite.Id;
        }

        //Read
        public async Task<Favourite> IsFavouriteAsync(int bookId)
        {
            return await _database.Table<Favourite>().Where(i => i.BookId == bookId).FirstOrDefaultAsync();
        }

        //Delete
        public async Task<int?> DeleteFavouriteAsync(int bookId)
        {
            //Check if it exists
            Favourite favourite = await _database.Table<Favourite>().Where(i => i.BookId == bookId).FirstOrDefaultAsync();

            if (favourite == null)
                return null;
            else
                return await _database.DeleteAsync(favourite);
        }

    }
}
