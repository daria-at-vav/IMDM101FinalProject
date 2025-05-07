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

    //IEnumerator Moveset()
   // {
       //move 1 or move 2
      // calc dmg
      //check for dead, set to win
      // update stats
      // end turn
     
     
      
    // bool isDead = enemyUnit.Damage(playerUnit.move);
    // enemyBenchDisplay.SetHP(enemyUnit.currentHP);
    //  dialogueText.text =  
    // yield return new WaitForSeconds(2f);
    //if(isDead)
   // {
   // state = BattleState.WIN;
   // } else
   //{ state = BattleState.ENEMYGO;
   //  StartCoroutine(EnemyGo());
   //}

    void PlayerGo()
    {
       // dialogueText.text for instructions
        // buttons active
        // inst cards to form deck?
         //from card array, bring in new card obj 
       // yield return new WaitForSeconds(2f);
        // card sprite to hand 
        //StartCoroutine(Moveset());
    }
     void EnemyGo()
   {
   // inst. specific cards
   // attack 
   // deal damage, check for lose
   // end turn 
   //state = BattleState.PLAYERGO;
   }

  void EndBattle()
   {
    if(state == BattleState.WIN)
    {
        //text, transition to scene
    } 
    else if(state == BattleState.LOSE)
    {
        //text, return to last point
    }
   }
}
   