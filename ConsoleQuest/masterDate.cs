using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Markup;

namespace ConsoleQuest
{
    class masterDate
    {
        public static int Exptable(int Lv)
        {
            const int cap = 31;
            int[] exptable = new int[cap];


                for (int i = 1; i < cap + 1; i++)
                {
                exptable[1] = 0;
                    if (i >= 1 && i <= 10)
                    {
                        exptable[i] = exptable[i - 1] + 8;
                }
                    else
                    {
                        exptable[i - 1] = 6 * i - 18;
                    }
                }
            if (Lv <= cap || Lv >= 0)
            {
                return exptable[Lv];
            }
            else
            {
                return exptable[30];
            }
        }

        static void ReadCsv()
        {
            string line;
            string[] values;
            try
            {
                // csvファイルを開く
                using (var sr = new System.IO.StreamReader(@"test.csv"))
                {
                    // ストリームの末尾まで繰り返す
                    while (!sr.EndOfStream)
                    {
                        // ファイルから一行読み込む
                        line = sr.ReadLine();
                        // 読み込んだ一行をカンマ毎に分けて配列に格納する
                        values = line.Split(',');
                        int x = 0;
                        while (x >= values.Length)
                        {
                            
                            x++;
                        }
                    }
                }

            }
            catch (System.Exception e)
            {
                // ファイルを開くのに失敗したとき
                System.Console.WriteLine(e.Message);
            }
        }
    }
}