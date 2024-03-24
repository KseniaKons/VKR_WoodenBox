using Kompas6API5;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TreeBox
{
    internal class Box12
    {


        private KompasObject kompas; // создание экземпляра КОМПАС
        private ksDocument3D ksDoc3d; // создание экземпляра 3D-документа
        private ksPart part; // создание экземпляра детали


        public void СreatingBox12(int x, int y, int z, double massa, int gap, int GOST, int heightBoard, 
            int widthBoard, string foldername)
        {
            try
            {
                kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            }
            catch
            {
                kompas = (KompasObject)Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));
            }
            if (kompas == null)
                return;

            kompas.Visible = true;


        }

        public void СreatingBox12Manually(int x, int y, int z, double massa, int gap, int GOST, int heightWidth, 
            int widthBoard, string savedValue1, string savedValue2, string savedValue3, string foldername)
        {
            try
            {
                kompas = (KompasObject)Marshal.GetActiveObject("KOMPAS.Application.5");
            }
            catch
            {
                kompas = (KompasObject)Activator.CreateInstance(Type.GetTypeFromProgID("KOMPAS.Application.5"));
            }
            if (kompas == null)
                return;

            kompas.Visible = true;

        }

    }
}
