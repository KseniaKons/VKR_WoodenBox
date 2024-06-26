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
using WoodenBox;
using System.Xml.Linq;
using static WoodenBox.SpecificationBox;
using System.IO;
using System.Resources;
using TreeBox.Properties;



namespace WoodenBox
{
    public partial class Form1 : Form
    {

        private Bitmap p;
 
        Box11 box11 = new Box11();
        Box12 box12 = new Box12();
        SpecificationBox specification = new SpecificationBox();

        public string savedGOSTWood = "ГОСТ 2695-83 Пиломатериалы лиственных пород";
        public string savedWood = "Береза";
        public string savedNails = "ГОСТ 4034-63 Гвозди тарные круглые";
        public string savedTape = "ГОСТ 503-81 Лента из низкоуглеродистой стали";
        public string savedTapeHeight = "0,50";
        public string savedTapeWidth = "20";

        public string foldername;

        public Form1()
        {
            InitializeComponent();
            cbTypeBox.SelectedIndexChanged += SelectedIndexChangedTypeBox;
            cbTypeBox.SelectedIndex = 0;
            
            string defoltPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\Ящик";
            Directory.CreateDirectory(defoltPath);
            tbSave.Text = defoltPath;
            foldername = tbSave.Text;

            tbMPST.Text = "МПСТ";
            tbNumber.Text = "001";

            tbWoodGOST.Enabled = false;
            tbNailsGOST.Enabled = false;
            tbTapeGOST.Enabled = false;

            rbCalculate.Checked = true;

            tbWoodGOST.Text = $"{savedGOSTWood}; {savedWood}";
            tbNailsGOST.Text = savedNails;
            tbTapeGOST.Text = $"{savedTape}; {savedTapeHeight} x {savedTapeWidth}";
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

            tbWoodGOST.Text = $"{savedGOSTWood}; {savedWood}";
            tbNailsGOST.Text = savedNails;
            tbTapeGOST.Text = $"{savedTape}; {savedTapeHeight} x {savedTapeWidth}";
            
        }

        private void SelectedIndexChangedTypeBox(object sender, EventArgs e)
        {
            if (cbTypeBox.SelectedIndex == 0)
            {
                tbGap.Enabled = false;
                label6.Enabled = false;
                tbGap.Text = "0";
                p = new Bitmap(Resources.I_1);
                pbImageBox.Image = p;
                pbImageBox.Invalidate();
            }
            

            else if (cbTypeBox.SelectedIndex == 1)
            {
                tbGap.Enabled = true;
                label6.Enabled = true;
                tbGap.Text = "20";
                p = new Bitmap(Resources.I_2);
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
                MessageBox.Show("Поля не могут быть пустыми!", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbTypeBox.SelectedIndex == 1 & !int.TryParse(tbGap.Text, out int result))
            {
                MessageBox.Show("Значения должны быть целыми положительными числами!!", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(tbHeightBox.Text, out int result1) ||
                !int.TryParse(tbLengthBox.Text, out int result2) ||
                !int.TryParse(tbWidthBox.Text, out int result3) ||
                !int.TryParse(tbMassa.Text, out int result4))
            {
                MessageBox.Show("Значения должны быть целыми положительными числами!!", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (!int.TryParse(tbNumber.Text, out int result5))
            {
                MessageBox.Show("Некорректное значение нумерации в обозначении!!", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(tbHeightBox.Text) <= 0 ||
                int.Parse(tbLengthBox.Text) <= 0 ||
                int.Parse(tbWidthBox.Text) <= 0 ||
                int.Parse(tbMassa.Text) <= 0)
            {
                MessageBox.Show("Значения должны быть целыми положительными числами!", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (cbTypeBox.SelectedIndex == 1 & int.Parse(tbGap.Text) <=0 )
            {
                MessageBox.Show("Значения должны быть целыми положительными числами!!", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cbTypeBox.SelectedIndex == 1 & int.Parse(tbGap.Text) > 100)
            {
                MessageBox.Show("Значение зазора слишком большое!!", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(tbHeightBox.Text) > 1000 ||
                int.Parse(tbLengthBox.Text) > 1000 ||
                int.Parse(tbWidthBox.Text) > 1000)
            {
                MessageBox.Show("Некорректное значение габаритных размеров ящика (значение больше 1000)!!", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (int.Parse(tbHeightBox.Text) < 250 ||
                int.Parse(tbLengthBox.Text) < 250 ||
                int.Parse(tbWidthBox.Text) < 250)
            {
                MessageBox.Show("Некорректное значение габаритных размеров ящика (значение меньше 250)!!", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (int.Parse(tbMassa.Text) > 1000 || int.Parse(tbMassa.Text) < 200)
            {
                MessageBox.Show("Некоректное значение массы груза (от 200 до 1000 кг)!!", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rbWrite.Checked && 
                (tbBottomBoards.Text == String.Empty ||
                tbAroundBoard.Text == String.Empty ||
                tbFrontBoard.Text == String.Empty ||
                tbSideBoard.Text == String.Empty ))
            {
                MessageBox.Show("Поля не могут быть пустыми!!", "Ошибка", MessageBoxButtons.OK, 
                    MessageBoxIcon.Error);
                return;
            }           
            
            if (rbWrite.Checked && 
                (!int.TryParse(tbBottomBoards.Text, out int result10) ||
                !int.TryParse(tbAroundBoard.Text, out int result11) ||
                !int.TryParse(tbFrontBoard.Text, out int result12) ||
                !int.TryParse(tbSideBoard.Text, out int result13)))
            {
                MessageBox.Show("Некорректные значения ширины досок (от 50 до 300)!!!", "Ошибка", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (rbWrite.Checked && (int.Parse(tbBottomBoards.Text) < 50 ||
                int.Parse(tbAroundBoard.Text) < 50 ||
                int.Parse(tbFrontBoard.Text) < 50 ||
                int.Parse(tbSideBoard.Text) < 50 ||
                int.Parse(tbBottomBoards.Text) > 300 ||
                int.Parse(tbAroundBoard.Text) > 300 ||
                int.Parse(tbFrontBoard.Text) > 300 ||
                int.Parse(tbSideBoard.Text) > 300))
            {
                MessageBox.Show("Некорректные значения ширины досок (от 50 до 300)!!!", 
                    "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int x = Convert.ToInt32(tbWidthBox.Text);  //ширина
            int y = Convert.ToInt32(tbLengthBox.Text); //длинна
            int z = Convert.ToInt32(tbHeightBox.Text); //высота

            double massa = Convert.ToInt32(tbMassa.Text); //масса груза
            double VBox = x * y * z / 1000000; //внутренний объем ящика, дм3
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

            string materials = string.Empty;
            double density = 0;

            Dictionary<string, (string, double)> woodMaterials = new Dictionary<string, (string, double)>()
            {
                { "Береза", ("Пиломатериал береза ГОСТ 2695-83", 0.65) },
                { "Бук", ("Пиломатериал бук ГОСТ 2695-83", 0.75) },
                { "Дуб", ("Пиломатериал дуб ГОСТ 2695-83", 0.9) },
                { "Клен", ("Пиломатериал клен ГОСТ 2695-83", 0.65) },
                { "Липа", ("Пиломатериал липа ГОСТ 2695-83", 0.45) },
                { "Ольха", ("Пиломатериал ольха ГОСТ 2695-83", 0.7) },
                { "Осина", ("Пиломатериал осина ГОСТ 2695-83", 0.7) },
                { "Ясень", ("Пиломатериал ясень ГОСТ 2695-83", 0.75) },
                { "Ель", ("Пиломатериал ель ГОСТ 8486-86", 0.45) },
                { "Кедр", ("Пиломатериал кедр ГОСТ 8486-86", 0.5) },
                { "Лиственница", ("Пиломатериал лиственница ГОСТ 8486-86", 0.5) },
                { "Пихта", ("Пиломатериал пихта ГОСТ 8486-86", 0.55) },
                { "Сосна", ("Пиломатериал сосна ГОСТ 8486-86", 0.6) },
            };

            if (woodMaterials.ContainsKey(savedWood))
            {
                (materials, density) = woodMaterials[savedWood];
            }

            string marking = tbMPST.Text;
            int number = Convert.ToInt32(tbNumber.Text);

            if (cbTypeBox.SelectedIndex == 0) //тип I-1
            {
                
                if(rbCalculate.Checked) // вычислить оптимальное
                    box11.СreatingBox11(x, y, z, WoodGOST, heightBoard, foldername, marking, number, materials, density);

                if (rbChGost.Checked) // вписать вручную
                    box11.СreatingBox11Manually(x, y, z, heightBoard, 
                        cbBottomBoards.Text, cbSideBoard.Text, cbAroundBoard.Text, cbFrontBoard.Text, foldername, 
                        marking, number, materials, density);

                if (rbWrite.Checked) // вписать вручную
                    box11.СreatingBox11Manually(x, y, z, heightBoard,
                        tbBottomBoards.Text, tbSideBoard.Text, tbAroundBoard.Text, tbFrontBoard.Text, 
                        foldername, marking, number, materials, density);

            }

            if (cbTypeBox.SelectedIndex == 1) //тип I-2
            {
                int gap = Convert.ToInt32(tbGap.Text); //зазор 

                if (rbCalculate.Checked)
                    box12.СreatingBox12(x, y, z, gap, WoodGOST, heightBoard, foldername, 
                        marking, number, materials, density);

                if (rbChGost.Checked)
                    box12.СreatingBox12Manually(x, y, z, gap, heightBoard,
                        cbBottomBoards.Text, cbSideBoard.Text, cbAroundBoard.Text, cbFrontBoard.Text, 
                        foldername, marking, number, materials, density);
                
                if (rbWrite.Checked)
                    box12.СreatingBox12Manually(x, y, z, gap, heightBoard,
                        tbBottomBoards.Text, tbSideBoard.Text, tbAroundBoard.Text, tbFrontBoard.Text, 
                        foldername, marking, number, materials, density);
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

            if (!InformationAboutBox.ValueBox.Any())
            {
                MessageBox.Show("Ящик не был построен!",
                    "Ошибка создания спецификации!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string marking = tbMPST.Text;
            int number = Convert.ToInt32(tbNumber.Text);

            string WoodGOST = "ГОСТ";
            if (savedGOSTWood == "ГОСТ 2695-83 Пиломатериалы лиственных пород")
                WoodGOST = "ГОСТ 2695-83";
            else if (savedGOSTWood == "ГОСТ 24454-80 Пиломатериалы хвойных пород")
                WoodGOST = "ГОСТ 24454-80";

            double heightBoard = InformationAboutBox.ValueBoxForReport[0].heightBoard;

            string nameNails = "Гвозди", gostNails = "ГОСТ";
            double massNails = 0;
            if (savedNails == "ГОСТ 4034-63 Гвозди тарные круглые")
            {
                if (heightBoard == 22)
                { 
                    nameNails = "Гвозди П 1,8х40";
                    massNails = 0.000783;
                }
                if (heightBoard == 25)
                { 
                    nameNails = "Гвозди П 2х45";
                    massNails = 0.00111;
                }
                if (heightBoard == 32)
                { 
                    nameNails = "Гвозди П 2,5х60";
                    massNails = 0.00229;
                }
                gostNails = "ГОСТ 4034-63";
            }

            if (savedNails == "ГОСТ 4029-63 Гвозди толевые круглые")
            {
                nameNails = "Гвозди 2,5х40";
                massNails = 0.00152;
                gostNails = "ГОСТ 4029-63";
            }
            if (savedNails == "ГОСТ 4028-63 Гвозди строительные")
            {
                if (heightBoard == 22 || heightBoard == 25)
                { 
                    nameNails = "Гвозди П 1,6х40";
                    massNails = 0.000633;
                }
                if (heightBoard == 32)
                { 
                    nameNails = "Гвозди П 1,6х50";
                    massNails = 0.000791;
                }
                gostNails = "ГОСТ 4028-63";
            }

            string nameTape = "Лента";
            string gostTape = "ГОСТ";
            if (savedTape == "ГОСТ 503-81 Лента из низкоуглеродистой стали")
            {
                nameTape = $"Лента Н-{savedTapeHeight}х{savedTapeWidth}";
                gostTape = "ГОСТ 503-81";
            }
            if (savedTape == "ГОСТ 3560-73 Лента стальная упаковочная")
            {
                nameTape = $"Лента Н-2-{savedTapeHeight}х{savedTapeWidth}";
                gostTape = "ГОСТ 3560-73";
            }

            specification.CreateSpecification(WoodGOST, savedWood, gostNails, nameNails, 
                massNails, gostTape, nameTape, heightBoard, marking, number, foldername);
        }

        private void btReportBox_Click(object sender, EventArgs e)
        {
            if (!InformationAboutBox.ValueBox.Any())
            {
                MessageBox.Show("Ящик не был построен!",
                    "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            double heightBoard = InformationAboutBox.ValueBoxForReport[0].heightBoard;

            string nameNails = "Гвозди";
            double massOneNails = 0;
            if (savedNails == "ГОСТ 4034-63 Гвозди тарные круглые")
            {
                if (heightBoard == 22)
                {
                    nameNails = "Гвозди П 1,8х40";
                    massOneNails = 0.000783;
                }
                if (heightBoard == 25)
                {
                    nameNails = "Гвозди П 2х45";
                    massOneNails = 0.00111;
                }

                if (heightBoard == 32)
                {
                    nameNails = "Гвозди П 2,5х60";
                    massOneNails = 0.00229;
                }
            }
            if (savedNails == "ГОСТ 4029-63 Гвозди толевые круглые")
            {
                nameNails = "Гвозди 2,5х40";
                massOneNails = 0.00152;
            }
            if (savedNails == "ГОСТ 4028-63 Гвозди строительные")
            {
                if (heightBoard == 22 || heightBoard == 25)
                {
                    nameNails = "Гвозди П 1,6х40";
                    massOneNails = 0.000633;
                }
                if (heightBoard == 32)
                {
                    nameNails = "Гвозди П 1,6х50";
                    massOneNails = 0.000791;
                }
            }

            string nameTape = "Лента";

            if (savedTape == "ГОСТ 503-81 Лента из низкоуглеродистой стали")
            {
                nameTape = $"Лента Н-{savedTapeHeight}х{savedTapeWidth}";
            }

            if (savedTape == "ГОСТ 3560-73 Лента стальная упаковочная")
            {
                nameTape = $"Лента Н-2-{savedTapeHeight}х{savedTapeWidth}";
            }

            double  massNails = massOneNails * InformationAboutBox.ValueBox[0].colNails;
            massNails = Math.Round(massNails, 2);

            InformationAboutBox.ForReport.Clear();
            InformationAboutBox.ForReport.Add(new ForReport
            {
                nameNails = nameNails,
                gostNails = savedNails,
                massNails = $"{massNails}",

                nameTape = nameTape,
                gostTape = savedTape,
                lenghtTape = $"{InformationAboutBox.ValueBox[0].lengthTape}",

                wood = savedWood,
                gostWood = savedGOSTWood,

            });

            ReportBox report = new ReportBox();
            report.foldername = foldername;

            report.ShowDialog();
        }

        //private void button1_Click(object sender, EventArgs e)
        //{
        //    KompasObject kompas;

        //    try
        //    {
        //        kompas = (KompasObject)Marshal.
        //            GetActiveObject("KOMPAS.Application.5");
        //    }
        //    catch
        //    {
        //        kompas = (KompasObject)Activator.
        //            CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));
        //    }
        //    if (kompas == null)
        //        return;

        //    kompas.Visible = true;

        //    ksDocument3D kompas_document_3D = (ksDocument3D)kompas.ActiveDocument3D();
        //    ksPart part = kompas_document_3D.GetPart((int)Part_Type.pTop_Part);

        //    ksColorParam kscolor = (ksColorParam)part.ColorParam();
        //    var u = kscolor.color;
        //    var t = part.material;
        //    MessageBox.Show($"Материал   {t}   ");
        //    part.Update();


        //}

        private void rbCalculate_CheckedChanged(object sender, EventArgs e)
        {
            if (rbCalculate.Checked)
            {
                cbAroundBoard.Enabled = false;
                cbBottomBoards.Enabled = false;
                cbFrontBoard.Enabled = false;  
                cbSideBoard.Enabled = false;

                tbAroundBoard.Enabled = false; 
                tbBottomBoards.Enabled = false;
                tbFrontBoard.Enabled = false;   
                tbSideBoard.Enabled = false;

            }
        }

        

        void SetComboBoxItems(System.Windows.Forms.ComboBox comboBox, List<string> items, int selectedIndex)
        {
            comboBox.Items.Clear();
            foreach (string item in items)
            {
                comboBox.Items.Add(item);
            }
            comboBox.SelectedIndex = selectedIndex;
        }


        bool leaves = false;
        bool conifer = false;
        private void rbChGost_CheckedChanged(object sender, EventArgs e)
        {
            if (rbChGost.Checked)
            {
                cbAroundBoard.Visible = true;
                cbBottomBoards.Visible = true;
                cbFrontBoard.Visible = true;
                cbSideBoard.Visible = true;

                cbAroundBoard.Enabled = true;
                cbBottomBoards.Enabled = true;
                cbFrontBoard.Enabled = true;
                cbSideBoard.Enabled = true;

                tbAroundBoard.Visible = false;
                tbBottomBoards.Visible = false;
                tbFrontBoard.Visible = false;
                tbSideBoard.Visible = false;

                

                if (savedGOSTWood == "ГОСТ 2695-83 Пиломатериалы лиственных пород")
                {
                    conifer = false;

                    if (!leaves)
                    {
                        List<string> leavesItems = new List<string> { "80", "90", "100", "110", 
                            "130", "150", "180", "200" };

                        SetComboBoxItems(cbFrontBoard, leavesItems, 0);
                        SetComboBoxItems(cbAroundBoard, leavesItems, 0);
                        SetComboBoxItems(cbSideBoard, leavesItems, 0);
                        SetComboBoxItems(cbBottomBoards, leavesItems, 0);

                        leaves = true;
                    }
                }
                else if (savedGOSTWood == "ГОСТ 24454-80 Пиломатериалы хвойных пород")
                {
                    leaves = false;

                    if (!conifer)
                    {

                        List<string> coniferItems = new List<string> { "75", "100", "125", "150", 
                            "175", "200", "225", "250", "275" };

                        SetComboBoxItems(cbFrontBoard, coniferItems, 0);
                        SetComboBoxItems(cbAroundBoard, coniferItems, 0);
                        SetComboBoxItems(cbSideBoard, coniferItems, 0);
                        SetComboBoxItems(cbBottomBoards, coniferItems, 0);

                        conifer = true;
                    }
                }

            }
        }

        private void rbWrite_CheckedChanged(object sender, EventArgs e)
        {
            if (rbWrite.Checked)
            {
                tbAroundBoard.Visible = true;
                tbBottomBoards.Visible = true;
                tbFrontBoard.Visible = true;
                tbSideBoard.Visible = true;

                tbAroundBoard.Enabled = true;
                tbBottomBoards.Enabled = true;
                tbFrontBoard.Enabled = true;
                tbSideBoard.Enabled = true;

                cbAroundBoard.Visible = false;
                cbBottomBoards.Visible = false;
                cbFrontBoard.Visible = false;
                cbSideBoard.Visible = false;
            }
        }

       
    }
}
