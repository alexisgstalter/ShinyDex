namespace ShinyDex
{
    partial class PokedexDescription
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
            NomPokemon = new Label();
            flowLayoutPanel1 = new FlowLayoutPanel();
            ImagesPokemon = new FlowLayoutPanel();
            SuspendLayout();
            // 
            // NomPokemon
            // 
            NomPokemon.Font = new Font("Segoe UI", 25F);
            NomPokemon.Location = new Point(12, 9);
            NomPokemon.Name = "NomPokemon";
            NomPokemon.Size = new Size(380, 58);
            NomPokemon.TabIndex = 0;
            NomPokemon.Text = "Pickachu";
            NomPokemon.TextAlign = ContentAlignment.TopCenter;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanel1.Location = new Point(12, 217);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(380, 690);
            flowLayoutPanel1.TabIndex = 2;
            flowLayoutPanel1.WrapContents = false;
            flowLayoutPanel1.Paint += flowLayoutPanel1_Paint;
            // 
            // ImagesPokemon
            // 
            ImagesPokemon.AutoScroll = true;
            ImagesPokemon.Location = new Point(12, 63);
            ImagesPokemon.Name = "ImagesPokemon";
            ImagesPokemon.Size = new Size(380, 148);
            ImagesPokemon.TabIndex = 0;
            ImagesPokemon.WrapContents = false;
            // 
            // PokedexDescription
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1563, 932);
            Controls.Add(ImagesPokemon);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(NomPokemon);
            Name = "PokedexDescription";
            Text = "PokedexDescription";
            FormClosed += PokedexDescription_FormClosed;
            Load += PokedexDescription_Load;
            ResumeLayout(false);
        }

        #endregion

        private Label NomPokemon;
        private FlowLayoutPanel flowLayoutPanel1;
        private FlowLayoutPanel ImagesPokemon;
    }
}