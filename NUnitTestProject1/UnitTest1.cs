using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        ConsoleQuest.Character testCaracter;
        ConsoleQuest.Character testTarget;

        [SetUp]
        public void Setup()
        {
            testCaracter = new ConsoleQuest.Character
                ("testchara", 100f, 40f, 14f);

            testTarget = new ConsoleQuest.Character
                ("testenem", 100f, 20f, 12f);
        }

        [Test]
        public void Test1()
        {
            Assert.That(testCaracter.HP, Is.EqualTo(100f));
        }

        [Test]
        public void Damegetest()
        {
            for (int i = 0; i < 10000; i++)
            {
                float damage = ConsoleQuest.DamageCalculator.CalculateDamage(testCaracter, testTarget);
                Assert.That(damage, Is.InRange(13f, 19f));
            }
            
        }
    }
}