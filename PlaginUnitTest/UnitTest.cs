using System;
using NUnit.Framework;
using Plugin;
using Assert = NUnit.Framework.Assert;

namespace UnitTest
{
    [TestFixture]
    public class UnitTest
    {

        [Test(Description = "Позитивный тест на корректность значений")]
        public void CorrectParametrs()
        {
            //setup
            Parametrs Parametrs = new Parametrs();
            var expectedLengtBolt = 100;
            var expectedRadBold = 15;
            var expectedRadCut = 10;
            var expectedRadTop = 30;
            var expectedWidthTop = 10;

            Parametrs.RadTop = 30;
            Parametrs.WidthTop = 10;
            Parametrs.RadCut = 10;
            Parametrs.LenghtBolt = 100;
            Parametrs.RadBolt = 15;
            
            //assert
            Assert.AreEqual(Parametrs.LenghtBolt, expectedLengtBolt, "Длина болта больше допустимой");
            Assert.AreEqual(Parametrs.RadBolt, expectedRadBold, "Радиус болта больше допустимой");
            Assert.AreEqual(Parametrs.RadCut, expectedRadCut, "Радиус вырезки больше допустимой");
            Assert.AreEqual(Parametrs.RadTop, expectedRadTop, "Радиус шапки больше допустимой");
            Assert.AreEqual(Parametrs.WidthTop, expectedWidthTop, "Толщина вырезки больше допустимой");
        }

        [Test(Description = "Негативный тест на корректность значений")]
        public void UncorrectParametrs()
        {
            //setup
            Parametrs Parametrs = new Parametrs();
            var wrongLengtBolt = 1000;
            var wrongRadBold = 150;
            var wrongRadCut = 100;
            var wrongRadTop = 300;
            var wrongWidthTop = 100;

            //assert
            Assert.Throws<ArgumentException>(
            () => { Parametrs.RadTop = wrongRadTop;},
            "Некоректная длина болта");
            Assert.Throws<ArgumentException>(
            () => { Parametrs.WidthTop = wrongWidthTop;},
            "Некоректный радиус болта");
            Assert.Throws<ArgumentException>(
            () => { Parametrs.RadCut = wrongRadCut;},
            "Некоректный радиус вырезки болта");
            Assert.Throws<ArgumentException>(
            () => { Parametrs.LenghtBolt = wrongLengtBolt;},
            "Некоректный радиус шапки болта");
            Assert.Throws<ArgumentException>(
            () => { Parametrs.RadBolt = wrongRadBold;},
            "Некоректная толщина шапки");
        }

        [Test(Description = "Тест на корректность зависимостей")]
        public void Dependence()
        {
            //setup
            Parametrs Parametrs = new Parametrs();
            var expectedRadBolt = 150;
            var expectedRadCut = 100;
            var expectedRadTop = 30;

            //assert
            Assert.Throws<ArgumentException>(
            () => { Parametrs.RadTop = expectedRadTop;
                    Parametrs.RadCut = expectedRadCut;
            },
            "Некоректная зависимость вырезки и шапки");
            Assert.Throws<ArgumentException>(
            () => { Parametrs.RadTop = expectedRadTop;
                    Parametrs.RadBolt = expectedRadBolt;},
            "Некоректная зависимость толщины болта и шапки");
        }
    }
}
