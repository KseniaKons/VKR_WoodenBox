using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Kompas6API5;
using Kompas6Constants;
using Kompas6Constants3D;

namespace TreeBox
{
    internal class Box11New
    {
        private KompasObject kompas; // создание экземпляра КОМПАС
        private ksDocument3D ksDoc3d; // создание экземпляра 3D-документа
        private ksPart part; // создание экземпляра детали

        void CalculationBoardsLeaves(int param, out double w_fact_bottom, out double col_fact_bottom)
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

        private void CalculationBoardsConifer(int param, int boardWidth, out double w_fact_bottom, out double col_fact_bottom)
        {
            //параметр по которому считаем, ширина доски вернется, количество досок вернется 

            w_fact_bottom = 0; //посчитанная длиннна доски
            col_fact_bottom = 0; // посчитанное количество
            int w_sh = 10000, buf_sh;
            int col;

            int[] arr = { 75, 100, 125, 150, 175, 200, 225, 250, 275 };

            if (boardWidth == 22)
            {
                //убрать последние два размера
                arr = arr.Take(arr.Length - 2).ToArray();
            }

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

        void Newboard(double height, double width, double length, double col, string name, string foldername)
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

            // массив по сетке //


            // создаём операцию линейного массива
            ksEntity MeshCopyE = part.NewEntity((short)Obj3dType.o3d_meshCopy);

            MeshCopyDefinition MeshCopyDef = MeshCopyE.GetDefinition(); //создаём интерфейс свойств линейного массива

            ksEntity baseAxisX = (ksEntity)part.GetDefaultEntity((short)Obj3dType.o3d_axisOX); //создаём ось линейного массива на основе базовой Х
            MeshCopyDef.SetAxis1(baseAxisX); //выставляем базовую ось для первого направления

            MeshCopyDef.count1 = (int)col; // ПОМЕНЯТЬ НА ПОСЧИТАННОЕ КОЛИЧЕСВО
            MeshCopyDef.step1 = width; // ПОМЕНЯТЬ НА ШИРИНУ ДОСКИ

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


        public void СreatingBox11(int x, int y, int z, double massa, int GOST, int heightWidth, string foldername)
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


            double w_fact_bottom = 0, col_fact_bottom = 0;
            double w_fact_side = 0, col_fact_side = 0;

            if (GOST == 0) //ЛИСТВЕННЫЕ ПОРОДЫ
            {
                // ДОСКИ ДНА И КРЫШКИ
                CalculationBoardsLeaves(x + 2 * heightWidth, out w_fact_bottom, out col_fact_bottom);

                // ДОСКИ БОКОВОГО ЩИТА
                CalculationBoardsLeaves(z, out w_fact_side, out col_fact_side);
            }
            else if (GOST == 1) //ХВОЙНЫЕ ПОРОДЫ
            {
                // ДОСКИ ДНА И КРЫШКИ
                CalculationBoardsConifer(x + 2 * heightWidth, heightWidth, out w_fact_bottom, out col_fact_bottom);

                // ДОСКИ БОКОВОГО ЩИТА
                CalculationBoardsConifer(z, heightWidth, out w_fact_side, out col_fact_side);
            }


            string name_bottom = "Щит дна и крышки";
            string name_side = "Боковой щит";
            string name_before = "Торцевой щит";

            //длинна торцевых досок 
            double lenghtBT = w_fact_bottom * col_fact_bottom - 2 * heightWidth;

            //ЩИТ дна и крышки
            Newboard(heightWidth, w_fact_bottom, y + 4 * heightWidth, col_fact_bottom, name_bottom, foldername); // передать параметры досок  ширина высота длинна

            //боковой щит
            Newboard(heightWidth, w_fact_side, y + 4 * heightWidth, col_fact_side, name_side, foldername);

            //торцевой щит
            Newboard(heightWidth, w_fact_side, lenghtBT, col_fact_side, name_before, foldername);





        }




        }
}
