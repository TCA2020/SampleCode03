using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public class json
	{
		public static void savejson(Player player, string savepath)
		{
			SaveData savedata = new SaveData();
			savedata.Player = new PlayerSaveData();
			savedata.Player.HP = player.HP;
			savedata.Player.maxHP = player.MaxHP;
			savedata.Player.name = player.Name;
			savedata.Player.attackPoint = player.AttackPoint;
			savedata.Player.defencePoint = player.DefencePoint;
			savedata.Player.Level = player.Level;
			savedata.Player.Exp = player.Exp;





			string jsonfile = Newtonsoft.Json.JsonConvert.SerializeObject(savedata);
			System.IO.File.WriteAllText(savepath, jsonfile);

		}

		public static Player LoadPlayer(string jsonfile)
		{
			try
			{
				string jsonData = System.IO.File.ReadAllText(jsonfile);
				SaveData saveData = Newtonsoft.Json.
					JsonConvert.DeserializeObject<SaveData>(jsonData);
				Player player = new Player(saveData.Player);
				return player;
			}
			catch
			{
				return null;
			}
		}
	}

		


		public class PlayerSaveData
		{
			public string name;
			public float maxHP;
			public float HP;
			public float attackPoint;
			public float defencePoint;
			public int Level;
			public int Exp;




		}
		public class SaveData
		{
			public PlayerSaveData Player;


		}

	}

