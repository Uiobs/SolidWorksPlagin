using System;
using NUnit.Framework;
using Plagin;
using Assert = NUnit.Framework.Assert;

namespace UnitTest
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

            Parametrs.RadTop = 30;
            Parametrs.WidthTop = 10;
            Parametrs.RadCut = 10;
            Parametrs.LenghtBolt = 100;
            Parametrs.RadBolt = 15;
            
            //assert
            Assert.AreEqual(Parametrs.LenghtBolt, exepted_lengtBolt, "Длина болта больше допустимой");
            Assert.AreEqual(Parametrs.RadBolt, exepted_radBold, "Радиус болта больше допустимой");
            Assert.AreEqual(Parametrs.RadCut, exepted_radCut, "Радиус вырезки больше допустимой");
            Assert.AreEqual(Parametrs.RadTop, exepted_radTop, "Радиус шапки больше допустимой");
            Assert.AreEqual(Parametrs.WidthTop, exepted_widthTop, "Толщина вырезки больше допустимой");
        }

        [Test(Description = "Негативный тест на корректность значений")]
        public void UncorrectParametrs()
        {
            //setup
            var wrong_lengtBolt = 1000;
            var wrong_radBold = 150;
            var wrong_radCut = 100;
            var wrong_radTop = 300;
            var wrong_widthTop = 100;

            //assert
            Assert.Throws<ArgumentException>(
            () => { Parametrs.RadTop = wrong_radTop;
                    Parametrs.RadTop = wrong_radTop;},
            "Некоректная длина болта");
            Assert.Throws<ArgumentException>(
            () => { Parametrs.WidthTop = wrong_widthTop;
                    Parametrs.WidthTop = wrong_widthTop;},
            "Некоректный радиус болта");
            Assert.Throws<ArgumentException>(
            () => { Parametrs.RadCut = wrong_radCut;
                    Parametrs.RadCut = wrong_radCut;},
            "Некоректный радиус вырезки болта");
            Assert.Throws<ArgumentException>(
            () => { Parametrs.LenghtBolt = wrong_lengtBolt;
                    Parametrs.LenghtBolt = wrong_lengtBolt;},
            "Некоректный радиус шапки болта");
            Assert.Throws<ArgumentException>(
            () => { Parametrs.RadBolt = wrong_radBold;
                    Parametrs.RadBolt = wrong_radBold;},
            "Некоректная толщина шапки");

        }
    }
}
