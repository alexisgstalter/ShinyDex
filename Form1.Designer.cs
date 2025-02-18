namespace ShinyDex
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Gen1 = new RadioButton();
            Gen2 = new RadioButton();
            panel1 = new Panel();
            Gen3 = new RadioButton();
            Gen4 = new RadioButton();
            Gen5 = new RadioButton();
            Gen6 = new RadioButton();
            Gen7 = new RadioButton();
            Gen8 = new RadioButton();
            Gen9 = new RadioButton();
            SuspendLayout();
            // 
            // Gen1
            // 
            Gen1.AutoSize = true;
            Gen1.Location = new Point(12, 12);
            Gen1.Name = "Gen1";
            Gen1.RightToLeft = RightToLeft.Yes;
            Gen1.Size = new Size(55, 19);
            Gen1.TabIndex = 0;
            Gen1.TabStop = true;
            Gen1.Text = "Gen 1";
            Gen1.UseVisualStyleBackColor = true;
            Gen1.CheckedChanged += Gen1_CheckedChanged;
            // 
            // Gen2
            // 
            Gen2.AutoSize = true;
            Gen2.Location = new Point(73, 12);
            Gen2.Name = "Gen2";
            Gen2.RightToLeft = RightToLeft.Yes;
            Gen2.Size = new Size(55, 19);
            Gen2.TabIndex = 1;
            Gen2.TabStop = true;
            Gen2.Text = "Gen 2";
            Gen2.UseVisualStyleBackColor = true;
            Gen2.CheckedChanged += Gen2_CheckedChanged;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Location = new Point(12, 58);
            panel1.Name = "panel1";
            panel1.Size = new Size(776, 851);
            panel1.TabIndex = 2;
            panel1.Scroll += panel1_Scroll;
            panel1.Paint += panel1_Paint;
            // 
            // Gen3
            // 
            Gen3.AutoSize = true;
            Gen3.Location = new Point(134, 12);
            Gen3.Name = "Gen3";
            Gen3.RightToLeft = RightToLeft.Yes;
            Gen3.Size = new Size(55, 19);
            Gen3.TabIndex = 3;
            Gen3.TabStop = true;
            Gen3.Text = "Gen 3";
            Gen3.UseVisualStyleBackColor = true;
            Gen3.CheckedChanged += Gen3_CheckedChanged;
            // 
            // Gen4
            // 
            Gen4.AutoSize = true;
            Gen4.Location = new Point(195, 12);
            Gen4.Name = "Gen4";
            Gen4.RightToLeft = RightToLeft.Yes;
            Gen4.Size = new Size(55, 19);
            Gen4.TabIndex = 4;
            Gen4.TabStop = true;
            Gen4.Text = "Gen 4";
            Gen4.UseVisualStyleBackColor = true;
            Gen4.CheckedChanged += Gen4_CheckedChanged;
            // 
            // Gen5
            // 
            Gen5.AutoSize = true;
            Gen5.Location = new Point(256, 12);
            Gen5.Name = "Gen5";
            Gen5.RightToLeft = RightToLeft.Yes;
            Gen5.Size = new Size(55, 19);
            Gen5.TabIndex = 5;
            Gen5.TabStop = true;
            Gen5.Text = "Gen 5";
            Gen5.UseVisualStyleBackColor = true;
            Gen5.CheckedChanged += Gen5_CheckedChanged;
            // 
            // Gen6
            // 
            Gen6.AutoSize = true;
            Gen6.Location = new Point(317, 12);
            Gen6.Name = "Gen6";
            Gen6.RightToLeft = RightToLeft.Yes;
            Gen6.Size = new Size(55, 19);
            Gen6.TabIndex = 6;
            Gen6.TabStop = true;
            Gen6.Text = "Gen 6";
            Gen6.UseVisualStyleBackColor = true;
            Gen6.CheckedChanged += Gen6_CheckedChanged;
            // 
            // Gen7
            // 
            Gen7.AutoSize = true;
            Gen7.Location = new Point(378, 12);
            Gen7.Name = "Gen7";
            Gen7.RightToLeft = RightToLeft.Yes;
            Gen7.Size = new Size(55, 19);
            Gen7.TabIndex = 7;
            Gen7.TabStop = true;
            Gen7.Text = "Gen 7";
            Gen7.UseVisualStyleBackColor = true;
            Gen7.CheckedChanged += Gen7_CheckedChanged;
            // 
            // Gen8
            // 
            Gen8.AutoSize = true;
            Gen8.Location = new Point(439, 12);
            Gen8.Name = "Gen8";
            Gen8.RightToLeft = RightToLeft.Yes;
            Gen8.Size = new Size(55, 19);
            Gen8.TabIndex = 8;
            Gen8.TabStop = true;
            Gen8.Text = "Gen 8";
            Gen8.UseVisualStyleBackColor = true;
            Gen8.CheckedChanged += Gen8_CheckedChanged;
            // 
            // Gen9
            // 
            Gen9.AutoSize = true;
            Gen9.Location = new Point(500, 12);
            Gen9.Name = "Gen9";
            Gen9.RightToLeft = RightToLeft.Yes;
            Gen9.Size = new Size(55, 19);
            Gen9.TabIndex = 9;
            Gen9.TabStop = true;
            Gen9.Text = "Gen 9";
            Gen9.UseVisualStyleBackColor = true;
            Gen9.CheckedChanged += Gen9_CheckedChanged;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 921);
            Controls.Add(Gen9);
            Controls.Add(Gen8);
            Controls.Add(Gen7);
            Controls.Add(Gen6);
            Controls.Add(Gen5);
            Controls.Add(Gen4);
            Controls.Add(Gen3);
            Controls.Add(panel1);
            Controls.Add(Gen2);
            Controls.Add(Gen1);
            Name = "Form1";
            Text = "Form1";
            FormClosed += Form1_FormClosed;
            Load += Form1_Load;
            SizeChanged += Form1_SizeChanged;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private RadioButton Gen1;
        private RadioButton Gen2;
        private Panel panel1;
        private RadioButton Gen3;
        private RadioButton Gen4;
        private RadioButton Gen5;
        private RadioButton Gen6;
        private RadioButton Gen7;
        private RadioButton Gen8;
        private RadioButton Gen9;
    }
}
