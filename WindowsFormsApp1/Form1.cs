using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.Drawing;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swcommands;
using SolidWorks.Interop.swconst;
using Plagin;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Получение данных о параметрах болта
        /// </summary>
        Parametrs var = new Parametrs();

        /// <summary>
        /// Информация о структуре програмы 
        /// </summary>
        Builder builder = new Builder();

        /// <summary>
        /// Начальная загрузка формы
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "30";
            textBox2.Text = "10";
            textBox3.Text = "15";
            textBox4.Text = "100";
            textBox5.Text = "10";

            ToolTip sizeInfo = new ToolTip();
            sizeInfo.SetToolTip(label1, "Min-1mm " + "\nMax-100mm");
            sizeInfo.SetToolTip(label2, "Min-1mm" + "\nMax - 100mm");
            sizeInfo.SetToolTip(label3, "Min-1mm" + "\nMax-50mm");
            sizeInfo.SetToolTip(label4, "Min-1mm" + "\nMax-500mm");

            panel1.Enabled = false;
        }

        /// <summary>
        /// Создание болта по указанным параметрам
        /// </summary>
        private void CreateModel_Click(object sender, EventArgs e)
        {
            TakeInfo();
            Validation();
        }

        /// <summary>
        /// Очищение документа от объектов
        /// </summary>
        private void ClearDoc_Click(object sender, EventArgs e)
        {
            builder.ClearDoc();
        }

        /// <summary>
        /// Проверка на пустоту textbox
        /// </summary>
        private void TakeInfo()
        {
            var.RadTop = float.Parse(textBox1.Text);
            var.WidthTop = float.Parse(textBox2.Text);
            var.RadBolt = float.Parse(textBox3.Text);
            var.LenghtBolt = float.Parse(textBox4.Text);
            var.RadCut = float.Parse(textBox5.Text);
        }

        /// <summary>
        /// Проверка корректности ввода данных
        /// </summary>
        private void Validation()
        {
            try
            {
                CheckSize(var.RadTop, var.WidthTop, var.RadBolt, var.LenghtBolt, var.RadCut);
                builder.CreateModel(var.RadTop, var.WidthTop, var.RadBolt, var.LenghtBolt, var.RadCut);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Кнопка создания нового документа
        /// </summary>
        private void CreateDoc_Click(object sender, EventArgs e)
        {
            //builder.CreateNewDoc();
            panel1.Enabled = true;
        }

        /// <summary>
        /// Проверка данных на совместимость параметров
        /// </summary>
        private void CheckSize(float radTop, float widthTop, float radBolt, float lenghtBolt, float radCut)
        {
            if (radTop > 100)
            {
                throw new ArgumentException("Радиус шапки не может быть больше 100mm!");
            }
            else if (widthTop > 100)
            {
                throw new ArgumentException("Толщина шапки не может быть больше 100m");
            }
            else if (radBolt > 100)
            {
                throw new ArgumentException("Радиус болта не может быть больше 50m");
            }
            else if (lenghtBolt > 500)
            {
                throw new ArgumentException("Длина болта не может быть больше 500m");
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

        /// <summary>
        /// Проверка на ввод букв
        /// </summary>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && (e.KeyChar <= 39 || e.KeyChar >= 46) && number != 47 && number != 61)
            {
                e.Handled = true;
            }
        }
    }
}
