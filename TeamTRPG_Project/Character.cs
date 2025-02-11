using System;
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
        public int[] LVGuage { get; set; }

        const int MAXLV = 5;

        public string name { get; set; }
        public float ATK { get; set; }
        public float itemATK { get; set; }

        public float DEF { get; set; }
        public float itemDEF { get; set; }

        public float HP { get; set; }
        public float MAX_HP { get; set; }

        public int MP { get; set; }
        public int MAX_MP { get; set; }

        public float crit { get; set; }
        public float critDamage { get; set; }

        public float avoid { get; set; } // 회피

        public int gold { get; set; }

        public Job job { get; set; }
        public List<Item> inventory { get; set; }
        public List<Item> equipment { get; set; } //장착 중 아이템

        public List<Skill> skills {get; set;}
        int skillPoints;

        Random rd = new Random();

        public Character(string name)
        {
            LV = 1;
            EXP = 0;
            LVGuage = new int[MAXLV] { 0, 10, 35, 65, 100 }; //일단 5렙까지 경험치 필요량
            this.name = name;

            ATK = 10;
            DEF = 5;
            itemATK = 0;
            itemDEF = 0;

            HP = 100;
            MAX_HP = 100;

            MP = 100; 
            MAX_MP = 100;

            crit = 0.15f;
            critDamage = 1.6f;

            avoid = 0.1f;

            gold = 1500000;

            job = Job.JobList[3]; //list 3 is Intern

            inventory = new List<Item>();
            equipment = new List<Item>();
            skills = new List<Skill>();

            skillPoints = 0;
        }

        public void ShowInfo()
        {
            Console.WriteLine("경력 : {0:D2}년차", LV);
            Console.WriteLine("EXP : {0} / {1}", EXP, (LV < MAXLV) ? LVGuage[LV] : "MAX");
            Console.WriteLine("{0} ( {1} )", name, job.Name);
            Console.WriteLine("정치력 : {0} {1}", ATK + itemATK, (itemATK > 0) ? $"(+{itemATK})" : "");
            Console.WriteLine("아부력 : {0} {1}", DEF + itemDEF, (itemDEF > 0) ? $"(+{itemDEF})" : "");
            Console.WriteLine("멘 탈 : {0} / {1}", HP, MAX_HP);
            Console.WriteLine("마 나 : {0} / {1}", MP, MAX_MP);
            Console.WriteLine("주 량 : {0}", crit);
            Console.WriteLine("GOLD : {0}", gold);

            Console.WriteLine();
            Console.WriteLine("장착 아이템");
            foreach (Item item in equipment)
                Console.WriteLine(item.ShowInfo());
            /*
            Console.WriteLine();
            Console.WriteLine("배운 스킬");
            foreach (Skill skill in skills)
                Console.WriteLine(skill.ShowInfo());
            */

        }

        public override string ToString()
        {
            return $"경력.{LV} {name} ({job.Name})\n멘탈 {HP}/{MAX_HP}";
        }

        public void ShowInventory()
        {

            foreach (Item item in inventory)
                if (item == null)
                {
                    Console.WriteLine("❌ 인벤토리에 null 아이템이 들어있음!");
                }
                else
                {
                    Console.WriteLine($"📦 현재 인벤토리 아이템 개수: {inventory.Count}");

                    Console.WriteLine(item.ShowInfo());
                }
        }

        public void Inventory(Item item)
        {
            inventory.Add(item);
        }

        public void RemoveItem(Item item)
        {
            if (equipment.Contains(item)) //장착 중이라면
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

            foreach (Item i in equipment)
            {
                if (i.ItemType == item.ItemType) //이미 장착한 아이템과 같은 경우
                {
                    UnEquip(i);
                    break;
                }
            }

            item.IsEquip = true;
            equipment.Add(item);

            if (item is Weapon weapon)
                itemATK += weapon.ATK;
            else if (item is Armor armor)
                itemDEF += armor.DEF;
        }

        public void UnEquip(Item item)
        {

            item.IsEquip = false;

            equipment.Remove(item);
            if (item is Weapon weapon)
                itemATK -= weapon.ATK;
            else if (item is Armor armor)
                itemDEF -= armor.DEF;

        }

        public void GetExp(int exp)
        {
            int prevEXP = EXP;
            EXP += exp;
            if (LV < MAXLV && EXP > LVGuage[LV]) //최대 레벨이 아니고 경험치 넘었을 때
            {
                LVUp();
            }
            Console.WriteLine("EXP {0} -> {1}", prevEXP, EXP);
        }

        private void LVUp()
        {
            //경험치 초기화를 할 경우 아래 코드 주석 제거
            //EXP -= LVGuage[LV];
            LV++;

            ATK += 0.5f;
            DEF += 1.0f;
            HP = MAX_HP; //레벨업시 풀피

            
            MP = MAX_MP;
            Console.WriteLine("경력이 {0}으로 올랐습니다.", LV);
            skillPoints += 10;  //레벨업시 스킬포인트
        }

        public float takeDamage(float damage)   //공격 받을 때
        {
            float prev_HP = HP;
            if (rd.NextDouble() > avoid) //회피 실패
            {
                HP -= damage;
                if (HP < 0f)
                {
                    HP = 0f;
                }
                Console.WriteLine("멘탈 {0:F0} -> {1:F0}", prev_HP, HP);
            }
            else
            {
                Console.WriteLine("회피 성공!");
            }

            /*
             * 방어력 공식이 있으면 추가 될 수 있음
             */

            return HP;
        }

        public float CalculateDamage() //가하는 데미지 계산 //일반 공격
        {
            float damageError = float.Ceiling((ATK + itemATK) * 0.1f); // 데미지 오차
            float damage = float.Ceiling(ATK + itemATK);

            if (rd.NextDouble() < crit) //크리티컬
                damage = float.Ceiling(damage * critDamage);

            damage = rd.Next((int)(damage - damageError), (int)(damage + damageError + 1));

            RegenerateMana(10); //일반 공격 시 마나 10 회복

            return damage;
        }

        public float UsePotion(Potion potion)
        {
            float prevHP = HP;
            HP += potion.REC;
            if (HP > MAX_HP)
                HP = MAX_HP;
            Console.WriteLine("멘탈 회복 {0:F0} -> {1:F0}", prevHP, HP);
            inventory.Remove(potion);
            return HP;
        }


        public void RegenerateMana(int mana) 
        {
            float prevMP = MP;
            MP += mana;
            if (MP > MAX_MP)
                MP = MAX_MP;
            Console.WriteLine("마나 재생 {0:F0} -> {1:F0}", prevMP, MP); //어색하면 제거
        }          
        

        public void SetJob(Job job) //직업은 기초 공방체 up
        {
            this.job = job;
            ATK += job.ATK;
            DEF += job.DEF;
            MAX_HP += job.MAX_HP;
            HP += job.MAX_HP;
        }

        
        public bool AddSkill(Skill skill)
        {
            if (skill.JobType != job.JobType)
            {
                Console.WriteLine("배울 수 없는 직업의 스킬입니다!");
                return false;
            }

            if(skill.IsLearn)
            {
                Console.WriteLine("이미 배운 스킬입니다!");
                return false;
            }
            
            if(skill.SkillPoint > skillPoints)
            {
                Console.WriteLine("스킬 포인트가 부족합니다!");
                return false;
            }

            Console.WriteLine("스킬을 획득하였습니다.");
            skillPoints -= skill.SkillPoint;
            skills.Add(skill);
            return true;
        }
        
        public void ShowSkills() 
        {
            for (int i = 0; i < skills.Count; i++)
            {
                //Console.WriteLine($"{i} - {skills[i].ShowInfo()}"); //skill클래스에서 string으로 반환하는 함수 필요
            }
        }

        /*
        public Skill UseSkill(int index) //입력시 -1 주의 
        {
            Skill skill = skills[index];
            
            if(skill.MP > MP)
            {
                Console.WriteLine("스킬을 사용하는 데 마나가 부족합니다!");
                return null; //null 반환시 스킬 사용 불가능!
            }

            MP -= skill.MP;
            Console.WriteLine($"스킬 {skill.Name}사용!");
            //Skill 관련 메소드
            return skill;
        }
        */ //skill 클래스에서 구현이 되었음
    }
}
