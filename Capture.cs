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
    public partial class Capture : Form
    {
        private WishedPokemon pokemon;
        public event EventHandler CaptureClosed;
        private bool isCaptured = false;

        public WishedPokemon Pokemon { get => pokemon; set => pokemon = value; }

        public Capture(WishedPokemon pokemon)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Pokemon = pokemon;
            if (pokemon.Captured)
            {
                isCaptured = true;
            }
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AnnulerCapture_Click(object sender, EventArgs e)
        {
            this.Pokemon.Captured = false;
            GestionSauvegarde.Sauvegarder(this.Pokemon);
            this.Close();
        }

        private void Capture_Load(object sender, EventArgs e)
        {
            Task.Run(async () =>
            {
                this.Invoke((Action)(async () =>
                {
                    var versions = await APIUtils.GetAllVersions();
                    foreach (var version in versions)
                    {
                        Version.Items.Add(version.Name);
                    }
                }));

            });
            if (this.Pokemon.NombreRencontres != null)
            {
                Rencontres.Text = this.Pokemon.NombreRencontres.ToString();
            }
            Surnom.Text = this.Pokemon.Surname;
            Lieu.Text = this.Pokemon.Location;
            Methode.Text = this.Pokemon.Method;
            Version.SelectedItem = this.Pokemon.Version;

            if (this.Pokemon.SpriteShiny == null)
            {
                WebClient webClient = new WebClient();
                Pokemon.SpriteShiny = webClient.DownloadData(Pokemon.Pokemon.Sprites.FrontShiny == null ? GestionSauvegarde.Charger("bulbizarre").Pokemon.Sprites.FrontShiny : Pokemon.Pokemon.Sprites.FrontShiny);
                GestionSauvegarde.Sauvegarder(Pokemon);
            }
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = Image.FromStream(new MemoryStream(this.Pokemon.SpriteShiny));

        }

        private void ValiderCapture_Click(object sender, EventArgs e)
        {
            isCaptured = true;
            this.Pokemon.Captured = true;
            this.Pokemon.Date_captured = DateTime.Now;
            this.Pokemon.Location = Lieu.Text;
            this.Pokemon.NombreRencontres = int.Parse(Rencontres.Text);
            this.Pokemon.Method = Methode.Text;
            this.Pokemon.Surname = Surnom.Text;
            this.Pokemon.Version = Version.SelectedItem.ToString();
            GestionSauvegarde.Sauvegarder(this.Pokemon);
            GestionSauvegarde.SupprimerShasse("Encours/" + this.Pokemon.Pokemon.Name + ".json");
            this.Close();
        }

        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            base.OnFormClosed(e);
            if (!isCaptured)
            {
                this.Pokemon.Captured = false;
                GestionSauvegarde.Sauvegarder(this.Pokemon);

            }
            CaptureClosed?.Invoke(this, EventArgs.Empty);
        }

        private void EnleverRencontre_Click(object sender, EventArgs e)
        {
            Rencontres.Text = (int.Parse(Rencontres.Text) - 1).ToString();
        }

        private void AjouterRencontre_Click(object sender, EventArgs e)
        {
            Rencontres.Text = (int.Parse(Rencontres.Text) + 1).ToString();
        }

        private void Capture_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isCaptured)
            {
                this.Pokemon.NombreRencontres = int.Parse(Rencontres.Text);
                this.Pokemon.Surname = Surnom.Text;
                this.Pokemon.Location = Lieu.Text;
                this.Pokemon.Method = Methode.Text;
                GestionSauvegarde.Sauvegarder(this.Pokemon, "Encours");
            }

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void Capture_FormClosed(object sender, FormClosedEventArgs e)
        {
            foreach (Form form in Application.OpenForms)
            {
                if (form is Form1 || form is SelectionShasse)
                {
                    form.Visible = true;
                }
            }
        }
    }
}
