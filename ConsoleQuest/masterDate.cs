using System;
using System.Collections.Generic;
using System.Text;

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
                return 0;
            }
        }
    }
}