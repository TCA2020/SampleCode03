﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
    class masterDate
    {
        const int cap = 30;
        int[] exptable = new int[cap];
        
         void Getexptable()
        {
            for (int i = 1; i < cap + 1; i++)
            {
                exptable[i - 1] = 6 * i - 25;
            }
        }
    }
}