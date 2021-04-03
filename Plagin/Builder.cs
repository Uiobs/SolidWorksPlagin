using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;

namespace Plagin
{
    /// <summary>
    /// Класс, отвечающий за создание модели
    /// </summary>
    public class Builder
    {
        /// <summary>
        /// Переменная для взаимодействие с программой
        /// </summary>
        private SldWorks _swApp;

        /// <summary>
        /// Переменная для взаимодействие с моделировнием
        /// </summary>
        private IModelDoc2 _swModel;

        /// <summary>
        /// Создание нового документа
        /// </summary>
        public void CreateNewDoc()
        {
            //Connector();
            //_swApp.NewPart();
            //_swModel.Extension.SelectByID2("Point1@Origin", "EXTSKETCHPOINT",
             //   0, 0, 0, false, 0, null, 0);
            //_swModel.BlankSketch();
        }

        /// <summary>
        /// Удаление созданной модели
        /// </summary>
        public void ClearDoc()
        {
            //Connector();

            //Удаляет последовательно элементы в моделе, элементов в моделе 7
            for (int i = 0; i <= 6; i++)
            {
                _swModel.Extension.SelectByID("", "", 0, 0, 0, false, 0, null);
                _swModel.EditDelete();
                _swModel.ClearSelection();
            }
        }

        /// <summary>
        /// Создание документа
        /// </summary>
        public void CreateModel(float radTop, float widthTop, float radBolt, 
            float lenghtBolt, float radCut)
        {
            _swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            _swApp.Visible = true;
            _swModel = _swApp.IActiveDoc2;

            ChangeSize(radTop,widthTop,radBolt,lenghtBolt,radCut);
            ClearDoc();

            _swModel.SketchManager.CreateCircle(0, 0, 0, radTop, 0.007061
                , 0);
            _swModel.FeatureManager.FeatureExtrusion2(true, false,false, 0, 0,
                widthTop, 0.1,
                false, false, false, false, 0.01745329251994333364, 0.0174532,
                false, false, false, false, true, true, true, 0, 0, false);
            _swModel.ISelectionManager.EnableContourSelection = false;
            _swModel.Extension.SelectByRay(-0.001382801503069686078, 
                -0.002641729037804907421, 0.009999999999820374796,
                -0.1709641387276086277, -0.3517034380559542761,
                -0.920367293491434757, 0.000862288242659958108, 2, false, 0, 0);
            _swModel.SketchManager.InsertSketch(true);
            _swModel.ClearSelection2(true);
            _swModel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000,
                radCut, 0.022985, 0.000000);
            _swModel.FeatureManager.FeatureCut4(true, false, false, 0, 0, 
                0.0005000000000000000104, 0.01000000000000000021,
                false, false, false, false, 0.01745329251994333364,
                0.01745329251994333364, false, false, false, false, false,
                     true, true, true, true, false, 0, 0, false, false);
            _swModel.ISelectionManager.EnableContourSelection = false;
            _swModel.Extension.SelectByRay(0.003617989768585516686,
                -0.00345214744564970033, 0, -0.2340412854091606099,
                -0.07533917344971632901, 0.9693031959443555445,
                0.000862288242659958108, 2, false, 0, 0);
            _swModel.SketchManager.InsertSketch(true);
            _swModel.ClearSelection2(true);
            _swModel.SketchManager.CreateCircle(0, 0, 0, radBolt ,
                -0.006153, 0.000000);

            if (widthTop > 10)
            {
                _swModel.FeatureManager.FeatureExtrusion2(true, true, true, 0, 0,
                    lenghtBolt + widthTop, 0,
                false, false, false, false, 0.0174, 0.0174, false, false, false,
                false, true, true, true, 0, 0, false);
            }
            else
            {
                _swModel.FeatureManager.FeatureExtrusion2(true, false,false, 0, 0,
                    lenghtBolt, 0,
                false, false, false, false, 0.0174, 0.0174, false, false, false,
                false, true, true, true, 0, 0, false);
            }
        }

        /// <summary>
        /// Коннектор с SolidWorks
        /// </summary>
        private void Connector()
        {
            _swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            _swApp.Visible = true;
            _swModel = _swApp.IActiveDoc2;
        }

        /// <summary>
        /// Перевод параметров в значения SolidWorks
        /// </summary>
        private void ChangeSize(float radTop, float widthTop, float radBolt,
            float lenghtBolt, float radCut)
        {
            radTop /= 1000;
            widthTop /= 1000;
            radBolt /= 1000;
            lenghtBolt /= 1000;
            radCut /= 1000;
        }
    }
}
