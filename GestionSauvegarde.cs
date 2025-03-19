using PokeApiNet;
using ShinyDex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShinyDex
{
    class GestionSauvegarde
    {
        public static void Sauvegarder(WishedPokemon pokemon)
        {
            //On charge la liste des pokémons qu'ona  déjà dans notre fichier Json s'il existe
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(pokemon);
            System.IO.File.WriteAllText(pokemon.Pokemon == null ? pokemon.PokemonForm.Name + ".json" : pokemon.Pokemon.Name + ".json", json);
        }

        public static void Sauvegarder(WishedPokemon pokemon, string path)
        {
            //On charge la liste des pokémons qu'ona  déjà dans notre fichier Json s'il existe
            if(!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(pokemon);
            System.IO.File.WriteAllText(pokemon.Pokemon == null ? Path.Combine(path, pokemon.PokemonForm.Name + ".json") : Path.Combine(path, pokemon.Pokemon.Name + ".json"), json);
        }

        public static WishedPokemon Charger(string name)
        {
            if (!File.Exists(name + ".json"))
            {
                return new WishedPokemon();
            }
            string json = File.ReadAllText(name + ".json");
            WishedPokemon pokemon = Newtonsoft.Json.JsonConvert.DeserializeObject<WishedPokemon>(json);
            return pokemon;

        }

        public static WishedPokemon ChargerShasse(string path)
        {
            if (!File.Exists(path))
            {
                return new WishedPokemon();
            }
            string json = File.ReadAllText(path);
            WishedPokemon pokemon = Newtonsoft.Json.JsonConvert.DeserializeObject<WishedPokemon>(json);
            return pokemon;

        }

        public static void SupprimerShasse(string path)
        {
            if (File.Exists(path))
                File.Delete(path);
        }
    }
}
