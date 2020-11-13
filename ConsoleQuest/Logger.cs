using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
	public static class Logger
	{

		private static readonly string LogDataPath =
		System.IO.Directory.GetCurrentDirectory() + "\\logdata.json";

		private static ILogger LoggerInstance;
		private static IInput InputInstance;

		public static void Inject(ILogger logger, IInput input)
		{
			LoggerInstance = logger;
			InputInstance = input;
		}

		public static void Log(string log)
		{
			LoggerInstance?.Log(log);
			LogData loaddata = new LogData();
			loaddata.Ldata = log;
			string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(loaddata.Ldata);
			System.IO.File.AppendAllText(LogDataPath, jsonData);

		}

		public static void Log(object log)
		{

			Log(log.ToString());

		}


		public static string ReadInput()
		{
			return InputInstance.ReadLine();
		}
	}


	public interface ILogger
	{
		void Log(string log);

	}

	public interface IInput
	{
		string ReadLine();
	}


	public class ConsoleLogger : ILogger
	{



		public void Log(string log)
		{
			Console.WriteLine(log);

			//string Ldata = new LogData();
			//Ldata = log.Ldata;
		}
	}

	public class ConsoleInput : IInput
	{
		public string ReadLine()
		{
			return Console.ReadLine();
		}
	}
}
