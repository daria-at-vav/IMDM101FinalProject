using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class CardInteractableObject : SimpleInteractableObject {
    
    [SerializeField] private CardData card;
    
    public override void Interact() {
        Talk(dialogueText);
        print("interacted");
        GameObject.Find("Player").GetComponent<Inventory>().addCardToInventory(card);
        print("added " + card.name + " to inventory");
    }


}
