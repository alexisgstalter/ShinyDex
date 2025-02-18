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

    public partial class SelectionShasse : Form
    {
        private static string path = "Encours";
        public List<WishedPokemon> WishedPokemons = new List<WishedPokemon>();
        public SelectionShasse(List<string> wishedPokemons)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            InitializeComponent();
            foreach (var pokemon in wishedPokemons)
            {
                this.WishedPokemons.Add(GestionSauvegarde.Charger(pokemon));
            }
        }

        private void SelectionShasse_Load(object sender, EventArgs e)
        {
            //On alimente NouvelleShasse avec les pokémons souhaités
            foreach (var pokemon in WishedPokemons)
            {
                NouvelleShasse.Items.Add(pokemon.NomFrancais);
            }
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            List<FileInfo> files = new DirectoryInfo(path).EnumerateFiles().ToList();
            foreach (var file in files)
            {
                WishedPokemon pokemon = GestionSauvegarde.ChargerShasse(file.FullName);
                ShasseEnCours.Items.Add(pokemon.NomFrancais);
            }
        }

        private void ChargerPokemon_Click(object sender, EventArgs e)
        {
            WishedPokemon pokemon = WishedPokemons.Where(p => p.NomFrancais == NouvelleShasse.SelectedItem.ToString()).FirstOrDefault();
            //pokemon = GestionSauvegarde.Charger(pokemon.Pokemon.Name);
            pokemon.NombreRencontres = 0;
            GestionSauvegarde.Sauvegarder(pokemon, path);
            Capture form = new Capture(pokemon);
            form.CaptureClosed += (sender, e) =>
            {
                //on récupère le pokémon courant du form Capture
                WishedPokemon p = ((Capture)sender).Pokemon;
                if (!pokemon.Captured)
                {
                    if (!ShasseEnCours.Items.Contains(p.NomFrancais))
                    {
                        ShasseEnCours.Items.Add(p.NomFrancais);
                    }
                }
            };
            form.Show();
            this.Visible = false;
        }

        private void ChargerShasse_Click(object sender, EventArgs e)
        {
            WishedPokemon pokemon = WishedPokemons.Where(p => p.NomFrancais == ShasseEnCours.SelectedItem.ToString()).FirstOrDefault();
            pokemon = GestionSauvegarde.ChargerShasse(path + "/" + pokemon.Pokemon.Name + ".json");
            GestionSauvegarde.Sauvegarder(pokemon, path);
            Capture form = new Capture(pokemon);
            form.CaptureClosed += (sender, e) =>
            {
                //on récupère le pokémon courant du form Capture
                WishedPokemon p = ((Capture)sender).Pokemon;
                if (!pokemon.Captured)
                {
                    if (!ShasseEnCours.Items.Contains(p.NomFrancais))
                    {
                        ShasseEnCours.Items.Add(p.NomFrancais);
                    }
                }
            };
            form.Show();
            this.Visible = false;
        }

        private void SupprimerShasse_Click(object sender, EventArgs e)
        {
            GestionSauvegarde.SupprimerShasse(path + "/" + WishedPokemons.Where(p => p.NomFrancais == ShasseEnCours.SelectedItem.ToString()).FirstOrDefault().Pokemon.Name + ".json");
            ShasseEnCours.Items.Remove(ShasseEnCours.SelectedItem);
        }

        private void SelectionShasse_FormClosed(object sender, FormClosedEventArgs e)
        {
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
