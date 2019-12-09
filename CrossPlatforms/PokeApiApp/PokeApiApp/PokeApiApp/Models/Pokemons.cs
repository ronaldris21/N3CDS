using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;


namespace PokeApiApp.Models
{
    public class Result  : MvvmHelpers.ObservableObject
    {
        private string _name;
        private string _url;
        private string _image;


        public string name { get; set; }
        public string url
        {
            get => _url;
            set
            {
                SetProperty(ref _url, value);

                string[] UrlSplit = url.Split('/');
                image = $"https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/{ UrlSplit[UrlSplit.Length - 2]}.png";
                OnPropertyChanged("image");
            }
        }
        [JsonIgnore]
        public string image
        {
            get => _image;
            set => SetProperty(ref _image, value);
        }
        
    }

    public class Pokemons
    {
        public int count { get; set; }
        public string next { get; set; }
        public object previous { get; set; }
        public List<Result> results { get; set; }
    }
}
