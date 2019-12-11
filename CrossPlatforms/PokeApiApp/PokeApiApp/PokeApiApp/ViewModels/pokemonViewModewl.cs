using System;
using PokeApiApp.Models;

namespace PokeApiApp.ViewModels
{
    public class pokemonViewModewl : BaseViewModel
    {
        Pokemondetail _poke;

        public Pokemondetail poke
        {
            get => _poke;
            set => SetProperty(ref _poke, value);
        }

        public pokemonViewModewl(Pokemondetail pokemon)
        {
            poke = pokemon;
        }
    }
}
