using UnityEngine;

public class Unit : MonoBehaviour
{
   public string unitName;
   public string unitDesc;

  // public string cardArray;

   public int maxHP;
   public int currentHP;

   public bool Damage(int dmg)//check for dead enemy
   {
    currentHP -= dmg;

    if(currentHP <= 0)
        return true;
    else  
        return false;
   }
   
}
