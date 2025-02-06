using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public enum ItemType
    {
        ATK,
        DEF,
        COUNT
    }

    public class Item
    {
        public string Name { get; set; }
        public ItemType ItemType { get; set; }
        public float ATK { get; set; }
        public float DEF { get; set; }
        public bool IsEquip {  get; set; }

        public Item(string name, ItemType itemType,float atk, float def)
        {
            Name = name;
            ItemType = itemType;
            ATK = atk;
            DEF = def;
            IsEquip = false;
        }
    }
}
