﻿using System;
using System.Windows.Forms;
using Plagin;

namespace PlaginUI
{
    public partial class MainForm : Form
    {
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
        /// Проверка корректности ввода данных
        /// </summary>
        private void Validation()
        {
            //Builder.CreateModel(Parametrs.RadTop, Parametrs.WidthTop,
            //Parametrs.RadBolt, Parametrs.LenghtBolt, Parametrs.RadCut);

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
        /// <remarks>
        /// e.KeyChar = 47-58 - цифры от 0-9
        /// e.KeyChar = 8 - backspace
        /// e.KeyChar = 44 - запятая
        /// </remarks>
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8 && e.KeyChar != 44)
            {
                e.Handled = true;
            }
        }
    }
}
