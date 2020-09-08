namespace Bai4
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
            this.txtResult = new System.Windows.Forms.TextBox();
            this.txtB = new System.Windows.Forms.TextBox();
            this.txtA = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rbtnDevide = new System.Windows.Forms.RadioButton();
            this.rbtnMul = new System.Windows.Forms.RadioButton();
            this.rbtnSub = new System.Windows.Forms.RadioButton();
            this.rbtnAdd = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.ckbMin = new System.Windows.Forms.CheckBox();
            this.ckbMax = new System.Windows.Forms.CheckBox();
            this.btnRework = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtResult);
            this.groupBox1.Controls.Add(this.txtB);
            this.groupBox1.Controls.Add(this.txtA);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(60, 25);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(371, 160);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // txtResult
            // 
            this.txtResult.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtResult.Location = new System.Drawing.Point(146, 112);
            this.txtResult.Name = "txtResult";
            this.txtResult.ReadOnly = true;
            this.txtResult.Size = new System.Drawing.Size(156, 26);
            this.txtResult.TabIndex = 5;
            // 
            // txtB
            // 
            this.txtB.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtB.Location = new System.Drawing.Point(146, 68);
            this.txtB.Name = "txtB";
            this.txtB.Size = new System.Drawing.Size(156, 26);
            this.txtB.TabIndex = 4;
            this.txtB.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtB_KeyPress);
            // 
            // txtA
            // 
            this.txtA.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtA.Location = new System.Drawing.Point(146, 27);
            this.txtA.Name = "txtA";
            this.txtA.Size = new System.Drawing.Size(156, 26);
            this.txtA.TabIndex = 3;
            this.txtA.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtA_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(67, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Kết quả";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(67, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 18);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nhập b =";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(67, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nhập a =";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rbtnDevide);
            this.groupBox2.Controls.Add(this.rbtnMul);
            this.groupBox2.Controls.Add(this.rbtnSub);
            this.groupBox2.Controls.Add(this.rbtnAdd);
            this.groupBox2.Location = new System.Drawing.Point(43, 202);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(175, 161);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Phép tính";
            // 
            // rbtnDevide
            // 
            this.rbtnDevide.AutoSize = true;
            this.rbtnDevide.Location = new System.Drawing.Point(17, 126);
            this.rbtnDevide.Name = "rbtnDevide";
            this.rbtnDevide.Size = new System.Drawing.Size(46, 17);
            this.rbtnDevide.TabIndex = 3;
            this.rbtnDevide.TabStop = true;
            this.rbtnDevide.Text = "Chia";
            this.rbtnDevide.UseVisualStyleBackColor = true;
            this.rbtnDevide.CheckedChanged += new System.EventHandler(this.radioButton4_CheckedChanged);
            // 
            // rbtnMul
            // 
            this.rbtnMul.AutoSize = true;
            this.rbtnMul.Location = new System.Drawing.Point(17, 94);
            this.rbtnMul.Name = "rbtnMul";
            this.rbtnMul.Size = new System.Drawing.Size(51, 17);
            this.rbtnMul.TabIndex = 2;
            this.rbtnMul.TabStop = true;
            this.rbtnMul.Text = "Nhân";
            this.rbtnMul.UseVisualStyleBackColor = true;
            this.rbtnMul.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // rbtnSub
            // 
            this.rbtnSub.AutoSize = true;
            this.rbtnSub.Location = new System.Drawing.Point(17, 60);
            this.rbtnSub.Name = "rbtnSub";
            this.rbtnSub.Size = new System.Drawing.Size(44, 17);
            this.rbtnSub.TabIndex = 1;
            this.rbtnSub.TabStop = true;
            this.rbtnSub.Text = "Trừ ";
            this.rbtnSub.UseVisualStyleBackColor = true;
            this.rbtnSub.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // rbtnAdd
            // 
            this.rbtnAdd.AutoSize = true;
            this.rbtnAdd.Location = new System.Drawing.Point(17, 27);
            this.rbtnAdd.Name = "rbtnAdd";
            this.rbtnAdd.Size = new System.Drawing.Size(50, 17);
            this.rbtnAdd.TabIndex = 0;
            this.rbtnAdd.TabStop = true;
            this.rbtnAdd.Text = "Cộng";
            this.rbtnAdd.UseVisualStyleBackColor = true;
            this.rbtnAdd.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.ckbMin);
            this.groupBox3.Controls.Add(this.ckbMax);
            this.groupBox3.Location = new System.Drawing.Point(282, 202);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(167, 161);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "So sánh";
            // 
            // ckbMin
            // 
            this.ckbMin.AutoSize = true;
            this.ckbMin.Location = new System.Drawing.Point(27, 94);
            this.ckbMin.Name = "ckbMin";
            this.ckbMin.Size = new System.Drawing.Size(43, 17);
            this.ckbMin.TabIndex = 1;
            this.ckbMin.Text = "Min";
            this.ckbMin.UseVisualStyleBackColor = true;
            this.ckbMin.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // ckbMax
            // 
            this.ckbMax.AutoSize = true;
            this.ckbMax.Location = new System.Drawing.Point(30, 31);
            this.ckbMax.Name = "ckbMax";
            this.ckbMax.Size = new System.Drawing.Size(46, 17);
            this.ckbMax.TabIndex = 0;
            this.ckbMax.Text = "Max";
            this.ckbMax.UseVisualStyleBackColor = true;
            this.ckbMax.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnRework
            // 
            this.btnRework.Location = new System.Drawing.Point(130, 389);
            this.btnRework.Name = "btnRework";
            this.btnRework.Size = new System.Drawing.Size(88, 31);
            this.btnRework.TabIndex = 3;
            this.btnRework.Text = "Làm lại";
            this.btnRework.UseVisualStyleBackColor = true;
            this.btnRework.Click += new System.EventHandler(this.btnRework_Click);
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(264, 389);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 31);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Thoát";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(488, 452);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnRework);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chương trình tính toán";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.RadioButton rbtnDevide;
        private System.Windows.Forms.RadioButton rbtnMul;
        private System.Windows.Forms.RadioButton rbtnSub;
        private System.Windows.Forms.RadioButton rbtnAdd;
        private System.Windows.Forms.CheckBox ckbMin;
        private System.Windows.Forms.CheckBox ckbMax;
        private System.Windows.Forms.Button btnRework;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtResult;
        private System.Windows.Forms.TextBox txtB;
        private System.Windows.Forms.TextBox txtA;
    }
}

