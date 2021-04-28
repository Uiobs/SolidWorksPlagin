using System.Runtime.InteropServices;
using SolidWorks.Interop.sldworks;

namespace Plugin
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
            Connector();
            _swApp.NewPart();
        }

        /// <summary>
        /// Удаление созданной модели
        /// </summary>
        public void ClearDoc()
        {
            Connector();

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
            float lenghtBolt, float radCut,float widthCut)
        {
            _swApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            _swApp.Visible = true;
            _swModel = _swApp.IActiveDoc2;

            ClearDoc();
            ChangeSize(ref radTop,ref widthTop,ref radBolt,ref lenghtBolt,
                ref radCut,ref widthCut);

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
            _swModel.SketchManager.CreateCircle(0,0,0,radCut,0.0022985,0);
            _swModel.FeatureManager.FeatureCut4(true, false, false, 0, 0,
                widthCut, 0.001,false, false, false, false, 0.3,
                0.3, false, false, false, false, false,
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

            if (widthTop > 0.01)
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
        private void ChangeSize(ref float radTop, ref float widthTop, ref float radBolt,
            ref float lenghtBolt, ref float radCut,ref float widthCut)
        {
            const float solidValue = 1000;
            radTop /= solidValue;
            widthTop /= solidValue;
            radBolt /= solidValue;
            lenghtBolt /= solidValue;
            radCut /= solidValue;
            widthCut /= solidValue;
        }
    }
}
