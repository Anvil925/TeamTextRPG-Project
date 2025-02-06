using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public enum ItemType
    {
        ATK,    // 무기
        DEF,    // 방어구
        COUNT
    }

    public class Item
    {
        public StringBuilder ItemInfo;

        public string Name { get; set; }
        public ItemType ItemType { get; set; }
        public float ATK { get; set; }
        public float DEF { get; set; }
        public string Description {  get; set; }    // 설명
        public int Price {  get; set; }

        public bool IsEquip {  get; set; }          // 장착이 되었는가?
        public bool IsPurchase { get; set; }        // 구매가 되었는가?

        public Item(string name, ItemType itemType,float atk, float def, string description, int price)
        {
            Name = name;
            ItemType = itemType;
            ATK = atk;
            DEF = def;

            Description = description;
            Price = price;

            IsEquip = false;
            IsPurchase = false;

            ItemInfo = new StringBuilder();
        }

        public string ShowInfo()
        {
            if(IsEquip) ItemInfo.Append("[E]");

            ItemInfo.Append($"{Name}\t| ");

            if (ItemType == ItemType.ATK)
                ItemInfo.Append($"공격력 +{ATK}\t| ");
            else
                ItemInfo.Append($"방어력 +{DEF}\t| ");

            ItemInfo.Append($"{Description}");

            return ItemInfo.ToString();

        }
    }
}
