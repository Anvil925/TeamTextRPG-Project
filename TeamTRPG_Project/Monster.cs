using System; // Console.WriteLine, Math.Max, Math.Min 사용을 위해 추가
using TeamTRPG_Project; // Character 클래스 사용을 위해 추가

public class Monster // 몬스터 클래스
{
    public string Name { get; private set; } // 몬스터 이름
    public float HP { get; private set; } // 체력
    public float ATK { get; private set; } // 공격력
    public float DEF { get; private set; } // 방어력
    public int LV { get; private set; } // 레벨
    public int GroupID { get; private set; } // 그룹 ID

    public Monster(string name, float hp, float atk, float def, int lv, int groupID) // 생성자
    {
        Name = name; // 이름 설정
        HP = hp; // 체력 설정
        ATK = atk; // 공격력 설정
        DEF = def; // 방어력 설정
        LV = lv; // 레벨 설정
        GroupID = groupID; // 그룹 ID 설정
    } 

    public void TakeDamage(int damage) // 피해를 입는 메서드
    {
        int actualDamage = Math.Max(1, damage - (int)DEF); // 최소 1 이상의 피해 보장
        HP = Math.Max(0, HP - actualDamage); // 체력이 0 이하로 내려가지 않도록 처리
        Console.WriteLine($"{Name}이(가) {actualDamage}의 피해를 입었습니다! (남은 체력: {HP})"); // 피해 출력
    }

    public bool IsDead() // 사망 여부를 반환하는 메서드
    {
        return HP <= 0; // 체력이 0 이하이면 사망
    }

    public override string ToString() // 문자열 반환 메서드 재정의
    {
        return $"[Lv.{LV}] {Name} - HP: {HP}, ATK: {ATK}, DEF: {DEF}"; // 몬스터 정보 반환
    }

    // Character.cs 에서 수정 후 사용
    // public void AttackPlayer(Character player)
    // {
    //     Console.WriteLine($"{Name}이(가) {player.Name}을(를) 공격합니다!");
    //     player.TakeDamage(ATK);
    // }

    public static List<Monster> MonsterList = new List<Monster> // 몬스터 리스트
    {
        new Monster("승진을 원하는 동료", 30, 5, 2, 1, 1),  // 그룹 1 (흡연실)
        new Monster("무능한 간부", 50, 8, 4, 2, 2),    // 그룹 2 (탕비실)
        new Monster("고집불통 팀장", 35, 6, 2, 2, 3), // 그룹 3 (이름 미정)
        new Monster("꼰대차장", 150, 20, 10, 5, 4), // 그룹 4 (이름 미정)
        new Monster("파일", 150, 20, 10, 5, 5),  // 그룹 4 (이름 미정)
        new Monster("서버실", 150, 20, 10, 5, 6),  // 그룹 4 (이름 미정)
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