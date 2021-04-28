using System;
using NUnit.Framework;
using Plugin;
using Assert = NUnit.Framework.Assert;

namespace UnitTest
{
    [TestFixture]
    public class UnitTest
    {

        [Test]
        [TestCase(100,15,10,30,10,8,
            TestName = "Позитивый тест на ввод корректных значений")]
        public void CorrectParametrs(float expectedLengtBolt,
            float expectedRadBold,float expectedRadCut, float
            expectedRadTop, float expectedWidthTop,float
            expectedWidthCut)
        {
            //setup
            Parametrs parametrs = new Parametrs();

            parametrs.RadTop = 30;
            parametrs.WidthTop = 10;
            parametrs.RadCut = 10;
            parametrs.LenghtBolt = 100;
            parametrs.RadBolt = 15;
            parametrs.WidthCut = 8;
            
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
            Assert.AreEqual(parametrs.WidthCut, expectedWidthCut,
              "Толщина вырезки больше допустимой");
        }

        [Test]
        [TestCase(1000, 150, 100, 300, 300,
            TestName = "Негативный тест на корректность значений")]
        public void UncorrectParametrs(float wrongLengtBolt,
            float wrongRadBold, float wrongRadCut, float
            wrongRadTop, float wrongWidthTop)
        {
            //setup
            Parametrs parametrs = new Parametrs();

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

        [Test]
        [TestCase(60, 60, 60,
            TestName = "Тест на корректность зависимостей")]
        public void Dependence(float exectedRadCut, float
            expectedRadBolt, float expectedWidthCut)
        {
            //setup
            Parametrs parametrs = new Parametrs();

            parametrs.RadTop = 30;

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
