using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace ConsoleQuest
{
	public class Character
	{
		public string Name
		{ get; private set; }

		public float MaxHP
		{ get; private set; }

		public float HP
		{ get; private set; }

		public bool IsAlive
		{ get { return HP > 0; } }

		public float AttackPoint
		{ get; private set; }

		public float DefencePoint
		{ get; private set; }


		public Character(string name, float maxHP, float attackPoint, float defencePoint)
		{
			Name = name;
			MaxHP = maxHP;
			HP = maxHP;
			AttackPoint = attackPoint;
			DefencePoint = defencePoint;
		
		}


		public float Attack(Character target)
		{
			float damage = DamageCalculator.CalculateDamage(this, target);
			target.HP -= damage;

			return damage;
		}
		private static readonly string SavedataPath =
				System.IO.Directory.GetCurrentDirectory() + "\\save.json";

		private static void SavePlayerData(Player player)
		{
			SaveData data = new SaveData();
			data.Player = new PlayerSaveData();
			data.Player.HP = player.HP;
			data.Player.MaxHP = player.MaxHP;
			data.Player.Name = player.Name;
			data.Player.AttackPoint = player.AttackPoint;
			data.Player.DefencePoint = player.DefencePoint;
			data.Player.Level = player.Level;
			data.Player.Exp = player.Exp;

			string dataJson = Newtonsoft.Json.JsonConvert.SerializeObject(data);
			System.IO.File.WriteAllText(SavedataPath, dataJson);
		}

		private static Player LoadPlayerData()
		{
			try
			{
				string dataJson = System.IO.File.ReadAllText(SavedataPath);
				SaveData saveData =
					Newtonsoft.Json.JsonConvert.DeserializeObject<SaveData>(dataJson);

				Player player = new Player(saveData.Player) ;
				return player;
			}
			catch
			{
				return null;
			}
		}

	}
}
