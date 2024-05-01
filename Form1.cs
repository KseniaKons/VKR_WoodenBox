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
using KompasAPI7;
using System.Runtime.InteropServices;
using TreeBox;
using System.Xml.Linq;



namespace WoodenBox
{
    public partial class Form1 : Form
    {

        private Bitmap p;
 
        Box11 box11 = new Box11();
        Box12 box12 = new Box12();

        SpecificationBox specification = new SpecificationBox();

        string savedValue1;
        string savedValue2;
        string savedValue3;
        string savedValue4;


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
            tbMPST.Text = "МПСТ";
            tbNumber.Text = "001";
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
                newForm.cbBeltBoard.SelectedItem = savedValue3;
                newForm.cbFrontBoard.SelectedItem = savedValue4;

                newForm.ShowDialog();

                savedValue1 = newForm.selectedValue1;
                savedValue2 = newForm.selectedValue2;
                savedValue3 = newForm.selectedValue3;
                savedValue4 = newForm.selectedValue4;

            }
            
        }

        private void SelectedIndexChangedTypeBox(object sender, EventArgs e)
        {
            if (cbTypeBox.SelectedIndex == 0)
            {
                tbGap.Enabled = false;
                label6.Enabled = false;
                tbGap.Text = " 0 ";
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
                MessageBox.Show("Поля не могут быть пустыми!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbTypeBox.SelectedIndex == 1 & !int.TryParse(tbGap.Text, out int result))
            {
                MessageBox.Show("Значения должны быть целыми положительными числами!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(tbHeightBox.Text, out int result1) ||
                !int.TryParse(tbLengthBox.Text, out int result2) ||
                !int.TryParse(tbWidthBox.Text, out int result3) ||
                !int.TryParse(tbMassa.Text, out int result4))
            {
                MessageBox.Show("Значения должны быть целыми положительными числами!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(tbHeightBox.Text) <= 0 ||
                int.Parse(tbLengthBox.Text) <= 0 ||
                int.Parse(tbWidthBox.Text) <= 0 ||
                int.Parse(tbMassa.Text) <= 0)
            {
                MessageBox.Show("Ошибка: значения должны быть целыми положительными числами!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbTypeBox.SelectedIndex == 1 & int.Parse(tbGap.Text) <=0 )
            {
                MessageBox.Show("Ошибка: значения должны быть целыми положительными числами!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

            string marking = tbMPST.Text;
            int number = Convert.ToInt32(tbNumber.Text);

            if (cbTypeBox.SelectedIndex == 0) //тип I-1
            {
                
                if(widthBoard == 0) // вычислить оптимальное
                    box11.СreatingBox11(x, y, z, GOST, heightBoard, foldername, marking, number);

                if (widthBoard == 1) // вписать вручную
                    box11.СreatingBox11Manually(x, y, z, heightBoard, 
                        savedValue1, savedValue2, savedValue3, savedValue4, foldername, marking, number);
                
            }

            if (cbTypeBox.SelectedIndex == 1) //тип I-2
            {
                int gap = Convert.ToInt32(tbGap.Text); //зазор 

                if (widthBoard == 0)
                    box12.СreatingBox12(x, y, z, gap, GOST, heightBoard, foldername, marking, number);

                if (widthBoard == 1)
                    box12.СreatingBox12Manually(x, y, z, gap, heightBoard, 
                        savedValue1, savedValue2, savedValue3, savedValue4, foldername, marking, number);
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

        private void btSpecification_Click(object sender, EventArgs e)
        {
            int GOST = cbGOST.SelectedIndex;
            string marking = tbMPST.Text;  
            int number = Convert.ToInt32(tbNumber.Text);
           
            specification.CreateSpecification(GOST, marking, number, foldername);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            KompasObject kompas;

            try
            {
                kompas = (KompasObject)Marshal.
                    GetActiveObject("KOMPAS.Application.5");
            }
            catch
            {
                kompas = (KompasObject)Activator.
                    CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));
            }
            if (kompas == null)
                return;

            kompas.Visible = true;
           
            ksDocument3D kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
            ksPart part = kompas_document_3D.GetPart((int)Part_Type.pTop_Part);

            ksColorParam kscolor = (ksColorParam)part.ColorParam();
            var u = kscolor.color;
            MessageBox.Show($"Цвет   {u}   ");
            part.Update();


        }
    }
}
