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

        /// <summary>
        /// Модификатор доступа к радиусу шапки болта
        /// </summary>
        public float RadTop {
            get => _radTop; 
            set
            {
                if (_radTop >= 100)
                {
                    _radTop = 30;
                    throw new ArgumentException("Радиус шапки не может быть" +
                        " больше или равно 100mm!");
                }
                else
                {
                    _radTop = value;
                }
            }
        }

        /// <summary>
        /// Модификатор доступа к высоте шапки болта
        /// </summary>
        public float WidthTop {
            get =>_widthTop;
            set
            {
                if (_widthTop >= 100)
                {
                    _widthTop = 10;
                    throw new ArgumentException("Толщина шапки не может быть" +
                        " больше или равно 100m");
                }
                else
                {
                    _widthTop = value;
                }
            }
        }

        /// <summary>
        /// Модификатор доступа к радиусу вырезки болта
        /// </summary>
        public float RadCut
        {
            get => _radCut;
            set
            {
                if (_radCut >= _radTop)
                {
                    _radCut = 10;
                    throw new ArgumentException("Радиус вырезки не может быть" +
                        " больше или равен радиусу шапки");
                }
                else
                {
                    _radCut = value;
                }
            }
        }

        /// <summary>
        /// Модификатор доступа к длине болта
        /// </summary>
        public float LenghtBolt
        {
            get => _lengthBolt;
            set
            {
                if (_lengthBolt >= 500)
                {
                    _lengthBolt = 100;
                    throw new ArgumentException("Длина болта не может быть" +
                        " больше или равен 500m");
                }
                else
                {
                    _lengthBolt = value;
                }
            }
        }

        /// <summary>
        /// Модификатор доступа к радиусу болта
        /// </summary>
        public float RadBolt
        {
            get => _radBolt;
            set
            {
                if (_radBolt >= 100)
                {
                    _radBolt = 15;
                    throw new ArgumentException("Радиус болта не может быть" +
                        " больше или равен 100m");
                }
                else if (_radBolt >= _radTop)
                {
                    _radBolt = 15;
                    throw new ArgumentException("Радиус болта не может быть" +
                        " больше или равен радиуса шапки");
                }
                else
                {
                    _radBolt = value;
                }
            }
        }
    }
}
