using NUnit.Framework;

namespace NunitTest
{
	public class Tests
	{
		ConsoleQuest.Player TestPlayer;

		[SetUp]
		public void Setup()
		{
            TestPlayer = new ConsoleQuest.Player("TestPlayer", 100f, 10f, 5f, 1, 0,
                new ConsoleQuest.Weapon("Œ•", 20f, 20));
		}

		[Test]
		public void Test1()
		{
			Assert.That(TestPlayer.HP, Is.EqualTo(100f));
		}
	}
}