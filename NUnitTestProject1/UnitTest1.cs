using NUnit.Framework;

namespace NUnitTestProject1
{
    public class Tests
    {
        ConsoleQuest.Character testCharacter;
        [SetUp]
        public void Setup()
        {
            testCharacter = new ConsoleQuest.Character
            ("testchara", 100, 10, 4); 
        }

        [Test]
        public void Test1()
        {
        Assert.That(testCharacter.HP, Is.EqualTo(100));            
        }
    }
}