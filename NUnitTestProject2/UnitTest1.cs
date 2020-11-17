using NUnit.Framework;

namespace NUnitTestProject2
{
    public class Tests
    {
        ConsoleQuest.Character testcharacter1;

        [SetUp]
        public void Setup()
        {
            Testcharacter1 = new ConsoleQuest.Character("aaa".100f.10f.5f);
        }

        [Test]
        public void Test1()
        {
            Assert.That(TestCharacter1.HP,Is.EquelTo(100f));
        }
    }
}