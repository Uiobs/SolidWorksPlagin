using System;
using System.Windows.Forms;
using Plugin;

namespace PluginUI
{
    /// <summary>
    /// Класс главной формы
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Получение данных о параметрах болта
        /// </summary>
        private Parametrs Parametrs = new Parametrs();
        
        /// <summary>
        /// Информация о структуре програмы 
        /// </summary>
        private Builder Builder = new Builder();
        
        /// <summary>
        /// Начальная загрузка формы
        /// </summary>
        public MainForm()
        {
            InitializeComponent();

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
            try
            {
            Parametrs.RadTop = float.Parse(textBox1.Text);
            Parametrs.WidthTop = float.Parse(textBox2.Text);
            Parametrs.RadBolt = float.Parse(textBox3.Text);
            Parametrs.LenghtBolt = float.Parse(textBox4.Text);
            Parametrs.RadCut = float.Parse(textBox5.Text);
            Builder.CreateModel(Parametrs.RadTop, Parametrs.WidthTop,
                Parametrs.RadBolt, Parametrs.LenghtBolt, Parametrs.RadCut);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Очищение документа от объектов
        /// </summary>
        private void ClearDoc_Click(object sender, EventArgs e)
        {
            Builder.ClearDoc();
        }

        /// <summary>
        /// Кнопка создания нового документа
        /// </summary>
        private void CreateDoc_Click(object sender, EventArgs e)
        {
            //Builder.CreateNewDoc();
            panel1.Enabled = true;
        }

        /// <summary>
        /// Проверка на ввод букв
        /// </summary>
        private void CheckValid_KeyPress(object sender, KeyPressEventArgs e)
        {
            const int backspace = 8;
            if ((e.KeyChar <= '0' || e.KeyChar >= '9') && e.KeyChar != backspace && e.KeyChar != '.')
            {
                e.Handled = true;
            }
        }
    }
}
