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

namespace WoodenBox
{
    internal class SpecificationBox
    {
        private KompasObject kompas; 

        
        public void CreateSpecification(string WoodGOST, string Wood, string NailsGOST, string NailsName, double mass1Nail,
            string TapeGOST, string TapeName, int heightBoard, string marking, int number, string foldername)
        {          
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

            string CL_cap = "321174"; // крышка 2 шт
            string CL_before = "321179"; // торцевой щит
            string CL_side = "321179"; // боковой щит
            string CL_around = "321175"; // планка пояса 
            string CL_front = "321175"; // планка торцевого щита
           
            // Доска - 2 - сосна - (ширина доски)
            // ГОСТ

            string board = $"Доска-2-{Wood}-{heightBoard}";            


            ksSpcDocument documentSpc = (ksSpcDocument)kompas.SpcDocument();
            //интерфейс документа-спецификации
            ksDocumentParam documentParam = (ksDocumentParam)kompas.
                GetParamStruct((short)StructType2DEnum.ko_DocumentParam);
            //интерфейс параметров документа
            if (documentParam == null)
                return;
            documentParam.Init();
            documentParam.type = (int)DocType.lt_DocSpc;
            ksSheetPar sheetParam = (ksSheetPar)documentParam.GetLayoutParam();
            //Интерфейс параметров оформления
            sheetParam.Init();
            sheetParam.layoutName = @"C:\Program Files\ASCON\KOMPAS-3D v21 Study\Sys\graphic.lyt";
            //путь до библиотеки стилей спецификации
            sheetParam.shtType = 1; //номер стиля из библиотеки
            documentSpc.ksCreateDocument(documentParam);
          

            
            int count = 1;
            string numDesignation = "000";

            if (number<10)
                numDesignation = $"00{number}";
            if (number >= 10 && number <100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            // 1 секция
            ksSpecification iSpc1 = (ksSpecification)documentSpc.GetSpecification();
            iSpc1.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference1 = iSpc1.ksSpcObjectEnd();

            ksSpcObjParam iSpcObjParam1 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc1.ksSpcObjectEdit(reference1);
            documentSpc.ksGetObjParam(reference1, iSpcObjParam1, ldefin2d.ALLPARAM);
            iSpcObjParam1.blockNumber = 0;
            iSpcObjParam1.draw = 1;
            iSpcObjParam1.firstOnSheet = 0;
            iSpcObjParam1.ispoln = 0;
            iSpcObjParam1.posInc = 1;
            iSpcObjParam1.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference1, iSpcObjParam1, ldefin2d.ALLPARAM);
            iSpc1.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc1.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc1.ksSetSpcObjectColumnText(4, 1, 0, $"{marking}.{CL_cap}.{numDesignation}");
            iSpc1.ksSetSpcObjectColumnText(5, 1, 0, "Крышка");
            iSpc1.ksSetSpcObjectColumnText(6, 1, 0, "2");
            iSpc1.ksSetSpcObjectColumnText(7, 1, 0, $"{InformationAboutBox.ValueBox[0].masscap} кг");
            reference1 = iSpc1.ksSpcObjectEnd();

            ksSpecification iSpc2 = (ksSpecification)documentSpc.GetSpecification();
            iSpc2.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference2 = iSpc2.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam2 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc2.ksSpcObjectEdit(reference2);
            documentSpc.ksGetObjParam(reference2, iSpcObjParam2, ldefin2d.ALLPARAM);
            iSpcObjParam2.blockNumber = 0;
            iSpcObjParam2.draw = 1;
            iSpcObjParam2.firstOnSheet = 0;
            iSpcObjParam2.ispoln = 0;
            iSpcObjParam2.posInc = 1;
            iSpcObjParam2.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference2, iSpcObjParam2, ldefin2d.ALLPARAM);
            iSpc2.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference2 = iSpc2.ksSpcObjectEnd();

            ksSpecification iSpc3 = (ksSpecification)documentSpc.GetSpecification();
            iSpc3.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference3 = iSpc3.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam3 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc3.ksSpcObjectEdit(reference3);
            documentSpc.ksGetObjParam(reference3, iSpcObjParam3, ldefin2d.ALLPARAM);
            iSpcObjParam3.blockNumber = 0;
            iSpcObjParam3.draw = 2;
            iSpcObjParam3.firstOnSheet = 0;
            iSpcObjParam3.ispoln = 0;
            iSpcObjParam3.posInc = 2;
            iSpcObjParam3.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference3, iSpcObjParam3, ldefin2d.ALLPARAM);
            iSpc3.ksSetSpcObjectColumnText(5, 1, 0, WoodGOST);
            reference3 = iSpc3.ksSpcObjectEnd();

            ksSpecification iSpc4 = (ksSpecification)documentSpc.GetSpecification();
            iSpc4.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference4 = iSpc4.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam4 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc4.ksSpcObjectEdit(reference4);
            documentSpc.ksGetObjParam(reference4, iSpcObjParam4, ldefin2d.ALLPARAM);
            iSpcObjParam4.blockNumber = 0;
            iSpcObjParam4.draw = 2;
            iSpcObjParam4.firstOnSheet = 0;
            iSpcObjParam4.ispoln = 0;
            iSpcObjParam4.posInc = 2;
            iSpcObjParam4.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference4, iSpcObjParam4, ldefin2d.ALLPARAM);
            iSpc4.ksSetSpcObjectColumnText(5, 1, 0, InformationAboutBox.ValueBox[0].cap);
            reference4 = iSpc4.ksSpcObjectEnd();

            count++;
            number++;

            // 2 секция           
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc9 = (ksSpecification)documentSpc.GetSpecification();
            iSpc9.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference9 = iSpc9.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam9 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc9.ksSpcObjectEdit(reference9);
            documentSpc.ksGetObjParam(reference9, iSpcObjParam9, ldefin2d.ALLPARAM);
            iSpcObjParam9.blockNumber = 0;
            iSpcObjParam9.draw = 1;
            iSpcObjParam9.firstOnSheet = 0;
            iSpcObjParam9.ispoln = 0;
            iSpcObjParam9.posInc = 1;
            iSpcObjParam9.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference9, iSpcObjParam9, ldefin2d.ALLPARAM);
            iSpc9.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc9.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc9.ksSetSpcObjectColumnText(4, 1, 0, $"{marking}.{CL_before}.{numDesignation}");
            iSpc9.ksSetSpcObjectColumnText(5, 1, 0, "Торцевой щит");
            iSpc9.ksSetSpcObjectColumnText(6, 1, 0, "2");
            iSpc9.ksSetSpcObjectColumnText(7, 1, 0, $"{InformationAboutBox.ValueBox[0].massbefore} кг");
            reference9 = iSpc9.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc10 = (ksSpecification)documentSpc.GetSpecification();
            iSpc10.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference10 = iSpc10.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam10 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc10.ksSpcObjectEdit(reference10);
            documentSpc.ksGetObjParam(reference10, iSpcObjParam10, ldefin2d.ALLPARAM);
            iSpcObjParam10.blockNumber = 0;
            iSpcObjParam10.draw = 1;
            iSpcObjParam10.firstOnSheet = 0;
            iSpcObjParam10.ispoln = 0;
            iSpcObjParam10.posInc = 1;
            iSpcObjParam10.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference10, iSpcObjParam10, ldefin2d.ALLPARAM);
            iSpc10.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference10 = iSpc10.ksSpcObjectEnd();

            ksSpecification iSpc11 = (ksSpecification)documentSpc.GetSpecification();
            iSpc11.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference11 = iSpc11.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam11 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc11.ksSpcObjectEdit(reference11);
            documentSpc.ksGetObjParam(reference11, iSpcObjParam11, ldefin2d.ALLPARAM);
            iSpcObjParam11.blockNumber = 0;
            iSpcObjParam11.draw = 2;
            iSpcObjParam11.firstOnSheet = 0;
            iSpcObjParam11.ispoln = 0;
            iSpcObjParam11.posInc = 2;
            iSpcObjParam11.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference11, iSpcObjParam11, ldefin2d.ALLPARAM);
            iSpc11.ksSetSpcObjectColumnText(5, 1, 0, WoodGOST);
            reference11 = iSpc11.ksSpcObjectEnd();

            ksSpecification iSpc12 = (ksSpecification)documentSpc.GetSpecification();
            iSpc12.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference12 = iSpc12.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam12 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc12.ksSpcObjectEdit(reference12);
            documentSpc.ksGetObjParam(reference12, iSpcObjParam12, ldefin2d.ALLPARAM);
            iSpcObjParam12.blockNumber = 0;
            iSpcObjParam12.draw = 2;
            iSpcObjParam12.firstOnSheet = 0;
            iSpcObjParam12.ispoln = 0;
            iSpcObjParam12.posInc = 2;
            iSpcObjParam12.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference12, iSpcObjParam12, ldefin2d.ALLPARAM);
            iSpc12.ksSetSpcObjectColumnText(5, 1, 0, InformationAboutBox.ValueBox[0].before);
            reference12 = iSpc12.ksSpcObjectEnd();

            // 3 секция           
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc13 = (ksSpecification)documentSpc.GetSpecification();
            iSpc13.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference13 = iSpc13.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam13 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc13.ksSpcObjectEdit(reference13);
            documentSpc.ksGetObjParam(reference13, iSpcObjParam13, ldefin2d.ALLPARAM);
            iSpcObjParam13.blockNumber = 0;
            iSpcObjParam13.draw = 1;
            iSpcObjParam13.firstOnSheet = 0;
            iSpcObjParam13.ispoln = 0;
            iSpcObjParam13.posInc = 1;
            iSpcObjParam13.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference13, iSpcObjParam13, ldefin2d.ALLPARAM);
            iSpc13.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc13.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc13.ksSetSpcObjectColumnText(4, 1, 0, $"{marking}.{CL_side}.{numDesignation}");
            iSpc13.ksSetSpcObjectColumnText(5, 1, 0, "Боковой щит");
            iSpc13.ksSetSpcObjectColumnText(6, 1, 0, "2");
            iSpc13.ksSetSpcObjectColumnText(7, 1, 0, $"{InformationAboutBox.ValueBox[0].massside} кг");
            reference13 = iSpc13.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc14 = (ksSpecification)documentSpc.GetSpecification();
            iSpc14.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference14 = iSpc14.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam14 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc14.ksSpcObjectEdit(reference14);
            documentSpc.ksGetObjParam(reference14, iSpcObjParam14, ldefin2d.ALLPARAM);
            iSpcObjParam14.blockNumber = 0;
            iSpcObjParam14.draw = 1;
            iSpcObjParam14.firstOnSheet = 0;
            iSpcObjParam14.ispoln = 0;
            iSpcObjParam14.posInc = 1;
            iSpcObjParam14.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference14, iSpcObjParam14, ldefin2d.ALLPARAM);
            iSpc14.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference14 = iSpc14.ksSpcObjectEnd();

            ksSpecification iSpc15 = (ksSpecification)documentSpc.GetSpecification();
            iSpc15.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference15 = iSpc15.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam15 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc15.ksSpcObjectEdit(reference15);
            documentSpc.ksGetObjParam(reference15, iSpcObjParam15, ldefin2d.ALLPARAM);
            iSpcObjParam15.blockNumber = 0;
            iSpcObjParam15.draw = 2;
            iSpcObjParam15.firstOnSheet = 0;
            iSpcObjParam15.ispoln = 0;
            iSpcObjParam15.posInc = 2;
            iSpcObjParam15.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference15, iSpcObjParam15, ldefin2d.ALLPARAM);
            iSpc15.ksSetSpcObjectColumnText(5, 1, 0, WoodGOST);
            reference15 = iSpc15.ksSpcObjectEnd();

            ksSpecification iSpc16 = (ksSpecification)documentSpc.GetSpecification();
            iSpc16.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference16 = iSpc16.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam16 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc16.ksSpcObjectEdit(reference16);
            documentSpc.ksGetObjParam(reference16, iSpcObjParam16, ldefin2d.ALLPARAM);
            iSpcObjParam16.blockNumber = 0;
            iSpcObjParam16.draw = 2;
            iSpcObjParam16.firstOnSheet = 0;
            iSpcObjParam16.ispoln = 0;
            iSpcObjParam16.posInc = 2;
            iSpcObjParam16.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference16, iSpcObjParam16, ldefin2d.ALLPARAM);
            iSpc16.ksSetSpcObjectColumnText(5, 1, 0, InformationAboutBox.ValueBox[0].side);
            reference16 = iSpc16.ksSpcObjectEnd();


            // 4 секция - планка пояса - верхняя     
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc17 = (ksSpecification)documentSpc.GetSpecification();
            iSpc17.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference17 = iSpc17.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam17 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc17.ksSpcObjectEdit(reference17);
            documentSpc.ksGetObjParam(reference17, iSpcObjParam17, ldefin2d.ALLPARAM);
            iSpcObjParam17.blockNumber = 0;
            iSpcObjParam17.draw = 1;
            iSpcObjParam17.firstOnSheet = 0;
            iSpcObjParam17.ispoln = 0;
            iSpcObjParam17.posInc = 1;
            iSpcObjParam17.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference17, iSpcObjParam17, ldefin2d.ALLPARAM);
            iSpc17.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc17.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc17.ksSetSpcObjectColumnText(4, 1, 0, $"{marking}.{CL_around}.{numDesignation}");
            iSpc17.ksSetSpcObjectColumnText(5, 1, 0, "Планка пояса");
            iSpc17.ksSetSpcObjectColumnText(6, 1, 0, "4");
            iSpc17.ksSetSpcObjectColumnText(7, 1, 0, $"{InformationAboutBox.ValueBox[0].massaround1} кг");
            reference17 = iSpc17.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc18 = (ksSpecification)documentSpc.GetSpecification();
            iSpc18.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference18 = iSpc18.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam18 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc18.ksSpcObjectEdit(reference18);
            documentSpc.ksGetObjParam(reference18, iSpcObjParam18, ldefin2d.ALLPARAM);
            iSpcObjParam18.blockNumber = 0;
            iSpcObjParam18.draw = 1;
            iSpcObjParam18.firstOnSheet = 0;
            iSpcObjParam18.ispoln = 0;
            iSpcObjParam18.posInc = 1;
            iSpcObjParam18.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference18, iSpcObjParam18, ldefin2d.ALLPARAM);
            iSpc18.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference18 = iSpc18.ksSpcObjectEnd();

            ksSpecification iSpc19 = (ksSpecification)documentSpc.GetSpecification();
            iSpc19.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference19 = iSpc19.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam19 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc19.ksSpcObjectEdit(reference19);
            documentSpc.ksGetObjParam(reference19, iSpcObjParam19, ldefin2d.ALLPARAM);
            iSpcObjParam19.blockNumber = 0;
            iSpcObjParam19.draw = 2;
            iSpcObjParam19.firstOnSheet = 0;
            iSpcObjParam19.ispoln = 0;
            iSpcObjParam19.posInc = 2;
            iSpcObjParam19.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference19, iSpcObjParam19, ldefin2d.ALLPARAM);
            iSpc19.ksSetSpcObjectColumnText(5, 1, 0, WoodGOST);
            reference19 = iSpc19.ksSpcObjectEnd();

            ksSpecification iSpc20 = (ksSpecification)documentSpc.GetSpecification();
            iSpc20.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference20 = iSpc20.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam20 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc20.ksSpcObjectEdit(reference20);
            documentSpc.ksGetObjParam(reference20, iSpcObjParam20, ldefin2d.ALLPARAM);
            iSpcObjParam20.blockNumber = 0;
            iSpcObjParam20.draw = 2;
            iSpcObjParam20.firstOnSheet = 0;
            iSpcObjParam20.ispoln = 0;
            iSpcObjParam20.posInc = 2;
            iSpcObjParam20.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference20, iSpcObjParam20, ldefin2d.ALLPARAM);
            iSpc20.ksSetSpcObjectColumnText(5, 1, 0, InformationAboutBox.ValueBox[0].around1);
            reference20 = iSpc20.ksSpcObjectEnd();


            // 5 секция - планка пояса - боковая    
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc21 = (ksSpecification)documentSpc.GetSpecification();
            iSpc21.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference21 = iSpc21.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam21 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc21.ksSpcObjectEdit(reference21);
            documentSpc.ksGetObjParam(reference21, iSpcObjParam21, ldefin2d.ALLPARAM);
            iSpcObjParam21.blockNumber = 0;
            iSpcObjParam21.draw = 1;
            iSpcObjParam21.firstOnSheet = 0;
            iSpcObjParam21.ispoln = 0;
            iSpcObjParam21.posInc = 1;
            iSpcObjParam21.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference21, iSpcObjParam21, ldefin2d.ALLPARAM);
            iSpc21.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc21.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc21.ksSetSpcObjectColumnText(4, 1, 0, $"{marking}.{CL_around}.{numDesignation}");
            iSpc21.ksSetSpcObjectColumnText(5, 1, 0, "Планка пояса");
            iSpc21.ksSetSpcObjectColumnText(6, 1, 0, "4");
            iSpc21.ksSetSpcObjectColumnText(7, 1, 0, $"{InformationAboutBox.ValueBox[0].massaround2} кг");
            reference21 = iSpc21.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc22 = (ksSpecification)documentSpc.GetSpecification();
            iSpc22.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference22 = iSpc22.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam22 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc22.ksSpcObjectEdit(reference22);
            documentSpc.ksGetObjParam(reference22, iSpcObjParam22, ldefin2d.ALLPARAM);
            iSpcObjParam22.blockNumber = 0;
            iSpcObjParam22.draw = 1;
            iSpcObjParam22.firstOnSheet = 0;
            iSpcObjParam22.ispoln = 0;
            iSpcObjParam22.posInc = 1;
            iSpcObjParam22.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference22, iSpcObjParam22, ldefin2d.ALLPARAM);
            iSpc22.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference22 = iSpc22.ksSpcObjectEnd();

            ksSpecification iSpc23 = (ksSpecification)documentSpc.GetSpecification();
            iSpc23.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference23 = iSpc23.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam23 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc23.ksSpcObjectEdit(reference23);
            documentSpc.ksGetObjParam(reference23, iSpcObjParam23, ldefin2d.ALLPARAM);
            iSpcObjParam23.blockNumber = 0;
            iSpcObjParam23.draw = 2;
            iSpcObjParam23.firstOnSheet = 0;
            iSpcObjParam23.ispoln = 0;
            iSpcObjParam23.posInc = 2;
            iSpcObjParam23.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference23, iSpcObjParam23, ldefin2d.ALLPARAM);
            iSpc23.ksSetSpcObjectColumnText(5, 1, 0, WoodGOST);
            reference23 = iSpc23.ksSpcObjectEnd();

            ksSpecification iSpc24 = (ksSpecification)documentSpc.GetSpecification();
            iSpc24.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference24 = iSpc24.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam24 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc24.ksSpcObjectEdit(reference24);
            documentSpc.ksGetObjParam(reference24, iSpcObjParam24, ldefin2d.ALLPARAM);
            iSpcObjParam24.blockNumber = 0;
            iSpcObjParam24.draw = 2;
            iSpcObjParam24.firstOnSheet = 0;
            iSpcObjParam24.ispoln = 0;
            iSpcObjParam24.posInc = 2;
            iSpcObjParam24.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference24, iSpcObjParam24, ldefin2d.ALLPARAM);
            iSpc24.ksSetSpcObjectColumnText(5, 1, 0, InformationAboutBox.ValueBox[0].around2);
            reference24 = iSpc24.ksSpcObjectEnd();


            // 6 секция - планка пояса - вертикальная
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc25 = (ksSpecification)documentSpc.GetSpecification();
            iSpc25.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference25 = iSpc25.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam25 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc25.ksSpcObjectEdit(reference25);
            documentSpc.ksGetObjParam(reference25, iSpcObjParam25, ldefin2d.ALLPARAM);
            iSpcObjParam25.blockNumber = 0;
            iSpcObjParam25.draw = 1;
            iSpcObjParam25.firstOnSheet = 0;
            iSpcObjParam25.ispoln = 0;
            iSpcObjParam25.posInc = 1;
            iSpcObjParam25.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference25, iSpcObjParam25, ldefin2d.ALLPARAM);
            iSpc25.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc25.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc25.ksSetSpcObjectColumnText(4, 1, 0, $"{marking}.{CL_front}.{numDesignation}");
            iSpc25.ksSetSpcObjectColumnText(5, 1, 0, "Планка торцевого щита");
            iSpc25.ksSetSpcObjectColumnText(6, 1, 0, "4");
            iSpc25.ksSetSpcObjectColumnText(7, 1, 0, $"{InformationAboutBox.ValueBox[0].massfront1} кг");
            reference25 = iSpc25.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc26 = (ksSpecification)documentSpc.GetSpecification();
            iSpc26.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference26 = iSpc26.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam26 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc26.ksSpcObjectEdit(reference26);
            documentSpc.ksGetObjParam(reference26, iSpcObjParam26, ldefin2d.ALLPARAM);
            iSpcObjParam26.blockNumber = 0;
            iSpcObjParam26.draw = 1;
            iSpcObjParam26.firstOnSheet = 0;
            iSpcObjParam26.ispoln = 0;
            iSpcObjParam26.posInc = 1;
            iSpcObjParam26.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference26, iSpcObjParam26, ldefin2d.ALLPARAM);
            iSpc26.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference26 = iSpc26.ksSpcObjectEnd();

            ksSpecification iSpc27 = (ksSpecification)documentSpc.GetSpecification();
            iSpc27.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference27 = iSpc27.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam27 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc27.ksSpcObjectEdit(reference27);
            documentSpc.ksGetObjParam(reference27, iSpcObjParam27, ldefin2d.ALLPARAM);
            iSpcObjParam27.blockNumber = 0;
            iSpcObjParam27.draw = 2;
            iSpcObjParam27.firstOnSheet = 0;
            iSpcObjParam27.ispoln = 0;
            iSpcObjParam27.posInc = 2;
            iSpcObjParam27.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference27, iSpcObjParam27, ldefin2d.ALLPARAM);
            iSpc27.ksSetSpcObjectColumnText(5, 1, 0, WoodGOST);
            reference27 = iSpc27.ksSpcObjectEnd();

            ksSpecification iSpc28 = (ksSpecification)documentSpc.GetSpecification();
            iSpc28.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference28 = iSpc28.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam28 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc28.ksSpcObjectEdit(reference28);
            documentSpc.ksGetObjParam(reference28, iSpcObjParam28, ldefin2d.ALLPARAM);
            iSpcObjParam28.blockNumber = 0;
            iSpcObjParam28.draw = 2;
            iSpcObjParam28.firstOnSheet = 0;
            iSpcObjParam28.ispoln = 0;
            iSpcObjParam28.posInc = 2;
            iSpcObjParam28.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference28, iSpcObjParam28, ldefin2d.ALLPARAM);
            iSpc28.ksSetSpcObjectColumnText(5, 1, 0, InformationAboutBox.ValueBox[0].front1);
            reference28 = iSpc28.ksSpcObjectEnd();

            //7 секция - планка пояса - горизонтальная
            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";

            ksSpecification iSpc29 = (ksSpecification)documentSpc.GetSpecification();
            iSpc29.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference29 = iSpc29.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam29 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc29.ksSpcObjectEdit(reference29);
            documentSpc.ksGetObjParam(reference29, iSpcObjParam29, ldefin2d.ALLPARAM);
            iSpcObjParam29.blockNumber = 0;
            iSpcObjParam29.draw = 1;
            iSpcObjParam29.firstOnSheet = 0;
            iSpcObjParam29.ispoln = 0;
            iSpcObjParam29.posInc = 1;
            iSpcObjParam29.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference29, iSpcObjParam29, ldefin2d.ALLPARAM);
            iSpc29.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc29.ksSetSpcObjectColumnText(3, 1, 0, $"{count}");
            iSpc29.ksSetSpcObjectColumnText(4, 1, 0, $"{marking}.{CL_front}.{numDesignation}");
            iSpc29.ksSetSpcObjectColumnText(5, 1, 0, "Планка торцевого щита");
            iSpc29.ksSetSpcObjectColumnText(6, 1, 0, "4");
            iSpc29.ksSetSpcObjectColumnText(7, 1, 0, $"{InformationAboutBox.ValueBox[0].massfront2} кг");
            reference29 = iSpc29.ksSpcObjectEnd();
            count++;
            number++;

            ksSpecification iSpc30 = (ksSpecification)documentSpc.GetSpecification();
            iSpc30.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference30 = iSpc30.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam30 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc30.ksSpcObjectEdit(reference30);
            documentSpc.ksGetObjParam(reference30, iSpcObjParam30, ldefin2d.ALLPARAM);
            iSpcObjParam30.blockNumber = 0;
            iSpcObjParam30.draw = 1;
            iSpcObjParam30.firstOnSheet = 0;
            iSpcObjParam30.ispoln = 0;
            iSpcObjParam30.posInc = 1;
            iSpcObjParam30.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference30, iSpcObjParam30, ldefin2d.ALLPARAM);
            iSpc30.ksSetSpcObjectColumnText(5, 1, 0, board);
            reference30 = iSpc30.ksSpcObjectEnd();

            ksSpecification iSpc31 = (ksSpecification)documentSpc.GetSpecification();
            iSpc31.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference31 = iSpc31.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam31 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc31.ksSpcObjectEdit(reference31);
            documentSpc.ksGetObjParam(reference31, iSpcObjParam31, ldefin2d.ALLPARAM);
            iSpcObjParam31.blockNumber = 0;
            iSpcObjParam31.draw = 2;
            iSpcObjParam31.firstOnSheet = 0;
            iSpcObjParam31.ispoln = 0;
            iSpcObjParam31.posInc = 2;
            iSpcObjParam31.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference31, iSpcObjParam31, ldefin2d.ALLPARAM);
            iSpc31.ksSetSpcObjectColumnText(5, 1, 0, WoodGOST);
            reference31 = iSpc31.ksSpcObjectEnd();

            ksSpecification iSpc32 = (ksSpecification)documentSpc.GetSpecification();
            iSpc32.ksSpcObjectCreate("", 0, 20, 0, 0, 1);
            int reference32 = iSpc32.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam32 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc32.ksSpcObjectEdit(reference32);
            documentSpc.ksGetObjParam(reference32, iSpcObjParam32, ldefin2d.ALLPARAM);
            iSpcObjParam32.blockNumber = 0;
            iSpcObjParam32.draw = 2;
            iSpcObjParam32.firstOnSheet = 0;
            iSpcObjParam32.ispoln = 0;
            iSpcObjParam32.posInc = 2;
            iSpcObjParam32.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference32, iSpcObjParam32, ldefin2d.ALLPARAM);
            iSpc32.ksSetSpcObjectColumnText(5, 1, 0, InformationAboutBox.ValueBox[0].front2);
            reference32 = iSpc32.ksSpcObjectEnd();


            // СТАНДАРТНЫЕ ИЗДЕЛИЯ

            double massNails = mass1Nail * InformationAboutBox.ValueBox[0].colNails;
            massNails = Math.Round(massNails, 2);

            ksSpecification iSpc33 = (ksSpecification)documentSpc.GetSpecification();
            iSpc33.ksSpcObjectCreate("", 0, 25, 0, 0, 1);
            int reference33 = iSpc33.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam33 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc33.ksSpcObjectEdit(reference33);
            documentSpc.ksGetObjParam(reference33, iSpcObjParam33, ldefin2d.ALLPARAM);
            iSpcObjParam33.blockNumber = 0;
            iSpcObjParam33.draw = 2;
            iSpcObjParam33.firstOnSheet = 0;
            iSpcObjParam33.ispoln = 0;
            iSpcObjParam33.posInc = 2;
            iSpcObjParam33.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference33, iSpcObjParam33, ldefin2d.ALLPARAM);
            iSpc33.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc33.ksSetSpcObjectColumnText(5, 1, 0, NailsName);
            iSpc33.ksSetSpcObjectColumnText(7, 1, 0, $"{massNails} кг") ;
            reference33 = iSpc33.ksSpcObjectEnd();

            ksSpecification iSpc34 = (ksSpecification)documentSpc.GetSpecification();
            iSpc34.ksSpcObjectCreate("", 0, 25, 0, 0, 1);
            int reference34 = iSpc34.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam34 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc34.ksSpcObjectEdit(reference34);
            documentSpc.ksGetObjParam(reference34, iSpcObjParam34, ldefin2d.ALLPARAM);
            iSpcObjParam34.blockNumber = 0;
            iSpcObjParam34.draw = 2;
            iSpcObjParam34.firstOnSheet = 0;
            iSpcObjParam34.ispoln = 0;
            iSpcObjParam34.posInc = 2;
            iSpcObjParam34.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference34, iSpcObjParam34, ldefin2d.ALLPARAM);
            iSpc34.ksSetSpcObjectColumnText(5, 1, 0, NailsGOST);
            reference34 = iSpc34.ksSpcObjectEnd();

            //Лента Н — 0.5х30 ГОСТ3560—73
            //Лента Н-2-2х50 ГОСТ 503

            ksSpecification iSpc35 = (ksSpecification)documentSpc.GetSpecification();
            iSpc35.ksSpcObjectCreate("", 0, 25, 0, 0, 1);
            int reference35 = iSpc35.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam35 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc35.ksSpcObjectEdit(reference35);
            documentSpc.ksGetObjParam(reference35, iSpcObjParam35, ldefin2d.ALLPARAM);
            iSpcObjParam35.blockNumber = 0;
            iSpcObjParam35.draw = 2;
            iSpcObjParam35.firstOnSheet = 0;
            iSpcObjParam35.ispoln = 0;
            iSpcObjParam35.posInc = 2;
            iSpcObjParam35.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference35, iSpcObjParam35, ldefin2d.ALLPARAM);
            iSpc35.ksSetSpcObjectColumnText(1, 1, 0, "БЧ");
            iSpc35.ksSetSpcObjectColumnText(5, 1, 0, TapeName);
            iSpc35.ksSetSpcObjectColumnText(7, 1, 0, $"{InformationAboutBox.ValueBox[0].lengthTape} м");
            reference35 = iSpc35.ksSpcObjectEnd();

            ksSpecification iSpc36 = (ksSpecification)documentSpc.GetSpecification();
            iSpc36.ksSpcObjectCreate("", 0, 25, 0, 0, 1);
            int reference36 = iSpc36.ksSpcObjectEnd();
            ksSpcObjParam iSpcObjParam36 =
           (ksSpcObjParam)kompas.GetParamStruct((short)StructType2DEnum.ko_SpcObjParam);
            iSpc36.ksSpcObjectEdit(reference36);
            documentSpc.ksGetObjParam(reference36, iSpcObjParam36, ldefin2d.ALLPARAM);
            iSpcObjParam36.blockNumber = 0;
            iSpcObjParam36.draw = 2;
            iSpcObjParam36.firstOnSheet = 0;
            iSpcObjParam36.ispoln = 0;
            iSpcObjParam36.posInc = 2;
            iSpcObjParam36.posNotDraw = 0;
            documentSpc.ksSetObjParam(reference36, iSpcObjParam36, ldefin2d.ALLPARAM);
            iSpc36.ksSetSpcObjectColumnText(5, 1, 0, TapeGOST);
            reference36 = iSpc36.ksSpcObjectEnd();

            string save;

            save = foldername + "\\Спецификация на Ящик.spw";

            documentSpc.ksSaveDocument(save);

        }




    }
}
