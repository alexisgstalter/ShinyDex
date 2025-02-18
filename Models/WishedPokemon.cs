using PokeApiNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace ShinyDex.Models
{
    public class WishedPokemon
    {
        private Pokemon pokemon;
        private PokemonForm pokemonForm;
        private string surname;
        private bool captured = false;
        private DateTime? date_captured;
        private string location;
        private byte[] spriteShiny = null;
        private byte[] spriteNormal = null;
        private string nomFrancais;
        private string generation;
        private int nombreRencontres = 0;
        private string method;
        private string version;

        public Pokemon Pokemon { get => pokemon; set => pokemon = value; }
        public string Surname { get => surname; set => surname = value; }
        public bool Captured { get => captured; set => captured = value; }
        public DateTime? Date_captured { get => date_captured; set => date_captured = value; }
        public string Location { get => location; set => location = value; }
        public byte[] SpriteShiny { get => spriteShiny; set => spriteShiny = value; }
        public string NomFrancais { get => nomFrancais; set => nomFrancais = value; }
        public PokemonForm PokemonForm { get => pokemonForm; set => pokemonForm = value; }
        public string Generation { get => generation; set => generation = value; }
        public int NombreRencontres { get => nombreRencontres; set => nombreRencontres = value; }
        public string Method { get => method; set => method = value; }
        public byte[] SpriteNormal { get => spriteNormal; set => spriteNormal = value; }
        public string Version { get => version; set => version = value; }

        public Color GetBackgroundColorForPokemon()
        {
            return this.Pokemon.Types[0].Type.Name switch
            {
                //on va ssigner une couleur par type, dans des tons pastel un peu délavés
                "normal" => Color.FromArgb(255, 200, 200, 200),
                "fighting" => Color.FromArgb(255, 200, 100, 100),
                "flying" => Color.FromArgb(255, 200, 200, 255),
                "poison" => Color.FromArgb(255, 200, 100, 200),
                "ground" => Color.FromArgb(255, 200, 150, 100),
                "rock" => Color.FromArgb(255, 200, 200, 100),
                "bug" => Color.FromArgb(255, 150, 200, 100),
                "ghost" => Color.FromArgb(255, 100, 100, 200),
                "steel" => Color.FromArgb(255, 200, 200, 200),
                "fire" => Color.FromArgb(255, 255, 150, 100),
                "water" => Color.FromArgb(255, 100, 100, 255),
                "grass" => Color.FromArgb(255, 100, 200, 100),
                "electric" => Color.FromArgb(255, 255, 255, 100),
                "psychic" => Color.FromArgb(255, 200, 100, 200),
                "ice" => Color.FromArgb(255, 100, 200, 200),
                "dragon" => Color.FromArgb(255, 100, 50, 200),
                "dark" => Color.FromArgb(255, 100, 100, 100),
                "fairy" => Color.FromArgb(255, 255, 200, 200),
                "unknown" => Color.FromArgb(255, 200, 200, 200),
                "shadow" => Color.FromArgb(255, 100, 100, 100),
                _ => Color.FromArgb(255, 200, 200, 200),

            };
        }
    }
}
