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

        string savedValue1GOST;
        string savedValue2GOST;
        string savedValue3GOST;
        string savedValue4GOST;

        string savedValue1Manually;
        string savedValue2Manually;
        string savedValue3Manually;
        string savedValue4Manually;


        string savedGOSTWood = "ГОСТ 2695-83 Пиломатериалы лиственных пород";
        string savedWood = "Береза";
        string savedNails = "ГОСТ 4034-63 Гвозди тарные круглые";
        string savedTape = "ГОСТ 503-81 Лента из низкоуглеродистой стали";
        string savedTapeHeight = "0,50";
        string savedTapeWidth = "20";

        //string savedGOSTWood;
        //string savedWood;
        //string savedNails;
        //string savedTape;
        //string savedTapeHeight;
        //string savedTapeWidth;


        string foldername;

        public Form1()
        {
            InitializeComponent();
            cbTypeBox.SelectedIndexChanged += SelectedIndexChangedTypeBox;
            cbWidthBoards.SelectedIndexChanged += SelectedIndexChangedWidthBoards;
            cbTypeBox.SelectedIndex = 0;
            cbWidthBoards.SelectedIndex = 0;
            tbSave.Text = "C:\\Users\\Ksenia\\Desktop\\дт";
            foldername = tbSave.Text;
            tbMPST.Text = "МПСТ";
            tbNumber.Text = "001";

            tbWoodGOST.Enabled = false;
            tbNailsGOST.Enabled = false;
            tbTapeGOST.Enabled = false; 

            tbWoodGOST.Text = $"{savedGOSTWood}; {savedWood}";
            tbNailsGOST.Text = savedNails;
            tbTapeGOST.Text = $"{savedTape}; {savedTapeHeight} x {savedTapeWidth}";
        }

        private void SelectedIndexChangedWidthBoards(object sender, EventArgs e)
        {
           if (cbWidthBoards.SelectedIndex == 1)
           {
                string selectedValue = "111";
                WidthBoardBox newForm = new WidthBoardBox();
                newForm.SetLabelValue(selectedValue);

                newForm.cbBottomBoards.SelectedItem = savedValue1GOST;
                newForm.cbSideBoard.SelectedItem = savedValue2GOST;
                newForm.cbBeltBoard.SelectedItem = savedValue3GOST;
                newForm.cbFrontBoard.SelectedItem = savedValue4GOST;

                newForm.ShowDialog();

                savedValue1GOST = newForm.selectedValue1GOST;
                savedValue2GOST = newForm.selectedValue2GOST;
                savedValue3GOST = newForm.selectedValue3GOST;
                savedValue4GOST = newForm.selectedValue4GOST;

           }

            if (cbWidthBoards.SelectedIndex == 2)
            {
                string selectedValue = "111";
                WidthBoardManually newForm = new WidthBoardManually();
                newForm.SetLabelValue(selectedValue);

                newForm.tbBottomBoards.Text = savedValue1Manually;
                newForm.tbSideBoard.Text = savedValue2Manually;
                newForm.tbBeltBoard.Text = savedValue3Manually;
                newForm.tbFrontBoard.Text = savedValue4Manually;

                newForm.ShowDialog();

                savedValue1Manually = newForm.selectedValue1Manually;
                savedValue2Manually = newForm.selectedValue2Manually;
                savedValue3Manually = newForm.selectedValue3Manually;
                savedValue4Manually = newForm.selectedValue4Manually;

            }
        }

        private void btChooseGOST_Click(object sender, EventArgs e)
        {
            ChooseGOST newForm = new ChooseGOST();

            newForm.cbGOSTWood.SelectedItem = savedGOSTWood;
            newForm.cbWood.SelectedItem = savedWood;
            newForm.cbNails.SelectedItem = savedNails;
            newForm.cbTape.SelectedItem = savedTape;
            newForm.cbTapeHeight.SelectedItem = savedTapeHeight;
            newForm.cbTapeWidth.SelectedItem = savedTapeWidth;

            newForm.ShowDialog();

            savedGOSTWood = newForm.selectedGOSTWood;
            savedWood = newForm.selectedWood;
            savedNails = newForm.selectedNails;
            savedTape = newForm.selectedTape;
            savedTapeHeight = newForm.selectedTapeHeight;
            savedTapeWidth = newForm.selectedTapeWidth;

            tbWoodGOST.Text = $"{savedGOSTWood}, {savedWood}";
            tbNailsGOST.Text = savedNails;
            tbTapeGOST.Text = $"{savedTape}, {savedTapeHeight}x{savedTapeWidth}";
            


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

            int WoodGOST = 0;
            if (savedGOSTWood == "ГОСТ 2695-83 Пиломатериалы лиственных пород")
                WoodGOST = 0;
            else if (savedGOSTWood == "ГОСТ 24454-80 Пиломатериалы хвойных пород")
                WoodGOST = 1;

            int widthBoard = cbWidthBoards.SelectedIndex;

            string marking = tbMPST.Text;
            int number = Convert.ToInt32(tbNumber.Text);

            if (cbTypeBox.SelectedIndex == 0) //тип I-1
            {
                
                if(widthBoard == 0) // вычислить оптимальное
                    box11.СreatingBox11(x, y, z, WoodGOST, heightBoard, foldername, marking, number);

                if (widthBoard == 1) // вписать вручную
                    box11.СreatingBox11Manually(x, y, z, heightBoard, 
                        savedValue1GOST, savedValue2GOST, savedValue3GOST, savedValue4GOST, foldername, marking, number);

                if (widthBoard == 2) // вписать вручную
                    box11.СreatingBox11Manually(x, y, z, heightBoard,
                        savedValue1Manually, savedValue2Manually, savedValue3Manually, savedValue4Manually, foldername, marking, number);

            }

            if (cbTypeBox.SelectedIndex == 1) //тип I-2
            {
                int gap = Convert.ToInt32(tbGap.Text); //зазор 

                if (widthBoard == 0)
                    box12.СreatingBox12(x, y, z, gap, WoodGOST, heightBoard, foldername, marking, number);

                if (widthBoard == 1)
                    box12.СreatingBox12Manually(x, y, z, gap, heightBoard, 
                        savedValue1GOST, savedValue2GOST, savedValue3GOST, savedValue4GOST, foldername, marking, number);
                
                if (widthBoard == 2)
                    box12.СreatingBox12Manually(x, y, z, gap, heightBoard,
                        savedValue1Manually, savedValue2Manually, savedValue3Manually, savedValue4Manually, foldername, marking, number);
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

        private void Specification_Click(object sender, EventArgs e)
        {
            string marking = tbMPST.Text;  
            int number = Convert.ToInt32(tbNumber.Text);
           
            specification.CreateSpecification(savedGOSTWood, savedNails, savedTape, savedTapeHeight, savedTapeWidth, marking, number, foldername);

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
            var t = part.material;
            MessageBox.Show($"Материал   {t}   ");
            part.Update();


        }

        
    }
}
