using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BattleInteractableObject : SimpleInteractableObject
{
    [SerializeField] string BattleName;
    [SerializeField] int maxInteractCount;

    int interactcount = 0;

    public override void Interact() {
        if (interactcount < maxInteractCount+1){
            interactcount++;
            Talk(dialogueText);
            print("interacted");
        } 
        
        if (interactcount == maxInteractCount + 1) {
            interactcount++;
            GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = false;
            SceneManager.LoadScene(BattleName, LoadSceneMode.Additive);
        }

    }
}
