using UnityEngine;
using static CardController;

[CreateAssetMenu (fileName = "Move", menuName = "Moves/New Move") ]
public class MoveScriptableObject : ScriptableObject
{
    public MonType monType;
    [SerializeField] protected int dmg;
    [SerializeField] protected int recoil;
    [SerializeField] protected int heal;

    [TextArea(5, 10)]
    public string flavorText;

    public virtual int CalculateDamage()
    {
        return dmg;
    }

    public int CalculateEffect()
    {
        return heal - recoil;
    }

}
