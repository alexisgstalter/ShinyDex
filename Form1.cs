using Newtonsoft.Json;
using PokeApiNet;
using ShinyDex.Models;
using ShinyDex.Utils;
using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net;

namespace ShinyDex
{
    public partial class Form1 : Form
    {
        String currentGeneration = "generation-i";
        private List<WishedPokemon> pokemons = new List<WishedPokemon>();
        public Form1(List<string> pokemons)
        {
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            this.Resize += new EventHandler(Form1_Resize);
            this.Load += new EventHandler(Form1_Load);
            foreach (String pokemon in pokemons)
            {
                this.pokemons.Add(GestionSauvegarde.Charger(pokemon));
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {


        }

        //ajout d'un évènement quand on redimensionne la fenêtre
        private void Form1_Resize(object sender, EventArgs e)
        {
            RepositionPokemon();
        }

        private void Gen1_CheckedChanged(object sender, EventArgs e)
        {
            if (Gen1.Checked)
            {
                currentGeneration = "generation-i";
                DrawPokemon();
            }
        }

        private void Gen2_CheckedChanged(object sender, EventArgs e)
        {
            if (Gen2.Checked)
            {
                currentGeneration = "generation-ii";
                DrawPokemon();
            }
        }

        private void DrawPokemon()
        {
            panel1.Controls.Clear();
            panel1.Width = this.ClientSize.Width - 50;
            panel1.Height = this.ClientSize.Height - 50;
            int x = 10;
            int y = 10;
            int pictureBoxWidth = 192;
            int pictureBoxHeight = 192;
            int spacing = 120;
            int spacingX = 10;

            List<WishedPokemon> pokemons = this.pokemons.Where(p => p.Generation == currentGeneration).ToList();
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

                    //on met un évènement click sur le pictureBox
                    pictureBox.Click += (sender, e) =>
                    {
                        if (pokemon.Captured)
                        {
                            //on affiche une messagebox qui demande si on veut annuler la capture, si oui on passe le pokémon en non capturé
                            DialogResult dialogResult = MessageBox.Show("Voulez-vous annuler la capture de " + pokemon.NomFrancais + " ?", "Annuler la capture", MessageBoxButtons.YesNo);
                            if (dialogResult == DialogResult.Yes)
                            {
                                pokemon.Captured = false;
                                pokemon.Date_captured = null;
                                pokemon.NombreRencontres = 0;
                                pokemon.Location = null;
                                pokemon.Method = null;
                                pokemon.Surname = null;
                                pokemon.Version = null;
                                Label label = (Label)panel1.Controls[panel1.Controls.IndexOf(pictureBox) + 1];
                                label.Text = pokemon.NomFrancais.ToUpper();
                            }
                        }
                        else
                        {
                            //pokemon.Captured = true;
                            Capture cap = new Capture(pokemon);
                            cap.CaptureClosed += (sender, e) =>
                            {
                                DrawPokemon();
                            };
                            cap.Show();
                            this.Visible = false;
                        }
                        GestionSauvegarde.Sauvegarder(pokemon);
                        pictureBox.Image = pokemon.Captured ? Image.FromStream(new MemoryStream(pokemon.SpriteShiny)) : ImageUtils.NoirEtBlanc(Image.FromStream(new MemoryStream(pokemon.SpriteShiny)));
                        //On actualise le label juste en dessous de la picturebox avec juste le nom du pokémon


                    };
                    if (pokemon.SpriteShiny == null)
                    {
                        pokemon.SpriteShiny = webClient.DownloadData(pokemon.Pokemon.Sprites.FrontShiny == null ? this.pokemons[0].Pokemon.Sprites.FrontShiny : pokemon.Pokemon.Sprites.FrontShiny);
                        GestionSauvegarde.Sauvegarder(pokemon);
                    }
                    //On met d'abord le fonde l'image en fonction du type du pokémon
                    pictureBox.BackColor = pokemon.GetBackgroundColorForPokemon();
                    pictureBox.Image = pokemon.Captured ? Image.FromStream(new MemoryStream(pokemon.SpriteShiny)) : ImageUtils.NoirEtBlanc(Image.FromStream(new MemoryStream(pokemon.SpriteShiny)));
                    panel1.Controls.Add(pictureBox);

                    Label label = new Label();
                    label.Text = pokemon.NomFrancais.ToUpper();
                    if (pokemon.Captured)
                    {
                        label.Text += "\n" + pokemon.Surname + "\n" + pokemon.Location + "\n" + pokemon.Version + "\n" + pokemon.Date_captured + "\n" + pokemon.Method;
                    }
                    //la taille de la font est choisie pour que le label ne fasse pas plus de 192 pixels de large

                    label.Font = new Font("Arial", 8, FontStyle.Bold);
                    label.AutoSize = false;
                    label.Size = new System.Drawing.Size(pictureBoxWidth, 120); // Taille du label
                    label.MaximumSize = new System.Drawing.Size(pictureBoxWidth, 120); // Taille maximale
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

        private void panel1_Scroll(object sender, ScrollEventArgs e)
        {
            //DrawPokemon();
        }

        private void Gen3_CheckedChanged(object sender, EventArgs e)
        {
            if (Gen3.Checked)
            {
                currentGeneration = "generation-iii";
                DrawPokemon();
            }
        }

        private void Gen4_CheckedChanged(object sender, EventArgs e)
        {
            if (Gen4.Checked)
            {
                currentGeneration = "generation-iv";
                DrawPokemon();
            }

        }

        private void Gen5_CheckedChanged(object sender, EventArgs e)
        {
            if (Gen5.Checked)
            {
                currentGeneration = "generation-v";
                DrawPokemon();
            }
        }

        private void Gen6_CheckedChanged(object sender, EventArgs e)
        {
            if (Gen6.Checked)
            {
                currentGeneration = "generation-vi";
                DrawPokemon();
            }
        }

        private void Gen7_CheckedChanged(object sender, EventArgs e)
        {
            if (Gen7.Checked)
            {
                currentGeneration = "generation-vii";
                DrawPokemon();
            }
        }

        private void Gen8_CheckedChanged(object sender, EventArgs e)
        {
            if (Gen8.Checked)
            {
                currentGeneration = "generation-viii";
                DrawPokemon();
            }
        }

        private void Gen9_CheckedChanged(object sender, EventArgs e)
        {
            if (Gen9.Checked)
            {
                currentGeneration = "generation-ix";
                DrawPokemon();
            }
        }

        private void Form1_SizeChanged(object sender, EventArgs e)
        {

        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is MenuPrincipal)
                {
                    form.Visible = true;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Visible = true;
            //DrawPokemon();
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
            int spacing = 120;
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

        /*private byte[] ConvertToJpeg(byte[] imageBytes, long quality = 90L)
        {
            using (MemoryStream inputStream = new MemoryStream(imageBytes))
            using (MemoryStream outputStream = new MemoryStream())
            {
                Image image = Image.FromStream(inputStream);
                ImageCodecInfo jpegCodec = GetEncoderInfo("image/jpeg");
                EncoderParameters encoderParams = new EncoderParameters(1);
                encoderParams.Param[0] = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, quality);
                image.Save(outputStream, jpegCodec, encoderParams);
                return outputStream.ToArray();
            }
        }

        private static ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            foreach (ImageCodecInfo codec in codecs)
            {
                if (codec.MimeType == mimeType)
                {
                    return codec;
                }
            }
            return null;
        }*/
    }
}
