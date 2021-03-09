using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
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
        Variables var = new Variables();

        /// <summary>
        /// Информация о структуре програмы 
        /// </summary>
        Program program = new Program();

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
            sizeInfo.SetToolTip(label1, "Размер в mm");
            sizeInfo.SetToolTip(label2, "Размер в mm");
            sizeInfo.SetToolTip(label3, "Размер в mm");
            sizeInfo.SetToolTip(label4, "Размер в mm");
            sizeInfo.SetToolTip(label7, "Размер в mm");
        }

        /// <summary>
        /// Создание болта по указанным параметрам
        /// </summary>
        private void button1_Click(object sender, EventArgs e)
        {
            TakeInfo();
            CheckValidation();
        }

        /// <summary>
        /// Очищение документа от объектов
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            program.ClearDoc();
        }

        /// <summary>
        /// Проверка на пустоту textbox
        /// </summary>
        public void TakeInfo()
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
        public void CheckValidation()
        {
            try
            {
                program.CheckSize(var.RadTop, var.WidthTop, var.RadBolt, var.LenghtBolt, var.RadCut);
                program.CreateModel(var.RadTop, var.WidthTop, var.RadBolt, var.LenghtBolt, var.RadCut);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            program.CreateNewDoc();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
