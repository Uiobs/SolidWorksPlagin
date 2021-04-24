﻿using System;

namespace Plugin
{
    /// <summary>
    /// Класс, содержащий параметры модели
    /// </summary>
    public class Parametrs
    {
        /// <summary>
        /// Отвечает за глубину вырезки
        /// </summary>
        private float _widthCut;

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
        /// Модификатор доступа к глубине вырезки
        /// </summary>
        public float WidthCut
        {
            get => _widthCut;
            set
            {
                if (value >= _widthTop)
                {
                    throw new ArgumentException("Глубина вырезки не может быть" +
                        " больше или равно радиусу шапки!");
                }
                else
                {
                    _widthCut = value;
                }
            }
        }

        /// <summary>
        /// Модификатор доступа к радиусу шапки болта
        /// </summary>
        public float RadTop
        {
            get => _radTop;
            set
            {
                if (value >= 100)
                {
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
        public float WidthTop
        {
            get => _widthTop;
            set
            {
                if (value >= 100)
                {
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
                if (value >= _radTop)
                {
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
                if (value >= 500)
                {
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
                if (value >= 100)
                {
                    throw new ArgumentException("Радиус болта не может быть" +
                        " больше или равен 100m");
                }
                else if (value >= _radTop)
                {
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
