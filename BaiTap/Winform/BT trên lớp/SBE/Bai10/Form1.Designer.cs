namespace Bai10
{
    partial class Form1
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rbtnItaly = new System.Windows.Forms.RadioButton();
            this.rbtnUSA = new System.Windows.Forms.RadioButton();
            this.rbtnJapan = new System.Windows.Forms.RadioButton();
            this.rbtnFrance = new System.Windows.Forms.RadioButton();
            this.rbtnEngland = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnRome = new System.Windows.Forms.RadioButton();
            this.rbtnParis = new System.Windows.Forms.RadioButton();
            this.rbtnWashingtonDC = new System.Windows.Forms.RadioButton();
            this.rbtnLondon = new System.Windows.Forms.RadioButton();
            this.rbtnTokyo = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rbtnItaly);
            this.groupBox1.Controls.Add(this.rbtnUSA);
            this.groupBox1.Controls.Add(this.rbtnJapan);
            this.groupBox1.Controls.Add(this.rbtnFrance);
            this.groupBox1.Controls.Add(this.rbtnEngland);
            this.groupBox1.Location = new System.Drawing.Point(12, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(134, 267);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Country";
            // 
            // rbtnItaly
            // 
            this.rbtnItaly.AutoSize = true;
            this.rbtnItaly.Location = new System.Drawing.Point(7, 197);
            this.rbtnItaly.Name = "rbtnItaly";
            this.rbtnItaly.Size = new System.Drawing.Size(47, 17);
            this.rbtnItaly.TabIndex = 4;
            this.rbtnItaly.TabStop = true;
            this.rbtnItaly.Text = "Italia";
            this.rbtnItaly.UseVisualStyleBackColor = true;
            this.rbtnItaly.CheckedChanged += new System.EventHandler(this.rbtnItaly_CheckedChanged);
            // 
            // rbtnUSA
            // 
            this.rbtnUSA.AutoSize = true;
            this.rbtnUSA.Location = new System.Drawing.Point(7, 161);
            this.rbtnUSA.Name = "rbtnUSA";
            this.rbtnUSA.Size = new System.Drawing.Size(69, 17);
            this.rbtnUSA.TabIndex = 3;
            this.rbtnUSA.TabStop = true;
            this.rbtnUSA.Text = "The USA";
            this.rbtnUSA.UseVisualStyleBackColor = true;
            this.rbtnUSA.CheckedChanged += new System.EventHandler(this.rbtnUSA_CheckedChanged);
            // 
            // rbtnJapan
            // 
            this.rbtnJapan.AutoSize = true;
            this.rbtnJapan.Location = new System.Drawing.Point(7, 122);
            this.rbtnJapan.Name = "rbtnJapan";
            this.rbtnJapan.Size = new System.Drawing.Size(54, 17);
            this.rbtnJapan.TabIndex = 2;
            this.rbtnJapan.TabStop = true;
            this.rbtnJapan.Text = "Japan";
            this.rbtnJapan.UseVisualStyleBackColor = true;
            this.rbtnJapan.CheckedChanged += new System.EventHandler(this.rbtnJapan_CheckedChanged);
            // 
            // rbtnFrance
            // 
            this.rbtnFrance.AutoSize = true;
            this.rbtnFrance.Location = new System.Drawing.Point(7, 85);
            this.rbtnFrance.Name = "rbtnFrance";
            this.rbtnFrance.Size = new System.Drawing.Size(58, 17);
            this.rbtnFrance.TabIndex = 1;
            this.rbtnFrance.TabStop = true;
            this.rbtnFrance.Text = "France";
            this.rbtnFrance.UseVisualStyleBackColor = true;
            this.rbtnFrance.CheckedChanged += new System.EventHandler(this.rbtnFrance_CheckedChanged);
            // 
            // rbtnEngland
            // 
            this.rbtnEngland.AutoSize = true;
            this.rbtnEngland.Location = new System.Drawing.Point(7, 43);
            this.rbtnEngland.Name = "rbtnEngland";
            this.rbtnEngland.Size = new System.Drawing.Size(64, 17);
            this.rbtnEngland.TabIndex = 0;
            this.rbtnEngland.TabStop = true;
            this.rbtnEngland.Text = "England";
            this.rbtnEngland.UseVisualStyleBackColor = true;
            this.rbtnEngland.CheckedChanged += new System.EventHandler(this.rbntEngland_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnRome);
            this.groupBox2.Controls.Add(this.rbtnParis);
            this.groupBox2.Controls.Add(this.rbtnWashingtonDC);
            this.groupBox2.Controls.Add(this.rbtnLondon);
            this.groupBox2.Controls.Add(this.rbtnTokyo);
            this.groupBox2.Location = new System.Drawing.Point(221, 27);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(134, 267);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Capital";
            // 
            // rbtnRome
            // 
            this.rbtnRome.AutoSize = true;
            this.rbtnRome.Location = new System.Drawing.Point(7, 197);
            this.rbtnRome.Name = "rbtnRome";
            this.rbtnRome.Size = new System.Drawing.Size(53, 17);
            this.rbtnRome.TabIndex = 4;
            this.rbtnRome.TabStop = true;
            this.rbtnRome.Text = "Rome";
            this.rbtnRome.UseVisualStyleBackColor = true;
            this.rbtnRome.CheckedChanged += new System.EventHandler(this.rbtnRome_CheckedChanged);
            // 
            // rbtnParis
            // 
            this.rbtnParis.AutoSize = true;
            this.rbtnParis.Location = new System.Drawing.Point(7, 161);
            this.rbtnParis.Name = "rbtnParis";
            this.rbtnParis.Size = new System.Drawing.Size(48, 17);
            this.rbtnParis.TabIndex = 3;
            this.rbtnParis.TabStop = true;
            this.rbtnParis.Text = "Paris";
            this.rbtnParis.UseVisualStyleBackColor = true;
            this.rbtnParis.CheckedChanged += new System.EventHandler(this.rbtnParis_CheckedChanged);
            // 
            // rbtnWashingtonDC
            // 
            this.rbtnWashingtonDC.AutoSize = true;
            this.rbtnWashingtonDC.Location = new System.Drawing.Point(7, 122);
            this.rbtnWashingtonDC.Name = "rbtnWashingtonDC";
            this.rbtnWashingtonDC.Size = new System.Drawing.Size(100, 17);
            this.rbtnWashingtonDC.TabIndex = 2;
            this.rbtnWashingtonDC.TabStop = true;
            this.rbtnWashingtonDC.Text = "Washington DC";
            this.rbtnWashingtonDC.UseVisualStyleBackColor = true;
            this.rbtnWashingtonDC.CheckedChanged += new System.EventHandler(this.rbtnWashingtonDC_CheckedChanged);
            // 
            // rbtnLondon
            // 
            this.rbtnLondon.AutoSize = true;
            this.rbtnLondon.Location = new System.Drawing.Point(7, 85);
            this.rbtnLondon.Name = "rbtnLondon";
            this.rbtnLondon.Size = new System.Drawing.Size(61, 17);
            this.rbtnLondon.TabIndex = 1;
            this.rbtnLondon.TabStop = true;
            this.rbtnLondon.Text = "London";
            this.rbtnLondon.UseVisualStyleBackColor = true;
            this.rbtnLondon.CheckedChanged += new System.EventHandler(this.rbtnLondon_CheckedChanged);
            // 
            // rbtnTokyo
            // 
            this.rbtnTokyo.AutoSize = true;
            this.rbtnTokyo.Location = new System.Drawing.Point(7, 43);
            this.rbtnTokyo.Name = "rbtnTokyo";
            this.rbtnTokyo.Size = new System.Drawing.Size(55, 17);
            this.rbtnTokyo.TabIndex = 0;
            this.rbtnTokyo.TabStop = true;
            this.rbtnTokyo.Text = "Tokyo";
            this.rbtnTokyo.UseVisualStyleBackColor = true;
            this.rbtnTokyo.CheckedChanged += new System.EventHandler(this.rbtnTokyo_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(280, 359);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Exit";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 13);
            this.label1.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 392);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rbtnItaly;
        private System.Windows.Forms.RadioButton rbtnUSA;
        private System.Windows.Forms.RadioButton rbtnJapan;
        private System.Windows.Forms.RadioButton rbtnFrance;
        private System.Windows.Forms.RadioButton rbtnEngland;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rbtnRome;
        private System.Windows.Forms.RadioButton rbtnParis;
        private System.Windows.Forms.RadioButton rbtnWashingtonDC;
        private System.Windows.Forms.RadioButton rbtnLondon;
        private System.Windows.Forms.RadioButton rbtnTokyo;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}

