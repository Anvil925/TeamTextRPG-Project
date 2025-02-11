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

    public static List<Monster> MonsterList = new List<Monster> // 몬스터 리스트
    {
        new Monster("승진을 원하는 동료", 30, 5, 2, 1, 1, 1),  // 그룹 1 (흡연실)
        new Monster("나를 견제하는 동료", 30, 5, 2, 1, 1, 1),  // 그룹 1 (흡연실)
        new Monster("회의 중 졸고 있는 동료", 30, 5, 2, 1, 1, 1),  // 그룹 1 (흡연실)
        new Monster("야근하는 동료", 30, 5, 2, 1, 1, 1),  // 그룹 1 (흡연실)

        new Monster("무능한 간부", 50, 8, 4, 2, 2, 2),    // 그룹 2 (탕비실)
        new Monster("게으른 간부", 50, 8, 4, 2, 2, 2),    // 그룹 2 (탕비실)
        new Monster("지시만 하는 간부", 50, 8, 4, 2, 2, 2),    // 그룹 2 (탕비실)
        new Monster("불평만 하는 간부", 50, 8, 4, 2, 2, 2),    // 그룹 2 (탕비실)

        new Monster("고집불통 팀장", 35, 6, 2, 2, 3, 3), // 그룹 3 (이름 미정)
        new Monster("독단적인 팀장", 35, 6, 2, 2, 3, 3), // 그룹 3 (이름 미정)
        new Monster("권위적인 팀장", 35, 6, 2, 2, 3, 3), // 그룹 3 (이름 미정)
        new Monster("소통 안 되는 팀장", 35, 6, 2, 2, 3, 3), // 그룹 3 (이름 미정)

        new Monster("꼰대차장", 150, 20, 10, 5, 4, 4), // 그룹 4 (이름 미정)
        new Monster("꼰대차장2", 150, 20, 10, 5, 4, 4), // 그룹 4 (이름 미정)
        new Monster("꼰대차장3", 150, 20, 10, 5, 4, 4), // 그룹 4 (이름 미정)
        new Monster("꼰대차장4", 150, 20, 10, 5, 4, 4), // 그룹 4 (이름 미정)

        new Monster("독불장군 사장", 150, 20, 10, 6, 5, 5),  // 그룹 5 (이름 미정)

        new Monster("🍔햄버거", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정)
        new Monster("🍕피자", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정)
        new Monster("🍣초밥", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정)
        new Monster("🍜라멘", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정)
        new Monster("🍛카레", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정)
        new Monster("🥩스테이크", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정)
        new Monster("🫕샤브샤브", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정)
        new Monster("🍲김치찌개", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정)
        new Monster("🍝스파게티", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정
        new Monster("🍚비빔밥", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정)
        new Monster("🍱도시락", 150, 20, 10, 6, 6, 6),  // 그룹 6 (이름 미정)

        new Monster("📄프로젝트 결과 보고서_1126", 150, 20, 10, 7, 7, 7),  // 그룹 7 (이름 미정)
        new Monster("📄프로젝트 결과 보고서_1126_수정", 150, 20, 10, 7, 7, 7),  // 그룹 7 (파일 어디갔니)
        new Monster("📄프로젝트 결과 보고서_1126_수정2", 150, 20, 10, 7, 7, 7),  // 그룹 7 (파일 어디갔니)
        new Monster("📄프로젝트 결과 보고서_1126_최종", 150, 20, 10, 7, 7, 7),  // 그룹 7 (파일 어디갔니)
        new Monster("📄프로젝트 결과 보고서_1126_최종_보고용", 150, 20, 10, 7, 7, 7),  // 그룹 7 (파일 어디갔니)
        new Monster("📄프로젝트 결과 보고서_1126_최종_보고용_1127 수정", 150, 20, 10, 7, 7, 7),  // 그룹 7 (파일 어디갔니)
        new Monster("📄프로젝트 결과 보고서_1126_최종_보고용_1127 최종", 150, 20, 10, 7, 7, 7),  // 그룹 7 (파일 어디갔니)
        new Monster("📄프로젝트 결과 보고서_1126_최종_보고용_1127 최종_진짜진짜최종", 150, 20, 10, 7, 7, 7),  // 그룹 7 (파일 어디갔니)
        new Monster("📄프로젝트 결과 보고서_1126_최종_보고용_1127 최종_진짜진짜진짜최종", 150, 20, 10, 7, 7, 7),  // 그룹 7 (파일 어디갔니)
        
        new Monster("서버", 150, 20, 10, 8, 8, 8)  // 그룹 8 (이름 미정)
    };


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
