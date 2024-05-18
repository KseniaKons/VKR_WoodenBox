using Kompas6API5;
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
    public partial class ReportBox : Form
    {
        string foldername;
        double col_cap = InformationAboutBox.ValueBoxForReport[0].col_cap;
        double w_cap = InformationAboutBox.ValueBoxForReport[0].w_cap;
        double col_side = InformationAboutBox.ValueBoxForReport[0].col_side;
        double w_side = InformationAboutBox.ValueBoxForReport[0].w_side;
        double lenghtBox = InformationAboutBox.ValueBoxForReport[0].lenghtBox;
        double heightBoard = InformationAboutBox.ValueBoxForReport[0].heightBoard;
        double gap = InformationAboutBox.ValueBoxForReport[0].gap;

        string wood = InformationAboutBox.WoodBoxForReport[0].Wood;
        string woodGOST = InformationAboutBox.WoodBoxForReport[0].WoodGOST;


        string front1 = InformationAboutBox.ValueBox[0].front1;
        string front2 = InformationAboutBox.ValueBox[0].front2;
        string around1 = InformationAboutBox.ValueBox[0].around1;
        string around2 = InformationAboutBox.ValueBox[0].around2;

        double typeBox = InformationAboutBox.ValueBox[0].TypeBox;

        public ReportBox()
        {
            InitializeComponent();
            // внешние
            tbHeightBox.Enabled = false; // высота
            tbWidthBox.Enabled = false; // ширина
            tbLenghtBox.Enabled = false; //длинна

            if (typeBox == 1)
            {
                tbHeightBox.Text = $"{col_side * w_side + 4 * heightBoard}";
                tbWidthBox.Text = $"{col_cap * w_cap + 2 * heightBoard}";
                tbLenghtBox.Text = $"{lenghtBox}";
            }
            if (typeBox == 2)
            {
                tbHeightBox.Text = $"{col_side * w_side + 4 * heightBoard + gap * (col_side - 1)}";
                tbWidthBox.Text = $"{col_cap * w_cap + 2 * heightBoard + gap * (col_cap - 1)}";
                tbLenghtBox.Text = $"{lenghtBox}";

            }

            tbHeightBoxInternal.Enabled = false;
            tbLenghtBoxInternal.Enabled = false;
            tbWidthBoxInternal.Enabled = false;

            if (typeBox == 1)
            {
                tbHeightBoxInternal.Text = $"{col_side * w_side}";
                tbWidthBoxInternal.Text = $"{col_cap * w_cap - 2 * heightBoard}";
                tbLenghtBoxInternal.Text = $"{lenghtBox - 4 * heightBoard}";
            }
            if (typeBox == 2)
            {
                tbHeightBoxInternal.Text = $"{col_side * w_side + gap * (col_side - 1)}";
                tbWidthBoxInternal.Text = $"{col_cap * w_cap - 2 * heightBoard + gap * (col_cap - 1)}";
                tbLenghtBoxInternal.Text = $"{lenghtBox - 4 * heightBoard}";
            }

            tbWood.Enabled = false;
            tbWoodGOST.Enabled = false;

            tbWood.Text = wood;
            tbWoodGOST.Text = woodGOST;

            //tbAround.Enabled = false;
            //tbBefore.Enabled = false;
            //tbCap.Enabled = false;
            //tbFront.Enabled = false;
            //tbSide.Enabled = false;

            //tbCap.Text = $"{col_cap * 2} шт {heightBoard}x{w_cap}x{lenghtBox}";
            //tbSide.Text = $"{col_side * 2} шт {heightBoard}x{w_side}x{lenghtBox}";
            //tbBefore.Text = $"{col_side * 2} штук {heightBoard}x{w_side}x{col_cap * w_cap - 2 * heightBoard}";
            //tbAround.Text = $"4 шт {heightBoard}x{around1}, 4 шт {heightBoard}x{around2}";
            //tbFront.Text = $"4 шт {heightBoard}x{front1}, 4 шт {heightBoard}x{front2}";

            //richTextBox1.Enabled = false;

            //double CapLenght = col_cap * lenghtBox * 2 / 1000;
            //double SideBeforLenght = (col_side * lenghtBox * 2 + col_side * (col_cap * w_cap - 2 * heightBoard) * 2) / 1000;


            ////double Around1Lenght = 

            //richTextBox1.Text = $"Для построения ящика типа I-{typeBox} понадобится: " +
            //    $" для крышки - доска {heightBoard}x{w_cap} {CapLenght}м, " +
            //    $" для бокового и торцевого щита - доска {heightBoard}x{w_side} {SideBeforLenght}м, " +
            //    $" для планок пояса - ...  " +
            //    $" для планок торцевого щита - ...  ";

            double CapLenght = col_cap * lenghtBox * 2 / 1000;
            double SideLenght = col_side * lenghtBox * 2 / 1000;
            double BeforLenght = col_side * (col_cap * w_cap - 2 * heightBoard) * 2 / 1000;


            string[,] RowData = new string[6, 4]
            {
                { "", "Кол-во досок", "Размер одной доски", "Для построения понадобится" },
                { "Дно и крышка", $"{col_cap * 2} шт", $"{heightBoard}x{w_cap}x{lenghtBox}", $"{CapLenght} м" },
                { "Боковые щиты", $"{col_side * 2} шт", $"{heightBoard}x{w_side}x{lenghtBox}", $"{SideLenght} м" },
                { "Торцевые щиты", $"{col_side * 2} шт", $"{heightBoard}x{w_side}x{col_cap * w_cap - 2 * heightBoard}", $"{BeforLenght} м" },
                { "Планки пояса", "4 шт, 4 шт", $"{heightBoard}x{around1}, {heightBoard}x{around2}", "15 м" },
                { "Планки торцевого щита", "4 шт, 4 шт", $"{heightBoard}x{front1}, {heightBoard}x{front2}", "15 м" }
            };

            tableLayoutPanel1.Controls.Clear();

            // Заполнение ячеек данными
            for (int row = 0; row < tableLayoutPanel1.RowCount; row++)
            {
                for (int col = 0; col < tableLayoutPanel1.ColumnCount; col++)
                {
                    Label headerLabel = new Label
                    {
                        Text = RowData[row, col],
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Fill,
                    };
                    tableLayoutPanel1.Controls.Add(headerLabel, col, row);
                }
            }
        }

        private void butTxt_Click(object sender, EventArgs e)
        {
            DialogResult dialogresult = folderBrowserDialog1.ShowDialog();

            if (dialogresult == DialogResult.OK)
            {
                //Извлечение имени папки
                foldername = folderBrowserDialog1.SelectedPath;
            }

           



        }
    }
}
