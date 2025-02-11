using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    internal class Skill
    {
        public Jobs JobType { get; set; }           // 스킬의 직업 타입
        string Name { get; set; }           // 이름
        float ATK { get; set; }            // 공격력
        int MP { get; set; }              // 마나 소모량
        string Description { get; set; }    // 설명

        int Range { get; set; }             // 범위 (스킬에 적중당할 몬스터의 수)
        public int SkillPoint {  get; set; }       // 스킬을 획득하기 위한 스킬 포인트

        public bool IsLearn {  get; set; }         // 스킬을 배웠는지 확인

        StringBuilder SkillInfo { get; set; }      // 스킬 설명을 위한 StringBuilder

        // 기획 스킬
        public static List<Skill> PlanSkills = new List<Skill>()
        {
            new Skill(Jobs.PLANNING, "아이디어 폭발", 50, 50, "새로운 기획안이 마구 떠오른다!", 2  ),
            new Skill(Jobs.PLANNING, "트랜드 감지", 50, 50, "업계 동향을 빠르게 파악!", 2  ),
            new Skill(Jobs.PLANNING, "기획서 생성술", 50, 50, "PPT + 문서를 초고속으로 생성!", 2  ),
            new Skill(Jobs.PLANNING, "회의 장악", 30, 50, "내가 원하는 방향으로 회의를 이끈다!", 3  ),
            new Skill(Jobs.PLANNING, "완벽한 기획서", 100, 100, "상사와 클라이언트가 감탄하는 기획서를 완성!", 3 , 10)
        };
        // 개발 스킬
        public static List<Skill> DevSkills = new List<Skill>()
        {
            new Skill(Jobs.DEVELOP, "디버깅 주문", 50, 50, "버그를 즉시 감지하고 수정!", 2  ),
            new Skill(Jobs.DEVELOP, "긴급 패치", 50, 50, "시스템 장애를 빠르게 해결!", 2  ),
            new Skill(Jobs.DEVELOP, "블루스크린의 저주", 30, 50, "적에게 치명적인 오류를 발생!", 3  ),
            new Skill(Jobs.DEVELOP, "로그 추적의 눈", 70, 50, "적의 약점을 찾아 치명적인 데미지를 준다!", 1  ),
            new Skill(Jobs.DEVELOP, "무한 루프의 형벌", 100, 100, "적을 영원히 루프에 가둔다!", 3 , 10)
        };
        // 디자인 스킬
        public static List<Skill> ArtSkills = new List<Skill>()
        {
            new Skill(Jobs.ART, "디버깅 주문", 50, 50, "버그를 즉시 감지하고 수정!", 2  ),
            new Skill(Jobs.ART, "긴급 패치", 50, 50, "시스템 장애를 빠르게 해결!", 2  ),
            new Skill(Jobs.ART, "블루스크린의 저주", 30, 50, "적에게 치명적인 오류를 발생!", 3  ),
            new Skill(Jobs.ART, "로그 추적의 눈", 70, 50, "적의 약점을 찾아 치명적인 데미지를 준다!", 1  ),
            new Skill(Jobs.ART, "무한 루프의 형벌", 100, 100, "적을 영원히 루프에 가둔다!", 3 , 10)
        };

        public Skill(Jobs job, string name, float atk, int mp, string description, int range = 1, int skillPoint = 5)
        {
            JobType = job;
            Name = name;
            ATK = atk;
            MP = mp;
            Description = description;
            Range = range;

            IsLearn = false;
            SkillPoint = skillPoint;
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

        public string ShowInfo(bool isSkillWindow = false)
        {
            SkillInfo.Clear();

            SkillInfo.Append($"{Name}\t| ");

            SkillInfo.Append($"데미지 : {ATK}\t| 마나 : {MP} MP\t| ");

            SkillInfo.Append($"{Description}\t| 획득 포인트 : {SkillPoint}P");

            if (isSkillWindow && IsLearn)
                SkillInfo.Append("\t| 획득 완료");

            return SkillInfo.ToString();
        }

    }
}
