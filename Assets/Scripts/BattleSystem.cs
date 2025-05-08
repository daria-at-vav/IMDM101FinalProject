using UnityEngine;
using UnityEngine.UI;

public enum BattleState { NULL, PLAYERGO, ENEMYGO, WIN, LOSE }
public class BattleSystem : MonoBehaviour
{
    //ui button references?
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

        IEnumerator SetupBattle() //inst the objects
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
        
        IEnumerator PlayerAttack()
        {
            bool isDead = enemyUnit.Damage(playerUnit.move);
            
            enemyBenchDisplay.SetHP(enemyUnit.currentHP);
            dialogueText.text =  "Attacked.";
   
            yield return new WaitForSeconds(2f);
    
            if(isDead)
            {
                state = BattleState.WIN;
                EndBattle();
            } else
                { state = BattleState.ENEMYGO;
                EnemyGo();
                }
        } 
            
           
    
   


    void PlayerGo()
    {
       dialogueText.text = "Draw or Play a Move!";
        // buttons active
        // inst cards to form deck?
         //from card array, bring in new card obj 
       
        yield return new WaitForSeconds(2f);
        // card image displayed
        StartCoroutine(PlayerAttack());
    }

    void OnButtons()
    {
         //if (OnCLick(deck button))
            //{ add card from deck to hand
            // disable deck button
            //}

            //else if (OnClick(move1 button))
            // {calc dmg
            //yield return new WaitForSeonds(2f);
            //check for dead, set to win
            // update stats
            // end turn}
     
            // else if(Input button move 2)
            // {calc dmg
            //check for dead, set to win
            // update stats
            // end turn}
      
    }
    
     void EnemyGo()
   {
   // inst. specific cards
   // attack 
   // deal damage, check for lose
   // end turn 
   //state = BattleState.PLAYERGO;
   //PlayerGo();
   }

  void EndBattle()
   {
    if(state == BattleState.WIN)
    {
        //text, SceneManager.LoadScene();
    } 
    else if(state == BattleState.LOSE)
    {
        //text, SceneManager.LoadScene();
    }
   }
}
   