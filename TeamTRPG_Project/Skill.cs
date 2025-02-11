using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    internal class Skill
    {
        Jobs JobType { get; set; }           // 스킬의 직업 타입
        string Name { get; set; }           // 이름
        float ATK { get; set; }            // 공격력
        int MP { get; set; }              // 마나 소모량
        string Description { get; set; }    // 설명

        int Range { get; set; }             // 범위 (스킬에 적중당할 몬스터의 수)

        public Skill(Jobs job, string name, float atk, int mp, string description, int range = 1)
        {
            JobType = job;
            Name = name;
            ATK = atk;
            MP = mp;
            Description = description;
            Range = range;
        }

        // 스킬을 사용할 때 불러올 함수
        public void Use(Character player, List<Monster> monsters)
        {

            if (CheckMP(player))
                return;

            Attack(monsters);
        }

        // MP가 충분한지 체크
        private bool CheckMP(Character player)
        {
            if (player.MP < MP)
            {
                Console.WriteLine("스킬을 사용하기 위한 마나가 부족합니다!!");
                return true;
            }

            int originMP = player.MP;
            player.MP -= MP;

            Console.WriteLine($"{Name} 스킬을 사용했습니다!!");
            Console.WriteLine($"MP {originMP} -> {player.MP}");

            return false;
        }

        public void Attack(List<Monster> monsters)
        {

            // 몬스터의 리스트를 받아와 랜덤으로 섞어준다.
            int count = monsters.Count;
            monsters = monsters.OrderBy(x => new Random().Next(0, count)).ToList();

            // 스킬의 범위가 몬스터 리스트보다 클 수 있으므로 범위를 제한한다.
            int range = Math.Clamp(Range, 1, count);

            // 섞어준 리스트에서 스킬의 범위 만큼 데미지를 적용한다.
            for (int i = 0; i < range; i++)
            {
                monsters[i].TakeDamage((int)ATK);
            }
        }

    }
}
