using KAPITypes;
using Kompas6API5;
using Kompas6Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace TreeBox
{
    internal class SpecificationBox
    {
        private KompasObject kompas; // создание экземпляра КОМПАС

        public static class DataSpecificationBox
        {
            public static List<ValueSpecificationBox> ValueBox = new List<ValueSpecificationBox>();
        }
        public class ValueSpecificationBox
        {
            public string cap { get; set; } //крышка
            public string cap_col { get; set; } //крышка
            public string bottom { get; set; } //дно
            public string bottom_col { get; set; } //дно
            public string before { get; set; } //торцевой щит
            public string before_col { get; set; } //торцевой щит
            public string side { get; set; } //боковой щит
            public string side_col { get; set; } //боковой щит
            public string around1 { get; set; } //планка пояса - верхняя
            public string around2 { get; set; } //планка пояса - боковая
            public string front1 { get; set; } //планка торцевого щита - вертикальная
            public string front2 { get; set; } //планка торцевого щита - горизонтальная
        }

        public void CreateSpecification(int gost1, string name, int number, string foldername)
        {
            if (!DataSpecificationBox.ValueBox.Any())
            {
                MessageBox.Show("Ошибка: Ящик для спецификации не был построен!", "Ошибка создания спецификации!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
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

            //Классификаторы 

            string CL_cap = "321174"; // крышка
            string CL_bottom = "321172"; // дно
            string CL_before = "321179"; // торцевой щит
            string CL_side = "321179"; // боковой щит
            string CL_around = "321175"; // планка пояса 
            string CL_front = "321175"; // планка торцевого щита

            int count = 1;
            string numDesignation = "000";

            string GOST = "ГОСТ";
            string board = "Доска";

            if (gost1 == 0)
            { 
                GOST = "ГОСТ 2695-83"; //ГОСТ 2695. Пиломатериалы лиственных пород
                board = "Доска-2-дуб";
            }

            if (gost1 == 1)
            { 
                GOST = "ГОСТ 24454-80"; //ГОСТ 24454-80. Пиломатериалы хвойных пород
                board = "Доска-2-сосна";
            }
            
            //Доска - 2 - дуб - 40 х 60 ГОСТ 2695-83
            // Доска - 2 - сосна - 20х70х300 ГОСТ...


            ksSpcDocument iDocumentSpc = (ksSpcDocument)kompas.SpcDocument();

            ksDocumentParam iDocumentParam = (ksDocumentParam)kompas.
            GetParamStruct((short)StructType2DEnum.ko_DocumentParam);
            if (iDocumentParam == null)
                return;
            iDocumentParam.Init();
            iDocumentParam.type = (int)DocType.lt_DocSpc;
            ksSheetPar iSheetParam = (ksSheetPar)iDocumentParam.GetLayoutParam();
            iSheetParam.Init();
            iSheetParam.layoutName = @"C:\Program Files\ASCON\KOMPAS-3D v21 Study\Sys\graphic.lyt";
            iSheetParam.shtType = 1;
            iDocumentSpc.ksCreateDocument(iDocumentParam);

            // 1 секция           
            if (number<10)
                numDesignation = $"00{number}";
            if (number >= 10 && number <100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc1 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc1.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference1 = iSpc1.ksSpcObjectEnd();

            ksSpcObjParam iSpcObjParam1 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc1.ksSpcObjectEdit(reference1);
            iDocumentSpc.ksGetObjParam(reference1, iSpcObjParam1, ldefin2d.ALLPARAM);
            iSpcObjParam1.blockNumber = 0;
            iSpcObjParam1.draw = 1;
            iSpcObjParam1.firstOnSheet = 0;
            iSpcObjParam1.ispoln = 0;
            iSpcObjParam1.posInc = 1;
            iSpcObjParam1.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference1, iSpcObjParam1, ldefin2d.ALLPARAM);
            iSpc1.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc1.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc1.ksSetSpcObjectColumnText(4, 1, 0, $"{name}.{CL_cap}.{numDesignation}");
            iSpc1.ksSetSpcObjectColumnText(5, 1, 0, "Крышка");
            iSpc1.ksSetSpcObjectColumnText(6, 1, 0, "1");
            reference1 = iSpc1.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc2 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc2.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference2 = iSpc2.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam2 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc2.ksSpcObjectEdit(reference2);
            iDocumentSpc.ksGetObjParam(reference2, iSpcObjParam2, ldefin2d.ALLPARAM);
            iSpcObjParam2.blockNumber = 0;
            iSpcObjParam2.draw = 1;
            iSpcObjParam2.firstOnSheet = 0;
            iSpcObjParam2.ispoln = 0;
            iSpcObjParam2.posInc = 1;
            iSpcObjParam2.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference2, iSpcObjParam2, ldefin2d.ALLPARAM);
            iSpc2.ksSetSpcObjectColumnText(5, 1, 0, board);
            iSpc2.ksSetSpcObjectColumnText(7, 1, 0, $"{DataSpecificationBox.ValueBox[0].cap_col}шт");
            reference2 = iSpc2.ksSpcObjectEnd();

            ksSpecification iSpc4 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc4.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference4 = iSpc4.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam4 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc4.ksSpcObjectEdit(reference4);
            iDocumentSpc.ksGetObjParam(reference4, iSpcObjParam4, ldefin2d.ALLPARAM);
            iSpcObjParam4.blockNumber = 0;
            iSpcObjParam4.draw = 2;
            iSpcObjParam4.firstOnSheet = 0;
            iSpcObjParam4.ispoln = 0;
            iSpcObjParam4.posInc = 2;
            iSpcObjParam4.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference4, iSpcObjParam4, ldefin2d.ALLPARAM);
            iSpc4.ksSetSpcObjectColumnText(5, 1, 0, DataSpecificationBox.ValueBox[0].cap);
            reference4 = iSpc4.ksSpcObjectEnd();

            ksSpecification iSpc3 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc3.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference3 = iSpc3.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam3 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc3.ksSpcObjectEdit(reference3);
            iDocumentSpc.ksGetObjParam(reference3, iSpcObjParam3, ldefin2d.ALLPARAM);
            iSpcObjParam3.blockNumber = 0;
            iSpcObjParam3.draw = 2;
            iSpcObjParam3.firstOnSheet = 0;
            iSpcObjParam3.ispoln = 0;
            iSpcObjParam3.posInc = 2;
            iSpcObjParam3.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference3, iSpcObjParam3, ldefin2d.ALLPARAM);
            iSpc3.ksSetSpcObjectColumnText(5, 1, 0, GOST);
            reference3 = iSpc3.ksSpcObjectEnd();


            // 2 секция           
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";            

            ksSpecification iSpc5 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc5.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference5 = iSpc5.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam5 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc5.ksSpcObjectEdit(reference5);
            iDocumentSpc.ksGetObjParam(reference5, iSpcObjParam5, ldefin2d.ALLPARAM);
            iSpcObjParam5.blockNumber = 0;
            iSpcObjParam5.draw = 1;
            iSpcObjParam5.firstOnSheet = 0;
            iSpcObjParam5.ispoln = 0;
            iSpcObjParam5.posInc = 1;
            iSpcObjParam5.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference5, iSpcObjParam5, ldefin2d.ALLPARAM);
            iSpc5.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc5.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc5.ksSetSpcObjectColumnText(4, 1, 0, $"{name}.{CL_bottom}.{numDesignation}");
            iSpc5.ksSetSpcObjectColumnText(5, 1, 0, "Дно");
            iSpc5.ksSetSpcObjectColumnText(6, 1, 0, "1");
            reference5 = iSpc5.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc6 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc6.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference6 = iSpc6.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam6 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc6.ksSpcObjectEdit(reference6);
            iDocumentSpc.ksGetObjParam(reference6, iSpcObjParam6, ldefin2d.ALLPARAM);
            iSpcObjParam6.blockNumber = 0;
            iSpcObjParam6.draw = 1;
            iSpcObjParam6.firstOnSheet = 0;
            iSpcObjParam6.ispoln = 0;
            iSpcObjParam6.posInc = 1;
            iSpcObjParam6.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference6, iSpcObjParam6, ldefin2d.ALLPARAM);
            iSpc6.ksSetSpcObjectColumnText(5, 1, 0, board);
            iSpc6.ksSetSpcObjectColumnText(7, 1, 0, $"{DataSpecificationBox.ValueBox[0].bottom_col}шт");
            reference6 = iSpc6.ksSpcObjectEnd();

            ksSpecification iSpc8 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc8.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference8 = iSpc8.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam8 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc8.ksSpcObjectEdit(reference8);
            iDocumentSpc.ksGetObjParam(reference8, iSpcObjParam8, ldefin2d.ALLPARAM);
            iSpcObjParam8.blockNumber = 0;
            iSpcObjParam8.draw = 2;
            iSpcObjParam8.firstOnSheet = 0;
            iSpcObjParam8.ispoln = 0;
            iSpcObjParam8.posInc = 2;
            iSpcObjParam8.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference8, iSpcObjParam8, ldefin2d.ALLPARAM);
            iSpc8.ksSetSpcObjectColumnText(5, 1, 0, DataSpecificationBox.ValueBox[0].cap);
            reference8 = iSpc8.ksSpcObjectEnd();

            ksSpecification iSpc7 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc7.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference7 = iSpc7.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam7 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc7.ksSpcObjectEdit(reference7);
            iDocumentSpc.ksGetObjParam(reference7, iSpcObjParam7, ldefin2d.ALLPARAM);
            iSpcObjParam7.blockNumber = 0;
            iSpcObjParam7.draw = 2;
            iSpcObjParam7.firstOnSheet = 0;
            iSpcObjParam7.ispoln = 0;
            iSpcObjParam7.posInc = 2;
            iSpcObjParam7.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference7, iSpcObjParam7, ldefin2d.ALLPARAM);
            iSpc7.ksSetSpcObjectColumnText(5, 1, 0, GOST);
            reference7 = iSpc7.ksSpcObjectEnd();

            // // СТАНДАРТНЫЕ ИЗДЕЛИЯ


            // // Гвозди П 2,5х50 ГОСТ 4034-63
            // //Гвозди К 2,5х50 ГОСТ 4034-63

            // ksSpecification iSpc57 = (ksSpecification)iDocumentSpc.GetSpecification();
            // iSpc57.ksSpcObjectCreate("", 0, 25, 0, 0, 1);
            // int reference57 = iSpc57.ksSpcObjectEnd();
            // ksSpcObjParam iSpcObjParam57 =
            //(ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            // iSpc57.ksSpcObjectEdit(reference57);
            // iDocumentSpc.ksGetObjParam(reference57, iSpcObjParam57, ldefin2d.ALLPARAM);
            // iSpcObjParam57.blockNumber = 0;
            // iSpcObjParam57.draw = 2;
            // iSpcObjParam57.firstOnSheet = 0;
            // iSpcObjParam57.ispoln = 0;
            // iSpcObjParam57.posInc = 2;
            // iSpcObjParam57.posNotDraw = 0;
            // iDocumentSpc.ksSetObjParam(reference57, iSpcObjParam57, ldefin2d.ALLPARAM);
            // iSpc57.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            // iSpc57.ksSetSpcObjectColumnText(3, 1, 0, 57.ToString());
            // iSpc57.ksSetSpcObjectColumnText(5, 1, 0, "Шток 1 Ряд " + "20.6x6");
            // reference57 = iSpc57.ksSpcObjectEnd();

        }




    }
}
