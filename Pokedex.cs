using ShinyDex.Models;
using ShinyDex.Utils;
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
    public partial class Pokedex : Form
    {
        private List<WishedPokemon> pokemons = new List<WishedPokemon>();
        public Pokedex(List<String> pokemons)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            //on fait en sorte que le formulaire s'affiche en plein écran par défaut
            this.WindowState = FormWindowState.Maximized;
            this.panel1 = new DoubleBufferedPanel();

            InitializeComponent();
            foreach (String pokemon in pokemons)
            {
                this.pokemons.Add(GestionSauvegarde.Charger(pokemon));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Pokedex_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            DrawPokemon();
        }

        private void DrawPokemon()
        {
            List<WishedPokemon> pokemons = this.pokemons.Where(p => p.Pokemon.IsDefault == true).ToList();
            panel1.Controls.Clear();
            panel1.Width = this.ClientSize.Width - 50;
            panel1.Height = this.ClientSize.Height - 50;
            int x = 10;
            int y = 10;
            int pictureBoxWidth = 192;
            int pictureBoxHeight = 192;
            int spacing = 20;
            int spacingX = 10;

            GestionSauvegarde gestionSauvegarde = new GestionSauvegarde();
            // on indique visuellement que la liste de pokemon charge avec une barre de chargement centrée
            ProgressBar progressBar = new ProgressBar();
            progressBar.Location = new Point(10, panel1.Height / 2 - 10);
            progressBar.Size = new Size(panel1.Width - 20, 40);
            progressBar.Maximum = pokemons.Count;
            panel1.Controls.Add(progressBar);
            panel1.SuspendLayout();
            //on bloque la possibilité d'intéragir avec le panel1 pendant le chargement
            panel1.Enabled = false;

            foreach (WishedPokemon pokemon in pokemons)
            {
                using (WebClient webClient = new WebClient())
                {
                    progressBar.Value++;
                    if (x + pictureBoxWidth > panel1.Width)
                    {
                        x = 10;
                        y += pictureBoxHeight + spacing + 20; // Ajout de 20 pixels pour le label
                    }

                    PictureBox pictureBox = new PictureBox();
                    pictureBox.Location = new Point(x, y);
                    pictureBox.Size = new Size(pictureBoxWidth, pictureBoxHeight);
                    pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;

                    if (pokemon.SpriteNormal == null)
                    {
                        pokemon.SpriteNormal = webClient.DownloadData(pokemon.Pokemon.Sprites.FrontDefault == null ? this.pokemons[0].Pokemon.Sprites.FrontDefault : pokemon.Pokemon.Sprites.FrontDefault);
                        GestionSauvegarde.Sauvegarder(pokemon);
                    }
                    //On met d'abord le fonde l'image en fonction du type du pokémon
                    pictureBox.BackColor = pokemon.GetBackgroundColorForPokemon();
                    pictureBox.Image = Image.FromStream(new MemoryStream(pokemon.SpriteNormal));
                    panel1.Controls.Add(pictureBox);

                    pictureBox.Click += (sender, e) =>
                    {
                        PokedexDescription form = new PokedexDescription(pokemon);
                        form.Show();
                        this.Visible = false;
                    };
                    Label label = new Label();
                    label.Text = pokemon.Pokemon.Id + "# " + pokemon.NomFrancais.ToUpper();

                    //la taille de la font est choisie pour que le label ne fasse pas plus de 192 pixels de large

                    label.Font = new Font("Arial", 8, FontStyle.Bold);
                    label.AutoSize = false;
                    label.Size = new System.Drawing.Size(pictureBoxWidth, 20); // Taille du label
                    label.MaximumSize = new System.Drawing.Size(pictureBoxWidth, 80); // Taille maximale
                    label.TextAlign = System.Drawing.ContentAlignment.TopCenter; // Alignement du texte
                    label.BackColor = pokemon.GetBackgroundColorForPokemon();

                    // Mesurer la taille du texte pour centrer correctement le label

                    label.Location = new Point(x, y + pictureBoxHeight);

                    panel1.Controls.Add(label);

                    x += pictureBoxWidth + spacingX;
                }
            }
            panel1.Enabled = true;
            panel1.ResumeLayout();
            progressBar.Dispose();
            panel1.AutoScroll = true;
            pokemons.Clear();
        }

        private void Pokedex_Resize(object sender, EventArgs e)
        {
            RepositionPokemon();
        }
        private void RepositionPokemon()
        {
            panel1.SuspendLayout(); // Suspendre la mise en page
            panel1.Width = this.ClientSize.Width - 50;
            panel1.Height = this.ClientSize.Height - 50;
            int x = 10;
            int y = 10;
            int pictureBoxWidth = 192;
            int pictureBoxHeight = 192;
            int spacing = 20;
            int spacingX = 10;

            foreach (Control control in panel1.Controls)
            {
                if (control is PictureBox)
                {
                    if (x + pictureBoxWidth > panel1.Width)
                    {
                        x = 10;
                        y += pictureBoxHeight + spacing + 20; // Ajout de 20 pixels pour le label
                    }

                    control.Location = new Point(x, y);
                    x += pictureBoxWidth + spacingX;
                }
                else if (control is Label)
                {
                    // Repositionner le label en fonction de la nouvelle position du PictureBox
                    PictureBox pictureBox = (PictureBox)panel1.Controls[panel1.Controls.IndexOf(control) - 1];

                    control.Location = new Point(pictureBox.Location.X, pictureBox.Location.Y + pictureBoxHeight);

                }
            }
            panel1.ResumeLayout(); // Reprendre la mise en page
        }

        private void Pokedex_ResizeEnd(object sender, EventArgs e)
        {

        }

        private void Pokedex_FormClosed(object sender, FormClosedEventArgs e)
        {
            //on cherche MenuPrincipal et on le rend visible
            foreach (Form form in Application.OpenForms)
            {
                if (form is MenuPrincipal)
                {
                    form.Visible = true;
                }
            }
        }
    }
}
