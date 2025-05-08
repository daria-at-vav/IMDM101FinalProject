using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class StartSceneText : MonoBehaviour, ITalkable, IInteractable 
{
    [SerializeField] private DialogueText dialogueText;
    [SerializeField] private DialogueControllerScript dialogueController;
    [SerializeField] private string nextScene;

    private int interactCount = 0;

    public void Interact() {

        SceneManager.LoadScene("Bedroom");
        interactCount++;
    }

    public void Talk(DialogueText text) {
        dialogueController.DisplayNextParagraph(text);
    }

    void Update() {
        if (Keyboard.current.enterKey.wasPressedThisFrame) {
            Interact();
        }
    }
}
