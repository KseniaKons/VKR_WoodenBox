﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using KAPITypes;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;
using KompasAPI7;
using static WoodenBox.SpecificationBox;

namespace WoodenBox
{
    internal class Box11
    {
        private KompasObject kompas; // создание экземпляра КОМПАС
        private ksPart part; // создание экземпляра детали
        void CalculationBoardsLeaves(int param, out double w_fact_bottom, out double col_fact_bottom)
        {
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

        private void CalculationBoardsConifer(int param, int boardWidth, 
            out double w_fact_bottom, out double col_fact_bottom)
        {
            w_fact_bottom = 0;
            col_fact_bottom = 0;
            int w_sh = 10000, buf_sh;
            int col;
            int[] arr = { 75, 100, 125, 150, 175, 200, 225, 250, 275 };
            if (boardWidth == 22)
                arr = arr.Take(arr.Length - 2).ToArray();

            for (int i = 0; i < arr.Length; i++)
            {
                if (param % arr[i] != 0)
                    col = param / arr[i] + 1; 
                else col = param / arr[i];

                buf_sh = arr[i] * col; 
                if (buf_sh < w_sh)
                {
                    w_sh = buf_sh;
                    w_fact_bottom = arr[i];
                    col_fact_bottom = col;
                }
            }
        }

        void NewShield(double height, double width, double length, double col, 
            string name, string foldername, string marking, string CL, string numDesignation, 
            string materials, double density, bool meshCopy, out double mass)
        {
            ksDocument3D ksDoc3d;
            ksDoc3d = (ksDocument3D)kompas.Document3D();
            ksDoc3d.Create(false, true);
            ksDoc3d.fileName = $"{marking}.{CL}.{numDesignation} {name}"; // указание названия файла

            part = ksDoc3d.GetPart((int)Part_Type.pTop_Part); // получаем интерфейс новой детали
            part.name = name;

            part.marking = $"{marking}.{CL}.{numDesignation}";
            part.useColor = 0;
            ksColorParam kscolor = (ksColorParam)part.ColorParam();
            kscolor.color = 10092543;
            part.SetMaterial(materials, density);
            //плотность гр/куб.см
            part.Update();

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


            //ИЩУ ГРАНИ

            ksEntityCollection flFaces = part.EntityCollection((int)Obj3dType.o3d_face);
            if(flFaces.SelectByPoint(0, height / 2, length / 2))
            {
                ksEntity face = flFaces.First();
                face.name = "Number0";
                face.Update();
            }

            ksEntityCollection flFaces1 = part.EntityCollection((int)Obj3dType.o3d_face);
            if (flFaces1.SelectByPoint(width / 2, height / 2, 0))
            {
                ksEntity face1 = flFaces1.First();
                face1.name = "Number1";
                face1.Update();
            }

            ksEntityCollection flFaces2 = part.EntityCollection((int)Obj3dType.o3d_face);
            if (flFaces2.SelectByPoint(width / 2, height / 2, length))
            {
                ksEntity face2 = flFaces2.First();
                face2.name = "Number2";
                face2.Update();
            }

            ksEntityCollection flFaces3 = part.EntityCollection((int)Obj3dType.o3d_face);
            if (flFaces3.SelectByPoint(width / 2, height, length / 2))
            {
                ksEntity face3 = flFaces3.First();
                face3.name = "Number3";
                face3.Update();
            }

            ksEntityCollection flFaces4 = part.EntityCollection((int)Obj3dType.o3d_face);
            if (flFaces4.SelectByPoint(width / 2, 0, length / 2))
            {
                ksEntity face4 = flFaces4.First();
                face4.name = "Number4";
                face4.Update();
            }


            //// массив по сетке //

            if (meshCopy == true)
            {
                // создаём операцию линейного массива
                ksEntity MeshCopyE = part.NewEntity((short)Obj3dType.o3d_meshCopy);

                MeshCopyDefinition MeshCopyDef = MeshCopyE.GetDefinition(); 
                //создаём интерфейс свойств линейного массива

                ksEntity baseAxisX = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_axisOX); 
                //создаём ось линейного массива на основе базовой Х

                MeshCopyDef.SetAxis1(baseAxisX); //выставляем базовую ось для первого направления

                MeshCopyDef.count1 = (int)col; 
                MeshCopyDef.step1 = width; 

                //создаём коллекцию для копируемых элементов
                ksEntityCollection EntityCollection = MeshCopyDef.OperationArray();
                EntityCollection.Clear(); 

                EntityCollection.Add(bossExtr); //добавляем элемент выдавливания в коллекци.

                MeshCopyE.Create(); // создаём массив
            }

            mass = Math.Round(part.GetMass(), 2);

            // сохранение //

            string save;

            save = foldername + "\\" + $"{marking}.{CL}.{numDesignation} {name}" + ".m3d";

            ksDoc3d.SaveAs(save);
            ksDoc3d.close();

        }

        public void MarkingBox(int number, out string numDesignation)
        {
            numDesignation = "000";

            if (number < 10)
                numDesignation = $"00{number}";
            if (number >= 10 && number < 100)
                numDesignation = $"0{number}";
            if (number >= 100 && number < 1000)
                numDesignation = $"{number}";
        }

        public void СreatingBox11(int x, int y, int z, int GOST, int heightBoard, 
            string foldername, string marking, int number, string materials, double density)
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

            //CreatingSpecification(7);

            double w_fact_bottom = 0, col_fact_bottom = 0;
            double w_fact_side = 0, col_fact_side = 0;

            if (GOST == 0) //ЛИСТВЕННЫЕ ПОРОДЫ
            {
                // ДОСКИ ДНА И КРЫШКИ
                CalculationBoardsLeaves(x + 2 * heightBoard, out w_fact_bottom, out col_fact_bottom);

                // ДОСКИ БОКОВОГО ЩИТА
                CalculationBoardsLeaves(z, out w_fact_side, out col_fact_side);
            }
            else if (GOST == 1) //ХВОЙНЫЕ ПОРОДЫ
            {
                // ДОСКИ ДНА И КРЫШКИ
                CalculationBoardsConifer(x + 2 * heightBoard, heightBoard, out w_fact_bottom, out col_fact_bottom);

                // ДОСКИ БОКОВОГО ЩИТА
                CalculationBoardsConifer(z, heightBoard, out w_fact_side, out col_fact_side);
            }


            string name_bottom = "Крышка";
            string name_side = "Боковой щит";
            string name_before = "Торцевой щит";
            string name_front1 = "Планка торцевого щита"; // вертикальная
            string name_front2 = "Планка торцевого щита"; // - горизонтальная
            string name_around1 = "Планка пояса"; // - вверхняя
            string name_around2 = "Планка пояса"; // - боковая

            //Классификаторы 
            string CL_bottom = "321174"; // крышка 2шт
            string CL_before = "321179"; // торцевой щит
            string CL_side = "321179"; // боковой щит
            string CL_around = "321175"; // планка пояса 
            string CL_front = "321175"; // планка торцевого щита
            string numDesignation = "000";

            //масса деталей
            double masscap = 0.0;
            double massbefore = 0.0;
            double massside = 0.0;
            double massaround1 = 0.0;
            double massaround2 = 0.0;
            double massfront1 = 0.0;
            double massfront2 = 0.0;


            //длинна торцевых досок 
            double lenghtBT = w_fact_bottom * col_fact_bottom - 2 * heightBoard;

            //ЩИТ Крышка 2 шт
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_fact_bottom, y + 4 * heightBoard, col_fact_bottom, 
                name_bottom, foldername, marking, CL_bottom, numDesignation, materials, density, true, out masscap);
            name_bottom = $"{marking}.{CL_bottom}.{numDesignation} {name_bottom}";

            //торцевой щит
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_fact_side, lenghtBT, col_fact_side, name_before, 
                foldername, marking, CL_before, numDesignation, materials, density, true, out massbefore);
            name_before = $"{marking}.{CL_before}.{numDesignation} {name_before}";

            //боковой щит
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_fact_side, y + 4 * heightBoard, col_fact_side,
                name_side, foldername, marking, CL_side, numDesignation, materials, density, true, out massside);
            name_side = $"{marking}.{CL_side}.{numDesignation} {name_side}";

            double w_around = w_fact_bottom;
            if (w_fact_bottom > 100)
                w_around =  100 ;

            double w_front = w_fact_side;
            if (w_fact_side > 100)
                w_front = 100;

            //Планка пояса - вверхняя
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_around, w_fact_bottom * col_fact_bottom, 0, 
                name_around1, foldername, marking, CL_around, numDesignation, materials, density, false, out massaround1);
            name_around1 = $"{marking}.{CL_around}.{numDesignation} {name_around1}";

            //Планка пояса - боковая
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_around, w_fact_side * col_fact_side + 4 * heightBoard, 
                0, name_around2, foldername, marking, CL_around, numDesignation, materials, density, false, out massaround2);
            name_around2 = $"{marking}.{CL_around}.{numDesignation} {name_around2}";

            //Планка торцевого щита - вертикальная
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_front, w_fact_side * col_fact_side, 0,
                name_front1, foldername, marking, CL_front, numDesignation, materials, density, false, out massfront1);
            name_front1 = $"{marking}.{CL_front}.{numDesignation} {name_front1}";

            //Планка торцевого щита - горизонтальная
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_front, lenghtBT - 2 * w_fact_side, 0,
                name_front2, foldername, marking, CL_front, numDesignation, materials, density, false, out massfront2);
            name_front2 = $"{marking}.{CL_front}.{numDesignation} {name_front2}";

            double colNails = (col_fact_bottom * 16 + 16) * 2 + 
                (col_fact_side * 16) * 2 + (col_fact_side * 4 * 4) + 26;
            double lengthTape = col_fact_bottom * w_fact_bottom * 4 +
                 col_fact_side * w_fact_side * 4 + 100 * 8 + 1000;
            InformationAboutBox.ValueBox.Clear();
            InformationAboutBox.ValueBox.Add(new ValueBox
            {
                TypeBox = 1,
                cap = $"{w_fact_bottom*col_fact_bottom}x{y + 4 * heightBoard}", 
                before = $"{w_fact_side*col_fact_side}x{lenghtBT}", 
                side = $"{w_fact_side*col_fact_side}x{y + 4 * heightBoard}", 
                around1 = $"{w_fact_bottom}x{w_fact_bottom * col_fact_bottom}", 
                around2 = $"{w_fact_bottom}x{w_fact_side * col_fact_side + 4 * heightBoard}", 
                front1 = $"{w_fact_side}x{w_fact_side * col_fact_side}", 
                front2 = $"{w_fact_side}x{lenghtBT - 2 * w_fact_side}", 
                masscap = $"{masscap}", massbefore = $"{massbefore}",
                massside = $"{massside}",massaround1 = $"{massaround1}",
                massaround2 = $"{massaround2}",massfront1 = $"{massfront1}",
                massfront2 = $"{massfront2}",
                colNails = colNails,
                lengthTape = Math.Round(lengthTape / 1000, 2),
            });

            InformationAboutBox.ValueBoxForReport.Clear();
            InformationAboutBox.ValueBoxForReport.Add(new ValueBoxForReport
            {
                col_cap = col_fact_bottom, col_side = col_fact_side,
                w_cap = w_fact_bottom, w_side = w_fact_side,
                lenghtBox = y + 4 * heightBoard,
                heightBoard = heightBoard,
            });

            //////////////СБОРКА

            ksDocument3D ksDoc3d1 = (ksDocument3D)kompas.Document3D();
            ksDoc3d1.Create(false, false);
            ksDoc3d1.fileName = $"{marking}.321169.000 Ящик деревянный I-1"; // указание названия файла
            ksPart partAs = ksDoc3d1.GetPart((int)Part_Type.pTop_Part); // получаем интерфейс новой сборки
            partAs.name = "Ящик деревянный I-1";
            partAs.marking = $"{marking}.321169.000";
            partAs.SetMaterial(materials, density);
            partAs.Update();

            string file_bottom;
            file_bottom = foldername + "\\" + name_bottom + ".m3d";

            string file_side;
            file_side = foldername + "\\" + name_side + ".m3d";

            string file_before;
            file_before = foldername + "\\" + name_before + ".m3d";

            string file_front1;
            file_front1 = foldername + "\\" + name_front1 + ".m3d";

            string file_front2;
            file_front2 = foldername + "\\" + name_front2 + ".m3d";

            string file_around1;
            file_around1 = foldername + "\\" + name_around1 + ".m3d";

            string file_around2;
            file_around2 = foldername + "\\" + name_around2 + ".m3d";

            ksEntityCollection pCol;  //массив граней
            ksEntity[] namePlane = new ksEntity[5]; //массив элементов детали

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

            ksEntityCollection pCol6;
            ksEntity[] namePlane6 = new ksEntity[5];

            ksEntityCollection pCol7;
            ksEntity[] namePlane7 = new ksEntity[5];

            ksEntityCollection pCol8;
            ksEntity[] namePlane8 = new ksEntity[5];

            ksEntityCollection pCol9;
            ksEntity[] namePlane9 = new ksEntity[5];

            ksEntityCollection pCol10;
            ksEntity[] namePlane10 = new ksEntity[5];

            ksEntityCollection pCol11;
            ksEntity[] namePlane11 = new ksEntity[5];

            ksEntityCollection pCol12;
            ksEntity[] namePlane12 = new ksEntity[5];

            ksEntityCollection pCol13;
            ksEntity[] namePlane13 = new ksEntity[5];

            ksEntityCollection pCol14;
            ksEntity[] namePlane14 = new ksEntity[5];

            ksEntityCollection pCol15;
            ksEntity[] namePlane15 = new ksEntity[5];

            ksEntityCollection pCol16;
            ksEntity[] namePlane16 = new ksEntity[5];

            ksEntityCollection pCol17;
            ksEntity[] namePlane17 = new ksEntity[5];

            ksEntityCollection pCol18;
            ksEntity[] namePlane18 = new ksEntity[5];

            ksEntityCollection pCol19;
            ksEntity[] namePlane19 = new ksEntity[5];

            ksEntityCollection pCol20;
            ksEntity[] namePlane20 = new ksEntity[5];

            ksEntityCollection pCol21;
            ksEntity[] namePlane21 = new ksEntity[5];


            ksDoc3d1.SetPartFromFile(file_bottom, partAs, false); //0 дно (крышка 1)
            ksDoc3d1.SetPartFromFile(file_side, partAs, false); // 1 боковой щит 1 
            ksDoc3d1.SetPartFromFile(file_side, partAs, false); //2 боковой щит 2
            ksDoc3d1.SetPartFromFile(file_bottom, partAs, false); //3 крышка2
            ksDoc3d1.SetPartFromFile(file_before, partAs, false); //4 торец 1
            ksDoc3d1.SetPartFromFile(file_before, partAs, false); //5 торец 2

            ksDoc3d1.SetPartFromFile(file_front1, partAs, false); //6 Планка торцевого щита - вертикальная
            ksDoc3d1.SetPartFromFile(file_front1, partAs, false); //7 Планка торцевого щита - вертикальная
            ksDoc3d1.SetPartFromFile(file_front2, partAs, false); //8 Планка торцевого щита - горизонтальная
            ksDoc3d1.SetPartFromFile(file_front2, partAs, false); //9 Планка торцевого щита - горизонтальная

            ksDoc3d1.SetPartFromFile(file_front1, partAs, false); //10 Планка торцевого щита - вертикальная
            ksDoc3d1.SetPartFromFile(file_front1, partAs, false); //11 Планка торцевого щита - вертикальная
            ksDoc3d1.SetPartFromFile(file_front2, partAs, false); //12 Планка торцевого щита - горизонтальная
            ksDoc3d1.SetPartFromFile(file_front2, partAs, false); //13 Планка торцевого щита - горизонтальная

            ksDoc3d1.SetPartFromFile(file_around1, partAs, false); // 14 Планка пояса - вверхняя
            ksDoc3d1.SetPartFromFile(file_around1, partAs, false); // 15 Планка пояса - вверхняя
            ksDoc3d1.SetPartFromFile(file_around1, partAs, false); // 16 Планка пояса - вверхняя
            ksDoc3d1.SetPartFromFile(file_around1, partAs, false); // 17 Планка пояса - вверхняя

            ksDoc3d1.SetPartFromFile(file_around2, partAs, false); // 18 Планка пояса - боковая
            ksDoc3d1.SetPartFromFile(file_around2, partAs, false); // 19 Планка пояса - боковая
            ksDoc3d1.SetPartFromFile(file_around2, partAs, false); // 20 Планка пояса - боковая
            ksDoc3d1.SetPartFromFile(file_around2, partAs, false); // 21 Планка пояса - боковая

            ksPartCollection partColl = ksDoc3d1.PartCollection(true);

            ////ДНО (крышка1)

            partAs = partColl.GetByIndex(0);
            partAs.fixedComponent = true;   
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
            ksDoc3d1.AddMateConstraint(5, namePlane1[3], namePlane2[3], 1, 1, 
                w_fact_bottom * col_fact_bottom - heightBoard);
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
            ksDoc3d1.AddMateConstraint(5, namePlane1[0], namePlane3[4], -1, 1, -(w_fact_side * col_fact_side + heightBoard));

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


            /////// Планка торцевого щита - вертикальная 2 штуки

            partAs = partColl.GetByIndex(6);
            pCol6 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane6[0] = pCol6.GetByName("Number0", true, true);
            namePlane6[1] = pCol6.GetByName("Number1", true, true);
            namePlane6[2] = pCol6.GetByName("Number2", true, true);
            namePlane6[3] = pCol6.GetByName("Number3", true, true);
            namePlane6[4] = pCol6.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane4[3], namePlane6[3], -1, 1, 0); // торец
            ksDoc3d1.AddMateConstraint(0, namePlane1[3], namePlane6[0], -1, 1, 0); // бок1
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane6[2], -1, 1, 0); // крышка
            

            partAs = partColl.GetByIndex(7);
            pCol7 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane7[0] = pCol7.GetByName("Number0", true, true);
            namePlane7[1] = pCol7.GetByName("Number1", true, true);
            namePlane7[2] = pCol7.GetByName("Number2", true, true);
            namePlane7[3] = pCol7.GetByName("Number3", true, true);
            namePlane7[4] = pCol7.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane4[3], namePlane7[3], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(5, namePlane1[3], namePlane7[0], -1, 1, lenghtBT - w_fact_side);
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane7[2], -1, 1, 0);

            //Планка торцевого щита - горизонтальная 2 штуки

            partAs = partColl.GetByIndex(8);
            pCol8 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane8[0] = pCol8.GetByName("Number0", true, true);
            namePlane8[1] = pCol8.GetByName("Number1", true, true);
            namePlane8[2] = pCol8.GetByName("Number2", true, true);
            namePlane8[3] = pCol8.GetByName("Number3", true, true);
            namePlane8[4] = pCol8.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane4[3], namePlane8[3], -1, 1, 0); //торец
            ksDoc3d1.AddMateConstraint(0, namePlane7[0], namePlane8[2], -1, 1, 0); // планка 2
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane8[0], -1, 1, 0); //крышка

            partAs = partColl.GetByIndex(9);
            pCol9 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane9[0] = pCol9.GetByName("Number0", true, true);
            namePlane9[1] = pCol9.GetByName("Number1", true, true);
            namePlane9[2] = pCol9.GetByName("Number2", true, true);
            namePlane9[3] = pCol9.GetByName("Number3", true, true);
            namePlane9[4] = pCol9.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane4[3], namePlane9[4], -1, 1, 0); //торец
            ksDoc3d1.AddMateConstraint(0, namePlane7[0], namePlane9[2], -1, 1, 0); // планка 2
            ksDoc3d1.AddMateConstraint(5, namePlane3[3], namePlane9[0], 1, 1, w_fact_side * col_fact_side); //крышка

            //ДАЛЬНИЕ Планка торцевого щита - вертикальная 2 штуки

            partAs = partColl.GetByIndex(10);
            pCol10 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane10[0] = pCol10.GetByName("Number0", true, true);
            namePlane10[1] = pCol10.GetByName("Number1", true, true);
            namePlane10[2] = pCol10.GetByName("Number2", true, true);
            namePlane10[3] = pCol10.GetByName("Number3", true, true);
            namePlane10[4] = pCol10.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane5[4], namePlane10[4], -1, 1, 0); // торец
            ksDoc3d1.AddMateConstraint(0, namePlane1[3], namePlane10[0], -1, 1, 0); // бок1
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane10[2], -1, 1, 0); // крышка

            partAs = partColl.GetByIndex(11);
            pCol11 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane11[0] = pCol11.GetByName("Number0", true, true);
            namePlane11[1] = pCol11.GetByName("Number1", true, true);
            namePlane11[2] = pCol11.GetByName("Number2", true, true);
            namePlane11[3] = pCol11.GetByName("Number3", true, true);
            namePlane11[4] = pCol11.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane5[4], namePlane11[4], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(5, namePlane1[3], namePlane11[0], -1, 1, lenghtBT - w_fact_side);
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane11[2], -1, 1, 0);

            //ДАЛЬНИЕ Планка торцевого щита - горизонтальные 2 штуки

            partAs = partColl.GetByIndex(12);
            pCol12 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane12[0] = pCol12.GetByName("Number0", true, true);
            namePlane12[1] = pCol12.GetByName("Number1", true, true);
            namePlane12[2] = pCol12.GetByName("Number2", true, true);
            namePlane12[3] = pCol12.GetByName("Number3", true, true);
            namePlane12[4] = pCol12.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane5[4], namePlane12[4], -1, 1, 0); //торец
            ksDoc3d1.AddMateConstraint(0, namePlane7[0], namePlane12[2], -1, 1, 0); // планка 2
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane12[0], -1, 1, 0); //крышка

            partAs = partColl.GetByIndex(13);
            pCol13 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane13[0] = pCol13.GetByName("Number0", true, true);
            namePlane13[1] = pCol13.GetByName("Number1", true, true);
            namePlane13[2] = pCol13.GetByName("Number2", true, true);
            namePlane13[3] = pCol13.GetByName("Number3", true, true);
            namePlane13[4] = pCol13.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane5[4], namePlane13[3], -1, 1, 0); //торец
            ksDoc3d1.AddMateConstraint(0, namePlane7[0], namePlane13[2], -1, 1, 0); // планка 2
            ksDoc3d1.AddMateConstraint(5, namePlane3[3], namePlane13[0], 1, 1, w_fact_side * col_fact_side); //крышка


            /////Планка пояса верхние - первая пара

            double distance = (y + 4 * heightBoard) / 6; 
            double constraint = (y + 4 * heightBoard) - 2 * distance - 2 * w_fact_bottom;
            if (constraint > 700)
                distance = ((y + 4 * heightBoard) - 700 - 2 * w_fact_bottom) / 2;
            distance = Math.Round(distance);

            partAs = partColl.GetByIndex(14);
            pCol14 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane14[0] = pCol14.GetByName("Number0", true, true);
            namePlane14[1] = pCol14.GetByName("Number1", true, true);
            namePlane14[2] = pCol14.GetByName("Number2", true, true);
            namePlane14[3] = pCol14.GetByName("Number3", true, true);
            namePlane14[4] = pCol14.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane3[4], namePlane14[4], -1, 1, 0); 
            ksDoc3d1.AddMateConstraint(0, namePlane3[0], namePlane14[1], 1, 1, 0); 
            ksDoc3d1.AddMateConstraint(5, namePlane6[4], namePlane14[0], 1, 1, -distance); 


            partAs = partColl.GetByIndex(15);
            pCol15 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane15[0] = pCol15.GetByName("Number0", true, true);
            namePlane15[1] = pCol15.GetByName("Number1", true, true);
            namePlane15[2] = pCol15.GetByName("Number2", true, true);
            namePlane15[3] = pCol15.GetByName("Number3", true, true);
            namePlane15[4] = pCol15.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane[3], namePlane15[3], -1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(0, namePlane3[0], namePlane15[1], 1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(5, namePlane6[4], namePlane15[0], 1, 1, -distance); //планка 1

            /////Планка пояса верхние - вторая пара

            partAs = partColl.GetByIndex(16);
            pCol16 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane16[0] = pCol16.GetByName("Number0", true, true);
            namePlane16[1] = pCol16.GetByName("Number1", true, true);
            namePlane16[2] = pCol16.GetByName("Number2", true, true);
            namePlane16[3] = pCol16.GetByName("Number3", true, true);
            namePlane16[4] = pCol16.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane3[4], namePlane16[4], -1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(0, namePlane3[0], namePlane16[1], 1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(5, namePlane10[3], namePlane16[0], -1, 1, -distance-w_fact_bottom); //планка 1

            partAs = partColl.GetByIndex(17);
            pCol17 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane17[0] = pCol17.GetByName("Number0", true, true);
            namePlane17[1] = pCol17.GetByName("Number1", true, true);
            namePlane17[2] = pCol17.GetByName("Number2", true, true);
            namePlane17[3] = pCol17.GetByName("Number3", true, true);
            namePlane17[4] = pCol17.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane[3], namePlane17[3], -1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(0, namePlane3[0], namePlane17[1], 1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(5, namePlane10[3], namePlane17[0], -1, 1, -distance- w_fact_bottom); //планка 1

            //Планка пояса боковая - первая пара 

            partAs = partColl.GetByIndex(18);
            pCol18 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane18[0] = pCol18.GetByName("Number0", true, true);
            namePlane18[1] = pCol18.GetByName("Number1", true, true);
            namePlane18[2] = pCol18.GetByName("Number2", true, true);
            namePlane18[3] = pCol18.GetByName("Number3", true, true);
            namePlane18[4] = pCol18.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane1[4], namePlane18[4], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane14[3], namePlane18[2], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane14[0], namePlane18[0], 1, 1, 0);

            partAs = partColl.GetByIndex(19);
            pCol19 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane19[0] = pCol19.GetByName("Number0", true, true);
            namePlane19[1] = pCol19.GetByName("Number1", true, true);
            namePlane19[2] = pCol19.GetByName("Number2", true, true);
            namePlane19[3] = pCol19.GetByName("Number3", true, true);
            namePlane19[4] = pCol19.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane1[4], namePlane19[4], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane16[3], namePlane19[2], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane16[0], namePlane19[0], 1, 1, 0);

            //Планка пояса боковая - вторая пара 

            partAs = partColl.GetByIndex(20);
            pCol20 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane20[0] = pCol20.GetByName("Number0", true, true);
            namePlane20[1] = pCol20.GetByName("Number1", true, true);
            namePlane20[2] = pCol20.GetByName("Number2", true, true);
            namePlane20[3] = pCol20.GetByName("Number3", true, true);
            namePlane20[4] = pCol20.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane2[3], namePlane20[3], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane14[3], namePlane20[2], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane14[0], namePlane20[0], 1, 1, 0);

            partAs = partColl.GetByIndex(21);
            pCol21 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane21[0] = pCol21.GetByName("Number0", true, true);
            namePlane21[1] = pCol21.GetByName("Number1", true, true);
            namePlane21[2] = pCol21.GetByName("Number2", true, true);
            namePlane21[3] = pCol21.GetByName("Number3", true, true);
            namePlane21[4] = pCol21.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane2[3], namePlane21[3], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane16[3], namePlane21[2], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane16[0], namePlane21[0], 1, 1, 0);

            string save;
            save = foldername + "\\" + $"{marking}.321169.000 Ящик деревянный I-1" + ".a3d";
            ksDoc3d1.SaveAs(save);

            MessageBox.Show("Построение выполнено!", "Уведомление", MessageBoxButtons.OK, 
                MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);


        }

        //Размеры вписаны вручную
        public void CalculationLenghtManually(int widthBoard, int param, out int col_fact)
        {
            col_fact = 0;
            int lenght = 0;
            while (lenght < param)
            {
                lenght = lenght + widthBoard;
                col_fact++;
            }
        }

        public void СreatingBox11Manually(int x, int y, int z, int heightBoard,
            string bottomBoards, string sideBoard, string aroundBoard, string frontBoard, string foldername, 
            string marking, int number, string materials, double density)
        { //дно, бок, торец, пояс, торец планка
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

            int col_bottom = 0;
            int col_side = 0;
            int w_bottom = int.Parse(bottomBoards);
            int w_side = int.Parse(sideBoard);
            int w_front = int.Parse(frontBoard);
            int w_around = int.Parse(aroundBoard);

            CalculationLenghtManually(w_bottom, x + 2 * heightBoard, out col_bottom);
            CalculationLenghtManually(w_side, z, out col_side);
            
            //длинна торцевых досок 
            double lenghtBT = w_bottom * col_bottom - 2 * heightBoard;

            string name_bottom = "Крышка";
            string name_side = "Боковой щит";
            string name_before = "Торцевой щит";
            string name_front1 = "Планка торцевого щита"; // - вертикальная
            string name_front2 = "Планка торцевого щита"; // - горизонтальная
            string name_around1 = "Планка пояса"; //размером с щит - вверхняя
            string name_around2 = "Планка пояса"; //высокая  - боковая

            //Классификаторы 
            string CL_bottom = "321174"; // крышка 2шт
            string CL_before = "321179"; // торцевой щит
            string CL_side = "321179"; // боковой щит
            string CL_around = "321175"; // планка пояса 
            string CL_front = "321175"; // планка торцевого щита
            string numDesignation = "000";

            //масса деталей
            double masscap = 0.0;
            double massbefore = 0.0;
            double massside = 0.0;
            double massaround1 = 0.0;
            double massaround2 = 0.0;
            double massfront1 = 0.0;
            double massfront2 = 0.0;

            //Крышка 2шт
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_bottom, y + 4 * heightBoard, col_bottom, name_bottom, 
                foldername, marking, CL_bottom, numDesignation, materials, density, true, out masscap); // передать параметры досок  ширина высота длинна
            name_bottom = $"{marking}.{CL_bottom}.{numDesignation} {name_bottom}";

            //торцевой щит
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_side, lenghtBT, col_side, name_before, 
                foldername, marking, CL_before, numDesignation, materials, density, true, out massbefore);
            name_before = $"{marking}.{CL_before}.{numDesignation} {name_before}";

            //боковой щит
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_side, y + 4 * heightBoard, col_side, name_side, foldername,
                marking, CL_side, numDesignation, materials, density, true, out massside);
            name_side = $"{marking}.{CL_side}.{numDesignation} {name_side}";

            //Планка пояса - вверхняя
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_around, w_bottom * col_bottom, 0, name_around1, 
                foldername, marking, CL_around, numDesignation, materials, density, false, out massaround1);
            name_around1 = $"{marking}.{CL_around}.{numDesignation} {name_around1}";

            //Планка пояса - боковая
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_around, w_side * col_side + 4 * heightBoard, 0, name_around2, 
                foldername, marking, CL_around, numDesignation, materials, density, false, out massaround2);
            name_around2 = $"{marking}.{CL_around}.{numDesignation} {name_around2}";

            //Планка торцевого щита - вертикальная
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_front, w_side * col_side, 0, name_front1,
                foldername, marking, CL_front, numDesignation, materials, density, false, out massfront1);
            name_front1 = $"{marking}.{CL_front}.{numDesignation} {name_front1}";

            //Планка торцевого щита - горизонтальная
            MarkingBox(number, out numDesignation);
            number++;
            NewShield(heightBoard, w_front, lenghtBT - 2 * w_front, 0, name_front2,
                foldername, marking, CL_front, numDesignation, materials, density, false, out massfront2);
            name_front2 = $"{marking}.{CL_front}.{numDesignation} {name_front2}";

            double colNails = 0;

            colNails = (col_bottom * 16 + 16) * 2 + (col_side * 16) * 2 + (col_side * 4 * 4) + 26;
            double lengthTape = col_bottom * w_bottom * 4 +
                col_side * w_side * 4 + 100 * 8 + 1000;

            InformationAboutBox.ValueBox.Clear();
            InformationAboutBox.ValueBox.Add(new ValueBox
            {
                TypeBox = 1,
                cap = $"{w_bottom*col_bottom}x{y + 4 * heightBoard}", //крышка
                before = $"{w_side*col_side}x{lenghtBT}", //торцевой щит
                side = $"{w_side*col_side}x{y + 4 * heightBoard}", //боковой щит
                around1 = $"{w_around}x{w_bottom * col_bottom}", //боковой щит
                around2 = $"{w_around}x{w_side * col_side + 4 * heightBoard}", //боковой щит
                front1 = $"{w_front}x{w_side * col_side}", //Планка торцевого щита - вертикальная
                front2 = $"{w_front}x{lenghtBT - 2 * w_side}", //Планка торцевого щита - горизонтальная

                masscap = $"{masscap}",
                massbefore = $"{massbefore}",
                massside = $"{massside}",
                massaround1 = $"{massaround1}",
                massaround2 = $"{massaround2}",
                massfront1 = $"{massfront1}",
                massfront2 = $"{massfront2}",

                colNails = colNails,
                lengthTape = Math.Round(lengthTape / 1000, 2),

            });

            InformationAboutBox.ValueBoxForReport.Clear();
            InformationAboutBox.ValueBoxForReport.Add(new ValueBoxForReport
            {
                col_cap = col_bottom,
                col_side = col_side,

                w_cap = w_bottom,
                w_side = w_side,

                lenghtBox = y + 4 * heightBoard,

                heightBoard = heightBoard,
            });


            ////////////////СБОРКА

            ksDocument3D ksDoc3d1 = (ksDocument3D)kompas.Document3D();
            ksDoc3d1.Create(false, false);
            ksDoc3d1.fileName = $"{marking}.321169.000 Ящик деревянный I-1"; // указание названия файла
            ksPart partAs = ksDoc3d1.GetPart((int)Part_Type.pTop_Part); // получаем интерфейс новой сборки
            partAs.name = "Ящик деревянный I-1";
            partAs.marking = $"{marking}.321169.000";
            partAs.SetMaterial(materials, density);
            partAs.Update();

            string file_bottom;
            file_bottom = foldername + "\\" + name_bottom + ".m3d";

            string file_side;
            file_side = foldername + "\\" + name_side + ".m3d";

            string file_before;
            file_before = foldername + "\\" + name_before + ".m3d";

            string file_front1;
            file_front1 = foldername + "\\" + name_front1 + ".m3d";

            string file_front2;
            file_front2 = foldername + "\\" + name_front2 + ".m3d";

            string file_around1;
            file_around1 = foldername + "\\" + name_around1 + ".m3d";

            string file_around2;
            file_around2 = foldername + "\\" + name_around2 + ".m3d";

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

            ksEntityCollection pCol6;
            ksEntity[] namePlane6 = new ksEntity[5];

            ksEntityCollection pCol7;
            ksEntity[] namePlane7 = new ksEntity[5];

            ksEntityCollection pCol8;
            ksEntity[] namePlane8 = new ksEntity[5];

            ksEntityCollection pCol9;
            ksEntity[] namePlane9 = new ksEntity[5];

            ksEntityCollection pCol10;
            ksEntity[] namePlane10 = new ksEntity[5];

            ksEntityCollection pCol11;
            ksEntity[] namePlane11 = new ksEntity[5];

            ksEntityCollection pCol12;
            ksEntity[] namePlane12 = new ksEntity[5];

            ksEntityCollection pCol13;
            ksEntity[] namePlane13 = new ksEntity[5];

            ksEntityCollection pCol14;
            ksEntity[] namePlane14 = new ksEntity[5];

            ksEntityCollection pCol15;
            ksEntity[] namePlane15 = new ksEntity[5];

            ksEntityCollection pCol16;
            ksEntity[] namePlane16 = new ksEntity[5];

            ksEntityCollection pCol17;
            ksEntity[] namePlane17 = new ksEntity[5];

            ksEntityCollection pCol18;
            ksEntity[] namePlane18 = new ksEntity[5];

            ksEntityCollection pCol19;
            ksEntity[] namePlane19 = new ksEntity[5];

            ksEntityCollection pCol20;
            ksEntity[] namePlane20 = new ksEntity[5];

            ksEntityCollection pCol21;
            ksEntity[] namePlane21 = new ksEntity[5];


            ksDoc3d1.SetPartFromFile(file_bottom, partAs, false); //0 дно (крышка1)
            ksDoc3d1.SetPartFromFile(file_side, partAs, false); //1 боковой щит 1
            ksDoc3d1.SetPartFromFile(file_side, partAs, false); //2 боковой щит 2
            ksDoc3d1.SetPartFromFile(file_bottom, partAs, false); //3 крышка2
            ksDoc3d1.SetPartFromFile(file_before, partAs, false); //4 торец 1
            ksDoc3d1.SetPartFromFile(file_before, partAs, false); //5 торец 2

            ksDoc3d1.SetPartFromFile(file_front1, partAs, false); //6 Планка торцевого щита - вертикальная
            ksDoc3d1.SetPartFromFile(file_front1, partAs, false); //7 Планка торцевого щита - вертикальная
            ksDoc3d1.SetPartFromFile(file_front2, partAs, false); //8 Планка торцевого щита - горизонтальная
            ksDoc3d1.SetPartFromFile(file_front2, partAs, false); //9 Планка торцевого щита - горизонтальная

            ksDoc3d1.SetPartFromFile(file_front1, partAs, false); //10 Планка торцевого щита - вертикальная
            ksDoc3d1.SetPartFromFile(file_front1, partAs, false); //11 Планка торцевого щита - вертикальная
            ksDoc3d1.SetPartFromFile(file_front2, partAs, false); //12 Планка торцевого щита - горизонтальная
            ksDoc3d1.SetPartFromFile(file_front2, partAs, false); //13 Планка торцевого щита - горизонтальная

            ksDoc3d1.SetPartFromFile(file_around1, partAs, false); // 14 Планка пояса - вверхняя
            ksDoc3d1.SetPartFromFile(file_around1, partAs, false); // 15 Планка пояса - вверхняя
            ksDoc3d1.SetPartFromFile(file_around1, partAs, false); // 16 Планка пояса - вверхняя
            ksDoc3d1.SetPartFromFile(file_around1, partAs, false); // 17 Планка пояса - вверхняя

            ksDoc3d1.SetPartFromFile(file_around2, partAs, false); // 18 Планка пояса - боковая
            ksDoc3d1.SetPartFromFile(file_around2, partAs, false); // 19 Планка пояса - боковая
            ksDoc3d1.SetPartFromFile(file_around2, partAs, false); // 20 Планка пояса - боковая
            ksDoc3d1.SetPartFromFile(file_around2, partAs, false); // 21 Планка пояса - боковая

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
            ksDoc3d1.AddMateConstraint(5, namePlane1[3], namePlane2[3], 1, 1, w_bottom * col_bottom - heightBoard);
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
            ksDoc3d1.AddMateConstraint(5, namePlane1[0], namePlane3[4], -1, 1, -(w_side * col_side + heightBoard));

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

            /////// Планка торцевого щита - вертикальная 2 штуки

            partAs = partColl.GetByIndex(6);
            pCol6 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane6[0] = pCol6.GetByName("Number0", true, true);
            namePlane6[1] = pCol6.GetByName("Number1", true, true);
            namePlane6[2] = pCol6.GetByName("Number2", true, true);
            namePlane6[3] = pCol6.GetByName("Number3", true, true);
            namePlane6[4] = pCol6.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane4[3], namePlane6[3], -1, 1, 0); // торец
            ksDoc3d1.AddMateConstraint(0, namePlane1[3], namePlane6[0], -1, 1, 0); // бок1
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane6[2], -1, 1, 0); // крышка


            partAs = partColl.GetByIndex(7);
            pCol7 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane7[0] = pCol7.GetByName("Number0", true, true);
            namePlane7[1] = pCol7.GetByName("Number1", true, true);
            namePlane7[2] = pCol7.GetByName("Number2", true, true);
            namePlane7[3] = pCol7.GetByName("Number3", true, true);
            namePlane7[4] = pCol7.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane4[3], namePlane7[3], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(5, namePlane1[3], namePlane7[0], -1, 1, lenghtBT - w_front);
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane7[2], -1, 1, 0);

            //Планка торцевого щита - горизонтальная 2 штуки

            partAs = partColl.GetByIndex(8);
            pCol8 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane8[0] = pCol8.GetByName("Number0", true, true);
            namePlane8[1] = pCol8.GetByName("Number1", true, true);
            namePlane8[2] = pCol8.GetByName("Number2", true, true);
            namePlane8[3] = pCol8.GetByName("Number3", true, true);
            namePlane8[4] = pCol8.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane4[3], namePlane8[3], -1, 1, 0); //торец
            ksDoc3d1.AddMateConstraint(0, namePlane7[0], namePlane8[2], -1, 1, 0); // планка 2
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane8[0], -1, 1, 0); //крышка

            partAs = partColl.GetByIndex(9);
            pCol9 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane9[0] = pCol9.GetByName("Number0", true, true);
            namePlane9[1] = pCol9.GetByName("Number1", true, true);
            namePlane9[2] = pCol9.GetByName("Number2", true, true);
            namePlane9[3] = pCol9.GetByName("Number3", true, true);
            namePlane9[4] = pCol9.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane4[3], namePlane9[4], -1, 1, 0); //торец
            ksDoc3d1.AddMateConstraint(0, namePlane7[0], namePlane9[2], -1, 1, 0); // планка 2
            ksDoc3d1.AddMateConstraint(5, namePlane3[3], namePlane9[0], 1, 1, w_side * col_side); //крышка

            //ДАЛЬНИЕ Планка торцевого щита - вертикальная 2 штуки

            partAs = partColl.GetByIndex(10);
            pCol10 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane10[0] = pCol10.GetByName("Number0", true, true);
            namePlane10[1] = pCol10.GetByName("Number1", true, true);
            namePlane10[2] = pCol10.GetByName("Number2", true, true);
            namePlane10[3] = pCol10.GetByName("Number3", true, true);
            namePlane10[4] = pCol10.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane5[4], namePlane10[4], -1, 1, 0); // торец
            ksDoc3d1.AddMateConstraint(0, namePlane1[3], namePlane10[0], -1, 1, 0); // бок1
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane10[2], -1, 1, 0); // крышка

            partAs = partColl.GetByIndex(11);
            pCol11 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane11[0] = pCol11.GetByName("Number0", true, true);
            namePlane11[1] = pCol11.GetByName("Number1", true, true);
            namePlane11[2] = pCol11.GetByName("Number2", true, true);
            namePlane11[3] = pCol11.GetByName("Number3", true, true);
            namePlane11[4] = pCol11.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane5[4], namePlane11[4], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(5, namePlane1[3], namePlane11[0], -1, 1, lenghtBT - w_front);
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane11[2], -1, 1, 0);

            //ДАЛЬНИЕ Планка торцевого щита - горизонтальные 2 штуки

            partAs = partColl.GetByIndex(12);
            pCol12 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane12[0] = pCol12.GetByName("Number0", true, true);
            namePlane12[1] = pCol12.GetByName("Number1", true, true);
            namePlane12[2] = pCol12.GetByName("Number2", true, true);
            namePlane12[3] = pCol12.GetByName("Number3", true, true);
            namePlane12[4] = pCol12.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane5[4], namePlane12[4], -1, 1, 0); //торец
            ksDoc3d1.AddMateConstraint(0, namePlane7[0], namePlane12[2], -1, 1, 0); // планка 2
            ksDoc3d1.AddMateConstraint(0, namePlane3[3], namePlane12[0], -1, 1, 0); //крышка

            partAs = partColl.GetByIndex(13);
            pCol13 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane13[0] = pCol13.GetByName("Number0", true, true);
            namePlane13[1] = pCol13.GetByName("Number1", true, true);
            namePlane13[2] = pCol13.GetByName("Number2", true, true);
            namePlane13[3] = pCol13.GetByName("Number3", true, true);
            namePlane13[4] = pCol13.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane5[4], namePlane13[3], -1, 1, 0); //торец
            ksDoc3d1.AddMateConstraint(0, namePlane7[0], namePlane13[2], -1, 1, 0); // планка 2
            ksDoc3d1.AddMateConstraint(5, namePlane3[3], namePlane13[0], 1, 1, w_side * col_side); //крышка


            /////Планка пояса верхние - первая пара

            double distance = (y + 4 * heightBoard) / 6;
            if (distance > 700)
                distance = ((y + 4 * heightBoard) - 700 - 2 * w_around) / 2;
            distance = Math.Round(distance);

            partAs = partColl.GetByIndex(14);
            pCol14 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane14[0] = pCol14.GetByName("Number0", true, true);
            namePlane14[1] = pCol14.GetByName("Number1", true, true);
            namePlane14[2] = pCol14.GetByName("Number2", true, true);
            namePlane14[3] = pCol14.GetByName("Number3", true, true);
            namePlane14[4] = pCol14.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane3[4], namePlane14[4], -1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(0, namePlane3[0], namePlane14[1], 1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(5, namePlane6[4], namePlane14[0], 1, 1, -distance); //планка 1


            partAs = partColl.GetByIndex(15);
            pCol15 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane15[0] = pCol15.GetByName("Number0", true, true);
            namePlane15[1] = pCol15.GetByName("Number1", true, true);
            namePlane15[2] = pCol15.GetByName("Number2", true, true);
            namePlane15[3] = pCol15.GetByName("Number3", true, true);
            namePlane15[4] = pCol15.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane[3], namePlane15[3], -1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(0, namePlane3[0], namePlane15[1], 1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(5, namePlane6[4], namePlane15[0], 1, 1, -distance); //планка 1

            /////Планка пояса верхние - вторая пара

            partAs = partColl.GetByIndex(16);
            pCol16 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane16[0] = pCol16.GetByName("Number0", true, true);
            namePlane16[1] = pCol16.GetByName("Number1", true, true);
            namePlane16[2] = pCol16.GetByName("Number2", true, true);
            namePlane16[3] = pCol16.GetByName("Number3", true, true);
            namePlane16[4] = pCol16.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane3[4], namePlane16[4], -1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(0, namePlane3[0], namePlane16[1], 1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(5, namePlane10[3], namePlane16[0], -1, 1, -distance - w_around); //планка 1

            partAs = partColl.GetByIndex(17);
            pCol17 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane17[0] = pCol17.GetByName("Number0", true, true);
            namePlane17[1] = pCol17.GetByName("Number1", true, true);
            namePlane17[2] = pCol17.GetByName("Number2", true, true);
            namePlane17[3] = pCol17.GetByName("Number3", true, true);
            namePlane17[4] = pCol17.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane[3], namePlane17[3], -1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(0, namePlane3[0], namePlane17[1], 1, 1, 0); //крышка
            ksDoc3d1.AddMateConstraint(5, namePlane10[3], namePlane17[0], -1, 1, -distance - w_around); //планка 1

            //Планка пояса боковая - первая пара 

            partAs = partColl.GetByIndex(18);
            pCol18 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane18[0] = pCol18.GetByName("Number0", true, true);
            namePlane18[1] = pCol18.GetByName("Number1", true, true);
            namePlane18[2] = pCol18.GetByName("Number2", true, true);
            namePlane18[3] = pCol18.GetByName("Number3", true, true);
            namePlane18[4] = pCol18.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane1[4], namePlane18[4], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane14[3], namePlane18[2], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane14[0], namePlane18[0], 1, 1, 0);

            partAs = partColl.GetByIndex(19);
            pCol19 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane19[0] = pCol19.GetByName("Number0", true, true);
            namePlane19[1] = pCol19.GetByName("Number1", true, true);
            namePlane19[2] = pCol19.GetByName("Number2", true, true);
            namePlane19[3] = pCol19.GetByName("Number3", true, true);
            namePlane19[4] = pCol19.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane1[4], namePlane19[4], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane16[3], namePlane19[2], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane16[0], namePlane19[0], 1, 1, 0);

            //Планка пояса боковая - вторая пара 

            partAs = partColl.GetByIndex(20);
            pCol20 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane20[0] = pCol20.GetByName("Number0", true, true);
            namePlane20[1] = pCol20.GetByName("Number1", true, true);
            namePlane20[2] = pCol20.GetByName("Number2", true, true);
            namePlane20[3] = pCol20.GetByName("Number3", true, true);
            namePlane20[4] = pCol20.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane2[3], namePlane20[3], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane14[3], namePlane20[2], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane14[0], namePlane20[0], 1, 1, 0);

            partAs = partColl.GetByIndex(21);
            pCol21 = partAs.EntityCollection((short)Obj3dType.o3d_face);

            namePlane21[0] = pCol21.GetByName("Number0", true, true);
            namePlane21[1] = pCol21.GetByName("Number1", true, true);
            namePlane21[2] = pCol21.GetByName("Number2", true, true);
            namePlane21[3] = pCol21.GetByName("Number3", true, true);
            namePlane21[4] = pCol21.GetByName("Number4", true, true);

            ksDoc3d1.AddMateConstraint(0, namePlane2[3], namePlane21[3], -1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane16[3], namePlane21[2], 1, 1, 0);
            ksDoc3d1.AddMateConstraint(0, namePlane16[0], namePlane21[0], 1, 1, 0);

            string save;

            save = foldername + "\\" + $"{marking}.321169.000 Ящик деревянный I-1" + ".a3d";

            ksDoc3d1.SaveAs(save);

            MessageBox.Show("Построение выполнено!", "Уведомление", MessageBoxButtons.OK, MessageBoxIcon.Information
                , MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification);

        }

    }
}
