﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public class Character
    {
        public int LV { get; set; }
        public int EXP { get; set; }
        public string name { get; set; }
        public float ATK { get; set; }
        public float itemATK { get; set; }

        public float DEF { get; set; }
        public float itemDEF { get; set; }

        public float HP { get; set; }
        public float MAX_HP { get; set; }
        public int gold { get; set; }

        public string job { get; set; } //string or enum //maybe change
        public List<Item> items { get; set; }

        public Character(string name)
        {
            LV = 1;
            EXP = 0;
            this.name = name;

            ATK = 10;
            DEF = 5;
            itemATK = 0;
            itemDEF = 0;

            HP = 100;
            MAX_HP = 100;

            gold = 1500;

            job = "전사";
        }

        public void ShowInfo()
        {
            Console.WriteLine("Lv : {0:D2}", LV);
            Console.WriteLine("{0} ( {1} )", name, job);
            Console.WriteLine("공격력 : {0} {1}", ATK + itemATK, (itemATK > 0) ? $"(+{itemATK})" : "");
            Console.WriteLine("방어력 : {0} {1}", DEF + itemDEF, (itemDEF > 0) ? $"(+{itemDEF})" : "");
            Console.WriteLine("체 력 : {0} / {1}", HP, MAX_HP);
            Console.WriteLine("GOLD : {0}", gold);
        }

    }
}
