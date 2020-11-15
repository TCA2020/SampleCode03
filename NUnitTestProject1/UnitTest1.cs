using NUnit.Framework;

namespace ConsoleQuest
{
    public class Tests
    {
        ConsoleQuest.Character character1;
        ConsoleQuest.Character character2;
        [SetUp]
        public void Setup()
        {
            character1 = new ConsoleQuest.Character("aaa", 100, 10, 5);
            character2 = new ConsoleQuest.Character("bbb", 100, 10, 2);
        }

        [Test]
        public void Test1()
        {
            Assert.That(character1.HP, Is.EqualTo(100));
        }
        public void DamageGest()
        {
            for(int i = 0;i<1000;i++)
            {
                float damage = ConsoleQuest.DamageCalculator.CalculateDamage(character1, character2);
                Assert.That(damage, Is.GreaterThanOrEuqualTo(1f));
                {

                }
            }
        }
    }
}