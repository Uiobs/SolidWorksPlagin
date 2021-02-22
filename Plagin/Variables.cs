using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plagin
{
    public class Variables
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
        public float RadTop
        {
            get { return _radTop; }

            set { _radTop = value; }
        }

        /// <summary>
        /// Модификатор доступа к высоте шапки болта
        /// </summary>
        public float WidthTop
        {
            get { return _widthTop; }

            set { _widthTop = value; }
        }

        /// <summary>
        /// Модификатор доступа к радиусу стержня болта
        /// </summary>
        public float RadBolt
        {
            get { return _radBolt; }

            set { _radBolt = value; }
        }

        /// <summary>
        /// Модификатор доступа к длине болта
        /// </summary>
        public float LenghtBolt
        {
            get { return _lengthBolt; }

            set { _lengthBolt = value; }
        }

        /// <summary>
        /// Модификатор доступа к радиусу вырезки болта
        /// </summary>
        public float RadCut
        {
            get { return _radCut; }

            set { _radCut = value; }
        }
    }
}
