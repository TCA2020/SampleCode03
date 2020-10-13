using NUnit.Framework;

namespace ConsoleQuestTest
{
    public class Tests
    {
        ConsoleQuest.Character Character1;

        ConsoleQuest.Character Character2;

        [SetUp]
        public void Setup()
        {
            Character1 = new ConsoleQuest.Character("aaaa", 100, 10, 4);
            Character2 = new ConsoleQuest.Character("bbbb", 100, 10, 2);
        }

        [Test]
        public void Test1()
        {
            Assert.That(Character1.HP, Is.EqualTo(100));
        }
        [Test]
        public void DamageTest()
        {
            for(int i = 0; i < 100; i++)
            {
                float damage = ConsoleQuest.DamageCalculator.CalculateDamage(Character1, Character2);
                Assert.That(damage, Is.GreaterThanOrEqualTo(1f));
            }
            
        }
    }
}