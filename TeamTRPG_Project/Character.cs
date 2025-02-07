using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public enum Jobs
    {
        WARRIOR,
        WIZARD,
        THIEF
    }

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

        public Jobs job { get; set; }
        public List<Item> inventory { get; set; }

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

            job = Jobs.WARRIOR;

            inventory = new List<Item>();
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

        public void GetItem(Item item)
        {
            inventory.Add(item);
        }
        
        public void EquipItem(Item item)
        {
            item.IsEquip = !item.IsEquip;

            if(item.IsEquip)
            {
                itemATK += item.ATK;
                itemDEF += item.DEF;
            } 
            else
            {
                itemATK -= item.ATK;
                itemDEF -= item.DEF;
            }
        }
        */ //Gamemanager가 인벤토리 관리하면 제거

        void EquipItem(Item item)
        {
            item.IsEquip = true;
            itemATK += item.ATK;
            itemDEF += item.DEF;
        }

        void UnEquip(Item item)
        {
            item.IsEquip = false;
            itemATK -= item.ATK;
            itemDEF -= item.DEF;
        }


        


    }
}
