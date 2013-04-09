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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cmbR1 = new System.Windows.Forms.ComboBox();
            this.cmbR2 = new System.Windows.Forms.ComboBox();
            this.cmbR3 = new System.Windows.Forms.ComboBox();
            this.cmbB1 = new System.Windows.Forms.ComboBox();
            this.cmbB2 = new System.Windows.Forms.ComboBox();
            this.cmbB3 = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(46, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Red Team";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(494, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Blue Team";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Player R1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 110);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Player R2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 170);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 13);
            this.label5.TabIndex = 5;
            this.label5.Text = "Player R3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(565, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Player B1";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(566, 110);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(52, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "Player B2";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(565, 170);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 13);
            this.label8.TabIndex = 8;
            this.label8.Text = "Player B3";
            // 
            // cmbR1
            // 
            this.cmbR1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbR1.Location = new System.Drawing.Point(12, 69);
            this.cmbR1.Name = "cmbR1";
            this.cmbR1.Size = new System.Drawing.Size(224, 21);
            this.cmbR1.TabIndex = 9;
            this.cmbR1.SelectedIndexChanged += new System.EventHandler(this.CheckAllValuesSelected);
            // 
            // cmbR2
            // 
            this.cmbR2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbR2.FormattingEnabled = true;
            this.cmbR2.Location = new System.Drawing.Point(12, 126);
            this.cmbR2.Name = "cmbR2";
            this.cmbR2.Size = new System.Drawing.Size(224, 21);
            this.cmbR2.TabIndex = 10;
            this.cmbR2.SelectedIndexChanged += new System.EventHandler(this.CheckAllValuesSelected);
            // 
            // cmbR3
            // 
            this.cmbR3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbR3.FormattingEnabled = true;
            this.cmbR3.Location = new System.Drawing.Point(12, 186);
            this.cmbR3.Name = "cmbR3";
            this.cmbR3.Size = new System.Drawing.Size(224, 21);
            this.cmbR3.TabIndex = 11;
            this.cmbR3.SelectedIndexChanged += new System.EventHandler(this.CheckAllValuesSelected);
            // 
            // cmbB1
            // 
            this.cmbB1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbB1.FormattingEnabled = true;
            this.cmbB1.Location = new System.Drawing.Point(394, 69);
            this.cmbB1.Name = "cmbB1";
            this.cmbB1.Size = new System.Drawing.Size(224, 21);
            this.cmbB1.TabIndex = 12;
            this.cmbB1.SelectedIndexChanged += new System.EventHandler(this.CheckAllValuesSelected);
            // 
            // cmbB2
            // 
            this.cmbB2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbB2.FormattingEnabled = true;
            this.cmbB2.Location = new System.Drawing.Point(394, 126);
            this.cmbB2.Name = "cmbB2";
            this.cmbB2.Size = new System.Drawing.Size(224, 21);
            this.cmbB2.TabIndex = 13;
            this.cmbB2.SelectedIndexChanged += new System.EventHandler(this.CheckAllValuesSelected);
            // 
            // cmbB3
            // 
            this.cmbB3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbB3.FormattingEnabled = true;
            this.cmbB3.Location = new System.Drawing.Point(394, 186);
            this.cmbB3.Name = "cmbB3";
            this.cmbB3.Size = new System.Drawing.Size(224, 21);
            this.cmbB3.TabIndex = 14;
            this.cmbB3.SelectedIndexChanged += new System.EventHandler(this.CheckAllValuesSelected);
            // 
            // HeroSelectionScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(630, 307);
            this.Controls.Add(this.cmbB3);
            this.Controls.Add(this.cmbB2);
            this.Controls.Add(this.cmbB1);
            this.Controls.Add(this.cmbR3);
            this.Controls.Add(this.cmbR2);
            this.Controls.Add(this.cmbR1);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "HeroSelectionScreen";
            this.Text = "HeroSelectionScreen";
            this.Load += new System.EventHandler(this.HeroSelectionScreen_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmbR2;
        private System.Windows.Forms.ComboBox cmbR3;
        private System.Windows.Forms.ComboBox cmbB1;
        private System.Windows.Forms.ComboBox cmbB2;
        private System.Windows.Forms.ComboBox cmbB3;
        private System.Windows.Forms.ComboBox cmbR1;
    }
}