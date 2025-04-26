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

    public void useMove (MoveScriptableObject move, CardController other)
    {
        int damage  = move.calculateDamage();
        int effect = move.calculateEffect();

        
        other.hp -= (int)(damage * typeInteraction(other, move));
        hp += effect;
    }

    // Know you didn'y finish but what is typeInteraction supposed to do
    public float typeInteraction(CardController other, MoveScriptableObject move)
    {
        int otherType = other.typeIndex;
        int moveType = TypeToInt(move.monType);
        return typeMatchArray[moveType, otherType];
    }
}
