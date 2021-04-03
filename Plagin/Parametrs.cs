using System;

namespace Plagin
{
    /// <summary>
    /// Класс, содержащий параметры модели
    /// </summary>
    public class Parametrs
    {
        /// <summary>
        /// Отвечает за радиус шапки болта
        /// </summary>
        private float _radTop;

        /// <summary>
        /// Отвечает высоту шапки болта
        /// </summary>
        private float _widthTop;

        /// <summary>
        /// Отвечает за радиус стержня болта
        /// </summary>
        private float _radBolt;

        /// <summary>
        /// Отвечает за длину болта
        /// </summary>
        private float _lengthBolt;

        /// <summary>
        /// Отвечает за радиус вырезки шапки
        /// </summary>
        private float _radCut;

        //TODO: В автосвойства
        /// <summary>
        /// Модификатор доступа к радиусу шапки болта
        /// </summary>
        public float RadTop{ get; set;}

        /// <summary>
        /// Модификатор доступа к высоте шапки болта
        /// </summary>
        public float WidthTop { get; set; }

        /// <summary>
        /// Модификатор доступа к радиусу стержня болта
        /// </summary>
        public float RadBolt { get; set; }

        /// <summary>
        /// Модификатор доступа к длине болта
        /// </summary>
        public float LenghtBolt { get; set; }

        /// <summary>
        /// Модификатор доступа к радиусу вырезки болта
        /// </summary>
        public float RadCut { get; set; }

        /// <summary>
        /// Проверка данных на совместимость параметров
        /// </summary>
        public void CheckSize(float radTop, float widthTop, float radBolt, float lenghtBolt, float radCut)
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
    }
}
