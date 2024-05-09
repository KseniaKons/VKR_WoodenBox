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
            this.btBuild = new System.Windows.Forms.Button();
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
            this.btChooseGOST = new System.Windows.Forms.Button();
            this.tbNailsGOST = new System.Windows.Forms.TextBox();
            this.tbTapeGOST = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tbWoodGOST = new System.Windows.Forms.TextBox();
            this.tbGap = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.btSpecification = new System.Windows.Forms.Button();
            this.cbFrontBoard = new System.Windows.Forms.ComboBox();
            this.cbBeltBoard = new System.Windows.Forms.ComboBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.cbSideBoard = new System.Windows.Forms.ComboBox();
            this.label21 = new System.Windows.Forms.Label();
            this.cbBottomBoards = new System.Windows.Forms.ComboBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbImageBox)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // btBuild
            // 
            this.btBuild.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btBuild.Location = new System.Drawing.Point(972, 528);
            this.btBuild.Name = "btBuild";
            this.btBuild.Size = new System.Drawing.Size(180, 55);
            this.btBuild.TabIndex = 2;
            this.btBuild.Text = "Построить ящик";
            this.btBuild.UseVisualStyleBackColor = false;
            this.btBuild.Click += new System.EventHandler(this.btBuild_Click);
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
            this.label6.Location = new System.Drawing.Point(647, 50);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(133, 16);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ширина зазора, мм";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(20, 14);
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
            this.cbTypeBox.Location = new System.Drawing.Point(23, 32);
            this.cbTypeBox.Name = "cbTypeBox";
            this.cbTypeBox.Size = new System.Drawing.Size(381, 24);
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
            this.panel1.Location = new System.Drawing.Point(428, 32);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(399, 269);
            this.panel1.TabIndex = 17;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(444, 23);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(324, 16);
            this.label8.TabIndex = 10;
            this.label8.Text = "Внутренние габаритные размеры и масса ящика";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(490, 540);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(123, 16);
            this.label9.TabIndex = 19;
            this.label9.Text = "Ширина досок, мм";
            // 
            // cbWidthBoards
            // 
            this.cbWidthBoards.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbWidthBoards.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbWidthBoards.FormattingEnabled = true;
            this.cbWidthBoards.Items.AddRange(new object[] {
            "Вычислить оптимальную",
            "Выбрать самостоятельно из ГОСТа",
            "Вписать вручную"});
            this.cbWidthBoards.Location = new System.Drawing.Point(493, 559);
            this.cbWidthBoards.Name = "cbWidthBoards";
            this.cbWidthBoards.Size = new System.Drawing.Size(360, 24);
            this.cbWidthBoards.TabIndex = 18;
            // 
            // butSave
            // 
            this.butSave.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.butSave.Location = new System.Drawing.Point(329, 476);
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
            this.tbSave.Location = new System.Drawing.Point(22, 479);
            this.tbSave.Name = "tbSave";
            this.tbSave.Size = new System.Drawing.Size(301, 22);
            this.tbSave.TabIndex = 10;
            // 
            // pbImageBox
            // 
            this.pbImageBox.Location = new System.Drawing.Point(23, 75);
            this.pbImageBox.Name = "pbImageBox";
            this.pbImageBox.Size = new System.Drawing.Size(381, 307);
            this.pbImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbImageBox.TabIndex = 6;
            this.pbImageBox.TabStop = false;
            // 
            // tbMPST
            // 
            this.tbMPST.Location = new System.Drawing.Point(23, 409);
            this.tbMPST.Name = "tbMPST";
            this.tbMPST.Size = new System.Drawing.Size(148, 22);
            this.tbMPST.TabIndex = 23;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label11.Location = new System.Drawing.Point(177, 408);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(13, 20);
            this.label11.TabIndex = 24;
            this.label11.Text = ".";
            // 
            // textBox2
            // 
            this.textBox2.Enabled = false;
            this.textBox2.Location = new System.Drawing.Point(193, 409);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(101, 22);
            this.textBox2.TabIndex = 25;
            this.textBox2.Text = "32117.";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label12.Location = new System.Drawing.Point(296, 408);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(13, 20);
            this.label12.TabIndex = 26;
            this.label12.Text = ".";
            // 
            // tbNumber
            // 
            this.tbNumber.Location = new System.Drawing.Point(312, 409);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(90, 22);
            this.tbNumber.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 390);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 16);
            this.label10.TabIndex = 22;
            this.label10.Text = "Обозначение";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(870, 23);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(82, 16);
            this.label13.TabIndex = 28;
            this.label13.Text = "ГОСТы на ...";
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.btChooseGOST);
            this.panel2.Controls.Add(this.tbNailsGOST);
            this.panel2.Controls.Add(this.tbTapeGOST);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.label15);
            this.panel2.Controls.Add(this.label16);
            this.panel2.Controls.Add(this.tbWoodGOST);
            this.panel2.Location = new System.Drawing.Point(854, 32);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(500, 269);
            this.panel2.TabIndex = 29;
            // 
            // btChooseGOST
            // 
            this.btChooseGOST.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btChooseGOST.Location = new System.Drawing.Point(21, 206);
            this.btChooseGOST.Name = "btChooseGOST";
            this.btChooseGOST.Size = new System.Drawing.Size(458, 41);
            this.btChooseGOST.TabIndex = 34;
            this.btChooseGOST.Text = "Выбрать ГОСТы";
            this.btChooseGOST.UseVisualStyleBackColor = false;
            this.btChooseGOST.Click += new System.EventHandler(this.btChooseGOST_Click);
            // 
            // tbNailsGOST
            // 
            this.tbNailsGOST.Location = new System.Drawing.Point(21, 105);
            this.tbNailsGOST.Name = "tbNailsGOST";
            this.tbNailsGOST.Size = new System.Drawing.Size(458, 22);
            this.tbNailsGOST.TabIndex = 16;
            // 
            // tbTapeGOST
            // 
            this.tbTapeGOST.Location = new System.Drawing.Point(21, 163);
            this.tbTapeGOST.Name = "tbTapeGOST";
            this.tbTapeGOST.Size = new System.Drawing.Size(458, 22);
            this.tbTapeGOST.TabIndex = 17;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(18, 27);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(114, 16);
            this.label14.TabIndex = 12;
            this.label14.Text = "Пиломатериалы";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(18, 144);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(144, 16);
            this.label15.TabIndex = 14;
            this.label15.Text = "Металическая лента";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(18, 86);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(54, 16);
            this.label16.TabIndex = 15;
            this.label16.Text = "Гвозди";
            // 
            // tbWoodGOST
            // 
            this.tbWoodGOST.Location = new System.Drawing.Point(21, 46);
            this.tbWoodGOST.Name = "tbWoodGOST";
            this.tbWoodGOST.Size = new System.Drawing.Size(458, 22);
            this.tbWoodGOST.TabIndex = 13;
            // 
            // tbGap
            // 
            this.tbGap.Location = new System.Drawing.Point(650, 71);
            this.tbGap.Name = "tbGap";
            this.tbGap.Size = new System.Drawing.Size(212, 22);
            this.tbGap.TabIndex = 32;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(20, 460);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(218, 16);
            this.label17.TabIndex = 31;
            this.label17.Text = "Директория сохранения файлов";
            // 
            // btSpecification
            // 
            this.btSpecification.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.btSpecification.Location = new System.Drawing.Point(1174, 528);
            this.btSpecification.Name = "btSpecification";
            this.btSpecification.Size = new System.Drawing.Size(180, 55);
            this.btSpecification.TabIndex = 32;
            this.btSpecification.Text = "Составить спецификацию";
            this.btSpecification.UseVisualStyleBackColor = false;
            this.btSpecification.Click += new System.EventHandler(this.Specification_Click);
            // 
            // cbFrontBoard
            // 
            this.cbFrontBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrontBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFrontBoard.FormattingEnabled = true;
            this.cbFrontBoard.Location = new System.Drawing.Point(349, 135);
            this.cbFrontBoard.Name = "cbFrontBoard";
            this.cbFrontBoard.Size = new System.Drawing.Size(212, 24);
            this.cbFrontBoard.TabIndex = 49;
            // 
            // cbBeltBoard
            // 
            this.cbBeltBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBeltBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbBeltBoard.FormattingEnabled = true;
            this.cbBeltBoard.Location = new System.Drawing.Point(350, 73);
            this.cbBeltBoard.Name = "cbBeltBoard";
            this.cbBeltBoard.Size = new System.Drawing.Size(211, 24);
            this.cbBeltBoard.TabIndex = 48;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(346, 115);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(239, 16);
            this.label18.TabIndex = 47;
            this.label18.Text = "Ширина планок торцевого щита, мм";
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(346, 54);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(173, 16);
            this.label19.TabIndex = 46;
            this.label19.Text = "Ширина планок пояса, мм";
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(52, 104);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(174, 16);
            this.label20.TabIndex = 45;
            this.label20.Text = "Ширина досок бокового и";
            // 
            // cbSideBoard
            // 
            this.cbSideBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSideBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSideBoard.FormattingEnabled = true;
            this.cbSideBoard.Location = new System.Drawing.Point(55, 138);
            this.cbSideBoard.Name = "cbSideBoard";
            this.cbSideBoard.Size = new System.Drawing.Size(209, 24);
            this.cbSideBoard.TabIndex = 44;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(52, 54);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(212, 16);
            this.label21.TabIndex = 43;
            this.label21.Text = "Ширина досок дна и крышки, мм";
            // 
            // cbBottomBoards
            // 
            this.cbBottomBoards.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBottomBoards.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbBottomBoards.FormattingEnabled = true;
            this.cbBottomBoards.Location = new System.Drawing.Point(55, 73);
            this.cbBottomBoards.Name = "cbBottomBoards";
            this.cbBottomBoards.Size = new System.Drawing.Size(209, 24);
            this.cbBottomBoards.TabIndex = 42;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.radioButton3);
            this.panel3.Controls.Add(this.radioButton2);
            this.panel3.Controls.Add(this.radioButton1);
            this.panel3.Controls.Add(this.label22);
            this.panel3.Controls.Add(this.cbBottomBoards);
            this.panel3.Controls.Add(this.cbFrontBoard);
            this.panel3.Controls.Add(this.label21);
            this.panel3.Controls.Add(this.tbGap);
            this.panel3.Controls.Add(this.cbBeltBoard);
            this.panel3.Controls.Add(this.cbSideBoard);
            this.panel3.Controls.Add(this.label18);
            this.panel3.Controls.Add(this.label20);
            this.panel3.Controls.Add(this.label19);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Location = new System.Drawing.Point(428, 322);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(926, 183);
            this.panel3.TabIndex = 50;
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(592, 16);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(143, 20);
            this.radioButton3.TabIndex = 53;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Вписать вручную";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(276, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(259, 20);
            this.radioButton2.TabIndex = 52;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Выбрать самостоятельно из ГОСТа";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(32, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(166, 20);
            this.radioButton1.TabIndex = 51;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Вычислить оптимало";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            this.label22.AutoSize = true;
            this.label22.Location = new System.Drawing.Point(52, 120);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(135, 16);
            this.label22.TabIndex = 50;
            this.label22.Text = "торцевого щита, мм";
            // 
            // label23
            // 
            this.label23.AutoSize = true;
            this.label23.Location = new System.Drawing.Point(448, 315);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(255, 16);
            this.label23.TabIndex = 51;
            this.label23.Text = "Ширина досок и зазора (при наличии)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(248, 598);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(162, 64);
            this.button1.TabIndex = 52;
            this.button1.Text = "Материал";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(1420, 715);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label23);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btSpecification);
            this.Controls.Add(this.cbWidthBoards);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label9);
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
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btBuild;
        private System.Windows.Forms.PictureBox pbImageBox;
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
        private System.Windows.Forms.TextBox tbNailsGOST;
        private System.Windows.Forms.TextBox tbTapeGOST;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox tbWoodGOST;
        private System.Windows.Forms.Button btChooseGOST;
        public System.Windows.Forms.ComboBox cbFrontBoard;
        public System.Windows.Forms.ComboBox cbBeltBoard;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
        public System.Windows.Forms.ComboBox cbSideBoard;
        private System.Windows.Forms.Label label21;
        public System.Windows.Forms.ComboBox cbBottomBoards;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.Button button1;
    }
}

