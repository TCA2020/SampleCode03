using System;


namespace ConsoleQuest
{

    class program
    {

        static void Main(string[] args)
        {

            string currentDirectory=System.IO.Directory.GetCurrentDirectory();

            string jsonPath=currentDirectory+"\\player.json";

            if (!System.IO.File.Exists(jsonPath))
            {
                Console.WriteLine("Jsonファイルがないので、ダミーデータを基にJsonを生成して書き込みます…");
                Console.WriteLine("出力先:"+jsonPath);

                Player dummy=MakeDefaultData();
                SavePlayerJson(dummy,jsonPath);
            }

            /*保存されているjsonデータをロードする*/
            Player loadedPlayer;
            if(!LoadPlayerJson(jsonPath,out loadedPlayer))
            {
                /*ロードに失敗した*/
                return;
            }

            Logger.Inject(new ConsoleLogger(), new ConsoleInput());

            Logger.Log("Start Game!");

            Logger.Log("プレイヤーの名前を入力してください:");

            string PlayerName = Logger.ReadInput();

            Console.WriteLine("プレイヤー(あなた)の最初のHPは" + loadedPlayer.MaxHP + "です。");

            /*create player*/
            Player player=new Player(PlayerName, 100f, 10f, 5f, 1, 0);

            /*create world*/
            World world = new World(player);

            /*worldが終了判定(false)を返すまでループ*/
            while(world.Loop())
            {
                /*Enter入力を待つ*/
                Logger.ReadInput();
            }
        
            

            /*THE END*/
            Logger.Log("Game Over.");
        

        
    }

        private static void SavePlayerJson(Player data, string filePath)
        {
            string jsonText = Newtonsoft.Json.JsonConvert.SerializeObject(data);
            System.IO.File.WriteAllText(filePath, jsonText);
        }

        private static bool LoadPlayerJson(string filePath,out Player loadedInstance)
        {

            try
            {
                string jsonText=System.IO.File.ReadAllText(filePath);
                loadedInstance=Newtonsoft.Json.JsonConvert.DeserializeObject<Player>(jsonText);
                return true;
            }
            catch(Exception e)
            {
                Console.WriteLine("ロード失敗:"+e.Message);
                loadedInstance=null;
                return false;
            }

        }

        private static Player MakeDefaultData()
        {
            Player player=new Player("PlayerName", 100f, 10f, 5f, 1, 0);

            return player;
        }
    }
}