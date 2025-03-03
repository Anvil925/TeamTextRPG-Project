using System;
using TeamTRPG_Project;
public class Monster
{
    public string Name { get; private set; } // 몬스터 이름
    public float HP { get; private set; } // 체력
    public float MaxHP { get; private set; } // 최대 체력
    public float ATK { get; private set; } // 공격력
    public float DEF { get; private set; } // 방어력
    public int LV { get; private set; } // 레벨
    public int EXP { get; private set; } //  몬스터 경험치 추가
    public int Gold { get; private set; } // 몬스터 골드 추가
    public int GroupID { get; private set; } // 그룹 ID
    public List<Skill> Skills { get; private set; } // 몬스터 스킬 리스트 추가

    public Monster(string name, float maxHp, float hp, float atk, float def, int lv, int exp, int gold, int groupID, List<Skill> skills = null) // 생성자
    {
        Name = name; // 이름 설정
        MaxHP = maxHp; // 최대 체력 설정
        HP = hp; // 체력 설정
        ATK = atk; // 공격력 설정
        DEF = def; // 방어력 설정
        LV = lv; // 레벨 설정
        EXP = exp; // 경험치 설정
        Gold = gold; // 골드 설정
        GroupID = groupID; // 그룹 ID 설정
        Skills = skills ?? new List<Skill>(); // 기본적으로 빈 스킬 리스트 설정
    }
    public override string ToString() // 문자열 반환 메서드 재정의
    {
        string info;
        if (GroupID <= 5)
            info = $"[경력 : {LV}년차 {Name} - 멘탈: {MaxHP}/{HP}, 정치력: {ATK}, 아부력: {DEF}]";
        else if (GroupID == 6)
            info = $"[{LV}년 경력의 {Name} 맛집 - 멘탈: {MaxHP}/{HP}, 정치력: {ATK}, 아부력: {DEF}]";
        else if (GroupID == 7)
            info = $"[{Name} - 멘탈: {MaxHP}/{HP}, 정치력: {ATK}, 아부력: {DEF}]";
        else
            info = $"[{GroupID} - {Name} - 멘탈: {MaxHP}/{HP}, 정치력: {ATK}, 아부력: {DEF}]";
        return info;
    }
    public bool IsDead()
    {
        return HP <= 0;
    }
    public void TakeDamage(int damage)
    {
        int actualDamage = Math.Max(damage - (int)DEF, 1);
        HP -= actualDamage;
        HP = Math.Max(HP, 0); // HP가 0 이하로 떨어지지 않도록
        Console.WriteLine($"{Name}(이)가 {actualDamage} 의 피해를 입었습니다!( 남은 체력{HP})");
    }
    public void AttackPlayer(Character player) // 플레이어를 공격하는 메서드
    {
        Random rand = new Random();
        if (Skills.Count > 0 && rand.Next(100) < 100) // 30% 확률로 스킬 사용
        {   
            UseRandomSkill(player);
            Thread.Sleep(2000);
        }
        else
        {
            Console.WriteLine($"{Name}이(가) 기본 공격을 시전했다!");
            player.takeDamage(ATK);
        }
    }
    public void UseRandomSkill(Character player)
    {
        Random rand = new Random(); // 랜덤 객체 생성
        int index = rand.Next(Skills.Count); // 스킬 리스트 중 랜덤으로 선택
        Skill selectedSkill = Skills[index]; // 선택된 스킬
        selectedSkill.UseSkillMonster(player, new List<Monster> { this }); // 스킬 사용
    }

    public static List<Monster> MonsterList = new List<Monster> //몬스터 리스트
    {
        // 일반 던전 (노가다) - 체력 낮고 경험치 적음
        new Monster("햄버거", 90 ,90, 5, 5, 1, 5, 100, 1),
        new Monster("피자", 90 ,90, 5, 5, 1, 5, 100, 1),
        new Monster("초밥", 90 ,90, 5, 5, 1, 5, 100, 1),
        new Monster("라멘", 90 ,90, 5, 5, 1, 5, 100, 1),
        new Monster("카레", 90 ,90, 5, 5, 1, 5, 100, 1),
        new Monster("스테이크", 90 ,90, 5, 5, 1, 5, 100, 1),
        new Monster("샤브샤브", 90 ,90, 5, 5, 1, 5, 100, 1),
        new Monster("김치찌개", 90 ,90, 5, 5, 1, 5, 100, 1),
        new Monster("스파게티", 90 ,90, 5, 5, 1, 5, 100, 1),
        new Monster("비빔밥", 90 ,90, 5, 5, 1, 5, 100, 1),
        new Monster("도시락", 90 ,90, 5, 5, 1, 5, 100, 1),
        // 파일 미궁 던전 (중급 난이도)
        new Monster("프로젝트 보고서_1126", 200, 200, 15, 10, 4, 12, 200, 2),
        new Monster("보고서_1126_수정", 200, 200, 15, 10, 4, 12, 200, 2),
        new Monster("보고서_1126_최종", 200, 200, 15, 10, 4, 12, 200, 2),
        new Monster("보고서_1126_최종_보고용", 200, 200, 15, 10, 4, 12, 200, 2),
        new Monster("보고서_1126_최종_진짜진짜최종", 200, 200, 15, 10, 4, 12, 200, 2),
        // 서버실 던전 (상급 난이도)
        new Monster("디스크 가득참 경고", 500, 500, 50, 20, 8, 52, 400, 3),
        new Monster("전력 서지", 500, 500, 50, 20, 8, 52, 400, 3),
        new Monster("치명적 버그", 500, 500, 50, 20, 8, 52, 400, 3),
        new Monster("서버 팬 과부하", 500, 500, 50, 20, 8, 52, 400, 3),
        new Monster("다운타임 악몽", 500, 500, 50, 20, 8, 52, 400, 3),
        new Monster("클라우드 장애", 500, 500, 50, 20, 8, 52, 400, 3),
        // 승진 시험 (난이도 점진적 증가)
        // 그룹 1 (흡연실) - 약함
        new Monster("승진을 원하는 동료", 150, 150, 12, 8, 3, 9, 150, 4),
        new Monster("나를 견제하는 동료", 150, 150, 12, 8, 3, 9, 150, 4),
        new Monster("회의 중 졸고 있는 동료", 150, 150, 8, 12, 3, 9, 150, 4),
        new Monster("야근하는 동료", 150, 150, 12, 8, 3, 9, 150, 4),
        // 그룹 2 (탕비실) - 중급
        new Monster("무능한 간부", 250, 250, 18, 13, 5, 20, 220, 5),
        new Monster("게으른 간부", 250, 250, 18, 13, 5, 20, 220, 5),
        new Monster("지시만 하는 간부", 250, 250, 18, 13, 5, 20, 220, 5),
        new Monster("불평만 하는 간부", 250, 250, 18, 13, 5, 20, 220, 5),
        // 그룹 3 (팀장) - 더 어려워짐
        new Monster("고집불통 팀장", 350, 350, 30, 16, 6, 35, 300, 6),
        new Monster("독단적인 팀장", 350, 350, 30, 16, 6, 35, 300, 6),
        new Monster("권위적인 팀장", 350, 350, 30, 16, 6, 35, 300, 6),
        new Monster("소통 안 되는 팀장", 350, 350, 30, 16, 6, 35, 300, 6),
        // 그룹 4 (차장) - 매우 어려움
        new Monster("꼰대차장", 530, 530, 55, 22, 8, 50, 500, 7),
        new Monster("꼰대차장2", 530, 530, 55, 22, 8, 50, 500, 7),
        new Monster("꼰대차장3", 530, 530, 55, 22, 8, 50, 500, 7),
        new Monster("꼰대차장4", 530, 530, 55, 22, 8, 50, 500, 7),
        // 그룹 5 (사장) - 최종 보스급
        new Monster("독불장군 사장", 1000, 1000, 100, 40, 10, 100, 1000, 8),
        new Monster("성과제일주의 사장", 1000, 1000, 100, 40, 10, 100, 1000, 8),
        new Monster("비용절감 사장", 1000, 1000, 100, 40, 10, 100, 1000, 8),
        new Monster("권모술수 사장", 1000, 1000, 100, 40, 10, 100, 1000, 8),
        new Monster("냉혈한 사장", 1000, 1000, 100, 40, 10, 100, 1000, 8),
        new Monster("기업사냥꾼 사장", 1000, 1000, 100, 40, 10, 100, 1000, 8),
        // 직업 던전 보스 (매우 강한 보스)
        new Monster("TEXT RPG PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("UNITY 2D PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("UNITY 3D PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("Action RPG PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("MOBA PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("BATTLE LOYAL PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("REYTHM GAME PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("HYPER FPS PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("STRATEGY PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("SPORTS GAME PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("FIGHTING GAME PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("FIGHTING GAME PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("MMO RPG PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("VIRTUAL RIALLITY PROJECT", 2000, 2000, 120, 50, 15, 200, 1600, 9),
        new Monster("????? ????? PROJECT", 9999, 9999, 300, 200, 30, 400, 8000, 100),
    }; //이름 , 최대 체력 , 현재 체력 , 공격력 , 방어력 , 레벨 , 경험치 , 그룹ID
    public void InitializeStats() // 몬스터 상태 초기화
    {
        HP = MaxHP; // 체력 초기화
    }
 // 그룹 9번의 몬스터에 스킬 추가
    public static Monster GetRandomMonsterByGroup(int groupID, Character player)
    {
        Random rand = new Random();
        List<Monster> filteredList = MonsterList.FindAll(m => m.GroupID == groupID);

        if (filteredList.Count == 0)
        {
            Console.WriteLine("몬스터 없음");
            return null;
        }
    if (groupID == 9) // 그룹 9번의 몬스터에게 플레이어 직업에 맞는 스킬을 부여
    {
        Monster rareMonster = filteredList.FirstOrDefault(m => m.Name == "????? ????? PROJECT");
        if (rareMonster != null)
        {
            int chance = rand.Next(100); 
            if (chance < 1) // 1% 확률로 특정 몬스터 생성
            {
                string playerJob = player.job.Name; // 플레이어 직업 가져오기
                if (playerJob == "기획") 
                {
                    rareMonster.Skills.AddRange(Skill.MonsterPlanSkills); // 기획자 스킬 추가
                }
                else if (playerJob == "개발") 
                {
                    rareMonster.Skills.AddRange(Skill.MonsterDevSkills);  // 개발자 스킬 추가
                }
                else if (playerJob == "아트") 
                {
                    rareMonster.Skills.AddRange(Skill.MonsterArtSkills);  // 디자이너 스킬 추가
                }
                else 
                {
                    rareMonster.Skills.AddRange(Skill.MonsterPlanSkills);
                    rareMonster.Skills.AddRange(Skill.MonsterDevSkills);
                    rareMonster.Skills.AddRange(Skill.MonsterArtSkills);
                }
                rareMonster.InitializeStats(); // 몬스터 상태 초기화
                return rareMonster; // 확률에 맞춰 특정 몬스터 반환
            }
        }
    }
        int index = rand.Next(filteredList.Count);
        Monster selectedMonster = filteredList[index];
    if (selectedMonster.GroupID == 9)
    {
        string playerJob = player.job.Name; // 플레이어 직업 가져오기
        if (playerJob == "기획") 
        {
            selectedMonster.Skills.AddRange(Skill.MonsterPlanSkills); // 기획자 스킬 추가
        }
        else if (playerJob == "개발") 
        {
            selectedMonster.Skills.AddRange(Skill.MonsterDevSkills);  // 개발자 스킬 추가
        }
        else if (playerJob == "아트") 
        {
            selectedMonster.Skills.AddRange(Skill.MonsterArtSkills);  // 디자이너 스킬 추가
        }
        else 
        {
            selectedMonster.Skills.AddRange(Skill.MonsterPlanSkills);
            selectedMonster.Skills.AddRange(Skill.MonsterDevSkills);
            selectedMonster.Skills.AddRange(Skill.MonsterArtSkills);
        }
    }
        selectedMonster.InitializeStats();
        return selectedMonster;
    }
}
