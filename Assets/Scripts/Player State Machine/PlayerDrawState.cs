using UnityEngine;

public class PlayerDrawState : PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager player);
        //
   public abstract void UpdateState(PlayerStateManager player):
        //
    
    public abstract void OnTriggerEnter(PlayerStateManager player);
//OnGUI ?
   // onClick(Draw){
   // getComponent.CardArray.CardNum; (random from 'deck' array)
    // getComponent.CardArray.CardNum,CardSprite (specific to the draw card)
    //  put model in 'hand' in UI
    // set button in UI for new card visible
   // stuf test

}
