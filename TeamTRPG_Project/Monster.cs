using System; // Console.WriteLine, Math.Max, Math.Min ����� ���� �߰�
using TeamTRPG_Project; // Character Ŭ���� ����� ���� �߰�
public class Monster // ���� Ŭ����
{    public string Name { get; private set; } // ���� �̸�
    public float HP { get; private set; } // ü��
    public float ATK { get; private set; } // ���ݷ�
    public float DEF { get; private set; } // ����
    public int LV { get; private set; } // ����
    public int GroupID { get; private set; } // �׷� ID
    public Monster(string name, float hp, float atk, float def, int lv, int groupID) // ������
    {        Name = name; // �̸� ����
        HP = hp; // ü�� ����
        ATK = atk; // ���ݷ� ����
        DEF = def; // ���� ����
        LV = lv; // ���� ����
        GroupID = groupID; // �׷� ID ����
    }    public void TakeDamage(int damage) // ���ظ� �Դ� �޼���
    {        int actualDamage = Math.Max(1, damage - (int)DEF); // �ּ� 1 �̻��� ���� ����
        HP = Math.Max(0, HP - actualDamage); // ü���� 0 ���Ϸ� �������� �ʵ��� ó��
        Console.WriteLine($"{Name}��(��) {actualDamage}�� ���ظ� �Ծ����ϴ�! (���� ü��: {HP})"); // ���� ���
    }    public bool IsDead() // ��� ���θ� ��ȯ�ϴ� �޼���
    {        return HP <= 0; // ü���� 0 �����̸� ���
    }    public override string ToString() // ���ڿ� ��ȯ �޼��� ������
    {        return $"[Lv.{LV}] {Name} - HP: {HP}, ATK: {ATK}, DEF: {DEF}"; // ���� ���� ��ȯ
    }
    // Character.cs ���� ���� �� ���
    // public void AttackPlayer(Character player)
    // {
    //     Console.WriteLine($"{Name}��(��) {player.Name}��(��) �����մϴ�!");
    //     player.TakeDamage(ATK);
    // }
    public static List<Monster> MonsterList = new List<Monster> // ���� ����Ʈ    {        new Monster("������ ���ϴ� ����", 30, 5, 2, 1, 1),  // �׷� 1 (����)        new Monster("������ ����", 50, 8, 4, 2, 2),    // �׷� 2 (�����)        new Monster("�������� ����", 35, 6, 2, 2, 3), // �׷� 3 (�̸� ����)        new Monster("��������", 150, 20, 10, 5, 4), // �׷� 4 (�̸� ����)        new Monster("����", 150, 20, 10, 5, 5),  // �׷� 4 (�̸� ����)        new Monster("������", 150, 20, 10, 5, 6),  // �׷� 4 (�̸� ����)    };    public static Monster GetRandomMonsterByGroup(int groupID) // �׷� ID�� ���� ���� ���� ��ȯ �޼���
    {        Random rand = new Random(); // ���� ��ü ����
        List<Monster> filteredList = MonsterList.FindAll(m => m.GroupID == groupID); // �׷� ID�� �ش��ϴ� ���� ����Ʈ ���͸�
        if (filteredList.Count == 0) // ���͸��� ���Ͱ� ������
        {            Console.WriteLine("���� ����"); // �޽��� ���
            return null; // null ��ȯ
        }        int index = rand.Next(filteredList.Count); // ���͸��� ���� �� ���� �ε��� ����
        return filteredList[index]; // ���õ� ���� ��ȯ
    }}