using System; 
public class Monster 
{
    public string Name { get; private set; } 
    public float HP { get; private set; } 
    public float ATK { get; private set; } 
    public float DEF { get; private set; } 
    public int LV { get; private set; } 

    public Monster(string name, float hp, float atk, float def, int lv) 
    {
        Name = name; 
        HP = hp; 
        ATK = atk; 
        DEF = def; 
        LV = lv; 
    } 

    public void TakeDamage(int damage)
    {
        int actualDamage = Math.Max(damage - (int)DEF, 1); 
        HP -= actualDamage;
        Console.WriteLine($"{Name}) {actualDamage} ���� ü��: {HP})"); 
    }

    public bool IsDead() 
    {
        return HP <= 0;

    }

    public override string ToString() // 문자열 반환 메서드 재정의
    {
        return $"[Lv.{LV}] {Name} - HP: {HP}, ATK: {ATK}, DEF: {DEF}"; // 몬스터 정보 반환
    }

    public void AttackPlayer(Character player) // 플레이어를 공격하는 메서드
    {
        Console.WriteLine($"{Name}이(가) {player.name}을(를) 공격합니다!"); // 공격 메시지 출력
        player.takeDamage(ATK); // 플레이어에게 공격력만큼 피해 입힘
    }

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
