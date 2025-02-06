using System;
public class Monster
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
        Console.WriteLine($"{Name}이(가) {actualDamage}의 피해를 입었습니다! (남은 체력: {HP})");
    }

    public bool IsDead()
    {
        return HP <= 0;
    }

    public void AttackPlayer(Player player)
    {
        Console.WriteLine($"{Name}이(가) {player.Name}을(를) 공격합니다!");
        player.TakeDamage(ATK);
    }

}