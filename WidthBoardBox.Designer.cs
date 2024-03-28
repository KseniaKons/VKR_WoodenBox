namespace WoodenBox
{
    partial class WidthBoardBox
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
            this.label9 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbGOST = new System.Windows.Forms.Label();
            this.cbFrontBoard = new System.Windows.Forms.ComboBox();
            this.cbSideBoard = new System.Windows.Forms.ComboBox();
            this.cbBottomBoards = new System.Windows.Forms.ComboBox();
            this.butSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 59);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 16);
            this.label9.TabIndex = 21;
            this.label9.Text = "Ширина досок дна и крышки, мм";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(222, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Ширина досок бокового щита, мм";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 184);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(230, 16);
            this.label2.TabIndex = 25;
            this.label2.Text = "Ширина досок торцевого щита, мм";
            // 
            // lbGOST
            // 
            this.lbGOST.AutoSize = true;
            this.lbGOST.Location = new System.Drawing.Point(39, 24);
            this.lbGOST.Name = "lbGOST";
            this.lbGOST.Size = new System.Drawing.Size(56, 16);
            this.lbGOST.TabIndex = 26;
            this.lbGOST.Text = "lbGOST";
            // 
            // cbFrontBoard
            // 
            this.cbFrontBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrontBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbFrontBoard.FormattingEnabled = true;
            this.cbFrontBoard.Location = new System.Drawing.Point(42, 203);
            this.cbFrontBoard.Name = "cbFrontBoard";
            this.cbFrontBoard.Size = new System.Drawing.Size(360, 24);
            this.cbFrontBoard.TabIndex = 24;
            // 
            // cbSideBoard
            // 
            this.cbSideBoard.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSideBoard.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbSideBoard.FormattingEnabled = true;
            this.cbSideBoard.Location = new System.Drawing.Point(42, 143);
            this.cbSideBoard.Name = "cbSideBoard";
            this.cbSideBoard.Size = new System.Drawing.Size(360, 24);
            this.cbSideBoard.TabIndex = 22;
            // 
            // cbWidthBoards
            // 
            this.cbBottomBoards.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBottomBoards.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbBottomBoards.FormattingEnabled = true;
            this.cbBottomBoards.Location = new System.Drawing.Point(42, 78);
            this.cbBottomBoards.Name = "cbWidthBoards";
            this.cbBottomBoards.Size = new System.Drawing.Size(360, 24);
            this.cbBottomBoards.TabIndex = 20;
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(355, 243);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(96, 27);
            this.butSave.TabIndex = 27;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // WidthBoardBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(479, 282);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.lbGOST);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbFrontBoard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cbSideBoard);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.cbBottomBoards);
            this.Name = "WidthBoardBox";
            this.Text = "Ширина досок ящика";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.ComboBox cbBottomBoards;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbSideBoard;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox cbFrontBoard;
        private System.Windows.Forms.Label lbGOST;
        private System.Windows.Forms.Button butSave;
    }
}