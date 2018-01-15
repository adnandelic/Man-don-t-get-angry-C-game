namespace CovjeceNeLjutiSe
{
    partial class OdaberiJezik
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
            this.buttonGer = new System.Windows.Forms.Button();
            this.buttonEng = new System.Windows.Forms.Button();
            this.buttonBos = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonGer
            // 
            this.buttonGer.BackgroundImage = global::CovjeceNeLjutiSe.Properties.Resources.flag_D;
            this.buttonGer.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonGer.Location = new System.Drawing.Point(252, 53);
            this.buttonGer.Name = "buttonGer";
            this.buttonGer.Size = new System.Drawing.Size(100, 60);
            this.buttonGer.TabIndex = 2;
            this.buttonGer.UseVisualStyleBackColor = true;
            this.buttonGer.Click += new System.EventHandler(this.buttonGer_Click);
            // 
            // buttonEng
            // 
            this.buttonEng.BackgroundImage = global::CovjeceNeLjutiSe.Properties.Resources.flag_E;
            this.buttonEng.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonEng.Location = new System.Drawing.Point(146, 53);
            this.buttonEng.Name = "buttonEng";
            this.buttonEng.Size = new System.Drawing.Size(100, 60);
            this.buttonEng.TabIndex = 1;
            this.buttonEng.UseVisualStyleBackColor = true;
            this.buttonEng.Click += new System.EventHandler(this.buttonEng_Click);
            // 
            // buttonBos
            // 
            this.buttonBos.BackgroundImage = global::CovjeceNeLjutiSe.Properties.Resources.flag_B;
            this.buttonBos.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.buttonBos.Location = new System.Drawing.Point(40, 53);
            this.buttonBos.Name = "buttonBos";
            this.buttonBos.Size = new System.Drawing.Size(100, 60);
            this.buttonBos.TabIndex = 0;
            this.buttonBos.UseVisualStyleBackColor = true;
            this.buttonBos.Click += new System.EventHandler(this.buttonBos_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ControlLight;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(316, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 3;
            this.button1.Text = "About";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Red;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(180, 122);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(35, 35);
            this.button2.TabIndex = 4;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // OdaberiJezik
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(392, 169);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonGer);
            this.Controls.Add(this.buttonEng);
            this.Controls.Add(this.buttonBos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OdaberiJezik";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Čovječe ne ljuti se / Man don\'t get angry / Mensch ärgere dich nicht";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonBos;
        private System.Windows.Forms.Button buttonEng;
        private System.Windows.Forms.Button buttonGer;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}