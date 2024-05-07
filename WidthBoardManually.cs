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
    public partial class WidthBoardManually : Form
    {
        public WidthBoardManually()
        {
            InitializeComponent();
        }

        public void SetLabelValue(string value)
        {
            lbGOST.Text = value;
           
        }

        public string selectedValue1Manually;
        public string selectedValue2Manually;
        public string selectedValue3Manually;
        public string selectedValue4Manually;

        private void butSave_Click(object sender, EventArgs e)
        {
            if (tbBottomBoards.Text == String.Empty || tbSideBoard.Text == String.Empty
               || tbFrontBoard.Text == String.Empty || tbBeltBoard.Text == String.Empty)
            {
                MessageBox.Show("Ошибка: введите значение ширины досок!!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else if (!int.TryParse(tbBottomBoards.Text, out int result1) ||
                !int.TryParse(tbSideBoard.Text, out int result2) ||
                !int.TryParse(tbFrontBoard.Text, out int result3) ||
                !int.TryParse(tbBeltBoard.Text, out int result4))
            {
                MessageBox.Show("Значения должны быть целыми положительными числами!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
          
            selectedValue1Manually = tbBottomBoards.Text; //дно и крышка
            selectedValue2Manually = tbSideBoard.Text; //бок и торец щит
            selectedValue3Manually = tbBeltBoard.Text; // планки пояса
            selectedValue4Manually = tbFrontBoard.Text; // планки торецевого щита
            this.Close();
        

        }
    }
}
