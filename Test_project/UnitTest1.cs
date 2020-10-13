using NUnit.Framework;

namespace Test_project
{
    public class tests
    {
        ConsoleQuest.Character testCharacter1;

        [SetUp]
        public void Setup()
        {
            testCharacter1 = new ConsoleQuest.Character
                ("testchara", 100f, 10f, 5f);
        }
        [Test]
        public void test()
        {

            Assert.That(testCharacter1.HP,Is.EqualTo(100));
        }
    }
    public class tests2
    {
        ConsoleQuest.Character testCharacter1;
        ConsoleQuest.Character testCharacter2;

        [SetUp]
        public void Setup()
        {
            testCharacter1 = new ConsoleQuest.Character
                ("testchara", 100f, 25f, 8f);
            testCharacter2 = new ConsoleQuest.Character
                 ("testchara", 100f, 20f, 10f);
        }
        [Test]
        public void test()
        {
            float damage = ConsoleQuest.DamageCalculator.CalculateDamage(testCharacter1, testCharacter2);

            Assert.That(damage,Is.InRange(13f,16f));
        }
    }
}