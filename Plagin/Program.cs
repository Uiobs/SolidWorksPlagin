using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;

namespace WindowsFormsApp1
{
    public class Program
    {
        /// <summary>
        /// Переменная для взаимодействие с программой
        /// </summary>
        public SldWorks SwApp;

        /// <summary>
        /// Переменная для взаимодействие с моделировнием
        /// </summary>
        public IModelDoc2 swModel;

        /// <summary>
        /// Удаление созданной модели
        /// </summary>
        public void ClearDoc()
        {
            SwApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            SwApp.Visible = true;
            swModel = SwApp.IActiveDoc2;

            for (int i = 0; i < 5; i++)
            {
                swModel.Extension.SelectByID("", "", 0, 0, 0, false, 0, null);
                swModel.EditDelete();
                swModel.ClearSelection();
            }
        }

        /// <summary>
        /// Создание документа
        /// </summary>
        public void CreateModel(float radTop, float widthTop, float radBolt, float lenghtBolt, float radCut)
        {
            SwApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            SwApp.Visible = true;
            swModel = SwApp.IActiveDoc2;

            ClearDoc();

            swModel.SketchManager.CreateCircle(0, 0, 0, radTop/1000, 0.007061, 0);
            swModel.FeatureManager.FeatureExtrusion2(true, false,false, 0, 0, widthTop / 1000, 0.1,
                false, false, false, false, 0.01745329251994333364, 0.01745329251994333364,
                false, false, false, false, true, true, true, 0, 0, false);
            swModel.ISelectionManager.EnableContourSelection = false;
            swModel.Extension.SelectByRay(-0.001382801503069686078, -0.002641729037804907421, 0.009999999999820374796,
                -0.1709641387276086277, -0.3517034380559542761,
                -0.920367293491434757, 0.000862288242659958108, 2, false, 0, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            swModel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, radCut / 1000, 0.022985, 0.000000);
            swModel.FeatureManager.FeatureCut4(true, false, false, 0, 0, 0.0005000000000000000104, 0.01000000000000000021,
                false, false, false, false, 0.01745329251994333364, 0.01745329251994333364, false, false, false, false, false,
                     true, true, true, true, false, 0, 0, false, false);
            swModel.ISelectionManager.EnableContourSelection = false;
            swModel.Extension.SelectByRay(0.003617989768585516686, -0.00345214744564970033, 0, -0.2340412854091606099,
                -0.07533917344971632901, 0.9693031959443555445, 0.000862288242659958108, 2, false, 0, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            swModel.SketchManager.CreateCircle(0, 0, 0, radBolt/1000 , -0.006153, 0.000000);

            if (widthTop > 10)
            {
                swModel.FeatureManager.FeatureExtrusion2(true, true, true, 0, 0, lenghtBolt / 1000 + widthTop / 1000, 0,
                false, false, false, false, 0.0174, 0.0174, false, false, false,
                false, true, true, true, 0, 0, false);
            }
            else
            {
                swModel.FeatureManager.FeatureExtrusion2(true, false,false, 0, 0, lenghtBolt / 1000, 0,
                false, false, false, false, 0.0174, 0.0174, false, false, false,
                false, true, true, true, 0, 0, false);
            }

        }

        /// <summary>
        /// Проверка данных на коректный размер
        /// </summary>
        public void CheckSize(float radTop,float widthTop,float radBolt, float lenghtBolt, float radCut)
        {
            if(radTop > 100)
            {
                throw new ArgumentException("Радиус шапки не может быть больше 100mm!");
            }
            else if(widthTop > 100)
            {
                throw new ArgumentException("Толщина шапки не может быть больше 100m");
            }
            else if(radBolt > 100)
            {
                throw new ArgumentException("Радиус болта не может быть больше 50m");
            }
            else if (lenghtBolt > 500)
            {
                throw new ArgumentException("Длина болта не может быть больше 500m");
            }
            else if (radCut > radTop)
            {
                throw new ArgumentException("Радиус вырезки не может быть больше радиуса шапки");
            }
            else if (radCut >= radTop)
            {
                throw new ArgumentException("Радиус вырезки не может быть больше или равен радиусу шапки");
            }
            else if (radBolt >= radTop)
            {
                throw new ArgumentException("Радиус болта не может быть больше или равен радиуса шапки");
            }

        }

        static void Main(string[] args) { }
    }
}
