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
}