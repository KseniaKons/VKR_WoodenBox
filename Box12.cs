using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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


        void CalculationBoardsLeaves(int param, int gap, out double w_fact_bottom, out double col_fact_bottom)
        {
            //параметр по которому считаем, ширина доски вернется, количество досок вернется 

            w_fact_bottom = 0; //посчитанная длиннна доски
            col_fact_bottom = 0; // посчитанное количество
            int w_sh = 10000, buf_sh = 0;
            int col = 0;

            int[] arr = { 80, 90, 100, 110, 130, 150, 180, 200 };

            for (int i = 0; i < arr.Length; i++)
            {
                while (buf_sh - gap < param)
                {
                    buf_sh = buf_sh + arr[i] + gap;
                    col++;
                }

                buf_sh = buf_sh - gap;

                if (buf_sh < w_sh)
                {
                    w_sh = buf_sh;
                    w_fact_bottom = arr[i];
                    col_fact_bottom = col;
                }

                buf_sh = 0; col = 0;
            }
        }

        private void CalculationBoardsConifer(int param, int gap, int boardWidth, out double w_fact_bottom, out double col_fact_bottom)
        {
            //параметр по которому считаем, ширина доски вернется, количество досок вернется 

            w_fact_bottom = 0; //посчитанная длиннна доски
            col_fact_bottom = 0; // посчитанное количество
            int w_sh = 10000, buf_sh = 0;
            int col = 0;

            int[] arr = { 75, 100, 125, 150, 175, 200, 225, 250, 275 };

            if (boardWidth == 22)
            {
                //убрать последние два размера
                arr = arr.Take(arr.Length - 2).ToArray();
            }

            for (int i = 0; i < arr.Length; i++)
            {
                while (buf_sh - gap < param)
                {
                    buf_sh = buf_sh + arr[i] + gap;
                    col++;
                }

                buf_sh = buf_sh - gap;

                if (buf_sh < w_sh)
                {
                    w_sh = buf_sh;
                    w_fact_bottom = arr[i];
                    col_fact_bottom = col;
                }

                buf_sh = 0; col = 0;
            }
        }

        void NewShield(double height, double width, double length, double col, double gap, string name, string foldername)
        {
            ksDoc3d = (ksDocument3D)kompas.Document3D();
            ksDoc3d.Create(false, true);
            ksDoc3d.fileName = name; // указание названия файла

            part = ksDoc3d.GetPart((int)Part_Type.pTop_Part); // получаем интерфейс новой детали

            ksEntity basePlaneXOY = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY);
            // получим интерфейс базовой плоскости XOY


            ksEntity ksNewScetchE = part.NewEntity((int)Obj3dType.o3d_sketch); // создание нового эскиза
            ksSketchDefinition ksNewScetchDef = ksNewScetchE.GetDefinition(); // получаем интерфейс свойств эскиза
            ksNewScetchDef.SetPlane(basePlaneXOY); // установим плоскость ZOY базовой 
            ksNewScetchE.Create(); // создадим эски

            ksDocument2D NewSketch = (ksDocument2D)ksNewScetchDef.BeginEdit(); // начинаем редактирование эскиз

            // получаем интерфейс параметров для создания прямоугольника
            ksRectangleParam recParam =
            (ksRectangleParam)kompas.GetParamStruct((short)StructType2DEnum.ko_RectangleParam);
            recParam.x = 0; // координата х одной из вершин прямоугольника
            recParam.y = 0; // координата y одной из вершин прямоугольника
            recParam.height = height; // высота
            recParam.width = width; // ширина
            recParam.ang = 0; // угол поворота
            recParam.style = 1; // стиль линии
            // отправляем интерфейс параметров в функцию создания
            NewSketch.ksRectangle(recParam);

            ksNewScetchDef.EndEdit(); //закончить редактирование

            // создаём объект выдавливания
            ksEntity bossExtr = part.NewEntity((short)Obj3dType.o3d_bossExtrusion);

            // интерфейс настроек выдавливания
            ksBossExtrusionDefinition ExtrDef = bossExtr.GetDefinition();
            ksExtrusionParam extrProp = (ksExtrusionParam)ExtrDef.ExtrusionParam();

            // создание выдавливания ////
            if (extrProp != null)
            {
                ExtrDef.SetSketch(ksNewScetchE); // эскиз операции выдавливания
                                                 // направление выдавливания (обычное)

                extrProp.direction = (short)Direction_Type.dtNormal;
                // тип выдавливания 
                extrProp.typeNormal = (short)End_Type.etBlind;
                extrProp.depthNormal = length; // глубина выдавливания
                bossExtr.Create(); // создадим операцию

            }


            /////ИЩУ ГРАНИ


            ksEntityCollection flFaces = part.EntityCollection((int)Obj3dType.o3d_face);

            for (int i = 0; i < flFaces.GetCount(); i++)
            {
                ksEntity face = flFaces.GetByIndex(i);
                ksFaceDefinition def = face.GetDefinition();
                if (def.GetOwnerEntity() == bossExtr)
                {
                    if (def.IsPlanar())
                    {
                        ksEdgeCollection col1 = def.EdgeCollection();
                        ksEdgeCollection col2 = def.EdgeCollection();
                        for (int k = 0; k < col1.GetCount(); k++)
                        {
                            for (int k1 = 0; k1 < col2.GetCount(); k1++)
                            {

                                ksEdgeDefinition d1 = col1.GetByIndex(k);
                                ksEdgeDefinition d2 = col2.GetByIndex(k1);

                                ksVertexDefinition p1 = d1.GetVertex(true);
                                ksVertexDefinition p2 = d2.GetVertex(true);

                                double x1, y1, z1;
                                double x2, y2, z2;

                                p1.GetPoint(out x1, out y1, out z1);
                                p2.GetPoint(out x2, out y2, out z2);

                                // Нулевая боковая

                                if (x1 == 0 && z1 == 0 && y1 == 0)
                                {
                                    if (x2 == 0 && y2 == height && z2 == length)
                                    {
                                        face.name = ("Number0");
                                        face.Update();
                                        break;
                                    }
                                }

                                // Первая нижняя

                                if (x1 == 0 && z1 == 0 && y1 == 0)
                                {
                                    if (x2 == width && y2 == height && z2 == 0)
                                    {
                                        face.name = ("Number1");
                                        face.Update();
                                        break;
                                    }

                                }

                                // Вторя верхняя

                                if (x1 == 0 && y1 == 0 && z1 == length)
                                {
                                    if (x2 == width && y2 == height && z2 == length)
                                    {
                                        face.name = ("Number2");
                                        face.Update();
                                        break;
                                    }

                                }

                                // Третья передняя

                                if (x1 == 0 && y1 == height && z1 == 0)
                                {
                                    if (x2 == width && y2 == height && z2 == length)
                                    {
                                        face.name = ("Number3");
                                        face.Update();
                                        break;
                                    }

                                }

                                // Четвертая задняя

                                if (x1 == width && y1 == 0 && z1 == 0)
                                {
                                    if (x2 == 0 && y2 == 0 && z2 == length)
                                    {
                                        face.name = ("Number4");
                                        face.Update();
                                        break;
                                    }

                                }



                            }
                        }
                    }
                }
            }

            //// массив по сетке //


            // создаём операцию линейного массива
            ksEntity MeshCopyE = part.NewEntity((short)Obj3dType.o3d_meshCopy);

            MeshCopyDefinition MeshCopyDef = MeshCopyE.GetDefinition(); //создаём интерфейс свойств линейного массива

            ksEntity baseAxisX = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_axisOX); //создаём ось линейного массива на основе базовой Х
            MeshCopyDef.SetAxis1(baseAxisX); //выставляем базовую ось для первого направления

            MeshCopyDef.count1 = (int)col; 
            MeshCopyDef.step1 = width + gap;
            //MeshCopyDef.angle1 = gap;

            //создаём коллекцию для копируемых элементов
            ksEntityCollection EntityCollection = MeshCopyDef.OperationArray();
            EntityCollection.Clear(); // очищаем её

            EntityCollection.Add(bossExtr); //добавляем элемент выдавливания в коллекци.

            MeshCopyE.Create(); // создаём массив

            // сохранение //

            string save;

            save = foldername + "\\" + name + ".m3d";

            ksDoc3d.SaveAs(save);
        }


        public void СreatingBox12(int x, int y, int z, double massa, int gap, int GOST, int heightBoard, string foldername)
        { //gap зазор
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

            double w_fact_bottom = 0, col_fact_bottom = 0;
            double w_fact_side = 0, col_fact_side = 0;

            if (GOST == 0) //ЛИСТВЕННЫЕ ПОРОДЫ
            {
                // ДОСКИ ДНА И КРЫШКИ
                CalculationBoardsLeaves(x + 2 * heightBoard, gap, out w_fact_bottom, out col_fact_bottom);

                // ДОСКИ БОКОВОГО ЩИТА
                CalculationBoardsLeaves(z, gap, out w_fact_side, out col_fact_side);
            }
            else if (GOST == 1) //ХВОЙНЫЕ ПОРОДЫ
            {
                // ДОСКИ ДНА И КРЫШКИ
                CalculationBoardsConifer(x + 2 * heightBoard, gap, heightBoard, out w_fact_bottom, out col_fact_bottom);

                // ДОСКИ БОКОВОГО ЩИТА
                CalculationBoardsConifer(z, gap, heightBoard, out w_fact_side, out col_fact_side);
            }


            string name_bottom = "Щит дна и крышки";
            string name_side = "Боковой щит";
            string name_before = "Торцевой щит";

            double lenghtBT = w_fact_bottom * col_fact_bottom - 2 * heightBoard + gap * (col_fact_bottom - 1);

            //ЩИТ дна и крышки
            NewShield(heightBoard, w_fact_bottom, y + 4 * heightBoard, col_fact_bottom, gap, name_bottom, foldername);

            //боковой щит
            NewShield(heightBoard, w_fact_side, y + 4 * heightBoard, col_fact_side, gap, name_side, foldername);

            //торцевой щит
            NewShield(heightBoard, w_fact_side, lenghtBT, col_fact_side, gap, name_before, foldername);


            ////////////////СБОРКА

            ksDocument3D ksDoc3d1 = (ksDocument3D)kompas.Document3D();
            ksDoc3d1.Create(false, false);
            ksPart partAs = ksDoc3d1.GetPart((int)Part_Type.pTop_Part); // получаем интерфейс новой сборки


            ////////////ДНО

            string file_bottom;
            file_bottom = foldername + "\\" + name_bottom + ".m3d";

            string file_side;
            file_side = foldername + "\\" + name_side + ".m3d";

            string file_before;
            file_before = foldername + "\\" + name_before + ".m3d";

            ksEntityCollection pCol;
            ksEntity[] namePlane = new ksEntity[5];

            ksEntityCollection pCol1;
            ksEntity[] namePlane1 = new ksEntity[5];

            ksEntityCollection pCol2;
            ksEntity[] namePlane2 = new ksEntity[5];

            ksEntityCollection pCol3;
            ksEntity[] namePlane3 = new ksEntity[5];

            ksEntityCollection pCol4;
            ksEntity[] namePlane4 = new ksEntity[5];

            ksEntityCollection pCol5;
            ksEntity[] namePlane5 = new ksEntity[5];

            ksDoc3d1.SetPartFromFile(file_bottom, partAs, false); //дно
            ksDoc3d1.SetPartFromFile(file_side, partAs, false); //боковой щит 1
            ksDoc3d1.SetPartFromFile(file_side, partAs, false); //боковой щит 2
            ksDoc3d1.SetPartFromFile(file_bottom, partAs, false); //крышка
            ksDoc3d1.SetPartFromFile(file_before, partAs, false); //торец 1
            ksDoc3d1.SetPartFromFile(file_before, partAs, false); //торец 2

            ksPartCollection partColl = ksDoc3d1.PartCollection(true);

            ////ДНО

            partAs = partColl.GetByIndex(0);
            pCol = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane[0] = pCol.GetByName("Number0", true, true);
            namePlane[1] = pCol.GetByName("Number1", true, true);
            namePlane[2] = pCol.GetByName("Number2", true, true);
            namePlane[3] = pCol.GetByName("Number3", true, true);
            namePlane[4] = pCol.GetByName("Number4", true, true);

            ////БОКОВОЙ ЩИТ 1

            partAs = partColl.GetByIndex(1);
            pCol1 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane1[0] = pCol1.GetByName("Number0", true, true);
            namePlane1[1] = pCol1.GetByName("Number1", true, true);
            namePlane1[2] = pCol1.GetByName("Number2", true, true);
            namePlane1[3] = pCol1.GetByName("Number3", true, true);
            namePlane1[4] = pCol1.GetByName("Number4", true, true);

            //дно и бок 1
            ksDoc3d1.AddMateConstraint(0, namePlane[4], namePlane1[0], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane[0], namePlane1[4], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane[2], namePlane1[2], 1, 1, 0);

            ////БОКОВОЙ ЩИТ 2

            partAs = partColl.GetByIndex(2);
            pCol2 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane2[0] = pCol2.GetByName("Number0", true, true);
            namePlane2[1] = pCol2.GetByName("Number1", true, true);
            namePlane2[2] = pCol2.GetByName("Number2", true, true);
            namePlane2[3] = pCol2.GetByName("Number3", true, true);
            namePlane2[4] = pCol2.GetByName("Number4", true, true);

            //дно и бок 2, бок 1
            ksDoc3d1.AddMateConstraint(0, namePlane[4], namePlane2[0], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(5, namePlane1[3], namePlane2[3], 1, 1, w_fact_bottom * col_fact_bottom - heightBoard + gap * (col_fact_bottom - 1));
            ksDoc3d1.AddMateConstraint(0, namePlane[2], namePlane2[2], 1, 1, 0);

            ////КРЫШКА

            partAs = partColl.GetByIndex(3);
            pCol3 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane3[0] = pCol3.GetByName("Number0", true, true);
            namePlane3[1] = pCol3.GetByName("Number1", true, true);
            namePlane3[2] = pCol3.GetByName("Number2", true, true);
            namePlane3[3] = pCol3.GetByName("Number3", true, true);
            namePlane3[4] = pCol3.GetByName("Number4", true, true);

            //бок 1 и крышка, дно
            ksDoc3d1.AddMateConstraint(0, namePlane1[4], namePlane3[0], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane1[2], namePlane3[2], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(5, namePlane1[0], namePlane3[4], -1, 1, -(w_fact_side * col_fact_side + heightBoard + gap * (col_fact_side - 1)));

            ////ТОРЦЕВОЙ ЩИТ 1

            partAs = partColl.GetByIndex(4);
            pCol4 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane4[0] = pCol4.GetByName("Number0", true, true);
            namePlane4[1] = pCol4.GetByName("Number1", true, true);
            namePlane4[2] = pCol4.GetByName("Number2", true, true);
            namePlane4[3] = pCol4.GetByName("Number3", true, true);
            namePlane4[4] = pCol4.GetByName("Number4", true, true);

            ////торец 1 и бок 1 дно
            ksDoc3d1.AddMateConstraint(5, namePlane1[4], namePlane4[1], 1, 1, -heightBoard);
            ksDoc3d1.AddMateConstraint(5, namePlane1[1], namePlane4[3], 1, 1, -heightBoard);
            ksDoc3d1.AddMateConstraint(0, namePlane[4], namePlane4[0], -1, 1, 0);



            ////ТОРЦЕВОЙ ЩИТ 2

            partAs = partColl.GetByIndex(5);
            pCol5 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane5[0] = pCol5.GetByName("Number0", true, true);
            namePlane5[1] = pCol5.GetByName("Number1", true, true);
            namePlane5[2] = pCol5.GetByName("Number2", true, true);
            namePlane5[3] = pCol5.GetByName("Number3", true, true);
            namePlane5[4] = pCol5.GetByName("Number4", true, true);

            ////торец 2 и бок 1 дно
            ksDoc3d1.AddMateConstraint(5, namePlane1[4], namePlane5[1], 1, 1, -heightBoard);
            ksDoc3d1.AddMateConstraint(5, namePlane1[1], namePlane5[3], 1, 1, -(y + 2 * heightBoard));
            ksDoc3d1.AddMateConstraint(0, namePlane[4], namePlane5[0], -1, 1, 0);

            string save = foldername + "\\" + "Ящик типа I-2" + ".m3d";

            ksDoc3d.SaveAs(save);

        }



        public void СreatingBox12Manually(int x, int y, int z, double massa, int gap, int GOST, int heightWidth, 
            string savedValue1, string savedValue2, string savedValue3, string foldername)
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
