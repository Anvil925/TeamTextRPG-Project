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
        public List<List<Item>> Items = new List<List<Item>>(3);

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
            for (int i = 0; i < Items.Capacity; i++)
            {
                Items.Add(new List<Item>());
            }

            // 무기
            Weapons.Add(new Weapon(1,"일반 키보드", 5, "일반 키보드. 평범한 키보드이다.", 300));
            Weapons.Add(new Weapon(1, "기계식 키보드", 10, "저가형 기계식 키보드. 소리가 시끄럽다.", 600));
            Weapons.Add(new Weapon(1, "무선 키보드", 20, "고급형 키보드. 조용한 소리에 상사의 눈치가 안보인다.", 900));
            Weapons.Add(new Weapon(1, "일반 마우스", 5, "일반 유선 마우스.", 300));
            Weapons.Add(new Weapon(1, "무선 마우스", 10, "선이 없는 마우스. 걸리는 느낌이 없어 쾌적하다", 600));
            Weapons.Add(new Weapon(1, "버티컬 마우스", 20, "손목 부담이 적은 마우스. 업무가 한층 수월해진다.", 900));
            Weapons.Add(new Weapon(1, "4080", 50, "고급 그래픽 카드. 렉이 없어져 업무가 너무 쾌적해진다.", 2000));

            // 방어구
            Armors.Add(new Armor(1, "거북목 방지기", 5 , "저가형 거북목 방지기. 목의 피로를 좀 덜어준다.", 300));
            Armors.Add(new Armor(1, "허리 교정기", 10, "허리 교정기. 허리의 부담을 줄여준다.", 600));
            Armors.Add(new Armor(1, "바의자", 15, "등받이 없는 의자. 작업하기에 너무 불편한 의자이다.", 900));
            Armors.Add(new Armor(1, "일반 사무용 의자", 20, "조금은 정상적으로 업무가 가능한 의자", 1200));
            Armors.Add(new Armor(1, "시디즈 의자", 20, "고가형 의자. 바른 자세를 유지해준다.", 1500));

            // 회복량
            Potions.Add(new Potion(0,"자판기 커피", 100, "평범한 자판기 커피.", 300));
            Potions.Add(new Potion(0,"데자와", 200, "로얄 밀크티", 600));
            Potions.Add(new Potion(0,"솔의 눈", 250, "머리까지 시원해지는 솔의 눈", 900));
            Potions.Add(new Potion(0,"여명", 300, "숙취 해소제", 1500));
            Potions.Add(new Potion(0,"하리보", 300, "곰 모양의 귀여운 젤리", 1500));
            Potions.Add(new Potion(0,"빈츠", 300, "달달한 초콜릿 과자", 1500));

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
