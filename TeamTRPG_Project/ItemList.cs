using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamTRPG_Project
{
    public class ItemList
    {
        private static ItemList instance;

        // 전체 아이템 리스트
        public List<List<Item>> Items = new List<List<Item>>();

        // 각 타입별 아이템 리스트
        public List<Weapon> Weapons = new List<Weapon>();
        public List<Armor> Armors = new List<Armor>();
        public List<Potion> Potions = new List<Potion>();
        public static ItemList Instance()
        {
            if (instance == null)
            {
                instance = new ItemList();
            }
            return instance;
        }

        public ItemList()
        {
            // 무기
            Weapons.Add(new Weapon("기계식 키보드", 10, "저가형 기계식 키보드. 소리가 시끄럽다.", 300));
            Weapons.Add(new Weapon("버티컬 마우스", 20, "손목 부담이 적은 마우스. 업무가 한층 수월해진다.", 600));

            // 방어구
            Armors.Add(new Armor("거북목 방지기", 5 , "저가형 거북목 방지기. 목의 피로를 좀 덜어준다.", 300));
            Armors.Add(new Armor("허리 교정기", 10, "허리 교정기. 허리의 부담을 줄여준다.", 600));
            Armors.Add(new Armor("시디즈 의자", 20, "고가형 의자. 바른 자세를 유지해준다.", 900));

            // 회복량
            Potions.Add(new Potion("자판기 커피", 100, "평범한 자판기 커피.", 300));
            Potions.Add(new Potion("데자와", 200, "로얄 밀크티", 600));
            Potions.Add(new Potion("솔의 눈", 250, "머리까지 시원해지는 솔의 눈", 900));
            Potions.Add(new Potion("여명", 300, "숙취 해소제", 1500));

            for (int i = 0; i < Weapons.Count; i++)
            {
                Items[0].Add(Weapons[i]);
            }

            for (int i = 0; i < Armors.Count; i++)
            {
                Items[1].Add(Armors[i]);
            }

            for (int i = 0; i < Potions.Count; i++)
            {
                Items[2].Add(Potions[i]);
            }
        }
    }
}
