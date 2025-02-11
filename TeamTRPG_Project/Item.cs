using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public enum ItemType
    {
        ATK,    // 무기
        DEF,    // 방어구
        POTION, // 회복약
        COUNT
    }

    public class Item
    {
        public StringBuilder ItemInfo;


        public string Name { get; set; }
        public ItemType ItemType { get; set; }
        public string Description {  get; set; }    // 설명
        public int Price {  get; set; }

        public bool IsEquip {  get; set; }          // 장착이 되었는가?
        public bool IsPurchase { get; set; }        // 구매가 되었는가?

        public Item(string name, string description, int price)
        {
            Name = name;
            Description = description;
            Price = price;

            IsEquip = false;
            IsPurchase = false;

            ItemInfo = new StringBuilder();
        }

        public virtual void InputAbility()
        {
            ItemInfo.Append("능력치 : 0\t| ");
        }

        public string ShowInfo(bool isShop = false)
        {
            ItemInfo.Clear();

            if(IsEquip) ItemInfo.Append("[E]");

            ItemInfo.Append($"{Name}\t| ");

            InputAbility();

            ItemInfo.Append($"{Description}\t| {Price}G");

            if (isShop && IsPurchase)
                ItemInfo.Append("\t| 구매 완료");

            return ItemInfo.ToString();
        }
    }

    public class Weapon : Item
    {
        public float ATK { get; set; }      // 공격력
        public Weapon(string name, float atk, string description, int price) : base(name, description, price)
        {
            ItemType = ItemType.ATK;
            ATK = atk;
        }

        public override void InputAbility()
        {
            ItemInfo.Append($"공격력 : {ATK}\t| ");
        }
    }

    public class Armor : Item
    {
        public float DEF { get; set; }      // 방어력
        public Armor(string name, float def, string description, int price) : base(name, description, price)
        {
            ItemType = ItemType.DEF;
            DEF = def;
        }

        public override void InputAbility()
        {
            ItemInfo.Append($"방어력 : {DEF}\t| ");
        }
    }

    public class Potion : Item
    {
        public float REC { get; set; }      // 회복량
        public Potion(string name, float def, string description, int price) : base(name, description, price)
        {
            ItemType = ItemType.POTION;
            REC = def;
        }

        public override void InputAbility()
        {
            ItemInfo.Append($"회복량 : {REC}\t| ");
        }
    }
}
