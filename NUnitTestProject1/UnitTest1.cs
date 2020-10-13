using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {

        ConsoleQuest.Character testCharacter;
        ConsoleQuest.Character testCharacter2;
        ConsoleQuest.Enemy testEnemy;
        ConsoleQuest.Battle testbattle;
        ConsoleQuest.Player testplayer;

        [SetUp]
        public void Setup()
        {
            testCharacter = new ConsoleQuest.Character("TESTCHARA", 100f, 30f, 10f);
            testCharacter2 = new ConsoleQuest.Character("dmgchara", 100f, 45f, 5f);

            testEnemy = new ConsoleQuest.Enemy("enemy", 100f, 10f, 4f, 0);

            testplayer = new ConsoleQuest.Player("asdasd", 100f, 10f, 4f, 5,0);

            testbattle = new ConsoleQuest.Battle(testplayer, testEnemy);
        }

        [Test]
        public void Test1()
        {
            Assert.That(testCharacter.HP, Is.EqualTo(100));
        }

        [Test]
        public void DamageTest()
        {
            for (int i= 0 ; i < 10000; i++)
            {
                float damage = ConsoleQuest.DamageCalculator.
                               CalculateDamage(testCharacter, testCharacter2);
                Assert.That(damage, Is.InRange(12f, 15f));
            }

        }
    }
}