using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class CardController : MonoBehaviour
{

    [SerializeField] int hp;
    [SerializeField] MonType type;
    [SerializeField] MoveScriptableObject move1;
    [SerializeField] MoveScriptableObject move2;


    private int typeIndex;

    // this is the effectiveness chart from the art assets spreadsheet, column is attacking type and row is recieving type
    public static float[,] typeMatchArray = 
        { 
        {2, 2, 0.5f, 1, 1, 1}, 
        {0.5f, 1, 2, 1, 0.5f, 1}, 
        {2, 0.5f, 1, 0.5f, 2, 1},
        {0.5f, 0.5f, 2, 1, 0.5f, 1}, 
        {1, 2, 0.5f, 2, 1, 1 }, 
        {1, 1, 1, 1, 1, 1 }  
        };
    public enum MonType
    {
        Fire, 
        Water,
        Grass,
        Ground,
        Electric,
        Normal,
    }

    // Types are an Enum instead of a string so that we dont have to worry about string entry and mispellings
    private static int TypeToInt( MonType type)
    {
        switch (type)
        {
            case MonType.Fire:
                return 0;
            case MonType.Water:
                return 1;
            case MonType.Grass:
                return 2;
            case MonType.Ground:
                return 3;
            case MonType.Electric:
                return 4;
            case MonType.Normal:
                return 5;
        }

        return 5;
       
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        typeIndex = TypeToInt(type);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // uses the specified move on the specified card
    public void useMove (MoveScriptableObject move, CardController other)
    {
        // gets the damage that the move does
        int damage  = move.CalculateDamage();
        // gets the effect on the user (recoil or heal)
        int effect = move.CalculateEffect();

        // calculates the damage to the other card based on type interaction and subtracts it from the other cards hp
        other.hp -= (int)(damage * typeInteraction(other, move));
        // adds the recoil or heal to the move users health
        hp += effect;
    }

    // returns damage multiplier based on the type of the move and the card the move is being used on
    public float typeInteraction(CardController other, MoveScriptableObject move)
    {
        // gets the type of the recieving card and converts it into an index
        int otherType = other.typeIndex;
        // gets the type of the move and converts it into an index
        int moveType = TypeToInt(move.monType);

        // returns the multiplier from the matchup array (either 1, 2, or 0.5)
        return typeMatchArray[moveType, otherType];
    }
}
