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



namespace WoodenBox
{
    public partial class Form1 : Form
    {

        private Bitmap p;
        

        Box11 box11 = new Box11();
        Box11New box11New = new Box11New();
        Box12 box12 = new Box12();
        //string foldername;

        string savedValue1;
        string savedValue2;
        string savedValue3;


        string foldername;
        public Form1()
        {
            InitializeComponent();
            cbTypeBox.SelectedIndexChanged += SelectedIndexChangedTypeBox;
            cbWidthBoards.SelectedIndexChanged += SelectedIndexChangedWidthBoards;
            cbGOST.SelectedIndex = 0;
            cbTypeBox.SelectedIndex = 0;
            cbWidthBoards.SelectedIndex = 0;
            tbSave.Text = "C:\\Users\\Ksenia\\Desktop\\дт";
            foldername = tbSave.Text;
            textBox1.Text = "МПСТ";
            textBox3.Text = "001";
        }

      

        private void SelectedIndexChangedWidthBoards(object sender, EventArgs e)
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

        private void SelectedIndexChangedTypeBox(object sender, EventArgs e)
        {
            if (cbTypeBox.SelectedIndex == 0)
            {
                tbGap.Enabled = false;
                label6.Enabled = false;
                tbGap.Text = " - ";
                p = new Bitmap(Properties.Resources.I_1);
                pbImageBox.Image = p;
                pbImageBox.Invalidate();
            }
            

            else if (cbTypeBox.SelectedIndex == 1)
            {
                tbGap.Enabled = true;
                label6.Enabled = true;
                tbGap.Text = " 10 ";
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
                tbMassa.Text == String.Empty ||
                tbGap.Text == String.Empty)
            {
                MessageBox.Show("Ошибка: поля не могут быть пустыми!");
                return;
            }
            if (cbTypeBox.SelectedIndex == 1 & !int.TryParse(tbGap.Text, out int result))
            {
                MessageBox.Show("Ошибка: значение зазора должно быть целым числом!!");
                return;
            }
            
            int x = Convert.ToInt32(tbWidthBox.Text);  //ширина
            int y = Convert.ToInt32(tbLengthBox.Text); //длинна
            int z = Convert.ToInt32(tbHeightBox.Text); //высота

            double massa = Convert.ToInt32(tbMassa.Text); //масса груза
            double VBox = x * y * z / 1000; //внутренний объем ящика, дм3
            double PackingDensity = massa / VBox; //Плотность упаковывания, кг/дм3 

            int heightBoard = 22;
            if (PackingDensity <= 1)
                heightBoard = 22;
            if (PackingDensity > 1 & PackingDensity <= 3)
                heightBoard = 25;
            if (PackingDensity > 3)
                heightBoard = 32;

            int GOST = cbGOST.SelectedIndex;
            int widthBoard = cbWidthBoards.SelectedIndex;

            if (cbTypeBox.SelectedIndex == 0) //тип I-1
            {
                
                if(widthBoard == 0) // вычислить оптимальное
                        box11New.СreatingBox11(x, y, z, massa, GOST, heightBoard, foldername);
                        //box11New.СreatingBox11(x, y, z, massa, GOST, heightWidth, foldername);
                //box11.СreatingBox11(x, y, z, massa, GOST, heightWidth, foldername);

                if (widthBoard == 1) // вписать вручную
                    box11.СreatingBox11Manually(x, y, z, massa, GOST, heightBoard, 
                        savedValue1, savedValue2, savedValue3, foldername);
                //ширина, длинна, высота ящика (внутренние), масса груза, ГОСТ, высота доски, 
                //ширина доски, папка 
            }

            if (cbTypeBox.SelectedIndex == 1) //тип I-2
            {
                int gap = Convert.ToInt32(tbGap.Text); //зазор 

                if (widthBoard == 0)
                    box12.СreatingBox12(x, y, z, massa, gap, GOST, heightBoard, foldername);

                if (widthBoard == 1)
                    box12.СreatingBox12Manually(x, y, z, massa, gap, GOST, heightBoard, 
                        savedValue1, savedValue2, savedValue3, foldername);
                //ширина, длинна, высота ящика (внутренние), масса груза, зазор, ГОСТ, высота доски, ширина доски
            }
        }

        private void butSave_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = folderBrowserDialog1.ShowDialog();

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
            newForm.ShowDialog();
        }

       
    }
}
