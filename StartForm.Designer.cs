namespace RunnerGame
{
    partial class StartForm
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
            this.PLAY = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PLAY
            // 
            this.PLAY.BackColor = System.Drawing.Color.DarkGray;
            this.PLAY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PLAY.Location = new System.Drawing.Point(344, 185);
            this.PLAY.Name = "PLAY";
            this.PLAY.Size = new System.Drawing.Size(218, 118);
            this.PLAY.TabIndex = 0;
            this.PLAY.Text = "PLAY";
            this.PLAY.UseVisualStyleBackColor = false;
            this.PLAY.Click += new System.EventHandler(this.PLAY_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(202)))), ((int)(((byte)(201)))));
            this.ClientSize = new System.Drawing.Size(907, 467);
            this.Controls.Add(this.PLAY);
            this.Name = "StartForm";
            this.Text = "StartForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PLAY;
    }
}