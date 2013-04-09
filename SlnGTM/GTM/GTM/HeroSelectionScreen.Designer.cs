namespace GTM
{
    partial class HeroSelectionScreen
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
            this.cmbHeroes = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cmbHeroes
            // 
            this.cmbHeroes.FormattingEnabled = true;
            this.cmbHeroes.Location = new System.Drawing.Point(84, 135);
            this.cmbHeroes.Name = "cmbHeroes";
            this.cmbHeroes.Size = new System.Drawing.Size(282, 21);
            this.cmbHeroes.TabIndex = 0;
            // 
            // HeroSelectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 310);
            this.Controls.Add(this.cmbHeroes);
            this.Name = "HeroSelectionScreen";
            this.Text = "HeroSelectionScreen";
            this.Load += new System.EventHandler(this.HeroSelectionScreen_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbHeroes;
    }
}