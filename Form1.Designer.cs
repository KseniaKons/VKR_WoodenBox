namespace WoodenBox
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.cbGOST = new System.Windows.Forms.ComboBox();
            this.btBuild = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbMassa = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbTypeBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbHeightBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbWidthBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tbLengthBox = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.cbWidthBoards = new System.Windows.Forms.ComboBox();
            this.butSave = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.tbSave = new System.Windows.Forms.TextBox();
            this.pbImageBox = new System.Windows.Forms.PictureBox();
            this.tbMPST = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tbGap = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btSpecification = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // cbGOST
            // 
            this.cbGOST.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbGOST.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbGOST.FormattingEnabled = true;
            this.cbGOST.Items.AddRange(new object[] {
            "ГОСТ 2695. Пиломатериалы лиственных пород",
            "ГОСТ 24454-80. Пиломатериалы хвойных пород"});
            this.cbGOST.Location = new System.Drawing.Point(20, 34);
            this.cbGOST.Name = "cbGOST";
            this.cbGOST.Size = new System.Drawing.Size(360, 24);
            this.cbGOST.TabIndex = 0;
            // 
            // btBuild
            // 
            this.btBuild.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btBuild.Location = new System.Drawing.Point(489, 540);
            this.btBuild.Name = "btBuild";
            this.btBuild.Size = new System.Drawing.Size(180, 55);
            this.btBuild.TabIndex = 2;
            this.btBuild.Text = "Построить ящик";
            this.btBuild.UseVisualStyleBackColor = false;
            this.btBuild.Click += new System.EventHandler(this.btBuild_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 16);
            this.label4.TabIndex = 10;
            this.label4.Text = "ГОСТ на доски";
            // 
            // tbMassa
            // 
            this.tbMassa.Location = new System.Drawing.Point(18, 225);
            this.tbMassa.Name = "tbMassa";
            this.tbMassa.Size = new System.Drawing.Size(360, 22);
            this.tbMassa.TabIndex = 11;
            this.tbMassa.Text = "150";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 206);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "Масса упаковываемого груза, кг";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 138);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ширина зазора, мм";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(503, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "Тип ящика";
            // 
            // cbTypeBox
            // 
            this.cbTypeBox.BackColor = System.Drawing.SystemColors.Window;
            this.cbTypeBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTypeBox.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbTypeBox.FormattingEnabled = true;
            this.cbTypeBox.Items.AddRange(new object[] {
            "I-1",
            "I-2"});
            this.cbTypeBox.Location = new System.Drawing.Point(506, 39);
            this.cbTypeBox.Name = "cbTypeBox";
            this.cbTypeBox.Size = new System.Drawing.Size(323, 24);
            this.cbTypeBox.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "Высота, мм";
            // 
            // tbHeightBox
            // 
            this.tbHeightBox.Location = new System.Drawing.Point(18, 46);
            this.tbHeightBox.Name = "tbHeightBox";
            this.tbHeightBox.Size = new System.Drawing.Size(360, 22);
            this.tbHeightBox.TabIndex = 7;
            this.tbHeightBox.Text = "400";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "Ширина, мм";
            // 
            // tbWidthBox
            // 
            this.tbWidthBox.Location = new System.Drawing.Point(18, 105);
            this.tbWidthBox.Name = "tbWidthBox";
            this.tbWidthBox.Size = new System.Drawing.Size(360, 22);
            this.tbWidthBox.TabIndex = 9;
            this.tbWidthBox.Text = "500";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 144);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Длина, мм";
            // 
            // tbLengthBox
            // 
            this.tbLengthBox.Location = new System.Drawing.Point(18, 163);
            this.tbLengthBox.Name = "tbLengthBox";
            this.tbLengthBox.Size = new System.Drawing.Size(360, 22);
            this.tbLengthBox.TabIndex = 9;
            this.tbLengthBox.Text = "1000";
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.tbWidthBox);
            this.panel1.Controls.Add(this.tbLengthBox);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.tbHeightBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.tbMassa);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Location = new System.Drawing.Point(33, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 269);
            this.panel1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(49, 26);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(324, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Внутренние габаритные размеры и масса ящика";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(16, 74);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(188, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ширина досок по ГОСТу, мм";
            // 
            // cbWidthBoards
            // 
            this.cbWidthBoards.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWidthBoards.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbWidthBoards.FormattingEnabled = true;
            this.cbWidthBoards.Items.AddRange(new object[] {
            "Вычислить оптимальную",
            "Вписать вручную"});
            this.cbWidthBoards.Location = new System.Drawing.Point(19, 93);
            this.cbWidthBoards.Name = "cbWidthBoards";
            this.cbWidthBoards.Size = new System.Drawing.Size(360, 24);
            this.cbWidthBoards.TabIndex = 18;
            // 
            // butSave
            // 
            this.butSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butSave.Location = new System.Drawing.Point(827, 490);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(75, 29);
            this.butSave.TabIndex = 20;
            this.butSave.Text = "Обзор...";
            this.butSave.UseVisualStyleBackColor = false;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // tbSave
            // 
            this.tbSave.Enabled = false;
            this.tbSave.Location = new System.Drawing.Point(475, 493);
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(339, 22);
            this.tbSave.TabIndex = 10;
            // 
            // pbImageBox
            // 
            this.pbImageBox.Location = new System.Drawing.Point(506, 82);
            this.pbImageBox.Name = "pbImageBox";
            this.pbImageBox.Size = new System.Drawing.Size(381, 307);
            this.pbImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageBox.TabIndex = 6;
            this.pbImageBox.TabStop = false;
            // 
            // tbMPST
            // 
            this.tbMPST.Location = new System.Drawing.Point(476, 426);
            this.tbMPST.Name = "tbMPST";
            this.tbMPST.Size = new System.Drawing.Size(128, 22);
            this.tbMPST.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(607, 425);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = ".";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(623, 426);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(170, 22);
            this.textBox2.TabIndex = 25;
            this.textBox2.Text = "32117.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(796, 425);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = ".";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(812, 426);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(90, 22);
            this.tbNumber.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(473, 407);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Обозначение";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(49, 321);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(263, 16);
            this.label13.TabIndex = 28;
            this.label13.Text = "Размеры досок и зазора (при наличии)";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.tbGap);
            this.panel2.Controls.Add(this.cbWidthBoards);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.cbGOST);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Location = new System.Drawing.Point(33, 330);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(399, 203);
            this.panel2.TabIndex = 29;
            // 
            // tbGap
            // 
            this.tbGap.Location = new System.Drawing.Point(18, 159);
            this.tbGap.Name = "tbGap";
            this.tbGap.Size = new System.Drawing.Size(362, 22);
            this.tbGap.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(473, 474);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(218, 16);
            this.label17.TabIndex = 31;
            this.label17.Text = "Директория сохранения файлов";
            // 
            // btSpecification
            // 
            this.btSpecification.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btSpecification.Location = new System.Drawing.Point(707, 540);
            this.btSpecification.Name = "btSpecification";
            this.btSpecification.Size = new System.Drawing.Size(180, 55);
            this.btSpecification.TabIndex = 32;
            this.btSpecification.Text = "Составить спецификацию";
            this.btSpecification.UseVisualStyleBackColor = false;
            this.btSpecification.Click += new System.EventHandler(this.btSpecification_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(982, 617);
            this.Controls.Add(this.btSpecification);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.tbMPST);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.tbSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cbTypeBox);
            this.Controls.Add(this.pbImageBox);
            this.Controls.Add(this.btBuild);
            this.Name = "Form1";
            this.Text = "ГОСТ 10198.91 Ящики деревянные для грузов массой св. 200 до 20000 кг";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageBox)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbGOST;
        private System.Windows.Forms.Button btBuild;
        private System.Windows.Forms.PictureBox pbImageBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbMassa;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbTypeBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbHeightBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbWidthBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbLengthBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cbWidthBoards;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.TextBox tbSave;
        private System.Windows.Forms.TextBox tbMPST;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox tbGap;
        private System.Windows.Forms.Button btSpecification;
    }
}

