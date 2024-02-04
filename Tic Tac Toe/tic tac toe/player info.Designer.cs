namespace arcade
{
    partial class Formt2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.name2 = new System.Windows.Forms.TextBox();
            this.B_play = new System.Windows.Forms.Button();
            this.name1 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                | System.Drawing.FontStyle.Underline))));
            this.label1.Location = new System.Drawing.Point(59, 39);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Player 1 Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic)
                | System.Drawing.FontStyle.Underline))));
            this.label3.Location = new System.Drawing.Point(51, 88);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Player 2 Name";
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // name1
            // 
            this.name1.Location = new System.Drawing.Point(198, 32);
            this.name1.Name = "name1";
            this.name1.Size = new System.Drawing.Size(207, 23);
            this.name1.TabIndex = 6;
            this.name1.TextChanged += new System.EventHandler(this.name1_TextChanged);
            // 
            // name2
            // 
            this.name2.Location = new System.Drawing.Point(198, 86);
            this.name2.Name = "name2";
            this.name2.Size = new System.Drawing.Size(207, 23);
            this.name2.TabIndex = 3;
            this.name2.TextChanged += new System.EventHandler(this.name2_TextChanged_1);
            // 
            // B_play
            // 
            this.B_play.Location = new System.Drawing.Point(430, 130);
            this.B_play.Name = "B_play";
            this.B_play.Size = new System.Drawing.Size(82, 22);
            this.B_play.TabIndex = 5;
            this.B_play.Text = "Play ";
            this.B_play.UseVisualStyleBackColor = true;
            this.B_play.Click += new System.EventHandler(this.B_play_Click_1);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(552, 187);
            this.Controls.Add(this.name1);
            this.Controls.Add(this.B_play);
            this.Controls.Add(this.name2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(568, 226);
            this.MinimumSize = new System.Drawing.Size(568, 226);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Players Name";
            this.Load += new System.EventHandler(this.player_info_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox name2;
        private System.Windows.Forms.Button B_play;
        private System.Windows.Forms.TextBox name1;
    }
}