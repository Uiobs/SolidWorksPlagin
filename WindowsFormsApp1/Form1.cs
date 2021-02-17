using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
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
        /// Начальная загрузка формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            ToolTip toolTip = new ToolTip();
            toolTip.SetToolTip(label6, "Радиус шапки: 30mm" 
                                     + "\nВысота шапки: 20mm" 
                                     + "\nДлина стержня: 100mm" 
                                     + "\nТолщина стержня: 15mm");

            ToolTip newDoc = new ToolTip();
            newDoc.SetToolTip(button2, "Не рекомендуется, если уже создан документ!");
            ToolTip sizeInfo = new ToolTip();
            sizeInfo.SetToolTip(label1, "Размер в cm");
            sizeInfo.SetToolTip(label2, "Размер в cm");
            sizeInfo.SetToolTip(label3, "Размер в cm");
            sizeInfo.SetToolTip(label4, "Размер в cm");
            sizeInfo.SetToolTip(label7, "Размер в cm");
        }

        /// <summary>
        /// Создание болта по указанным параметрам
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            SwApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            SwApp.Visible = true;
            swModel = SwApp.IActiveDoc2;
            swModel.SketchManager.CreateCircle(0, 0, 0, 0.037567, 0.007061, 0);
            swModel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.01, 0.1,
                false, false, false, false, 0.01745329251994333364, 0.01745329251994333364,
                false, false, false, false, true, true, true, 0, 0, false);
            swModel.ISelectionManager.EnableContourSelection = false;
            swModel.Extension.SelectByID2("Point1@Origin", "EXTSKETCHPOINT", 0, 0, 0, false, 0, null, 0);
            swModel.Extension.SelectByRay(-0.001382801503069686078, -0.002641729037804907421, 0.009999999999820374796,
                -0.1709641387276086277, -0.3517034380559542761, 
                -0.920367293491434757, 0.000862288242659958108, 2, false, 0, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            swModel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, 0.026500, 0.022985, 0.000000);
            swModel.FeatureManager.FeatureCut4(true, false, false, 0, 0, 0.0005000000000000000104, 0.01000000000000000021,
                false, false, false, false, 0.01745329251994333364, 0.01745329251994333364, false, false, false, false, false, 
                     true, true, true, true, false, 0, 0, false, false);
            swModel.ISelectionManager.EnableContourSelection = false;
            swModel.Extension.SelectByRay(0.003617989768585516686, -0.00345214744564970033, 0, -0.2340412854091606099,
                -0.07533917344971632901, 0.9693031959443555445, 0.000862288242659958108, 2, false, 0, 0);
            swModel.SketchManager.InsertSketch(true);
            swModel.ClearSelection2(true);
            swModel.SketchManager.CreateCircle(0.000000, 0.000000, 0.000000, 0.019607, -0.006153, 0.000000);
            swModel.FeatureManager.FeatureExtrusion2(true, false, false, 0, 0, 0.1000000000000000056, 0.0005000000000000000104,
                false, false, false, false, 0.01745329251994333364, 0.01745329251994333364, false, false, false,
                false, true, true, true, 0, 0, false);
        }

        /// <summary>
        /// Очищение документа от объектов
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            SwApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
            SwApp.Visible = true;
            swModel = SwApp.IActiveDoc2;

            for(int i  = 0;i<3;i++)
            {
                swModel.Extension.SelectByID("", "", 0, 0, 0, false, 0, null);
                swModel.EditDelete();
                swModel.ClearSelection2(true);
            }

        }

        /// <summary>
        /// Создание нового чистого документа
        /// </summary>
        private void button2_Click(object sender, EventArgs e)
        {
            SwApp.NewPart();
        }
    }
}
