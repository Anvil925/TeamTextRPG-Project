using System; // System 네임스페이스 사용
public class Monster // 몬스터 클래스
{
    public string Name { get; private set; } // 이름
    public float HP { get; private set; } // 체력
    public float ATK { get; private set; } // 공격력
    public float DEF { get; private set; } // 방어력
    public int LV { get; private set; } // 레벨

    public Monster(string name, float hp, float atk, float def, int lv) // 생성자
    {
        Name = name; // 이름 설정
        HP = hp; // 체력 설정
        ATK = atk; // 공격력 설정
        DEF = def; // 방어력 설정
        LV = lv; // 레벨 설정
    } 

    public void TakeDamage(int damage)
    {
        int actualDamage = Math.Max(damage - (int)DEF, 1); // 최소 1 이상의 피해를 받게 설정
        HP -= actualDamage;
        Console.WriteLine($"{Name}이(가) {actualDamage}의 피해를 입었습니다! (남은 체력: {HP})"); // 피해 출력
    }

    public bool IsDead() // 몬스터가 죽었는지 확인하는 메서드
    {
        return HP <= 0; // 체력이 0 이하이면 true 반환
    }

    // Character.cs 에서 선언한 클래스 확인하여 수정 필요
    // public void AttackPlayer(Player player)
    // {
    //     Console.WriteLine($"{Name}이(가) {player.Name}을(를) 공격합니다!");
    //     player.TakeDamage(ATK);
    // }

}