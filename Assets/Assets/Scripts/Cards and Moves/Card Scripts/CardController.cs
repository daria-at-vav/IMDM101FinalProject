using System.Runtime.CompilerServices;
using JetBrains.Annotations;
using UnityEngine;

public class CardController : MonoBehaviour
{

    
    [SerializeField] public CardData cardData;

    // ik this shows up in the editor dont touch it
    public int currHp;
    private int typeIndex;

    // this is the effectiveness chart from the art assets spreadsheet, column is attacking type and row is recieving type, number is the multiplier to the moves damage
    public static float[,] typeMatchArray = 
        { 
        {2, 2, 0.5f, 1, 1, 1}, 
        {0.5f, 1, 2, 1, 0.5f, 1}, 
        {2, 0.5f, 1, 0.5f, 2, 1},
        {0.5f, 0.5f, 2, 1, 0.5f, 1}, 
        {1, 2, 0.5f, 2, 1, 1 }, 
        {1, 1, 1, 1, 1, 1 }  
        };

    // Types are an Enum instead of a string so that we dont have to worry about string entry and mispellings
    public enum MonType
    {
        Fire, 
        Water,
        Grass,
        Ground,
        Electric,
        Normal,
    }

    // converts the card's type to a number to be indexed into the type matchup array
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
        typeIndex = TypeToInt(cardData.type);
        currHp = cardData.baseHp;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // uses the specified move on the specified card
    public void useMove(MoveScriptableObject move, CardController other)
    {
        // gets the damage that the move does
        int damage = move.CalculateDamage();
        // gets the effect on the user (recoil or heal)
        int effect = move.CalculateEffect();

        // calculates the damage to the other card based on type interaction and subtracts it from the other cards hp
        other.currHp -= (int)(damage * typeInteraction(other));

        // adds the recoil or heal to the move users health
        if (currHp + effect <= cardData.baseHp && currHp + effect >= 0)
        {
            // adds effect normally if effect will put currHp in the range [0, baseHp]
            currHp += effect;
        }
        else if (currHp + effect > cardData.baseHp) 
        {
            // if adding the effect will make currHp higher than baseHp just sets it to baseHp
            currHp = cardData.baseHp;
        }
        else if(currHp + effect < 0)
        {
            // if adding the effect will make currHp less than 0 then just set currHp to 0
            currHp = 0;
        }


        
    }

    // returns damage multiplier based on the type of the card using the move and the card the move is being used on
    public float typeInteraction(CardController other)
    {
        // gets the type of the recieving card and converts it into an index
        int otherType = other.typeIndex;

        // returns the multiplier from the matchup array (either 1, 2, or 0.5)
        return typeMatchArray[typeIndex, otherType];
    }
}
