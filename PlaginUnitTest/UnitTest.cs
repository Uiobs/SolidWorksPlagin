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
            Parametrs parametrs = new Parametrs();
            var expectedLengtBolt = 100;
            var expectedRadBold = 15;
            var expectedRadCut = 10;
            var expectedRadTop = 30;
            var expectedWidthTop = 10;

            parametrs.RadTop = 30;
            parametrs.WidthTop = 10;
            parametrs.RadCut = 10;
            parametrs.LenghtBolt = 100;
            parametrs.RadBolt = 15;
            
            //assert
            Assert.AreEqual(parametrs.LenghtBolt, expectedLengtBolt,
                "Длина болта больше допустимой");
            Assert.AreEqual(parametrs.RadBolt, expectedRadBold, 
                "Радиус болта больше допустимой");
            Assert.AreEqual(parametrs.RadCut, expectedRadCut, 
                "Радиус вырезки больше допустимой");
            Assert.AreEqual(parametrs.RadTop, expectedRadTop, 
                "Радиус шапки больше допустимой");
            Assert.AreEqual(parametrs.WidthTop, expectedWidthTop, 
                "Толщина вырезки больше допустимой");
        }

        [Test(Description = "Негативный тест на корректность значений")]
        public void UncorrectParametrs()
        {
            //setup
            Parametrs parametrs = new Parametrs();
            var wrongLengtBolt = 1000;
            var wrongRadBold = 150;
            var wrongRadCut = 100;
            var wrongRadTop = 300;

            //assert
            Assert.Throws<ArgumentException>(
            () => { parametrs.RadTop = wrongRadTop;},
            "Некоректная длина болта");
            Assert.Throws<ArgumentException>(
            () => { parametrs.WidthTop = wrongWidthTop;},
            "Некоректный радиус болта");
            Assert.Throws<ArgumentException>(
            () => { parametrs.RadCut = wrongRadCut;},
            "Некоректный радиус вырезки болта");
            Assert.Throws<ArgumentException>(
            () => { parametrs.LenghtBolt = wrongLengtBolt;},
            "Некоректный радиус шапки болта");
            Assert.Throws<ArgumentException>(
            () => { parametrs.RadBolt = wrongRadBold;},
            "Некоректная толщина шапки");
        }

        [Test(Description = "Тест на корректность зависимостей")]
        public void Dependence()
        {
            //setup
            Parametrs parametrs = new Parametrs();

            parametrs.RadTop = 30;
            var exectedRadCut = 60;
            var expectedRadBolt = 60;
            var expectedWidthCut = 60;

            //assert
            Assert.Throws<ArgumentException>(
            () => 
            {
                parametrs.RadBolt = expectedRadBolt;
            },
            "Некоректная зависимость толщины болта и шапки");
            Assert.Throws<ArgumentException>(
            () =>
            {
                parametrs.RadCut = exectedRadCut;
            },
            "Некоректная зависимость толщины болта и вырезки");
            Assert.Throws<ArgumentException>(
            () =>
            {
                parametrs.WidthCut = expectedWidthCut;
            },
            "Некоректная зависимость толщины болта и вырезки");
        }
    }
}
