using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class Player : Character
	{
		
		

		public Weapon EquipWeapon
		{ get; set; }
		

		public Player(string name, float maxHP, float attackPoint, float defencePoint, Weapon weapon)
			: base(name, maxHP, attackPoint, defencePoint)
		{
			
			EquipWeapon = weapon;
			AttackPoint  = attackPoint + 20f;//weapon.WATK

		}




		public int Choice()
		{
			Console.WriteLine("何をするのか?");
			int choice = 0;
			bool CpSuccess = false;
			while (!CpSuccess)
			{
				Console.WriteLine(
					"Actions" + "\n" +
					"[ 1 ] 武器アップグレード" + "\n" +
					"[ 2 ] 休憩(HPの20％を回復する)" + "\n" +
					"  :  "
					);
				bool ChoiceTest = int.TryParse(Console.ReadLine(), out choice);
				if (!ChoiceTest || choice > 2 || choice <= 0)
				{
					Console.WriteLine(" 無効な記入" + "\n");
					continue;
				}
				if (choice >= 1 && choice <= 2)
					break;

			}

			return choice;
		}




		public void PlayerChoice(int dec)
		{
			if (dec == 1)
			{
				UpgradeWeapon();
			}
			if (dec == 2)
			{
				Have_Rest();
			}
		}

		public void Have_Rest()
		{
			Console.WriteLine("ZZZZZ..." + "\n" +
				(MaxHP / 4) + "HP回復した。" + "\n");
			HP += (MaxHP / 4);
			if (HP > MaxHP) HP = MaxHP;
		}
		public void UpgradeWeapon()
		{
			Console.WriteLine(
				"武器を強化した!" + "\n" +
				"ATK + 4"
				);
			AttackPoint += 4;
		}

	}

}
