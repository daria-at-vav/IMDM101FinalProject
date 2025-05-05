using UnityEngine;
using UnityEngine.UI;

public class BenchDisplay : MonoBehaviour
{
   public Text nameText;
   public Text descText;
   public Text statsText;
   public Slider hpSlider;

   public void SetDisplay(Unit unit)
   {
        nameText.text = unit.unitName;
        descText.text = unit.unitDesc;
        statsText.text = "HP:" + unit.currentHP + "/" + unit.maxHP;
        hpSlider.maxValue = unit.maxHP;
        hpSlider.value = unit.currentHP;
   }

   public void SetHP(int hp)
   {
        hpSlider.value = hp;
   }

}
