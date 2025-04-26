using UnityEngine;
using static CardController;


public class MoveScriptableObject : ScriptableObject
{
    public MonType monType;
    private int dmg;
    private int recoil;
    private int heal;

    [TextArea(5, 10)]
    public string flavorText;

    public int calculateDamage()
    {
        return dmg;
    }

    public int calculateEffect()
    {
        return heal - recoil;
    }

}
