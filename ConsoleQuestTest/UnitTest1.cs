using NUnit.Framework;

namespace ConsoleQuestTest
{
	public class Tests
	{
		ConsoleQuest.Character TestCharacter1;
		ConsoleQuest.Character TestCharacter2;

		[SetUp]
		public void Setup()
		{
			TestCharacter1 = new ConsoleQuest.Character("aaa", 100f, 30f, 10f);
			TestCharacter2 = new ConsoleQuest.Character("bb", 100f, 10f, 10f);
		}

		[Test]
		public void Test1()
		{
			//HP‚É–{“–‚É100‚ª“ü‚Á‚Ä‚¢‚é‚©H
			Assert.That(TestCharacter1.HP, Is.EqualTo(100f));
		}

		[Test]
		public void DamageTest()
		{
			for (int i = 0; i < 10000; i++)
			{
				float damage = ConsoleQuest.DamageCalculator.CalculateDamage(TestCharacter1, TestCharacter2);
				Assert.That(damage, Is.InRange(9f, 16f));
			}

		}
	}
}
