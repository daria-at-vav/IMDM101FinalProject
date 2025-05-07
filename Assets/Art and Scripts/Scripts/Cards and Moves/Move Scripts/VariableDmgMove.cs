using UnityEngine;

[CreateAssetMenu(fileName = "Move", menuName = "Moves/New Variable Move")]
public class VariableDmgMove : MoveScriptableObject
{
    // when making this type of move in the asset menu make dmg be the base damage
    [SerializeField] private int coins;
    [SerializeField] private int multiplier;
    [SerializeField] private RandomType randomType;


    // how the random element is calculated
    private enum RandomType
    {
        // flipping a coin a set number of times (coin)
        NumHeads,
        // flipping a coin until its tails
        FlipUntilTails
    }

    public override int CalculateDamage()
    {
        // runs the calculation for numheads moves
        if (randomType == RandomType.NumHeads) 
        { 
            return dmg + (FlipCoins() * multiplier);
        }

        // runs the calculation for flipuntil moods
        if (randomType == RandomType.FlipUntilTails)
        {
            return dmg + (FlipUntil());
        }

        return base.CalculateDamage();
        
    }

    // flips all coins and returns the number that came up heads
    public int FlipCoins()
    {
        int counter = 0;
        for (int i = 0; i < coins; i++)
        {
            // gets either 0 or 1 and increments the counter if the random number is 1
            if (Random.Range(0, 2) == 1)
            {
                counter++;
            }

        }
        
        return counter;
    }
    
    // returns the number of heads flipped in a row
    public int FlipUntil()
    {
        int counter = 0;
        bool heads = true;

        // while the last coin flipped was heads
        while (heads)
        {
            // increment counter
            counter++;
            // flip coin again and see if it was heads or not
            heads = Random.Range(0, 2) == 1;
        }
        

        return counter;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


}
