namespace ShinyDex
{
    partial class SelectionShasse
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ShasseEnCours = new ComboBox();
            label1 = new Label();
            label2 = new Label();
            NouvelleShasse = new ComboBox();
            ChargerShasse = new Button();
            ChargerPokemon = new Button();
            SupprimerShasse = new Button();
            SuspendLayout();
            // 
            // ShasseEnCours
            // 
            ShasseEnCours.Font = new Font("Segoe UI", 25F);
            ShasseEnCours.FormattingEnabled = true;
            ShasseEnCours.Location = new Point(292, 32);
            ShasseEnCours.Name = "ShasseEnCours";
            ShasseEnCours.Size = new Size(259, 53);
            ShasseEnCours.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 25F);
            label1.Location = new Point(10, 35);
            label1.Name = "label1";
            label1.Size = new Size(256, 46);
            label1.TabIndex = 1;
            label1.Text = "Shasse en cours";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 25F);
            label2.Location = new Point(10, 187);
            label2.Name = "label2";
            label2.Size = new Size(257, 46);
            label2.TabIndex = 2;
            label2.Text = "Nouvelle shasse";
            // 
            // NouvelleShasse
            // 
            NouvelleShasse.AutoCompleteMode = AutoCompleteMode.Suggest;
            NouvelleShasse.Font = new Font("Segoe UI", 25F);
            NouvelleShasse.FormattingEnabled = true;
            NouvelleShasse.Location = new Point(292, 184);
            NouvelleShasse.Name = "NouvelleShasse";
            NouvelleShasse.Size = new Size(259, 53);
            NouvelleShasse.TabIndex = 3;
            // 
            // ChargerShasse
            // 
            ChargerShasse.Font = new Font("Segoe UI", 25F);
            ChargerShasse.Location = new Point(557, 32);
            ChargerShasse.Name = "ChargerShasse";
            ChargerShasse.Size = new Size(231, 54);
            ChargerShasse.TabIndex = 4;
            ChargerShasse.Text = "Commencer";
            ChargerShasse.UseVisualStyleBackColor = true;
            ChargerShasse.Click += ChargerShasse_Click;
            // 
            // ChargerPokemon
            // 
            ChargerPokemon.Font = new Font("Segoe UI", 25F);
            ChargerPokemon.Location = new Point(557, 183);
            ChargerPokemon.Name = "ChargerPokemon";
            ChargerPokemon.Size = new Size(231, 54);
            ChargerPokemon.TabIndex = 5;
            ChargerPokemon.Text = "Commencer";
            ChargerPokemon.UseVisualStyleBackColor = true;
            ChargerPokemon.Click += ChargerPokemon_Click;
            // 
            // SupprimerShasse
            // 
            SupprimerShasse.Font = new Font("Segoe UI", 25F);
            SupprimerShasse.Location = new Point(557, 92);
            SupprimerShasse.Name = "SupprimerShasse";
            SupprimerShasse.Size = new Size(231, 54);
            SupprimerShasse.TabIndex = 6;
            SupprimerShasse.Text = "Supprimer";
            SupprimerShasse.UseVisualStyleBackColor = true;
            SupprimerShasse.Click += SupprimerShasse_Click;
            // 
            // SelectionShasse
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(SupprimerShasse);
            Controls.Add(ChargerPokemon);
            Controls.Add(ChargerShasse);
            Controls.Add(NouvelleShasse);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(ShasseEnCours);
            Name = "SelectionShasse";
            Text = "SelectionShasse";
            FormClosed += SelectionShasse_FormClosed;
            Load += SelectionShasse_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox ShasseEnCours;
        private Label label1;
        private Label label2;
        private ComboBox NouvelleShasse;
        private Button ChargerShasse;
        private Button ChargerPokemon;
        private Button SupprimerShasse;
    }
}