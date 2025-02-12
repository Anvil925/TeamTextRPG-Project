using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public class Skill
    {
        public Jobs JobType { get; set; }           // 스킬의 직업 타입
        public string Name { get; set; }           // 이름
        public float ATK { get; set; }            // 공격력
        public int MP { get; set; }              // 마나 소모량
        public string Description { get; set; }    // 설명

        public int Range { get; set; }             // 범위 (스킬에 적중당할 몬스터의 수)
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
        // 프로젝트 몬스터 기획용 스킬
        public static List<Skill> MonsterPlanSkills = new List<Skill>()
        {
            new Skill(Jobs.PLANNING, "이거 왜 바뀌었어요?", 50, 50, "초기 기획과 실제 구현 사이에서 계속해서 기획이 변경되었다.", 1),
            new Skill(Jobs.PLANNING, "조금만 더 수정하면 완벽해질 것 같은데요?!", 70, 50, "\"한 번 더 논의 해보죠??\"라는 말과 함께 회의가 끝나지 않는다.", 1),
            new Skill(Jobs.PLANNING, "이거 구현이 안되는데요?", 90, 50, "여러 고민 끝에 기획을 완성했지만 퇴짜맞았다", 1  ),
            new Skill(Jobs.PLANNING, "이 캐릭터 너무 사기인데요?", 120, 50, "성난 유저들의 항의가 빗발친다.", 1  ),
            new Skill(Jobs.PLANNING, "이거 내일까지 가능하죠?", 300, 100, "마감이 다가오는데 무리한 수정들이 들어온다.", 1)
        };
        // 프로젝트 몬스터 개발용 스킬
        public static List<Skill> MonsterDevSkills = new List<Skill>()
        {
            new Skill(Jobs.DEVELOP, "이거 구현해주세요!!", 50, 50, "기획자가 무리한 요구를 한다. 개발 기간이 3배로 늘어났다.", 1  ),
            new Skill(Jobs.DEVELOP, "처음 기획과 다르게 된 것 같은데요?", 70, 50, "기획이 계속 수정되면서 개발 일정이 꼬인다.", 1  ),
            new Skill(Jobs.DEVELOP, "게임이 왜 자꾸 튕기죠??", 90, 50, "예상치 못한 버그 발생으로 출시 일정에 차질이 발생!", 1  ),
            new Skill(Jobs.DEVELOP, "새로운 기능 추가할 수 있나요?", 120, 50, "마감 직전에 새로운 기능을 추가해달라고 요청이 들어왔다!", 1  ),
            new Skill(Jobs.DEVELOP, "어???????????????", 300, 100, "다른 개발자가 버그를 발견했다.", 1)
        };
        // 프로젝트 몬스터 디자이너용 스킬
        public static List<Skill> MonsterArtSkills = new List<Skill>()
        {
            new Skill(Jobs.ART, "리소스 빠르게 만들어주세요!", 50, 50, "기획팀에서는 리소스 수정, 개발팀에서는 리소스가 필요하다고 한다!", 1),
            new Skill(Jobs.ART, "이런식으로 디자인 해주세요!", 70, 50, "기획서에 적힌 내용이 너무 추상적이거나 모호해서 디자인 방향이 불분명하다", 1),
            new Skill(Jobs.ART, "이거 왜 이렇게 촌스러워요?", 90, 50, "유저들이 캐릭터 디자인에 대한 혹평만 가득하다...!!", 1),
            new Skill(Jobs.ART, "약간만 수정 가능할까요?", 120, 50, "약간의 수정이 끝난 후, 새로운 수정들이 가득하다", 1),
            new Skill(Jobs.ART, "디자인 툴 강제 종료", 300, 100, "저장을 못해 작업했던 내용이 전부 날아간다.", 1)
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
        public void UseSkillMonster(Character player, List<Monster> monsters)
        {
            Console.WriteLine($"{player.name}에게 {Name} 사용! 데미지: {this.ATK}"); // 스킬 사용 메시지 출력
            Console.WriteLine($"{Description}"); // 스킬 설명 출력
            player.takeDamage((int)ATK); // 플레이어에게 데미지 적용
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
            if(SkillInfo == null)
                SkillInfo = new StringBuilder();
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
