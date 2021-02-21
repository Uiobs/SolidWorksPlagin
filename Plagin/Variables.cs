using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plagin
{
    public class Variables
    {
        private float _radTop;

        private float _widthTop;

        private float _radBolt;

        private float _lengthBolt;

        private float _radCut;

        public float RadTop
        {
            get { return _radTop; }

            set { _radTop = value; }
        }

        public float WidthTop
        {
            get { return _widthTop; }

            set { _widthTop = value; }
        }

        public float RadBolt
        {
            get { return _radBolt; }

            set { _radBolt = value; }
        }

        public float LenghtBolt
        {
            get { return _lengthBolt; }

            set { _lengthBolt = value; }
        }

        public float RadCut
        {
            get { return _radCut; }

            set { _radCut = value; }
        }
    }
}
