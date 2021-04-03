using System;
using System.Windows.Forms;
using Plagin;

namespace PlaginUI
{
    public partial class MainForm : Form
    {
         //TODO: RSDN
        /// <summary>
        /// Получение данных о параметрах болта
        /// </summary>
        Parametrs Parametrs = new Parametrs();

        /// <summary>
        /// Информация о структуре програмы 
        /// </summary>
        Builder Builder = new Builder();
        
        /// <summary>
        /// Начальная загрузка формы
        /// </summary>
        public MainForm()
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
            Builder.ClearDoc();
        }

        /// <summary>
        /// Проверка на пустоту textbox
        /// </summary>
        private void TakeInfo()
        {
            Parametrs.RadTop = float.Parse(textBox1.Text);
            Parametrs.WidthTop = float.Parse(textBox2.Text);
            Parametrs.RadBolt = float.Parse(textBox3.Text);
            Parametrs.LenghtBolt = float.Parse(textBox4.Text);
            Parametrs.RadCut = float.Parse(textBox5.Text);
        }

        /// <summary>
        /// Проверка корректности ввода данных
        /// </summary>
        private void Validation()
        {
            try
            {

                Parametrs.CheckSize(Parametrs.RadTop, Parametrs.WidthTop, Parametrs.RadBolt,
                    Parametrs.LenghtBolt, Parametrs.RadCut);
                Builder.CreateModel(Parametrs.RadTop, Parametrs.WidthTop,
                    Parametrs.RadBolt, Parametrs.LenghtBolt, Parametrs.RadCut);
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
            Builder.CreateNewDoc();
            panel1.Enabled = true;
        }

        /// <summary>
        /// Проверка на ввод букв
        /// </summary>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;

            //47-58: цифры от 0 до 9
            //8: backspace
            //44: запятая
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }
    }
}
