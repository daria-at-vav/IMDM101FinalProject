using UnityEngine;
 //base sprite for player, starting stats
public class PlayerNullState : PlayerBaseState
{
    public abstract void EnterState(PlayerStateManager player);
        //
   public abstract void UpdateState(PlayerStateManager player):
        //
    
    public abstract void OnTriggerEnter(PlayerStateManager player);
//OnGUI ?
}
