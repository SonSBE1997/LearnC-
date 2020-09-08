namespace DictionarySpeaking
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSpeakEnglish = new System.Windows.Forms.Button();
            this.cbListWord = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnSpeak = new System.Windows.Forms.Button();
            this.btnSpeakVN = new System.Windows.Forms.Button();
            this.txbExplaination = new System.Windows.Forms.TextBox();
            this.txbMeaning = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSpeakEnglish);
            this.panel1.Controls.Add(this.cbListWord);
            resources.ApplyResources(this.panel1, "panel1");
            this.panel1.Name = "panel1";
            // 
            // btnSpeakEnglish
            // 
            resources.ApplyResources(this.btnSpeakEnglish, "btnSpeakEnglish");
            this.btnSpeakEnglish.Name = "btnSpeakEnglish";
            this.btnSpeakEnglish.UseVisualStyleBackColor = true;
            this.btnSpeakEnglish.Click += new System.EventHandler(this.btnSpeakEnglish_Click);
            // 
            // cbListWord
            // 
            this.cbListWord.DropDownStyle = System.Windows.Forms.ComboBoxStyle.Simple;
            this.cbListWord.FormattingEnabled = true;
            resources.ApplyResources(this.cbListWord, "cbListWord");
            this.cbListWord.Name = "cbListWord";
            this.cbListWord.Sorted = true;
            this.cbListWord.SelectedIndexChanged += new System.EventHandler(this.cbListWord_SelectedIndexChanged);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnSpeak);
            this.panel2.Controls.Add(this.btnSpeakVN);
            this.panel2.Controls.Add(this.txbExplaination);
            this.panel2.Controls.Add(this.txbMeaning);
            resources.ApplyResources(this.panel2, "panel2");
            this.panel2.Name = "panel2";
            // 
            // btnSpeak
            // 
            resources.ApplyResources(this.btnSpeak, "btnSpeak");
            this.btnSpeak.Name = "btnSpeak";
            this.btnSpeak.UseVisualStyleBackColor = true;
            this.btnSpeak.Click += new System.EventHandler(this.btnSpeak_Click);
            // 
            // btnSpeakVN
            // 
            resources.ApplyResources(this.btnSpeakVN, "btnSpeakVN");
            this.btnSpeakVN.Name = "btnSpeakVN";
            this.btnSpeakVN.UseVisualStyleBackColor = true;
            this.btnSpeakVN.Click += new System.EventHandler(this.btnSpeakVN_Click);
            // 
            // txbExplaination
            // 
            resources.ApplyResources(this.txbExplaination, "txbExplaination");
            this.txbExplaination.Name = "txbExplaination";
            // 
            // txbMeaning
            // 
            resources.ApplyResources(this.txbMeaning, "txbMeaning");
            this.txbMeaning.Name = "txbMeaning";
            // 
            // Form1
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.ShowIcon = false;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ComboBox cbListWord;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnSpeakEnglish;
        private System.Windows.Forms.Button btnSpeak;
        private System.Windows.Forms.Button btnSpeakVN;
        private System.Windows.Forms.TextBox txbExplaination;
        private System.Windows.Forms.TextBox txbMeaning;
    }
}

