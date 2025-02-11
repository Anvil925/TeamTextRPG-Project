using System;
using TeamTRPG_Project;
public class Monster
{
    public string Name { get; private set; } // 몬스터 이름
    public float HP { get; private set; } // 체력
    public float ATK { get; private set; } // 공격력
    public float DEF { get; private set; } // 방어력
    public int LV { get; private set; } // 레벨
    public int EXP { get; private set; } //  몬스터 경험치 추가
    public int GroupID { get; private set; } // 그룹 ID

    public Monster(string name, float hp, float atk, float def, int lv, int exp, int groupID) // 생성자
    {
        Name = name; // 이름 설정
        HP = hp; // 체력 설정
        ATK = atk; // 공격력 설정
        DEF = def; // 방어력 설정
        LV = lv; // 레벨 설정
        EXP = exp; // 경험치 설정
        GroupID = groupID; // 그룹 ID 설정
    }
    public override string ToString() // 문자열 반환 메서드 재정의
    {
        string info;
        if (GroupID <= 5)
            info = $"[경력 : {LV}년차 {Name} - 멘탈: {HP}, 정치력: {ATK}, 아부력: {DEF}]";
        else if (GroupID == 6)
            info = $"[{LV}년 경력의 {Name} 맛집 - 멘탈: {HP}, 정치력: {ATK}, 아부력: {DEF}]";
        else if (GroupID == 7)
            info = $"[{Name} - 멘탈: {HP}, 정치력: {ATK}, 아부력: {DEF}]";
        else
            info = $"[Unknown Group {GroupID} - {Name} - 멘탈: {HP}, 정치력: {ATK}, 아부력: {DEF}]";
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
        Console.WriteLine($"{Name})(이)가 {actualDamage} 의 피해를 입었습니다!( 남은 체력{HP})");
    }
    public void AttackPlayer(Character player) // 플레이어를 공격하는 메서드
    {
        Console.WriteLine($"{Name}이(가) {player.name}을(를) 공격합니다!"); // 공격 메시지 출력
        player.takeDamage(ATK); // 플레이어에게 공격력만큼 피해 입힘
    }

    public static List<Monster> MonsterList = new List<Monster> //몬스터 리스트
    {
        // 일반 던전 (노가다) - 체력 낮고 경험치 적음
        new Monster("🍔햄버거", 120, 15, 5, 1, 5, 1),
        new Monster("🍕피자", 130, 16, 6, 1, 5, 1),
        new Monster("🍣초밥", 140, 17, 7, 1, 6, 1),
        new Monster("🍜라멘", 150, 18, 8, 2, 6, 1),
        new Monster("🍛카레", 160, 19, 9, 2, 7, 1),
        new Monster("🥩스테이크", 170, 20, 10, 2, 7, 1),
        new Monster("🫕샤브샤브", 180, 21, 11, 3, 8, 1),
        new Monster("🍲김치찌개", 190, 22, 12, 3, 8, 1),
        new Monster("🍝스파게티", 200, 23, 13, 3, 9, 1),
        new Monster("🍚비빔밥", 220, 24, 14, 3, 10, 1),
        new Monster("🍱도시락", 240, 25, 15, 4, 10, 1),

        // 파일 미궁 던전 (중급 난이도)
        new Monster("📄프로젝트 보고서_1126", 250, 26, 15, 4, 12, 2),
        new Monster("📄보고서_1126_수정", 260, 27, 16, 4, 12, 2),
        new Monster("📄보고서_1126_최종", 270, 28, 17, 5, 13, 2),
        new Monster("📄보고서_1126_최종_보고용", 280, 29, 18, 5, 14, 2),
        new Monster("📄보고서_1126_최종_진짜진짜최종", 300, 30, 19, 6, 15, 2),

        // 서버실 던전 (상급 난이도)
        new Monster("💾디스크 가득참 경고", 550, 50, 33, 8, 52, 3),
        new Monster("⚡전력 서지", 700, 60, 40, 10, 65, 3),
        new Monster("🐞치명적 버그", 580, 53, 32, 9, 54, 3),
        new Monster("🌪️서버 팬 과부하", 600, 52, 38, 9, 56, 3),
        new Monster("📉다운타임 악몽", 750, 65, 45, 11, 70, 3),
        new Monster("☁️클라우드 장애", 620, 55, 37, 9, 58, 3),

        

        // 승진 시험 (난이도 점진적 증가)
        // 그룹 1 (흡연실) - 약함
        new Monster("승진을 원하는 동료", 150, 18, 10, 3, 15, 4),
        new Monster("나를 견제하는 동료", 160, 19, 11, 3, 16, 4),
        new Monster("회의 중 졸고 있는 동료", 170, 20, 12, 3, 17, 4),
        new Monster("야근하는 동료", 180, 21, 13, 4, 18, 4),

        // 그룹 2 (탕비실) - 중급
        new Monster("무능한 간부", 250, 30, 18, 5, 25, 5),
        new Monster("게으른 간부", 260, 31, 19, 5, 26, 5),
        new Monster("지시만 하는 간부", 270, 32, 20, 5, 27, 5),
        new Monster("불평만 하는 간부", 280, 33, 21, 5, 28, 5),

        // 그룹 3 (팀장) - 더 어려워짐
        new Monster("고집불통 팀장", 350, 40, 25, 6, 35, 6),
        new Monster("독단적인 팀장", 360, 41, 26, 6, 36, 6),
        new Monster("권위적인 팀장", 370, 42, 27, 6, 37, 6),
        new Monster("소통 안 되는 팀장", 380, 43, 28, 7, 38, 6),

        // 그룹 4 (차장) - 매우 어려움
        new Monster("꼰대차장", 500, 55, 35, 8, 50, 7),
        new Monster("꼰대차장2", 510, 56, 36, 8, 51, 7),
        new Monster("꼰대차장3", 520, 57, 37, 8, 52, 7),
        new Monster("꼰대차장4", 530, 58, 38, 8, 53, 7),

        // 그룹 5 (사장) - 최종 보스급
        new Monster("독불장군 사장", 1000, 100, 50, 10, 100, 8),
        new Monster("성과제일주의 사장", 1050, 110, 55, 11, 110, 8),
        new Monster("비용절감 사장", 1100, 120, 60, 12, 120, 8),
        new Monster("권모술수 사장", 1150, 130, 65, 13, 130, 9),
        new Monster("냉혈한 사장", 1200, 140, 70, 14, 140, 9),
        new Monster("기업사냥꾼 사장", 1300, 160, 80, 15, 160, 10),
 

        // 직업 던전 보스 (매우 강한 보스)
        new Monster("스파르타최종프로젝트", 2000, 120, 60, 15, 200, 9)
    }; //이름 , 체력 , 공격력 , 방어력 , 레벨 , 경험치 , 그룹ID




    public static Monster GetRandomMonsterByGroup(int groupID) // 그룹 ID에 따른 랜덤 몬스터 반환 메서드
    {
        Random rand = new Random(); // 랜덤 객체 생성
        List<Monster> filteredList = MonsterList.FindAll(m => m.GroupID == groupID); // 그룹 ID에 해당하는 몬스터 리스트 필터링

        if (filteredList.Count == 0) // 필터링된 몬스터가 없으면
        {
            Console.WriteLine("몬스터 없음"); // 메시지 출력
            return null; // null 반환
        }

        int index = rand.Next(filteredList.Count); // 필터링된 몬스터 중 랜덤 인덱스 선택
        return filteredList[index]; // 선택된 몬스터 반환
    }



}
