using NUnit.Framework;

namespace ConsoleQuestTest
{

    public class Tests
    {
        ConsoleQuest.Character testcharacter1;
        ConsoleQuest.Character testcharacter2;
        [SetUp]
        public void Setup()
        {
            testcharacter1 = new ConsoleQuest.Character("aaa",100f,10f,5f);
            testcharacter2 = new ConsoleQuest.Character("bb", 100f, 10f, 2f);
        }

        [Test]
        public void Test1()
        {
            Assert.That(testcharacter1.HP, Is.EqualTo(100f));
            Assert.That(1,Is.InRange(1,9));
        }
        public void DamageTest()
        {

            for (int i=0; i < 1000; i++)
            {
                float damage = ConsoleQuest.DamageCalculator.CalculateDamage(testcharacter1, testcharacter2);
                Assert.That(damage, Is.InRange(9f, 16f));
            }
        }
    }
}
