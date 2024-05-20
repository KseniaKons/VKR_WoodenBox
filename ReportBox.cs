using Kompas6API5;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace WoodenBox
{
    public partial class ReportBox : Form
    {
        public string foldername;
        
        string nameNails = InformationAboutBox.ForReport[0].nameNails;
        string massNails = InformationAboutBox.ForReport[0].massNails;
        string gostNails = InformationAboutBox.ForReport[0].gostNails;

        string nameTape = InformationAboutBox.ForReport[0].nameTape;
        string lenghtTape = InformationAboutBox.ForReport[0].lenghtTape;
        string gostTape = InformationAboutBox.ForReport[0].gostTape;


        string wood = InformationAboutBox.ForReport[0].wood;
        string woodGost = InformationAboutBox.ForReport[0].gostWood;

        double col_cap = InformationAboutBox.ValueBoxForReport[0].col_cap;
        double w_cap = InformationAboutBox.ValueBoxForReport[0].w_cap;
        double col_side = InformationAboutBox.ValueBoxForReport[0].col_side;
        double w_side = InformationAboutBox.ValueBoxForReport[0].w_side;
        double lenghtBox = InformationAboutBox.ValueBoxForReport[0].lenghtBox;
        double heightBoard = InformationAboutBox.ValueBoxForReport[0].heightBoard;
        double gap = InformationAboutBox.ValueBoxForReport[0].gap;

        string front1 = InformationAboutBox.ValueBox[0].front1;
        string front2 = InformationAboutBox.ValueBox[0].front2;
        string around1 = InformationAboutBox.ValueBox[0].around1;
        string around2 = InformationAboutBox.ValueBox[0].around2;

        double typeBox = InformationAboutBox.ValueBox[0].TypeBox;

        string HeightBox = string.Empty;
        string WidthBox = string.Empty;
        string LenghtBox = string.Empty;

        string HeightBoxInternal = string.Empty;
        string WidthBoxInternal = string.Empty;
        string LenghtBoxInternal = string.Empty;

        string[,] RowData = new string[6, 4];
        double CapLenght;
        double SideLenght;
        double BeforLenght;

        double ar1Lenght;
        double ar2Lenght;
        double fr1Lenght;
        double fr2Lenght;


        public ReportBox()
        {
            InitializeComponent();
            // внешние
            tbHeightBox.Enabled = false; // высота
            tbWidthBox.Enabled = false; // ширина
            tbLenghtBox.Enabled = false; //длинна

            if (typeBox == 1)
            {
                HeightBox = $"{col_side * w_side + 4 * heightBoard}";
                WidthBox = $"{col_cap * w_cap + 2 * heightBoard}";
                LenghtBox = $"{lenghtBox}";
            }
            if (typeBox == 2)
            {
                HeightBox = $"{col_side * w_side + 4 * heightBoard + gap * (col_side - 1)}";
                WidthBox = $"{col_cap * w_cap + 2 * heightBoard + gap * (col_cap - 1)}";
                LenghtBox = $"{lenghtBox}";

            }

            tbHeightBox.Text = HeightBox;
            tbWidthBox.Text = WidthBox;
            tbLenghtBox.Text = LenghtBox;

            tbHeightBoxInternal.Enabled = false;
            tbLenghtBoxInternal.Enabled = false;
            tbWidthBoxInternal.Enabled = false;

            if (typeBox == 1)
            {
                HeightBoxInternal = $"{col_side * w_side}";
                WidthBoxInternal = $"{col_cap * w_cap - 2 * heightBoard}";
                LenghtBoxInternal = $"{lenghtBox - 4 * heightBoard}";
            }
            if (typeBox == 2)
            {
                HeightBoxInternal = $"{col_side * w_side + gap * (col_side - 1)}";
                WidthBoxInternal = $"{col_cap * w_cap - 2 * heightBoard + gap * (col_cap - 1)}";
                LenghtBoxInternal = $"{lenghtBox - 4 * heightBoard}";
            }

            tbHeightBoxInternal.Text = HeightBoxInternal;
            tbWidthBoxInternal.Text = WidthBoxInternal;
            tbLenghtBoxInternal.Text = LenghtBoxInternal;

            tbWood.Enabled = false;
            tbWoodGOST.Enabled = false;

            tbWood.Text = wood;
            tbWoodGOST.Text = woodGost;

            if (typeBox == 1)
            {
                 CapLenght = col_cap * lenghtBox * 2 / 1000;
                 SideLenght = col_side * lenghtBox * 2 / 1000;
                 BeforLenght = col_side * (col_cap * w_cap - 2 * heightBoard) * 2 / 1000;

                 ar1Lenght = w_cap * col_cap * 4 / 1000;
                 ar2Lenght = (w_side * col_side + 4 * heightBoard) * 4 / 1000;
                 fr1Lenght = w_side * col_side * 4 / 1000;
                 fr2Lenght = (w_cap * col_cap - 2 * heightBoard - 2 * w_side) * 4 / 1000;

                RowData = new string[,]
                {
                { "", "Кол-во досок", "Размер одной доски", "Для построения понадобится" },
                { "Дно и крышка", $"{col_cap * 2} шт", $"{heightBoard}x{w_cap}x{lenghtBox}", $"{CapLenght} м" },
                { "Боковые щиты", $"{col_side * 2} шт", $"{heightBoard}x{w_side}x{lenghtBox}", $"{SideLenght} м" },
                { "Торцевые щиты", $"{col_side * 2} шт", $"{heightBoard}x{w_side}x{col_cap * w_cap - 2 * heightBoard}", $"{BeforLenght} м" },
                { "Планки пояса", "4 шт, 4 шт", $"{heightBoard}x{around1}, {heightBoard}x{around2}", $"{ar1Lenght} м, {ar2Lenght} м" },
                { "Планки торцевого щита", "4 шт, 4 шт", $"{heightBoard}x{front1}, {heightBoard}x{front2}", $"{fr1Lenght} м, {fr2Lenght} м" }
                };

            }
            if (typeBox == 2)
            {
                 CapLenght = col_cap * lenghtBox * 2 / 1000;
                 SideLenght = col_side * lenghtBox * 2 / 1000;
                 BeforLenght = col_side * (col_cap * w_cap + gap*(col_cap - 1) - 2 * heightBoard) * 2 / 1000;

                 ar1Lenght = (w_cap * col_cap + gap * (col_cap - 1)) * 4 / 1000;
                 ar2Lenght = (w_side * col_side + 4 * heightBoard + gap * (col_cap - 1)) * 4 / 1000;
                 fr1Lenght = (w_side * col_side + gap * (col_cap - 1)) * 4 / 1000;
                 fr2Lenght = (w_cap * col_cap + gap * (col_cap - 1) - 2 * heightBoard - 2 * w_side) * 4 / 1000;

                RowData = new string[,]
                {
                { "", "Кол-во досок", "Размер одной доски", "Для построения понадобится" },
                { "Дно и крышка", $"{col_cap * 2} шт", $"{heightBoard}x{w_cap}x{lenghtBox}", $"{Math.Round(CapLenght, 2)} м" },
                { "Боковые щиты", $"{col_side * 2} шт", $"{heightBoard}x{w_side}x{lenghtBox}", $"{Math.Round(SideLenght, 2)} м" },
                { "Торцевые щиты", $"{col_side * 2} шт", $"{heightBoard}x{w_side}x{col_cap * w_cap + gap*(col_cap - 1) - 2 * heightBoard}", 
                        $"{Math.Round(BeforLenght, 2)} м" },
                { "Планки пояса", "4 шт, 4 шт", $"{heightBoard}x{around1}, {heightBoard}x{around2}", $"{Math.Round(ar1Lenght, 2)} м, {Math.Round(ar2Lenght, 2)} м" },
                { "Планки торцевого щита", "4 шт, 4 шт", $"{heightBoard}x{front1}, {heightBoard}x{front2}", $"{Math.Round(fr1Lenght, 2)} м, {Math.Round(fr2Lenght, 2)} м" }
                };
            }

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
            
            string filePath = foldername + "\\Отчет.txt";

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.WriteLine($"Ящик типа I-{typeBox}");
                writer.WriteLine($"{woodGost}  -  {wood}");
                writer.WriteLine($"Внешние габаритные размеры: {HeightBox}х{WidthBox}x{LenghtBox}");
                writer.WriteLine($"Внутренние габаритные размеры: {HeightBoxInternal}х{WidthBoxInternal}x{LenghtBoxInternal}");
                writer.WriteLine($"Для построения ящика понадобится:");
                writer.WriteLine($"- Крашки: доски {heightBoard}x{w_cap}x{lenghtBox} {col_cap * 2} шт, общая длинна досок - {Math.Round(CapLenght, 2)} м");
                writer.WriteLine($"- Боковые щиты: доски {heightBoard}x{w_side}x{lenghtBox} {col_side * 2} шт, общая длинна досок - {Math.Round(SideLenght, 2)} м");
                writer.WriteLine($"- Торцевые щиты: доски {heightBoard}x{w_side}x{col_cap * w_cap - 2 * heightBoard} {col_side * 2} шт, общая длинна досок - {Math.Round(BeforLenght, 2)} м");
                writer.WriteLine($"- Планки пояса: доски {heightBoard}x{around1} 4 шт, общая длинна досок - {Math.Round(ar1Lenght, 2)} м; ");
                writer.WriteLine($"доски {heightBoard}x{around2} 4 шт, общая длинна досок - {Math.Round(ar2Lenght, 2)} м");
                writer.WriteLine($"- Планки торцевого щита: доски {heightBoard}x{front1} 4 шт, общая длинна досок - {Math.Round(fr1Lenght, 2)} м; ");
                writer.WriteLine($"доски {heightBoard}x{front2} 4 шт, общая длинна досок - {Math.Round(fr2Lenght, 2)} м");
                writer.WriteLine($"- {gostNails} {nameNails} {massNails} кг ");
                writer.WriteLine($"- {gostTape} {nameTape} {lenghtTape} м ");
            }

            MessageBox.Show("Отчет соохранен!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

        }
    }
}
