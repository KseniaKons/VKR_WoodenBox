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


            // 3 секция           
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc9 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc9.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference9 = iSpc9.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam9 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc9.ksSpcObjectEdit(reference9);
            iDocumentSpc.ksGetObjParam(reference9, iSpcObjParam9, ldefin2d.ALLPARAM);
            iSpcObjParam9.blockNumber = 0;
            iSpcObjParam9.draw = 1;
            iSpcObjParam9.firstOnSheet = 0;
            iSpcObjParam9.ispoln = 0;
            iSpcObjParam9.posInc = 1;
            iSpcObjParam9.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference9, iSpcObjParam9, ldefin2d.ALLPARAM);
            iSpc9.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc9.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc9.ksSetSpcObjectColumnText(4, 1, 0, $"{name}.{CL_before}.{numDesignation}");
            iSpc9.ksSetSpcObjectColumnText(5, 1, 0, "Торцевой щит");
            iSpc9.ksSetSpcObjectColumnText(6, 1, 0, "2");
            reference9 = iSpc9.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc10 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc10.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference10 = iSpc10.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam10 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc10.ksSpcObjectEdit(reference10);
            iDocumentSpc.ksGetObjParam(reference10, iSpcObjParam10, ldefin2d.ALLPARAM);
            iSpcObjParam10.blockNumber = 0;
            iSpcObjParam10.draw = 1;
            iSpcObjParam10.firstOnSheet = 0;
            iSpcObjParam10.ispoln = 0;
            iSpcObjParam10.posInc = 1;
            iSpcObjParam10.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference10, iSpcObjParam10, ldefin2d.ALLPARAM);
            iSpc10.ksSetSpcObjectColumnText(5, 1, 0, board);
            iSpc10.ksSetSpcObjectColumnText(7, 1, 0, $"{DataSpecificationBox.ValueBox[0].before_col}шт");
            reference10 = iSpc10.ksSpcObjectEnd();

            ksSpecification iSpc11 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc11.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference11 = iSpc11.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam11 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc11.ksSpcObjectEdit(reference11);
            iDocumentSpc.ksGetObjParam(reference11, iSpcObjParam11, ldefin2d.ALLPARAM);
            iSpcObjParam11.blockNumber = 0;
            iSpcObjParam11.draw = 2;
            iSpcObjParam11.firstOnSheet = 0;
            iSpcObjParam11.ispoln = 0;
            iSpcObjParam11.posInc = 2;
            iSpcObjParam11.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference11, iSpcObjParam11, ldefin2d.ALLPARAM);
            iSpc11.ksSetSpcObjectColumnText(5, 1, 0, DataSpecificationBox.ValueBox[0].before);
            reference11 = iSpc11.ksSpcObjectEnd();

            ksSpecification iSpc12 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc12.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference12 = iSpc12.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam12 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc12.ksSpcObjectEdit(reference12);
            iDocumentSpc.ksGetObjParam(reference12, iSpcObjParam12, ldefin2d.ALLPARAM);
            iSpcObjParam12.blockNumber = 0;
            iSpcObjParam12.draw = 2;
            iSpcObjParam12.firstOnSheet = 0;
            iSpcObjParam12.ispoln = 0;
            iSpcObjParam12.posInc = 2;
            iSpcObjParam12.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference12, iSpcObjParam12, ldefin2d.ALLPARAM);
            iSpc12.ksSetSpcObjectColumnText(5, 1, 0, GOST);
            reference12 = iSpc12.ksSpcObjectEnd();

            // 4 секция           
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc13 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc13.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference13 = iSpc13.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam13 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc13.ksSpcObjectEdit(reference13);
            iDocumentSpc.ksGetObjParam(reference13, iSpcObjParam13, ldefin2d.ALLPARAM);
            iSpcObjParam13.blockNumber = 0;
            iSpcObjParam13.draw = 1;
            iSpcObjParam13.firstOnSheet = 0;
            iSpcObjParam13.ispoln = 0;
            iSpcObjParam13.posInc = 1;
            iSpcObjParam13.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference13, iSpcObjParam13, ldefin2d.ALLPARAM);
            iSpc13.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc13.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc13.ksSetSpcObjectColumnText(4, 1, 0, $"{name}.{CL_side}.{numDesignation}");
            iSpc13.ksSetSpcObjectColumnText(5, 1, 0, "Боковой щит");
            iSpc13.ksSetSpcObjectColumnText(6, 1, 0, "2");
            reference13 = iSpc13.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc14 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc14.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference14 = iSpc14.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam14 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc14.ksSpcObjectEdit(reference14);
            iDocumentSpc.ksGetObjParam(reference14, iSpcObjParam14, ldefin2d.ALLPARAM);
            iSpcObjParam14.blockNumber = 0;
            iSpcObjParam14.draw = 1;
            iSpcObjParam14.firstOnSheet = 0;
            iSpcObjParam14.ispoln = 0;
            iSpcObjParam14.posInc = 1;
            iSpcObjParam14.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference14, iSpcObjParam14, ldefin2d.ALLPARAM);
            iSpc14.ksSetSpcObjectColumnText(5, 1, 0, board);
            iSpc14.ksSetSpcObjectColumnText(7, 1, 0, $"{DataSpecificationBox.ValueBox[0].side_col}шт");
            reference14 = iSpc14.ksSpcObjectEnd();

            ksSpecification iSpc15 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc15.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference15 = iSpc15.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam15 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc15.ksSpcObjectEdit(reference15);
            iDocumentSpc.ksGetObjParam(reference15, iSpcObjParam15, ldefin2d.ALLPARAM);
            iSpcObjParam15.blockNumber = 0;
            iSpcObjParam15.draw = 2;
            iSpcObjParam15.firstOnSheet = 0;
            iSpcObjParam15.ispoln = 0;
            iSpcObjParam15.posInc = 2;
            iSpcObjParam15.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference15, iSpcObjParam15, ldefin2d.ALLPARAM);
            iSpc15.ksSetSpcObjectColumnText(5, 1, 0, DataSpecificationBox.ValueBox[0].side);
            reference15 = iSpc15.ksSpcObjectEnd();

            ksSpecification iSpc16 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc16.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference16 = iSpc16.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam16 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc16.ksSpcObjectEdit(reference16);
            iDocumentSpc.ksGetObjParam(reference16, iSpcObjParam16, ldefin2d.ALLPARAM);
            iSpcObjParam16.blockNumber = 0;
            iSpcObjParam16.draw = 2;
            iSpcObjParam16.firstOnSheet = 0;
            iSpcObjParam16.ispoln = 0;
            iSpcObjParam16.posInc = 2;
            iSpcObjParam16.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference16, iSpcObjParam16, ldefin2d.ALLPARAM);
            iSpc16.ksSetSpcObjectColumnText(5, 1, 0, GOST);
            reference16 = iSpc16.ksSpcObjectEnd();

            // 5 секция - планка пояса - верхняя     
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc17 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc17.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference17 = iSpc17.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam17 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc17.ksSpcObjectEdit(reference17);
            iDocumentSpc.ksGetObjParam(reference17, iSpcObjParam17, ldefin2d.ALLPARAM);
            iSpcObjParam17.blockNumber = 0;
            iSpcObjParam17.draw = 1;
            iSpcObjParam17.firstOnSheet = 0;
            iSpcObjParam17.ispoln = 0;
            iSpcObjParam17.posInc = 1;
            iSpcObjParam17.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference17, iSpcObjParam17, ldefin2d.ALLPARAM);
            iSpc17.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc17.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc17.ksSetSpcObjectColumnText(4, 1, 0, $"{name}.{CL_around}.{numDesignation}");
            iSpc17.ksSetSpcObjectColumnText(5, 1, 0, "Планка пояса");
            iSpc17.ksSetSpcObjectColumnText(6, 1, 0, "4");
            reference17 = iSpc17.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc18 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc18.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference18 = iSpc18.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam18 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc18.ksSpcObjectEdit(reference18);
            iDocumentSpc.ksGetObjParam(reference18, iSpcObjParam18, ldefin2d.ALLPARAM);
            iSpcObjParam18.blockNumber = 0;
            iSpcObjParam18.draw = 1;
            iSpcObjParam18.firstOnSheet = 0;
            iSpcObjParam18.ispoln = 0;
            iSpcObjParam18.posInc = 1;
            iSpcObjParam18.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference18, iSpcObjParam18, ldefin2d.ALLPARAM);
            iSpc18.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference18 = iSpc18.ksSpcObjectEnd();

            ksSpecification iSpc19 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc19.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference19 = iSpc19.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam19 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc19.ksSpcObjectEdit(reference19);
            iDocumentSpc.ksGetObjParam(reference19, iSpcObjParam19, ldefin2d.ALLPARAM);
            iSpcObjParam19.blockNumber = 0;
            iSpcObjParam19.draw = 2;
            iSpcObjParam19.firstOnSheet = 0;
            iSpcObjParam19.ispoln = 0;
            iSpcObjParam19.posInc = 2;
            iSpcObjParam19.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference19, iSpcObjParam19, ldefin2d.ALLPARAM);
            iSpc19.ksSetSpcObjectColumnText(5, 1, 0, DataSpecificationBox.ValueBox[0].around1);
            reference19 = iSpc19.ksSpcObjectEnd();

            ksSpecification iSpc20 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc20.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference20 = iSpc20.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam20 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc20.ksSpcObjectEdit(reference20);
            iDocumentSpc.ksGetObjParam(reference20, iSpcObjParam20, ldefin2d.ALLPARAM);
            iSpcObjParam20.blockNumber = 0;
            iSpcObjParam20.draw = 2;
            iSpcObjParam20.firstOnSheet = 0;
            iSpcObjParam20.ispoln = 0;
            iSpcObjParam20.posInc = 2;
            iSpcObjParam20.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference20, iSpcObjParam20, ldefin2d.ALLPARAM);
            iSpc20.ksSetSpcObjectColumnText(5, 1, 0, GOST);
            reference20 = iSpc20.ksSpcObjectEnd();

            // 6 секция - планка пояса - боковая    
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc21 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc21.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference21 = iSpc21.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam21 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc21.ksSpcObjectEdit(reference21);
            iDocumentSpc.ksGetObjParam(reference21, iSpcObjParam21, ldefin2d.ALLPARAM);
            iSpcObjParam21.blockNumber = 0;
            iSpcObjParam21.draw = 1;
            iSpcObjParam21.firstOnSheet = 0;
            iSpcObjParam21.ispoln = 0;
            iSpcObjParam21.posInc = 1;
            iSpcObjParam21.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference21, iSpcObjParam21, ldefin2d.ALLPARAM);
            iSpc21.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc21.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc21.ksSetSpcObjectColumnText(4, 1, 0, $"{name}.{CL_around}.{numDesignation}");
            iSpc21.ksSetSpcObjectColumnText(5, 1, 0, "Планка пояса");
            iSpc21.ksSetSpcObjectColumnText(6, 1, 0, "4");
            reference21 = iSpc21.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc22 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc22.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference22 = iSpc22.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam22 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc22.ksSpcObjectEdit(reference22);
            iDocumentSpc.ksGetObjParam(reference22, iSpcObjParam22, ldefin2d.ALLPARAM);
            iSpcObjParam22.blockNumber = 0;
            iSpcObjParam22.draw = 1;
            iSpcObjParam22.firstOnSheet = 0;
            iSpcObjParam22.ispoln = 0;
            iSpcObjParam22.posInc = 1;
            iSpcObjParam22.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference22, iSpcObjParam22, ldefin2d.ALLPARAM);
            iSpc22.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference22 = iSpc22.ksSpcObjectEnd();

            ksSpecification iSpc23 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc23.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference23 = iSpc23.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam23 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc23.ksSpcObjectEdit(reference23);
            iDocumentSpc.ksGetObjParam(reference23, iSpcObjParam23, ldefin2d.ALLPARAM);
            iSpcObjParam23.blockNumber = 0;
            iSpcObjParam23.draw = 2;
            iSpcObjParam23.firstOnSheet = 0;
            iSpcObjParam23.ispoln = 0;
            iSpcObjParam23.posInc = 2;
            iSpcObjParam23.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference23, iSpcObjParam23, ldefin2d.ALLPARAM);
            iSpc23.ksSetSpcObjectColumnText(5, 1, 0, DataSpecificationBox.ValueBox[0].around2);
            reference23 = iSpc23.ksSpcObjectEnd();

            ksSpecification iSpc24 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc24.ksSpcObjectCreate("", 0, 24, 0, 0, 1);
            int reference24 = iSpc24.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam24 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc24.ksSpcObjectEdit(reference24);
            iDocumentSpc.ksGetObjParam(reference24, iSpcObjParam24, ldefin2d.ALLPARAM);
            iSpcObjParam24.blockNumber = 0;
            iSpcObjParam24.draw = 2;
            iSpcObjParam24.firstOnSheet = 0;
            iSpcObjParam24.ispoln = 0;
            iSpcObjParam24.posInc = 2;
            iSpcObjParam24.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference24, iSpcObjParam24, ldefin2d.ALLPARAM);
            iSpc24.ksSetSpcObjectColumnText(5, 1, 0, GOST);
            reference24 = iSpc24.ksSpcObjectEnd();


            // 7 секция - планка пояса - вертикальная
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc25 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc25.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference25 = iSpc25.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam25 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc25.ksSpcObjectEdit(reference25);
            iDocumentSpc.ksGetObjParam(reference25, iSpcObjParam25, ldefin2d.ALLPARAM);
            iSpcObjParam25.blockNumber = 0;
            iSpcObjParam25.draw = 1;
            iSpcObjParam25.firstOnSheet = 0;
            iSpcObjParam25.ispoln = 0;
            iSpcObjParam25.posInc = 1;
            iSpcObjParam25.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference25, iSpcObjParam25, ldefin2d.ALLPARAM);
            iSpc25.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc25.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc25.ksSetSpcObjectColumnText(4, 1, 0, $"{name}.{CL_front}.{numDesignation}");
            iSpc25.ksSetSpcObjectColumnText(5, 1, 0, "Планка торцевого щита");
            iSpc25.ksSetSpcObjectColumnText(6, 1, 0, "4");
            reference25 = iSpc25.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc26 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc26.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference26 = iSpc26.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam26 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc26.ksSpcObjectEdit(reference26);
            iDocumentSpc.ksGetObjParam(reference26, iSpcObjParam26, ldefin2d.ALLPARAM);
            iSpcObjParam26.blockNumber = 0;
            iSpcObjParam26.draw = 1;
            iSpcObjParam26.firstOnSheet = 0;
            iSpcObjParam26.ispoln = 0;
            iSpcObjParam26.posInc = 1;
            iSpcObjParam26.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference26, iSpcObjParam26, ldefin2d.ALLPARAM);
            iSpc26.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference26 = iSpc26.ksSpcObjectEnd();

            ksSpecification iSpc27 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc27.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference27 = iSpc27.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam27 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc27.ksSpcObjectEdit(reference27);
            iDocumentSpc.ksGetObjParam(reference27, iSpcObjParam27, ldefin2d.ALLPARAM);
            iSpcObjParam27.blockNumber = 0;
            iSpcObjParam27.draw = 2;
            iSpcObjParam27.firstOnSheet = 0;
            iSpcObjParam27.ispoln = 0;
            iSpcObjParam27.posInc = 2;
            iSpcObjParam27.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference27, iSpcObjParam27, ldefin2d.ALLPARAM);
            iSpc27.ksSetSpcObjectColumnText(5, 1, 0, DataSpecificationBox.ValueBox[0].front1);
            reference27 = iSpc27.ksSpcObjectEnd();

            ksSpecification iSpc28 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc28.ksSpcObjectCreate("", 0, 28, 0, 0, 1);
            int reference28 = iSpc28.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam28 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc28.ksSpcObjectEdit(reference28);
            iDocumentSpc.ksGetObjParam(reference28, iSpcObjParam28, ldefin2d.ALLPARAM);
            iSpcObjParam28.blockNumber = 0;
            iSpcObjParam28.draw = 2;
            iSpcObjParam28.firstOnSheet = 0;
            iSpcObjParam28.ispoln = 0;
            iSpcObjParam28.posInc = 2;
            iSpcObjParam28.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference28, iSpcObjParam28, ldefin2d.ALLPARAM);
            iSpc28.ksSetSpcObjectColumnText(5, 1, 0, GOST);
            reference28 = iSpc28.ksSpcObjectEnd();

            //8 секция - планка пояса - горизонтальная
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc29 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc29.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference29 = iSpc29.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam29 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc29.ksSpcObjectEdit(reference29);
            iDocumentSpc.ksGetObjParam(reference29, iSpcObjParam29, ldefin2d.ALLPARAM);
            iSpcObjParam29.blockNumber = 0;
            iSpcObjParam29.draw = 1;
            iSpcObjParam29.firstOnSheet = 0;
            iSpcObjParam29.ispoln = 0;
            iSpcObjParam29.posInc = 1;
            iSpcObjParam29.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference29, iSpcObjParam29, ldefin2d.ALLPARAM);
            iSpc29.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc29.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc29.ksSetSpcObjectColumnText(4, 1, 0, $"{name}.{CL_front}.{numDesignation}");
            iSpc29.ksSetSpcObjectColumnText(5, 1, 0, "Планка торцевого щита");
            iSpc29.ksSetSpcObjectColumnText(6, 1, 0, "4");
            reference29 = iSpc29.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc30 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc30.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference30 = iSpc30.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam30 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc30.ksSpcObjectEdit(reference30);
            iDocumentSpc.ksGetObjParam(reference30, iSpcObjParam30, ldefin2d.ALLPARAM);
            iSpcObjParam30.blockNumber = 0;
            iSpcObjParam30.draw = 1;
            iSpcObjParam30.firstOnSheet = 0;
            iSpcObjParam30.ispoln = 0;
            iSpcObjParam30.posInc = 1;
            iSpcObjParam30.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference30, iSpcObjParam30, ldefin2d.ALLPARAM);
            iSpc30.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference30 = iSpc30.ksSpcObjectEnd();

            ksSpecification iSpc31 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc31.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference31 = iSpc31.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam31 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc31.ksSpcObjectEdit(reference31);
            iDocumentSpc.ksGetObjParam(reference31, iSpcObjParam31, ldefin2d.ALLPARAM);
            iSpcObjParam31.blockNumber = 0;
            iSpcObjParam31.draw = 2;
            iSpcObjParam31.firstOnSheet = 0;
            iSpcObjParam31.ispoln = 0;
            iSpcObjParam31.posInc = 2;
            iSpcObjParam31.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference31, iSpcObjParam31, ldefin2d.ALLPARAM);
            iSpc31.ksSetSpcObjectColumnText(5, 1, 0, DataSpecificationBox.ValueBox[0].front2);
            reference31 = iSpc31.ksSpcObjectEnd();

            ksSpecification iSpc32 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc32.ksSpcObjectCreate("", 0, 32, 0, 0, 1);
            int reference32 = iSpc32.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam32 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc32.ksSpcObjectEdit(reference32);
            iDocumentSpc.ksGetObjParam(reference32, iSpcObjParam32, ldefin2d.ALLPARAM);
            iSpcObjParam32.blockNumber = 0;
            iSpcObjParam32.draw = 2;
            iSpcObjParam32.firstOnSheet = 0;
            iSpcObjParam32.ispoln = 0;
            iSpcObjParam32.posInc = 2;
            iSpcObjParam32.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference32, iSpcObjParam32, ldefin2d.ALLPARAM);
            iSpc32.ksSetSpcObjectColumnText(5, 1, 0, GOST);
            reference32 = iSpc32.ksSpcObjectEnd();

            // // СТАНДАРТНЫЕ ИЗДЕЛИЯ


            // // Гвозди П 2,5х50 ГОСТ 4034-63
            // //Гвозди К 2,5х50 ГОСТ 4034-63

            ksSpecification iSpc33 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc33.ksSpcObjectCreate("", 0, 25, 0, 0, 1);
            int reference33 = iSpc33.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam33 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc33.ksSpcObjectEdit(reference33);
            iDocumentSpc.ksGetObjParam(reference33, iSpcObjParam33, ldefin2d.ALLPARAM);
            iSpcObjParam33.blockNumber = 0;
            iSpcObjParam33.draw = 2;
            iSpcObjParam33.firstOnSheet = 0;
            iSpcObjParam33.ispoln = 0;
            iSpcObjParam33.posInc = 2;
            iSpcObjParam33.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference33, iSpcObjParam33, ldefin2d.ALLPARAM);
            iSpc33.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc33.ksSetSpcObjectColumnText(5, 1, 0, "Гвозди П 2, 5х50");
            reference33 = iSpc33.ksSpcObjectEnd();

            ksSpecification iSpc34 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc34.ksSpcObjectCreate("", 0, 25, 0, 0, 1);
            int reference34 = iSpc34.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam34 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc34.ksSpcObjectEdit(reference34);
            iDocumentSpc.ksGetObjParam(reference34, iSpcObjParam34, ldefin2d.ALLPARAM);
            iSpcObjParam34.blockNumber = 0;
            iSpcObjParam34.draw = 2;
            iSpcObjParam34.firstOnSheet = 0;
            iSpcObjParam34.ispoln = 0;
            iSpcObjParam34.posInc = 2;
            iSpcObjParam34.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference34, iSpcObjParam34, ldefin2d.ALLPARAM);
            iSpc34.ksSetSpcObjectColumnText(5, 1, 0, "ГОСТ 4034 - 63");
            reference34 = iSpc34.ksSpcObjectEnd();

            //Лента Н — 0.5х30 ГОСТ3560—73

            ksSpecification iSpc35 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc35.ksSpcObjectCreate("", 0, 25, 0, 0, 1);
            int reference35 = iSpc35.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam35 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc35.ksSpcObjectEdit(reference35);
            iDocumentSpc.ksGetObjParam(reference35, iSpcObjParam35, ldefin2d.ALLPARAM);
            iSpcObjParam35.blockNumber = 0;
            iSpcObjParam35.draw = 2;
            iSpcObjParam35.firstOnSheet = 0;
            iSpcObjParam35.ispoln = 0;
            iSpcObjParam35.posInc = 2;
            iSpcObjParam35.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference35, iSpcObjParam35, ldefin2d.ALLPARAM);
            iSpc35.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc35.ksSetSpcObjectColumnText(5, 1, 0, "Лента Н - 0.5х30");
            reference35 = iSpc35.ksSpcObjectEnd();

            ksSpecification iSpc36 = (ksSpecification)iDocumentSpc.GetSpecification();
            iSpc36.ksSpcObjectCreate("", 0, 25, 0, 0, 1);
            int reference36 = iSpc36.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam36 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc36.ksSpcObjectEdit(reference36);
            iDocumentSpc.ksGetObjParam(reference36, iSpcObjParam36, ldefin2d.ALLPARAM);
            iSpcObjParam36.blockNumber = 0;
            iSpcObjParam36.draw = 2;
            iSpcObjParam36.firstOnSheet = 0;
            iSpcObjParam36.ispoln = 0;
            iSpcObjParam36.posInc = 2;
            iSpcObjParam36.posNotDraw = 0;
            iDocumentSpc.ksSetObjParam(reference36, iSpcObjParam36, ldefin2d.ALLPARAM);
            iSpc36.ksSetSpcObjectColumnText(5, 1, 0, "ГОСТ 3560 - 73");
            reference36 = iSpc36.ksSpcObjectEnd();

            string save;

            save = foldername + "\\Спецификация.spw";

            iDocumentSpc.ksSaveDocument(save);

        }




    }
}
