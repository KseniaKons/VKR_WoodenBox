using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeBox
{
    internal class Box11
    {

        
        private KompasObject kompas; // создание экземпляра КОМПАС
        private ksDocument3D ksDoc3d; // создание экземпляра 3D-документа
        private ksPart part; // создание экземпляра детали

        void CalculationBoards(int param, out double w_fact_bottom, out double col_fact_bottom)
        {
            //параметр по которому считаем, ширина доски вернется, количество досок вернется 

            w_fact_bottom = 0; //посчитанная длиннна доски
            col_fact_bottom = 0; // посчитанное количество
            int w_sh = 10000, buf_sh;
            int col;

            int[] arr = { 80, 90, 100, 110, 130, 150, 180, 200 };

            for (int i = 0; i < arr.Length; i++)
            {
                if (param % arr[i] != 0)
                    col = param / arr[i] + 1; //кол-во досок
                else col = param / arr[i];

                buf_sh = arr[i] * col; //длина щита

                if (buf_sh < w_sh)
                {
                    w_sh = buf_sh;
                    w_fact_bottom = arr[i];
                    col_fact_bottom = col;
                }
            }
        }

        void Newboard(double height, double width, double length, string name, string foldername) //ширина 22 высота 75 длинна 1000
        {

            // создаём экземпляры для базовых плоскостей
            ksDoc3d = (ksDocument3D)kompas.Document3D();
            ksDoc3d.Create(false, true);
            ksDoc3d.fileName = name; // указание названия файла

            part = ksDoc3d.GetPart((int)Part_Type.pTop_Part); // получаем интерфейс новой детали

            ksEntity basePlaneXOY = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_planeXOY); // получим интерфейс базовой плоскости XOY


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

            string save;

            save = foldername + "\\" + name + ".m3d";


            ksDoc3d.SaveAs(save);

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

                                if (x1 == 0 && z1 == 0 && y1 == 0)
                                {
                                    if (x2 == width && y2 == height && z2 == 0)
                                    {
                                        face.name = ("Number0");
                                        face.Update();
                                        break;
                                    }

                                }

                                if (x1 == 0 && z1 == 0 && y1 == 0)
                                {
                                    if (x2 == 0 && y2 == height && z2 == length)
                                    {
                                        face.name = ("Number1");
                                        face.Update();
                                        break;
                                    }

                                }

                                if (x1 == width && y1 == height && z1 == 0)
                                {
                                    if (x2 == width && y2 == 0 && z2 == length)
                                    {
                                        face.name = ("Number2");
                                        face.Update();
                                        break;
                                    }

                                }

                                if (x1 == 0 && y1 == 0 && z1 == length)
                                {
                                    if (x2 == width && y2 == 0 && z2 == 0)
                                    {
                                        face.name = ("Number3");
                                        face.Update();
                                        break;
                                    }

                                }

                            }
                        }
                    }
                }
            }
        }

        public void СreatingBox11(int x, int y, int z, double massa, double GOST, int boardWidth, string foldername)
        {
            //ширина, длинна, высота (внутренние), масса груза, ГОСТ, высота доски

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

            //РАСЧЕТ 

            // ДОСКИ ДНА И КРЫШКИ
            double w_fact_bottom, col_fact_bottom;
            CalculationBoards(x + 2*boardWidth, out w_fact_bottom, out col_fact_bottom);

            // ДОСКИ БОКОВОГО ЩИТА
            double w_fact_side, col_fact_side;
            CalculationBoards(z, out w_fact_side, out col_fact_side);


            string name_bottom = "Доски дна и крышки";
            string name_side = "Доски бокового щита";
            string name_before = "Доски торцевого щита";

            //длинна торцевых досок 
            double lenghtBT = w_fact_bottom * col_fact_bottom - 2 * boardWidth;

            //доски дна и крышки
            Newboard(boardWidth, w_fact_bottom, y + 4*boardWidth, name_bottom, foldername); // передать параметры досок  ширина высота длинна

            //доски бокового щита
            Newboard(boardWidth, w_fact_side, y + 4 * boardWidth, name_side, foldername);

            //доски торцевого щита
            Newboard(boardWidth, w_fact_side, lenghtBT, name_before, foldername);



            ////////////////СБОРКА

            ksDocument3D ksDoc3d1 = (ksDocument3D)kompas.Document3D();
            ksDoc3d1.Create(false, false);
            ksDoc3d1.fileName = "Ящик деревянные"; // указание названия файла
            ksPart partAs = ksDoc3d1.GetPart((int)Part_Type.pTop_Part); // получаем интерфейс новой сборки


            ////////////ДНО

            string file_bottom;
            file_bottom = foldername + "\\" + name_bottom + ".m3d";

            ksEntityCollection pCol;
            ksEntity[,] namePlane = new ksEntity[(int)col_fact_bottom, 4];

            int counter = 0;
            for (int i = 0; i < (int)col_fact_bottom; i++)
            {
                ksDoc3d1.SetPartFromFile(file_bottom, partAs, false);
                counter++;
            }

            ksPartCollection partColl = ksDoc3d1.PartCollection(true);

            for (int i = 0; i < (int)col_fact_bottom; i++)
            {
                partAs = partColl.GetByIndex(i);
                pCol = partAs.EntityCollection((short)Obj3dType.o3d_face);

                namePlane[i, 0] = pCol.GetByName("Number0", true, true);
                namePlane[i, 1] = pCol.GetByName("Number1", true, true);
                namePlane[i, 2] = pCol.GetByName("Number2", true, true);
                namePlane[i, 3] = pCol.GetByName("Number3", true, true);
            }

            for (int i = 0; i < (int)col_fact_bottom - 1; i++)
            {
                ksDoc3d1.AddMateConstraint(0, namePlane[i, 0], namePlane[i + 1, 0], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane[i, 3], namePlane[i + 1, 3], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane[i, 1], namePlane[i + 1, 2], -1, 1, 0);
            }



            ////БОКОВОЙ ЩИТ 1

            int counter1 = counter;

            string file_side;
            file_side = foldername + "\\" + name_side + ".m3d";

            ksEntityCollection pCol1;
            ksEntity[,] namePlane1 = new ksEntity[(int)col_fact_side, 4];

            for (int i = 0; i < (int)col_fact_side; i++)
            {
                ksDoc3d1.SetPartFromFile(file_side, partAs, false);
                counter1++;
            }

            ksPartCollection partColl1 = ksDoc3d1.PartCollection(true);

            for (int i = 0; i < (int)col_fact_side; i++)
            {
                partAs = partColl1.GetByIndex(i + counter);
                pCol1 = partAs.EntityCollection((short)Obj3dType.o3d_face);

                namePlane1[i, 0] = pCol1.GetByName("Number0", true, true);
                namePlane1[i, 1] = pCol1.GetByName("Number1", true, true);
                namePlane1[i, 2] = pCol1.GetByName("Number2", true, true);
                namePlane1[i, 3] = pCol1.GetByName("Number3", true, true);
            }

            for (int i = 0; i < (int)col_fact_side - 1; i++)
            {
                ksDoc3d1.AddMateConstraint(0, namePlane1[i, 0], namePlane1[i + 1, 0], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane1[i, 3], namePlane1[i + 1, 3], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane1[i, 1], namePlane1[i + 1, 2], -1, 1, 0);
            }

            ////СОЕДИНЕНИЕ ДНА И БОК1

            ksDoc3d1.AddMateConstraint(0, namePlane[0, 0], namePlane1[0, 0], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane[0, 2], namePlane1[0, 3], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane[0, 3], namePlane1[0, 2], -1, 1, 0);



            ////БОКОВОЙ ЩИТ 2

            int counter2 = counter1;

            string file_side1;
            file_side1 = foldername + "\\" + name_side + ".m3d";

            ksEntityCollection pCol2;
            ksEntity[,] namePlane2 = new ksEntity[(int)col_fact_side, 4];

            for (int i = 0; i < (int)col_fact_side; i++)
            {
                ksDoc3d1.SetPartFromFile(file_side1, partAs, false);
                counter2++;
            }

            ksPartCollection partColl2 = ksDoc3d1.PartCollection(true);

            for (int i = 0; i < (int)col_fact_side; i++)
            {
                partAs = partColl2.GetByIndex(i + counter1);
                pCol2 = partAs.EntityCollection((short)Obj3dType.o3d_face);

                namePlane2[i, 0] = pCol2.GetByName("Number0", true, true);
                namePlane2[i, 1] = pCol2.GetByName("Number1", true, true);
                namePlane2[i, 2] = pCol2.GetByName("Number2", true, true);
                namePlane2[i, 3] = pCol2.GetByName("Number3", true, true);
            }

            for (int i = 0; i < (int)col_fact_side - 1; i++)
            {
                ksDoc3d1.AddMateConstraint(0, namePlane2[i, 0], namePlane2[i + 1, 0], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane2[i, 3], namePlane2[i + 1, 3], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane2[i, 1], namePlane2[i + 1, 2], -1, 1, 0);
            }

            ////СОЕДИНЕНИЕ ДНА И БОК2


            ksDoc3d1.AddMateConstraint(0, namePlane[0, 0], namePlane2[0, 0], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(5, namePlane[0, 2], namePlane2[0, 3], 1, 1, -(w_fact_bottom * col_fact_bottom - boardWidth));
            ksDoc3d1.AddMateConstraint(0, namePlane[0, 3], namePlane2[0, 2], -1, 1, 0);

            ////КРЫШКА


            int counter3 = counter2;

            string file_bottom1;
            file_bottom1 = foldername + "\\" + name_bottom + ".m3d";


            ksEntityCollection pCol3;
            ksEntity[,] namePlane3 = new ksEntity[(int)col_fact_bottom, 4];

            for (int i = 0; i < (int)col_fact_bottom; i++)
            {
                ksDoc3d1.SetPartFromFile(file_bottom1, partAs, false);
                counter3++;
            }


            ksPartCollection partColl3 = ksDoc3d1.PartCollection(true);

            for (int i = 0; i < (int)col_fact_bottom; i++)
            {
                partAs = partColl3.GetByIndex(i + counter2);
                pCol3 = partAs.EntityCollection((short)Obj3dType.o3d_face);

                namePlane3[i, 0] = pCol3.GetByName("Number0", true, true);
                namePlane3[i, 1] = pCol3.GetByName("Number1", true, true);
                namePlane3[i, 2] = pCol3.GetByName("Number2", true, true);
                namePlane3[i, 3] = pCol3.GetByName("Number3", true, true);
            }

            for (int i = 0; i < (int)col_fact_bottom - 1; i++)
            {
                ksDoc3d1.AddMateConstraint(0, namePlane3[i, 0], namePlane3[i + 1, 0], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane3[i, 3], namePlane3[i + 1, 3], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane3[i, 1], namePlane3[i + 1, 2], -1, 1, 0);
            }

            ////СОЕДИНЕНИЕ КРЫШКА И БОК2


            ksDoc3d1.AddMateConstraint(0, namePlane3[0, 0], namePlane2[0, 0], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(5, namePlane3[0, 3], namePlane2[0, 2], 1, 1, (w_fact_side * col_fact_side));
            ksDoc3d1.AddMateConstraint(5, namePlane3[0, 2], namePlane2[0, 3], -1, 1, -boardWidth);


            ////ТОРЦЕВОЙ ЩИТ


            int counter4 = counter3;

            string file_before;
            file_before = foldername + "\\" + name_before + ".m3d";

            int col_fact_before = (int)col_fact_side;

            ksEntityCollection pCol4;
            ksEntity[,] namePlane4 = new ksEntity[col_fact_before, 4];

            for (int i = 0; i < col_fact_before; i++)
            {
                ksDoc3d1.SetPartFromFile(file_before, partAs, false);
                counter4++;
            }


            ksPartCollection partColl4 = ksDoc3d1.PartCollection(true);

            for (int i = 0; i < col_fact_before; i++)
            {
                partAs = partColl4.GetByIndex(i + counter3);
                pCol4 = partAs.EntityCollection((short)Obj3dType.o3d_face);

                namePlane4[i, 0] = pCol4.GetByName("Number0", true, true);
                namePlane4[i, 1] = pCol4.GetByName("Number1", true, true);
                namePlane4[i, 2] = pCol4.GetByName("Number2", true, true);
                namePlane4[i, 3] = pCol4.GetByName("Number3", true, true);
            }

            for (int i = 0; i < col_fact_before - 1; i++)
            {
                ksDoc3d1.AddMateConstraint(0, namePlane4[i, 0], namePlane4[i + 1, 0], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane4[i, 3], namePlane4[i + 1, 3], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane4[i, 1], namePlane4[i + 1, 2], -1, 1, 0);
            }

            // торец 4, бок 2, крышка 3


            ksDoc3d1.AddMateConstraint(0, namePlane4[0, 0], namePlane2[0, 3], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane4[0, 2], namePlane[0, 3], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(5, namePlane4[0, 3], namePlane3[0, 0], 1, 1, 2 * boardWidth);


            ////ТОРЦЕВОЙ ЩИТ2


            int counter5 = counter4;

            ksEntityCollection pCol5;
            ksEntity[,] namePlane5 = new ksEntity[col_fact_before, 4];

            for (int i = 0; i < col_fact_before; i++)
            {
                ksDoc3d1.SetPartFromFile(file_before, partAs, false);
                counter5++;
            }


            ksPartCollection partColl5 = ksDoc3d1.PartCollection(true);

            for (int i = 0; i < col_fact_before; i++)
            {
                partAs = partColl5.GetByIndex(i + counter4);
                pCol5 = partAs.EntityCollection((short)Obj3dType.o3d_face);

                namePlane5[i, 0] = pCol5.GetByName("Number0", true, true);
                namePlane5[i, 1] = pCol5.GetByName("Number1", true, true);
                namePlane5[i, 2] = pCol5.GetByName("Number2", true, true);
                namePlane5[i, 3] = pCol5.GetByName("Number3", true, true);
            }

            for (int i = 0; i < col_fact_before - 1; i++)
            {
                ksDoc3d1.AddMateConstraint(0, namePlane5[i, 0], namePlane5[i + 1, 0], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane5[i, 3], namePlane5[i + 1, 3], 1, 1, 0);
                ksDoc3d1.AddMateConstraint(0, namePlane5[i, 1], namePlane5[i + 1, 2], -1, 1, 0);
            }

            // торец 4, бок 2, крышка 3


            ksDoc3d1.AddMateConstraint(0, namePlane5[0, 0], namePlane2[0, 3], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane5[0, 2], namePlane[0, 3], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(5, namePlane5[0, 3], namePlane3[0, 0], 1, 1, y + boardWidth);



            string save1;
            save1 = foldername + "\\Ящик деревянные.a3d";


            //ksDoc3d.SaveAs(save1);



        }

    }


    
}
