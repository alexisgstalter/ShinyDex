using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokeApiNet;
using System.Diagnostics;
using ShinyDex.Models;

namespace ShinyDex
{
    public partial class Chargement : Form
    {
        public Chargement()
        {
            this.StartPosition = FormStartPosition.CenterScreen;

            InitializeComponent();
        }

        private void Chargement_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            ChargerPokemon();
        }
        static string GetEstimatedGeneration(string formName, string baseGeneration)
        {
            if (formName.Contains("-mega")) return "generation-vi"; // Méga-évolutions = Gen 6
            if (formName.Contains("-gmax")) return "generation-viii"; // Gigamax = Gen 8
            if (formName.Contains("-alola")) return "generation-vii"; // Formes Alola = Gen 7
            if (formName.Contains("-galar")) return "generation-viii"; // Formes Galar = Gen 8
            if (formName.Contains("-hisui")) return "generation-viii"; // Formes Hisui = Gen 8
            if (formName.Contains("-paldea")) return "generation-ix"; // Formes Paldea = Gen 9

            return baseGeneration; // Sinon, on garde la génération de base
        }
        private async Task ChargerPokemon()
        {
            using (HttpClient httpClient = new HttpClient())
            {
                string json = await httpClient.GetStringAsync("https://pokeapi.co/api/v2/pokemon?limit=20000");
                var all_pokemon = JsonConvert.DeserializeObject<dynamic>(json);

                int nbr_pokemon = 0;
                if (all_pokemon?.results != null)
                {
                    foreach (var pokemon in all_pokemon.results)
                    {
                        if (pokemon.name != null)
                        {
                            nbr_pokemon++;
                        }
                    }
                }

                progressBar1.Maximum = nbr_pokemon;
                List<string> pokemons = new List<string>();


                if (all_pokemon?.results != null)
                {
                    foreach (var pokemon in all_pokemon.results)
                    {

                        try
                        {
                            using (var PokeApiClient = new PokeApiClient())
                            {
                                WishedPokemon match = GestionSauvegarde.Charger((string)pokemon.name);
                                if (match.Pokemon == null)
                                {
                                    if (pokemon.name != null)
                                    {
                                        var pokemon_details = await PokeApiClient.GetResourceAsync<Pokemon>((string)pokemon.name);
                                        int id = pokemon_details.Id;
                                        if (pokemon_details.IsDefault)
                                        {
                                            progressBar1.Value++;
                                            var pokemon_species = await PokeApiClient.GetResourceAsync<PokemonSpecies>(id);
                                            WishedPokemon wishedPokemon = new WishedPokemon();

                                            wishedPokemon.Pokemon = pokemon_details;
                                            wishedPokemon.NomFrancais = pokemon_species.Names.Where(n => n.Language.Name == "fr").FirstOrDefault()?.Name;
                                            wishedPokemon.Generation = pokemon_species.Generation.Name;
                                            pokemons.Add(wishedPokemon.Pokemon.Name);
                                            GestionSauvegarde.Sauvegarder(wishedPokemon);

                                            //On parcours les variétés de ce pokémon pour les sauvegarder
                                            foreach (var variety in pokemon_species.Varieties.Where(v => v.IsDefault == false))
                                            {
                                                progressBar1.Value++;
                                                var pokemon_infos = await PokeApiClient.GetResourceAsync<Pokemon>(variety.Pokemon);
                                                var pokemon_form = await PokeApiClient.GetResourceAsync<PokemonForm>(variety.Pokemon.Name);
                                                WishedPokemon wishedPokemonVariety = new WishedPokemon();
                                                wishedPokemonVariety.Pokemon = pokemon_infos;
                                                wishedPokemonVariety.NomFrancais = pokemon_form.Names.Where(n => n.Language.Name == "fr").FirstOrDefault()?.Name;
                                                wishedPokemonVariety.Generation = pokemon_species.Generation.Name;
                                                pokemons.Add(wishedPokemonVariety.Pokemon.Name);
                                                GestionSauvegarde.Sauvegarder(wishedPokemonVariety);
                                            }
                                        }

                                    }
                                }
                                else
                                {
                                    pokemons.Add(match.Pokemon.Name);
                                }
                            }

                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"{ex.Message} : {pokemon}");
                        }
                    }
                }

                MenuPrincipal form1 = new MenuPrincipal(pokemons);
                form1.Show();
                this.Hide();
            }

        }

    }
}
