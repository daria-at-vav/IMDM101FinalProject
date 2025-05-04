using UnityEngine;
using static CardController;

[CreateAssetMenu (fileName = "Move", menuName = "Scriptable Objects/Moves/New Move") ]
public class MoveScriptableObject : ScriptableObject
{
    // name of the move
    [SerializeField] public string moveName;
    // damage the move deals to the other card (can be 0)
    [SerializeField] public int dmg;
    // damage the move does to itself
    [SerializeField] protected int recoil;
    // healing the move does to itself
    [SerializeField] protected int heal;
    // description of the move
    [TextArea(5, 10)]
    public string flavorText;

    // returns the amount of damage a move does
    public virtual int CalculateDamage()
    {
        return dmg;
    }

    // returns the effect done to the card (ie heal for 10 or 1 point of recoil)
    public int CalculateEffect()
    {
        return heal - recoil;
    }

}
