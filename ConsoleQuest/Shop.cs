﻿using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleQuest
{
    public class Shop
    {
        public float shopping()
        {
            Logger.Log(" welcome to the shop ! ! ");
            Logger.Log("1. buy Potion  2. Leave ");

            int shoppinglist = Convert.ToInt32(Logger.ReadInput());

            if(shoppinglist == 1)
            {
                Logger.Log(" Not Availabe yet ! ! ");

 
            }

            if(shoppinglist == 2)
            {
                Logger.Log(" GoodBye !");
            }
        }
    }
}