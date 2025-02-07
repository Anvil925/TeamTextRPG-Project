using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public enum Jobs
    {
        INTERN,     //인턴
        DEVELOPE,   //개발
        PLANNING,   //기획
        ART         //아트
    }

    public class Character
    {
        public int LV { get; set; }
        public int EXP { get; set; }
        public int[] LVGuage { get; set; }

        const int MAXLV = 5;

        public string name { get; set; }
        public float ATK { get; set; }
        public float itemATK { get; set; }

        public float DEF { get; set; }
        public float itemDEF { get; set; }

        public float HP { get; set; }
        public float MAX_HP { get; set; }

        public float crit { get; set; }
        public float critDamage { get; set; }

        public float avoid { get; set; } // 회피

        public int gold { get; set; }

        public Jobs job { get; set; }
        public List<Item> inventory { get; set; }
        public List<Item> equipment { get; set; } //장착 중 아이템

        public Character(string name)
        {
            LV = 1;
            EXP = 0;
            LVGuage = [0, 10, 35, 65, 100]; //일단 5렙까지 경험치 필요량
            this.name = name;

            ATK = 10;
            DEF = 5;
            itemATK = 0;
            itemDEF = 0;

            HP = 100;
            MAX_HP = 100;

            crit = 0.15f;
            critDamage = 1.6f;

            avoid = 0.1f;

            gold = 1500;

            job = Jobs.INTERN;

            inventory = new List<Item>();
            equipment = new List<Item>();
        }

        public void ShowInfo()
        {
            Console.WriteLine("Lv : {0:D2}", LV);
            Console.WriteLine("EXP : {0} / {1}", EXP, LVGuage[LV]);
            Console.WriteLine("{0} ( {1} )", name, job);
            Console.WriteLine("정치력 : {0} {1}", ATK + itemATK, (itemATK > 0) ? $"(+{itemATK})" : "");
            Console.WriteLine("아부력 : {0} {1}", DEF + itemDEF, (itemDEF > 0) ? $"(+{itemDEF})" : "");
            Console.WriteLine("멘 탈 : {0} / {1}", HP, MAX_HP);
            Console.WriteLine("주 량 : {0}", crit);
            Console.WriteLine("GOLD : {0}", gold);
        }

        public void GetItem(Item item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if(equipment.Contains(item)) //장착 중이라면
                UnEquip(item);

            inventory.Remove(item);
        }

        public void EquipItem(Item item) //아이템 장착 or 해제 는 이 함수 부를 것
        {
            if (item.IsEquip)
            {
                UnEquip(item);
                return;
            } //이미 착용한 경우 장착 해제 후 바로 리턴
            
            item.IsEquip = true;

            foreach (Item i in equipment)
                if (i.ItemType == item.ItemType) //이미 장착한 아이템과 같은 경우
                    UnEquip(i);

            equipment.Add(item);
            itemATK += item.ATK;
            itemDEF += item.DEF;
        }

        private void UnEquip(Item item)
        {
            item.IsEquip = false;

            equipment.Remove(item);
            itemATK -= item.ATK;
            itemDEF -= item.DEF;
            
        }

        public void GetExp(int exp)
        {
            EXP += exp;
            if (LV < MAXLV && EXP > LVGuage[LV]) //최대 레벨이 아니고 경험치 넘었을 때
            {
                LVUp();
            }
        }

        private void LVUp()
        {
            EXP -= LVGuage[LV];
            LV++;

            ATK += 0.5f;
            DEF += 1.0f;
            HP = MAX_HP; //레벨업시 풀피
        }
        
    }
}
