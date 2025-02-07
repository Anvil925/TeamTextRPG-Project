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
        Console.WriteLine($"{Name}) {actualDamage} 몬스터 체력: {HP})"); 
    }

    public bool IsDead() 
    {
        return HP <= 0;

    }

}