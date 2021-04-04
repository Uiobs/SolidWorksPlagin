using System;
using NUnit.Framework;
using Plagin;
using Assert = NUnit.Framework.Assert;

namespace PlaginUnitTest
{
    [TestFixture]
    public class UnitTest
    {

        Parametrs Parametrs = new Parametrs();

        [Test(Description = "Позитивный тест на корректность значений")]
        public void CorrectParametrs()
        {
            //setup
            var exepted_lengtBolt = 100;
            var exepted_radBold = 15;
            var exepted_radCut = 10;
            var exepted_radTop = 30;
            var exepted_widthTop = 10;

            Parametrs.LenghtBolt = 100;
            Parametrs.RadBolt = 15;
            Parametrs.RadCut = 10;
            Parametrs.RadTop = 30;
            Parametrs.WidthTop = 10;

            //assert
            Assert.AreEqual(exepted_lengtBolt, Parametrs.LenghtBolt, "Длина болта больше допустимой");
            Assert.AreEqual(exepted_radBold, Parametrs.RadBolt, "Радиус болта больше допустимой");
            Assert.AreEqual(exepted_radCut, Parametrs.RadCut, "Радиус вырезки больше допустимой");
            Assert.AreEqual(exepted_radTop, Parametrs.RadTop, "Радиус шапки больше допустимой");
            Assert.AreEqual(exepted_widthTop, Parametrs.WidthTop, "Толщина вырезки больше допустимой");
        }

        [Test(Description = "Негативный тест на корректность значений")]
        public void UncorrectParametrs()
        {
            //setup
            var _lengtBolt = 1000;
            var _radBold = 150;
            var _radCut = 100;
            var _radTop = 300;
            var _widthTop = 100;

            //assert
            var message = "Некоректная длина";
            Assert.Throws<ArgumentException>(
            () => { Parametrs.CheckSize(_lengtBolt, _lengtBolt, _radCut, _radTop, _widthTop); },
            message);
        }
    }
}
