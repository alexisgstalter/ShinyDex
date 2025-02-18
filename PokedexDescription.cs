using Newtonsoft.Json;
using PokeApiNet;
using ShinyDex.Models;
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

namespace ShinyDex
{
    public partial class PokedexDescription : Form
    {
        private WishedPokemon pokemon;
        private PokemonSpecies species;
        public PokedexDescription(WishedPokemon pokemon)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.pokemon = pokemon;
            this.Visible = false;
            InitializeComponent();
        }

        private void PokedexDescription_Load(object sender, EventArgs e)
        {
            // Assurez-vous que le FlowLayoutPanel est visible
            ImagesPokemon.Visible = true;

            // Définir le nom du Pokémon
            NomPokemon.Text = pokemon.NomFrancais;

            // Créer et configurer le PictureBox
            Image img = Image.FromStream(new MemoryStream(pokemon.SpriteNormal));
            PictureBox pic = new PictureBox();
            pic.Image = img;
            pic.SizeMode = PictureBoxSizeMode.Zoom;
            pic.Size = new Size(128, 128);
            pic.Margin = new Padding(10); // Ajouter une marge pour l'espacement

            // Ajouter le PictureBox au FlowLayoutPanel
            ImagesPokemon.Controls.Add(pic);

            // Charger les données du Pokémon de manière asynchrone
            Task task = Task.Run(async () =>
            {
                this.species = await LoadSpeces();
                if (this.species != null)
                {
                    // Utilisez Invoke pour mettre à jour l'interface utilisateur sur le thread principal
                    this.Invoke((Action)(async () =>
                    {
                        foreach (var varieties in species.Varieties)
                        {
                            if (!varieties.IsDefault)
                            {
                                var pokeforms = await LoadForms(varieties.Pokemon.Name);
                                using (WebClient client = new WebClient())
                                {
                                    if (pokeforms.Sprites.FrontDefault != null)
                                    {
                                        byte[] sprite = client.DownloadData(pokeforms.Sprites.FrontDefault);
                                        Image imgForm = Image.FromStream(new MemoryStream(sprite));
                                        PictureBox picForm = new PictureBox();
                                        picForm.Image = imgForm;
                                        picForm.SizeMode = PictureBoxSizeMode.Zoom;
                                        picForm.Size = new Size(128, 128);
                                        picForm.Margin = new Padding(10); // Ajouter une marge pour l'espacement
                                        // Ajouter le PictureBox au FlowLayoutPanel
                                        ImagesPokemon.Controls.Add(picForm);
                                    }
                                }
                            }
                        }
                        var textes = species.FlavorTextEntries.Where(d => d.Language.Name == "fr").ToList();
                        foreach (var texte in textes)
                        {
                            var nom_jeu = await LoadVersion(texte.Version.Name);
                            string nom_version_fr = nom_jeu.Names.Where(n => n.Language.Name == "fr").FirstOrDefault()?.Name;
                            Label lbl = new Label();
                            lbl.Text += nom_version_fr + " : \n\n" + texte.FlavorText + "\n\n";
                            lbl.AutoSize = true;
                            lbl.Padding = new Padding(0, 5, 0, 5);
                            flowLayoutPanel1.Controls.Add(lbl);
                        }

                        // Ajouter les descriptions au FlowLayoutPanel

                    }));
                }
                else
                {
                    this.Invoke((Action)(() =>
                    {
                        MessageBox.Show("Erreur lors du chargement des données du Pokémon.");
                    }));
                }
                this.Visible = true;
            });


        }

        private async Task<PokemonSpecies> LoadSpeces()
        {
            using (PokeApiClient client = new PokeApiClient())
            {
                return await client.GetResourceAsync<PokemonSpecies>(this.pokemon.Pokemon.Id);
            }

        }

        private async Task<PokemonForm> LoadForms(string name)
        {
            using (PokeApiClient client = new PokeApiClient())
            {
                return await client.GetResourceAsync<PokemonForm>(name);
            }
        }

        private async Task<PokeApiNet.Version> LoadVersion(string name)
        {
            using (PokeApiClient client = new PokeApiClient())
            {
                return await client.GetResourceAsync<PokeApiNet.Version>(name);
            }
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void PokedexDescription_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Pokedex)
                {
                    form.Visible = true;
                }
            }
        }
    }
}
