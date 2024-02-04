namespace arcade
{
    partial class game_mode
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
            this.computerMode = new System.Windows.Forms.Button();
            this.Muliti = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // computerMode
            // 
            this.computerMode.Location = new System.Drawing.Point(160, 39);
            this.computerMode.Name = "computerMode";
            this.computerMode.Size = new System.Drawing.Size(261, 37);
            this.computerMode.TabIndex = 0;
            this.computerMode.Text = "1 Player ";
            this.computerMode.UseVisualStyleBackColor = true;
            this.computerMode.Click += new System.EventHandler(this.computerMode_Click_1);
            // 
            // Muliti
            // 
            this.Muliti.Location = new System.Drawing.Point(160, 104);
            this.Muliti.Name = "Muliti";
            this.Muliti.Size = new System.Drawing.Size(261, 37);
            this.Muliti.TabIndex = 1;
            this.Muliti.Text = "2 Players";
            this.Muliti.UseVisualStyleBackColor = true;
            this.Muliti.Click += new System.EventHandler(this.Muliti_Click);
            // 
            // game_mode
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 201);
            this.Controls.Add(this.Muliti);
            this.Controls.Add(this.computerMode);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "game_mode";
            this.Text = "game_mode";
            this.Load += new System.EventHandler(this.game_mode_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button computerMode;
        private System.Windows.Forms.Button Muliti;
    }
}