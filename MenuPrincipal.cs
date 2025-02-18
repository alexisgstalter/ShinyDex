using ShinyDex.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ShinyDex
{
    public partial class MenuPrincipal : Form
    {
        private PictureBox backgroundPictureBox;
        public List<string> WishedPokemons;
        public MenuPrincipal(List<string> pokemon)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            backgroundPictureBox = new PictureBox();
            backgroundPictureBox.Dock = DockStyle.Fill;
            backgroundPictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            backgroundPictureBox.Image = Image.FromFile("Assets/Images/oiseaux.gif"); // Remplacez par le chemin de votre GIF
            this.Controls.Add(backgroundPictureBox);
            backgroundPictureBox.SendToBack();
            this.WishedPokemons = pokemon;

        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            // Démarrer le Timer

        }

        private void ShinyDex_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1(WishedPokemons);
            form.Show();
            this.Visible = false;
        }

        private void MenuPrincipal_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (Application.OpenForms.Cast<Form>().All(f => !f.Visible))
            {
                Application.Exit();
            }
        }

        private void Shasser_Click(object sender, EventArgs e)
        {
            SelectionShasse form = new SelectionShasse(WishedPokemons);
            form.Show();
            this.Visible = false;
        }

        private void Pokedex_Click(object sender, EventArgs e)
        {
            Pokedex form = new Pokedex(WishedPokemons);
            form.Show();
            this.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
