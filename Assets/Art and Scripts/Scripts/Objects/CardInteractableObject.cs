using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class CardInteractableObject : SimpleInteractableObject {
    
    [SerializeField] private CardData card;
    [SerializeField] private int max;
    private int count = 0;

    public override void Interact() {
        if (count < max + 1){
            count++;
            Talk(dialogueText);
            print("interacted");
        } else {
            print("already interacted with object");
        }
        if (count == max) {
            GameObject.Find("Player").GetComponent<Inventory>().addCardToInventory(card);
            print("added " + card.name + " to inventory");
        }
    }
}
