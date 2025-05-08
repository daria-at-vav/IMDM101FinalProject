using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class SimpleInteractableObject : NonPlayerObject {

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField] protected DialogueText dialogueText;    
    [SerializeField] private DialogueControllerScript dialogueController;
    
    public override void Interact() {

        Talk(dialogueText);
        print("interacted");
    }

    public void Talk(DialogueText text) {
        dialogueController.DisplayNextParagraph(text);
    }
}
