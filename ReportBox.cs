using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            tbHeightBox.Enabled = false; // высота
            tbWidthBox.Enabled = false; // ширина
            tbLenghtBox.Enabled = false; //длинна

            //tbHeightBox.Text = 


            tbHeightBoxInternal.Enabled = false;
            tbLenghtBoxInternal.Enabled = false;
            tbWidthBoxInternal.Enabled = false;

            tbWood.Enabled = false;
            tbWoodGOST.Enabled = false;

            //tbWood.Text = wood;
            //tbWoodGOST.Text = woodGOST;

            tbAround.Enabled = false;
            tbBefore.Enabled = false;
            tbCap.Enabled = false;
            tbFront.Enabled = false;
            tbSide.Enabled = false;

            richTextBox1.Enabled = false;


            richTextBox1.Text = "";
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
