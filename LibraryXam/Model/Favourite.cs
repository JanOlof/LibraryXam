using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryXam.Model
{
    public class Favourite
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int BookId { get; set; }
    }
}
