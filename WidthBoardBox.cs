using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WoodenBox
{
   
    public partial class WidthBoardBox : Form
    {

        public WidthBoardBox()
        {
            InitializeComponent();
        }




        public void SetLabelValue(string value)
        {
            lbGOST.Text = value;

            if (lbGOST.Text == "ГОСТ 2695. Пиломатериалы лиственных пород")
            {
                //cbFrontBoard.Items.Insert(0, "80");
                //cbFrontBoard.Items.Insert(1, "90");
                //cbFrontBoard.Items.Insert(2, "100");
                //cbFrontBoard.Items.Insert(3, "110");
                //cbFrontBoard.Items.Insert(4, "130");
                //cbFrontBoard.Items.Insert(5, "150");
                //cbFrontBoard.Items.Insert(6, "180");
                //cbFrontBoard.Items.Insert(7, "200");

                cbSideBoard.Items.Insert(0, "80");
                cbSideBoard.Items.Insert(1, "90");
                cbSideBoard.Items.Insert(2, "100");
                cbSideBoard.Items.Insert(3, "110");
                cbSideBoard.Items.Insert(4, "130");
                cbSideBoard.Items.Insert(5, "150");
                cbSideBoard.Items.Insert(6, "180");
                cbSideBoard.Items.Insert(7, "200");

                cbBottomBoards.Items.Insert(0, "80");
                cbBottomBoards.Items.Insert(1, "90");
                cbBottomBoards.Items.Insert(2, "100");
                cbBottomBoards.Items.Insert(3, "110");
                cbBottomBoards.Items.Insert(4, "130");
                cbBottomBoards.Items.Insert(5, "150");
                cbBottomBoards.Items.Insert(6, "180");
                cbBottomBoards.Items.Insert(7, "200");

            }
            else if (lbGOST.Text == "ГОСТ 24454-80. Пиломатериалы хвойных пород")
            {
                //cbFrontBoard.Items.Insert(0, "75");
                //cbFrontBoard.Items.Insert(1, "100");
                //cbFrontBoard.Items.Insert(2, "125");
                //cbFrontBoard.Items.Insert(3, "150");
                //cbFrontBoard.Items.Insert(4, "175");
                //cbFrontBoard.Items.Insert(5, "200");
                //cbFrontBoard.Items.Insert(6, "225");
                //cbFrontBoard.Items.Insert(7, "250");
                //cbFrontBoard.Items.Insert(8, "275");

                cbSideBoard.Items.Insert(0, "75");
                cbSideBoard.Items.Insert(1, "100");
                cbSideBoard.Items.Insert(2, "125");
                cbSideBoard.Items.Insert(3, "150");
                cbSideBoard.Items.Insert(4, "175");
                cbSideBoard.Items.Insert(5, "200");
                cbSideBoard.Items.Insert(6, "225");
                cbSideBoard.Items.Insert(7, "250");
                cbSideBoard.Items.Insert(8, "275");

                cbBottomBoards.Items.Insert(0, "75");
                cbBottomBoards.Items.Insert(1, "100");
                cbBottomBoards.Items.Insert(2, "125");
                cbBottomBoards.Items.Insert(3, "150");
                cbBottomBoards.Items.Insert(4, "175");
                cbBottomBoards.Items.Insert(5, "200");
                cbBottomBoards.Items.Insert(6, "225");
                cbBottomBoards.Items.Insert(7, "250");
                cbBottomBoards.Items.Insert(8, "275");
            }


        }

        public string selectedValue1;
        public string selectedValue2;
        public string selectedValue3;

        public void butSave_Click(object sender, EventArgs e)
        {
            
            if (cbBottomBoards.SelectedIndex == -1 || cbSideBoard.SelectedIndex == -1)
            {
                MessageBox.Show("Ошибка: введите значение ширины досок!!");
            }
            else
            {
                selectedValue1 = cbBottomBoards.SelectedItem.ToString(); //дно
                selectedValue2 = cbSideBoard.SelectedItem.ToString(); //бок
                //selectedValue3 = cbFrontBoard.SelectedItem.ToString(); //торец

                this.Close();
            }
        }
    }
}
