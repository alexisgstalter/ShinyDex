namespace ShinyDex
{
    partial class Capture
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            Surnom = new TextBox();
            Lieu = new TextBox();
            Methode = new TextBox();
            Rencontres = new TextBox();
            ValiderCapture = new Button();
            AnnulerCapture = new Button();
            pictureBox1 = new PictureBox();
            EnleverRencontre = new Button();
            AjouterRencontre = new Button();
            lblversion = new Label();
            Version = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.Control;
            label1.Font = new Font("Segoe UI", 25F);
            label1.ForeColor = SystemColors.ControlText;
            label1.Location = new Point(12, 28);
            label1.Name = "label1";
            label1.Size = new Size(137, 46);
            label1.TabIndex = 0;
            label1.Text = "Surnom";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 25F);
            label2.ForeColor = SystemColors.ControlText;
            label2.Location = new Point(12, 95);
            label2.Name = "label2";
            label2.Size = new Size(81, 46);
            label2.TabIndex = 1;
            label2.Text = "Lieu";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.Control;
            label3.Font = new Font("Segoe UI", 25F);
            label3.ForeColor = SystemColors.ControlText;
            label3.Location = new Point(12, 237);
            label3.Name = "label3";
            label3.Size = new Size(158, 46);
            label3.TabIndex = 2;
            label3.Text = "Méthode";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.Control;
            label4.Font = new Font("Segoe UI", 25F);
            label4.ForeColor = SystemColors.ControlText;
            label4.Location = new Point(1036, 286);
            label4.Name = "label4";
            label4.Size = new Size(360, 46);
            label4.TabIndex = 3;
            label4.Text = "Nombre de rencontres";
            // 
            // Surnom
            // 
            Surnom.Font = new Font("Segoe UI", 25F);
            Surnom.Location = new Point(422, 28);
            Surnom.Name = "Surnom";
            Surnom.Size = new Size(353, 52);
            Surnom.TabIndex = 4;
            // 
            // Lieu
            // 
            Lieu.Font = new Font("Segoe UI", 25F);
            Lieu.Location = new Point(422, 95);
            Lieu.Name = "Lieu";
            Lieu.Size = new Size(353, 52);
            Lieu.TabIndex = 5;
            // 
            // Methode
            // 
            Methode.Font = new Font("Segoe UI", 25F);
            Methode.Location = new Point(422, 231);
            Methode.Name = "Methode";
            Methode.Size = new Size(353, 52);
            Methode.TabIndex = 6;
            // 
            // Rencontres
            // 
            Rencontres.Font = new Font("Segoe UI", 25F);
            Rencontres.Location = new Point(1036, 231);
            Rencontres.Name = "Rencontres";
            Rencontres.Size = new Size(353, 52);
            Rencontres.TabIndex = 7;
            // 
            // ValiderCapture
            // 
            ValiderCapture.Font = new Font("Segoe UI", 25F);
            ValiderCapture.Location = new Point(12, 337);
            ValiderCapture.Name = "ValiderCapture";
            ValiderCapture.Size = new Size(376, 56);
            ValiderCapture.TabIndex = 8;
            ValiderCapture.Text = "Confirmer la capture";
            ValiderCapture.UseVisualStyleBackColor = true;
            ValiderCapture.Click += ValiderCapture_Click;
            // 
            // AnnulerCapture
            // 
            AnnulerCapture.Font = new Font("Segoe UI", 25F);
            AnnulerCapture.Location = new Point(399, 337);
            AnnulerCapture.Name = "AnnulerCapture";
            AnnulerCapture.Size = new Size(376, 56);
            AnnulerCapture.TabIndex = 9;
            AnnulerCapture.Text = "Annuler";
            AnnulerCapture.UseVisualStyleBackColor = true;
            AnnulerCapture.Click += AnnulerCapture_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(1151, 65);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(128, 128);
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // EnleverRencontre
            // 
            EnleverRencontre.Font = new Font("Segoe UI", 25F);
            EnleverRencontre.Location = new Point(975, 231);
            EnleverRencontre.Name = "EnleverRencontre";
            EnleverRencontre.Size = new Size(55, 52);
            EnleverRencontre.TabIndex = 11;
            EnleverRencontre.Text = "-";
            EnleverRencontre.UseVisualStyleBackColor = true;
            EnleverRencontre.Click += EnleverRencontre_Click;
            // 
            // AjouterRencontre
            // 
            AjouterRencontre.Font = new Font("Segoe UI", 25F);
            AjouterRencontre.Location = new Point(1395, 231);
            AjouterRencontre.Name = "AjouterRencontre";
            AjouterRencontre.Size = new Size(59, 52);
            AjouterRencontre.TabIndex = 12;
            AjouterRencontre.Text = "+";
            AjouterRencontre.UseVisualStyleBackColor = true;
            AjouterRencontre.Click += AjouterRencontre_Click;
            // 
            // lblversion
            // 
            lblversion.AutoSize = true;
            lblversion.BackColor = SystemColors.Control;
            lblversion.Font = new Font("Segoe UI", 25F);
            lblversion.ForeColor = SystemColors.ControlText;
            lblversion.Location = new Point(12, 164);
            lblversion.Name = "lblversion";
            lblversion.Size = new Size(130, 46);
            lblversion.TabIndex = 13;
            lblversion.Text = "Version";
            lblversion.Click += label5_Click;
            // 
            // Version
            // 
            Version.Font = new Font("Segoe UI", 25F);
            Version.FormattingEnabled = true;
            Version.Location = new Point(422, 164);
            Version.Name = "Version";
            Version.Size = new Size(353, 53);
            Version.TabIndex = 14;
            // 
            // Capture
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1545, 450);
            Controls.Add(Version);
            Controls.Add(lblversion);
            Controls.Add(AjouterRencontre);
            Controls.Add(EnleverRencontre);
            Controls.Add(pictureBox1);
            Controls.Add(AnnulerCapture);
            Controls.Add(ValiderCapture);
            Controls.Add(Rencontres);
            Controls.Add(Methode);
            Controls.Add(Lieu);
            Controls.Add(Surnom);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "Capture";
            Text = "Capture";
            FormClosing += Capture_FormClosing;
            FormClosed += Capture_FormClosed;
            Load += Capture_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox Surnom;
        private TextBox Lieu;
        private TextBox Methode;
        private TextBox Rencontres;
        private Button ValiderCapture;
        private Button AnnulerCapture;
        private PictureBox pictureBox1;
        private Button EnleverRencontre;
        private Button AjouterRencontre;
        private Label lblversion;
        private ComboBox Version;
    }
}