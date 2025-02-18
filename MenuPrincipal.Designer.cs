namespace ShinyDex
{
    partial class MenuPrincipal
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
            ShinyDex = new Button();
            Shasser = new Button();
            Pokedex = new Button();
            button1 = new Button();
            SuspendLayout();
            // 
            // ShinyDex
            // 
            ShinyDex.Font = new Font("Segoe UI", 30F);
            ShinyDex.Location = new Point(324, 91);
            ShinyDex.Name = "ShinyDex";
            ShinyDex.Size = new Size(210, 64);
            ShinyDex.TabIndex = 0;
            ShinyDex.Text = "ShinyDex";
            ShinyDex.UseVisualStyleBackColor = true;
            ShinyDex.Click += ShinyDex_Click;
            // 
            // Shasser
            // 
            Shasser.Font = new Font("Segoe UI", 30F);
            Shasser.Location = new Point(324, 170);
            Shasser.Name = "Shasser";
            Shasser.Size = new Size(210, 64);
            Shasser.TabIndex = 1;
            Shasser.Text = "Shasser";
            Shasser.UseVisualStyleBackColor = true;
            Shasser.Click += Shasser_Click;
            // 
            // Pokedex
            // 
            Pokedex.Font = new Font("Segoe UI", 30F);
            Pokedex.Location = new Point(324, 12);
            Pokedex.Name = "Pokedex";
            Pokedex.Size = new Size(210, 64);
            Pokedex.TabIndex = 2;
            Pokedex.Text = "Pokedex";
            Pokedex.UseVisualStyleBackColor = true;
            Pokedex.Click += Pokedex_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI", 30F);
            button1.Location = new Point(626, 749);
            button1.Name = "button1";
            button1.Size = new Size(210, 64);
            button1.TabIndex = 3;
            button1.Text = "Quitter";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // MenuPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(848, 825);
            Controls.Add(button1);
            Controls.Add(Pokedex);
            Controls.Add(Shasser);
            Controls.Add(ShinyDex);
            Name = "MenuPrincipal";
            Text = "MenuPrincipal";
            FormClosed += MenuPrincipal_FormClosed;
            Load += MenuPrincipal_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button ShinyDex;
        private Button Shasser;
        private Button Pokedex;
        private Button button1;
    }
}