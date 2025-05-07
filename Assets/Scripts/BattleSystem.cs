using UnityEngine;
using UnityEngine.UI;

public enum BattleState { NULL, PLAYERGO, ENEMYGO, WIN, LOSE }
public class BattleSystem : MonoBehaviour
{
    public GameObject playerPrefab;
    public GameObject enemyPrefab;

    public Transform playerBench;
    public Transform enemyBench;

    Unit playerUnit;
    Unit enemyUnit;

    public Text dialogueText;

    public BenchDisplay playerBenchDisplay;
    public BenchDisplay enemyBenchDisplay;
    public BattleState state;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        state = BattleState.NULL;
        StartCoroutine(SetupBattle());
    }

    IEnumerator SetupBattle()
    {
       GameObject playerObj = Instantiate(playerPrefab, playerBench);
       playerUnit = playerObj.GetComponent<Unit>();
       
       GameObject enemyObj = Instantiate(enemyPrefab, enemyBench);
       enemyUnit = enemyObj.GetComponent<Unit>();

       
       playerBenchDisplay.SetDisplay(playerUnit);
       enemyBenchDisplay.SetDisplay(enemyUnit);

       yield return new WaitForSeconds(2f);

       state = BattleState.PLAYERGO;
       PlayerGo();

    }

    //IEnumerator DrawCards()
   // {
        //from card array, bring in new card obj 
       // yield return new WaitForSeconds(2f);
        // card sprite to hand 
        //StartCoroutine(CardAttack());
   // }

    //IEnumerator CardAttack()
    // bool isDead = enemyUnit.Damage(playerUnit.attack);
    // enemyBenchDisplay.SetHP(enemyUnit.currentHP);
    //  dialogueText.text = 
    //
    // yield return new WaitForSeconds(2f);
    //if(isDead)
   // {
   // state = BattleState.WIN;
   // } else
   //{ state = BattleState.ENEMYGO;
   //  StartCoroutine(EnemyGo());
   //}

   //IEnumerator EnemyGo()
   //{
   // attack from cards in array enemyUnit.cardArray
   // deal damage
   // end turn 
   //}

   void EndBattle()
   {
    if(state == BattleState.WIN)
    {
        //text, transition to scene to get prize
    } 
    else if(state == BattleState.LOSE)
    {
        //text, return to last scene
    }
   }

    void PlayerGo()
    {
       // dialogueText.text = "Draw from Deck, Play a Card from Hand, or Choose a Move on a Card in Play.";
//err cs8300 merge
    }

    public void OnDrawButton()
    {
        if (state != BattleState.PLAYERGO)
            return;
        //else
    }
}