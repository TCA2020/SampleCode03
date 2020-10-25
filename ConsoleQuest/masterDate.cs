using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
    class masterDate
    {
        public static int Exptable(int Lv)
        {
            const int cap = 30;
            int[] exptable = new int[cap];


                for (int i = 1; i < cap + 1; i++)
                {
                    if (i >= 1 && i <= 10)
                    {
                        exptable[i] = 4 * i + 1;
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
                return 0;
            }
        }
    }
}