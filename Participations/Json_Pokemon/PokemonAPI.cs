using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Json_Pokemon
{
    public class PokemonAPI
    {
        public List<PokemonItem> results { get; set; }
    }

    public class PokemonItem
    {

        public string name { get; set; }

        public string url { get; set; }


    }
}
