using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace LibraryXam.Model
{
    public class Book : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string ISBN { get; set; }
        public string ImageLink { get; set; }
        public string Description { get; set; }
        public Shelf Shelf { get; set; }
        public List<Author> Authors { get; set; }
        
        private string _starImage = "yellowstargrey.png";
        public string StarImage
        {
            get { return _starImage; }
            set 
            { 
                if(value != _starImage)
                { 
                    _starImage = value;
                    RaisePropertyChanged("StarImage");
                }
            }
        }

        private bool _isFavourite;

        public bool IsFavourite
        {
            get { return _isFavourite; }
            set 
            {
                if (value == true)
                    StarImage = "yellowstargold.png"; 
                else
                    StarImage = "yellowstargrey.png";
                
                _isFavourite = value; 
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
