namespace TreeBox
{
    partial class WidthBoardManually
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
            this.label16 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.butSave = new System.Windows.Forms.Button();
            this.lbGOST = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tbBottomBoards = new System.Windows.Forms.TextBox();
            this.tbSideBoard = new System.Windows.Forms.TextBox();
            this.tbBeltBoard = new System.Windows.Forms.TextBox();
            this.tbFrontBoard = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(35, 247);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(239, 16);
            this.label16.TabIndex = 49;
            this.label16.Text = "Ширина планок торцевого щита, мм";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(34, 182);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(173, 16);
            this.label15.TabIndex = 48;
            this.label15.Text = "Ширина планок пояса, мм";
            // 
            // butSave
            // 
            this.butSave.Location = new System.Drawing.Point(308, 324);
            this.butSave.Name = "butSave";
            this.butSave.Size = new System.Drawing.Size(96, 27);
            this.butSave.TabIndex = 47;
            this.butSave.Text = "Сохранить";
            this.butSave.UseVisualStyleBackColor = true;
            this.butSave.Click += new System.EventHandler(this.butSave_Click);
            // 
            // lbGOST
            // 
            this.lbGOST.AutoSize = true;
            this.lbGOST.Location = new System.Drawing.Point(34, 22);
            this.lbGOST.Name = "lbGOST";
            this.lbGOST.Size = new System.Drawing.Size(56, 16);
            this.lbGOST.TabIndex = 46;
            this.lbGOST.Text = "lbGOST";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 122);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(305, 16);
            this.label1.TabIndex = 45;
            this.label1.Text = "Ширина досок бокового и торцевого щита, мм";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 57);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(212, 16);
            this.label9.TabIndex = 43;
            this.label9.Text = "Ширина досок дна и крышки, мм";
            // 
            // tbBottomBoards
            // 
            this.tbBottomBoards.Location = new System.Drawing.Point(38, 76);
            this.tbBottomBoards.Name = "tbBottomBoards";
            this.tbBottomBoards.Size = new System.Drawing.Size(341, 22);
            this.tbBottomBoards.TabIndex = 52;
            // 
            // tbSideBoard
            // 
            this.tbSideBoard.Location = new System.Drawing.Point(37, 141);
            this.tbSideBoard.Name = "tbSideBoard";
            this.tbSideBoard.Size = new System.Drawing.Size(341, 22);
            this.tbSideBoard.TabIndex = 53;
            // 
            // tbBeltBoard
            // 
            this.tbBeltBoard.Location = new System.Drawing.Point(38, 201);
            this.tbBeltBoard.Name = "tbBeltBoard";
            this.tbBeltBoard.Size = new System.Drawing.Size(341, 22);
            this.tbBeltBoard.TabIndex = 54;
            // 
            // tbFrontBoard
            // 
            this.tbFrontBoard.Location = new System.Drawing.Point(37, 266);
            this.tbFrontBoard.Name = "tbFrontBoard";
            this.tbFrontBoard.Size = new System.Drawing.Size(341, 22);
            this.tbFrontBoard.TabIndex = 55;
            // 
            // WidthBoardManually
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.ClientSize = new System.Drawing.Size(422, 365);
            this.Controls.Add(this.tbFrontBoard);
            this.Controls.Add(this.tbBeltBoard);
            this.Controls.Add(this.tbSideBoard);
            this.Controls.Add(this.tbBottomBoards);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.butSave);
            this.Controls.Add(this.lbGOST);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label9);
            this.Name = "WidthBoardManually";
            this.Text = "Ширина досок ящика вписанные в ручную";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Button butSave;
        private System.Windows.Forms.Label lbGOST;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox tbBottomBoards;
        public System.Windows.Forms.TextBox tbSideBoard;
        public System.Windows.Forms.TextBox tbBeltBoard;
        public System.Windows.Forms.TextBox tbFrontBoard;
    }
}