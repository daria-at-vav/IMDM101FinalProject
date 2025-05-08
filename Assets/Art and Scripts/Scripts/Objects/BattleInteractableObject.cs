using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class BattleInteractableObject : SimpleInteractableObject
{
    [SerializeField] string BattleName;
    [SerializeField] int maxInteractCount;

    int interactcount = 0;
    public override void Interact()
    {
        if (SceneManager.loadedSceneCount == 1 && interactcount < 2)
        {
            Talk(dialogueText);
            interactcount++;
        } else if (SceneManager.loadedSceneCount == 1 && interactcount < maxInteractCount)
        {
            Talk(dialogueText); 
            GameObject.Find("EventSystem").GetComponent<EventSystem>().enabled = false;

            SceneManager.LoadScene(BattleName, LoadSceneMode.Additive);
        }
        print("interacted");

    }
}
