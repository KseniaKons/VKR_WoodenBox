namespace WoodenBox
{
    partial class ReportBox
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
            this.butTxt = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbWidthBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHeightBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tbLenghtBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbLenghtBoxInternal = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tbWidthBoxInternal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tbHeightBoxInternal = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.tbAround = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tbFront = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tbBefore = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tbSide = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tbWood = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tbCap = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.tbWoodGOST = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // butTxt
            // 
            this.butTxt.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butTxt.Location = new System.Drawing.Point(597, 447);
            this.butTxt.Name = "butTxt";
            this.butTxt.Size = new System.Drawing.Size(173, 47);
            this.butTxt.TabIndex = 0;
            this.butTxt.Text = "Выгрузить в .txt";
            this.butTxt.UseVisualStyleBackColor = false;
            this.butTxt.Click += new System.EventHandler(this.butTxt_Click);
            // 
            // tbWidthBox
            // 
            this.tbWidthBox.Location = new System.Drawing.Point(21, 94);
            this.tbWidthBox.Name = "tbWidthBox";
            this.tbWidthBox.Size = new System.Drawing.Size(102, 22);
            this.tbWidthBox.TabIndex = 13;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Высота, мм";
            // 
            // tbHeightBox
            // 
            this.tbHeightBox.Location = new System.Drawing.Point(21, 35);
            this.tbHeightBox.Name = "tbHeightBox";
            this.tbHeightBox.Size = new System.Drawing.Size(102, 22);
            this.tbHeightBox.TabIndex = 11;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "Ширина, мм";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbLenghtBox);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbWidthBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tbHeightBox);
            this.panel1.Location = new System.Drawing.Point(26, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(248, 197);
            this.panel1.TabIndex = 14;
            // 
            // tbLenghtBox
            // 
            this.tbLenghtBox.Location = new System.Drawing.Point(21, 158);
            this.tbLenghtBox.Name = "tbLenghtBox";
            this.tbLenghtBox.Size = new System.Drawing.Size(102, 22);
            this.tbLenghtBox.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(18, 139);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Длинна, мм";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(207, 16);
            this.label4.TabIndex = 16;
            this.label4.Text = "Внешние габаритные размеры";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbLenghtBoxInternal);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.tbWidthBoxInternal);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.tbHeightBoxInternal);
            this.panel2.Location = new System.Drawing.Point(296, 35);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(248, 197);
            this.panel2.TabIndex = 17;
            // 
            // tbLenghtBoxInternal
            // 
            this.tbLenghtBoxInternal.Location = new System.Drawing.Point(21, 158);
            this.tbLenghtBoxInternal.Name = "tbLenghtBoxInternal";
            this.tbLenghtBoxInternal.Size = new System.Drawing.Size(102, 22);
            this.tbLenghtBoxInternal.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(18, 139);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 14;
            this.label6.Text = "Длинна, мм";
            // 
            // tbWidthBoxInternal
            // 
            this.tbWidthBoxInternal.Location = new System.Drawing.Point(21, 94);
            this.tbWidthBoxInternal.Name = "tbWidthBoxInternal";
            this.tbWidthBoxInternal.Size = new System.Drawing.Size(102, 22);
            this.tbWidthBoxInternal.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(18, 75);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(82, 16);
            this.label7.TabIndex = 12;
            this.label7.Text = "Ширина, мм";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(18, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Высота, мм";
            // 
            // tbHeightBoxInternal
            // 
            this.tbHeightBoxInternal.Location = new System.Drawing.Point(21, 35);
            this.tbHeightBoxInternal.Name = "tbHeightBoxInternal";
            this.tbHeightBoxInternal.Size = new System.Drawing.Size(102, 22);
            this.tbHeightBoxInternal.TabIndex = 11;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.tbAround);
            this.panel3.Controls.Add(this.label16);
            this.panel3.Controls.Add(this.tbFront);
            this.panel3.Controls.Add(this.label15);
            this.panel3.Controls.Add(this.tbBefore);
            this.panel3.Controls.Add(this.label14);
            this.panel3.Controls.Add(this.tbSide);
            this.panel3.Controls.Add(this.label13);
            this.panel3.Controls.Add(this.tbWood);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.tbCap);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label11);
            this.panel3.Controls.Add(this.tbWoodGOST);
            this.panel3.Location = new System.Drawing.Point(26, 258);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(518, 236);
            this.panel3.TabIndex = 16;
            // 
            // tbAround
            // 
            this.tbAround.Location = new System.Drawing.Point(274, 147);
            this.tbAround.Name = "tbAround";
            this.tbAround.Size = new System.Drawing.Size(226, 22);
            this.tbAround.TabIndex = 25;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(271, 128);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(182, 16);
            this.label16.TabIndex = 24;
            this.label16.Text = "Планки пояса состоят из ...";
            // 
            // tbFront
            // 
            this.tbFront.Location = new System.Drawing.Point(21, 200);
            this.tbFront.Name = "tbFront";
            this.tbFront.Size = new System.Drawing.Size(226, 22);
            this.tbFront.TabIndex = 23;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 181);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(248, 16);
            this.label15.TabIndex = 22;
            this.label15.Text = "Планки торцевого щита состоят из ...";
            // 
            // tbBefore
            // 
            this.tbBefore.Location = new System.Drawing.Point(21, 147);
            this.tbBefore.Name = "tbBefore";
            this.tbBefore.Size = new System.Drawing.Size(226, 22);
            this.tbBefore.TabIndex = 21;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 128);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(194, 16);
            this.label14.TabIndex = 20;
            this.label14.Text = "Торцевые щиты состоят из ...";
            // 
            // tbSide
            // 
            this.tbSide.Location = new System.Drawing.Point(274, 90);
            this.tbSide.Name = "tbSide";
            this.tbSide.Size = new System.Drawing.Size(226, 22);
            this.tbSide.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(271, 71);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(185, 16);
            this.label13.TabIndex = 18;
            this.label13.Text = "Боковые щиты состоят из ...";
            // 
            // tbWood
            // 
            this.tbWood.Location = new System.Drawing.Point(374, 35);
            this.tbWood.Name = "tbWood";
            this.tbWood.Size = new System.Drawing.Size(126, 22);
            this.tbWood.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(371, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(79, 16);
            this.label10.TabIndex = 16;
            this.label10.Text = "Древесина";
            // 
            // tbCap
            // 
            this.tbCap.Location = new System.Drawing.Point(21, 90);
            this.tbCap.Name = "tbCap";
            this.tbCap.Size = new System.Drawing.Size(226, 22);
            this.tbCap.TabIndex = 15;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(18, 71);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(179, 16);
            this.label9.TabIndex = 14;
            this.label9.Text = "Дно и крышка состоят из ...";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(18, 16);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(169, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "ГОСТ на пиломатериалы";
            // 
            // tbWoodGOST
            // 
            this.tbWoodGOST.Location = new System.Drawing.Point(21, 35);
            this.tbWoodGOST.Name = "tbWoodGOST";
            this.tbWoodGOST.Size = new System.Drawing.Size(328, 22);
            this.tbWoodGOST.TabIndex = 11;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(33, 247);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 19;
            this.label12.Text = "Доски";
            // 
            // panel4
            // 
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.richTextBox1);
            this.panel4.Location = new System.Drawing.Point(567, 35);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(248, 393);
            this.panel4.TabIndex = 18;
            // 
            // richTextBox1
            // 
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(10, 20);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(226, 356);
            this.richTextBox1.TabIndex = 0;
            this.richTextBox1.Text = "";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(302, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(229, 16);
            this.label5.TabIndex = 18;
            this.label5.Text = "Внутренние габаритные размеры";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(575, 26);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(46, 16);
            this.label20.TabIndex = 20;
            this.label20.Text = "Итого";
            // 
            // ReportBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(834, 513);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.butTxt);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ReportBox";
            this.Text = "Отчет о построении";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button butTxt;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox tbWidthBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHeightBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox tbLenghtBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox tbLenghtBoxInternal;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbWidthBoxInternal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox tbHeightBoxInternal;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbCap;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox tbWoodGOST;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbBefore;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbSide;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbWood;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tbAround;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbFront;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}