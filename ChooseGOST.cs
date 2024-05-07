using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeBox
{
    public partial class ChooseGOST : Form
    {
        public ChooseGOST()
        {
            InitializeComponent();

            cbGOSTWood.SelectedIndexChanged += cbGOST_SelectedIndexChanged;
            cbTape.SelectedIndexChanged += cbTape_SelectedIndexChanged;
            cbTapeHeight.SelectedIndexChanged += cbTapeHeight_SelectedIndexChanged;
            cbGOSTWood.SelectedIndex = 0;
            cbNails.SelectedIndex = 0;  
            cbTape.SelectedIndex = 0;
        }

        private void cbGOST_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbGOSTWood.SelectedIndex == 0) // ГОСТ 2695. Пиломатериалы лиственных пород
            {
                cbWood.Items.Clear();
                cbWood.Items.Insert(0, "Береза");
                cbWood.Items.Insert(1, "Бук");
                cbWood.Items.Insert(2, "Дуб");
                cbWood.Items.Insert(3, "Клен");
                cbWood.Items.Insert(4, "Липа");
                cbWood.Items.Insert(5, "Ольха");
                cbWood.Items.Insert(6, "Осина");
                cbWood.Items.Insert(7, "Ясень");

                cbWood.SelectedIndex = 0;
            }

            if (cbGOSTWood.SelectedIndex == 1) // ГОСТ 24454 - 80.Пиломатериалы хвойных пород
            {
                cbWood.Items.Clear();
                cbWood.Items.Insert(0, "Ель");
                cbWood.Items.Insert(1, "Кедр");
                cbWood.Items.Insert(2, "Лиственница");
                cbWood.Items.Insert(3, "Пихта");
                cbWood.Items.Insert(4, "Сосна");

                cbWood.SelectedIndex = 0;

            }
            
        }

        private void cbTape_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTape.SelectedIndex == 0) // ГОСТ 503-81 Лента холоднокатаная из низкоуглеродистой стали
            {
                cbTapeHeight.Items.Clear();

                string[] tapeHeightsValues = {
                    "0,05", "0,06", "0,07", "0,08", "0,09", "0,10", "0,11", "0,12", "0,15", "0,18",
                    "0,20", "0,22", "0,25", "0,28", "0,30", "0,32", "0,35", "0,40", "0,45", "0,50",
                    "0,55", "0,57", "0,60", "0,65", "0,70", "0,75", "0,80", "0,855", "0,90", "0,95",
                    "1,0", "1,05", "1,10", "1,15", "1,20", "1,25", "1,30", "1,35", "1,40", "1,45",
                    "1,50", "1,55", "1,60", "1,65", "1,70", "1,75", "1,80", "1,85", "1,90", "1,95",
                    "2,00", "2,10", "2,20", "2,25", "2,30", "2,40", "2,45", "2,50", "2,60", "2,70",
                    "2,80", "2,90", "3,00", "3,10", "3,20", "3,30", "3,40", "3,50", "3,60", "3,80",
                    "3,90", "4,00"
                };

                foreach (string value in tapeHeightsValues)
                    cbTapeHeight.Items.Add(value);


                cbTapeHeight.SelectedIndex = 19;

                cbTapeWidth.Items.Clear();
                string[] tapeWidthValues = {
                    "4", "5", "6", "7", "8", "9", "10", "11", "12", "13", "14", "15",
                    "16", "17", "18", "19", "20", "21", "22", "23", "24", "25", "26",
                    "27", "28", "29", "30", "32", "34", "36", "38", "39", "40", "42",
                    "43", "45", "46", "48", "50", "52", "53", "54", "55", "56", "58",
                    "60", "63", "65", "66", "70", "73", "75", "76", "80", "83", "85",
                    "86", "90", "93", "95", "96", "100", "102", "103", "105", "110",
                    "112", "114", "115", "117", "120", "123", "125", "130", "135",
                    "140", "142", "145", "150"
                };

                foreach (var value in tapeWidthValues)
                    cbTapeWidth.Items.Add(value);


                cbTapeWidth.SelectedIndex = 16;


            }

            if (cbTape.SelectedIndex == 1) //ГОСТ 3560 - 73 Лента стальная упаковочная
            {
                cbTapeHeight.Items.Clear();

                string[] tapeHeightsValues = {
                    "0,20", "0,25", "0,30", "0,40", "0,50", "0,70", "0,80", "0,90",
                    "1,00", "1,20", "1,50", "1,80"
                };

                foreach (string value in tapeHeightsValues)
                {
                    cbTapeHeight.Items.Add(value);
                }

                cbTapeHeight.SelectedIndex = 4;
            }

        }

        private void cbTapeHeight_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTape.SelectedIndex == 1 && cbTapeHeight.Text == "0,80")
            {
                cbTapeWidth.Items.Clear();

                cbTapeWidth.Items.Insert(0, "20");
                cbTapeWidth.Items.Insert(1, "30");
                cbTapeWidth.SelectedIndex = 0;
            }
            else if (cbTape.SelectedIndex == 1 && cbTapeHeight.Text == "1,00")
            {
                cbTapeWidth.Items.Clear();

                cbTapeWidth.Items.Insert(0, "20");
                cbTapeWidth.Items.Insert(1, "30");
                cbTapeWidth.Items.Insert(2, "40");
                cbTapeWidth.Items.Insert(3, "50");
                cbTapeWidth.SelectedIndex = 0;
            }
            else if (cbTape.SelectedIndex == 1 && cbTapeHeight.Text == "1,20")
            {
                cbTapeWidth.Items.Clear();

                cbTapeWidth.Items.Insert(0, "20");
                cbTapeWidth.Items.Insert(1, "30");
                cbTapeWidth.SelectedIndex = 0;
            }
            else if (cbTape.SelectedIndex == 1 && cbTapeHeight.Text == "1,50")
            {
                cbTapeWidth.Items.Clear();

                cbTapeWidth.Items.Insert(0, "30");
                cbTapeWidth.Items.Insert(1, "40");
                cbTapeWidth.Items.Insert(2, "50");
                cbTapeWidth.SelectedIndex = 0;
            }
            else if (cbTape.SelectedIndex == 1 && cbTapeHeight.Text == "1,80")
            {
                cbTapeWidth.Items.Clear();

                cbTapeWidth.Items.Insert(0, "30");
                cbTapeWidth.SelectedIndex = 0;
            }
            else if (cbTape.SelectedIndex == 1)
            {
                cbTapeWidth.Items.Clear();

                cbTapeWidth.Items.Insert(0, "15");
                cbTapeWidth.Items.Insert(1, "20");
                cbTapeWidth.Items.Insert(2, "30");
                cbTapeWidth.Items.Insert(3, "40");
                cbTapeWidth.Items.Insert(4, "50");
                cbTapeWidth.SelectedIndex = 1;
            }
        }

        public string selectedGOSTWood;
        public string selectedWood;
        public string selectedNails;
        public string selectedTape;
        public string selectedTapeHeight;
        public string selectedTapeWidth;

        private void button1_Click(object sender, EventArgs e)
        {
            if (cbNails.SelectedIndex == -1 || cbGOSTWood.SelectedIndex == -1 ||
                cbTape.SelectedIndex == -1 || cbTapeHeight.SelectedIndex == -1 ||
                cbTapeWidth.SelectedIndex == -1 || cbWood.SelectedIndex == -1)
            {
                MessageBox.Show("Ошибка: выберите все значения!!");
            }
            else
            {
                selectedGOSTWood = cbGOSTWood.SelectedItem.ToString();
                selectedWood = cbWood.SelectedItem.ToString();
                selectedNails = cbNails.SelectedItem.ToString();
                selectedTapeHeight = cbTapeHeight.SelectedItem.ToString();
                selectedTapeWidth = cbTapeWidth.SelectedItem.ToString();
                selectedTape = cbTape.SelectedItem.ToString();

                this.Close();
            }
        }
    }
}
