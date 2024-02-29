using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using KAPITypes;
using System.Runtime.InteropServices;



namespace TreeBox
{
    public partial class Form1 : Form
    {

        private Bitmap p;
        
       
        Box11 box11 = new Box11();
        Box12 box12 = new Box12();
        string foldername;

        string savedValue1;
        string savedValue2;
        string savedValue3;

        public Form1()
        {
            InitializeComponent();
            cbTypeBox.SelectedIndexChanged += cbTypeBox_SelectedIndexChanged;
            cbWidthBoards.SelectedIndexChanged += CbWidthBoards_SelectedIndexChanged;
            cbGOST.SelectedIndex = 0;
            cbTypeBox.SelectedIndex = 0;
            cbWidthBoards.SelectedIndex = 0;
            tbSave.Text = "C:\\Users\\Ksenia\\Desktop\\дт";
            foldername = tbSave.Text;
            textBox1.Text = "МПСТ";
            textBox3.Text = "001";
        }

      

        private void CbWidthBoards_SelectedIndexChanged(object sender, EventArgs e)
        {
           if (cbWidthBoards.SelectedIndex == 1)
            {
                string selectedValue = cbGOST.SelectedItem.ToString();
                WidthBoardBox newForm = new WidthBoardBox();
                newForm.SetLabelValue(selectedValue);

                newForm.cbBottomBoards.SelectedItem = savedValue1;
                newForm.cbSideBoard.SelectedItem = savedValue2;
                newForm.cbFrontBoard.SelectedItem = savedValue3;

                newForm.ShowDialog();

                savedValue1 = newForm.selectedValue1;
                savedValue2 = newForm.selectedValue2;
                savedValue3 = newForm.selectedValue3;

            }
            
        }

        private void cbTypeBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypeBox.SelectedIndex == 0)
            {
                cbGapWidth.Enabled = false;
                label6.Enabled = false;
                cbGapWidth.SelectedIndex = 0;
                p = new Bitmap(Properties.Resources.I_1);
                pbImageBox.Image = p;
                pbImageBox.Invalidate();
            }
            

            else if (cbTypeBox.SelectedIndex == 1)
            {
                cbGapWidth.Enabled = true;
                label6.Enabled = true;
                cbGapWidth.SelectedIndex = 5;
                p = new Bitmap(Properties.Resources.I_2);
                pbImageBox.Image = p;
                pbImageBox.Invalidate();
            }


        }

        private void btBuild_Click(object sender, EventArgs e)
        {
            if (tbHeightBox.Text == String.Empty ||
                tbLengthBox.Text == String.Empty ||
                tbWidthBox.Text == String.Empty ||
                tbMassa.Text == String.Empty)
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }

            if (cbTypeBox.SelectedIndex == 1 & cbGapWidth.SelectedIndex == 0)
            {
                MessageBox.Show("Ошибка: введите значение зазора!!");
                return;
            }

            int x = Convert.ToInt32(tbWidthBox.Text);  //ширина
            int y = Convert.ToInt32(tbLengthBox.Text); //длинна
            int z = Convert.ToInt32(tbHeightBox.Text); //высота

            double massa = Convert.ToInt32(tbMassa.Text); //масса груза

            double VBox = x * y * z / 1000; //внутренний объем ящика, дм3

            double PackingDensity = massa / VBox; //Плотность упаковывания, кг/дм3 

            int boardWidth = 22;

            if (PackingDensity <= 1)
                boardWidth = 22;
            if (PackingDensity > 1 & PackingDensity <= 3)
                boardWidth = 25;
            if (PackingDensity > 3)
                boardWidth = 32;

            double GOST = cbGOST.SelectedIndex;

            if (cbTypeBox.SelectedIndex == 0) //тип I-1
            {
                box11.СreatingBox11(x, y, z, massa, GOST, boardWidth, foldername);
                //ширина, длинна, высота (внутренние), масса груза, ГОСТ, высота доски, плотность упаковывания
            }

            if (cbTypeBox.SelectedIndex == 1) //тип I-2
            {
                double gap = cbGapWidth.SelectedIndex; //зазор (индекс равен зазору в мм)
                
                box12.СreatingBox12(x, y, z, massa, gap, GOST, boardWidth, foldername);
                //ширина, длинна, высота (внутренние), масса груза, зазор, ГОСТ, высота доски
            }



        }

        private void butSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = folderBrowserDialog1.ShowDialog();
            //Надпись выше окна контрола
            folderBrowserDialog1.Description = "Поиск папки";

            if (dialogresult == DialogResult.OK)
            {
                //Извлечение имени папки
                foldername = folderBrowserDialog1.SelectedPath;
            }
            tbSave.Text = foldername;
        }

        private void Information_Click(object sender, EventArgs e)
        {
            Information newForm = new Information();
            newForm.Show();
        }
    }
}
