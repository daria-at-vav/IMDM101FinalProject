using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public abstract class NonPlayerObject : MonoBehaviour, IInteractable {

    protected bool interactable = false;
    
    protected GameObject player;
    private Transform playerTransform;
    
    private float interactDistance = 2f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    protected void Start() {
        player = GameObject.FindGameObjectWithTag("Player");
        playerTransform = player.transform;
    }

    // Update is called once per frame
    void Update() {

        interactable = WithinInteractDistance();
        if (Keyboard.current.enterKey.wasPressedThisFrame && interactable) {
            Interact();
        }
        
    }

    public abstract void Interact();

    public bool WithinInteractDistance() {
        
        if (Vector2.Distance(transform.position, player.transform.position) < interactDistance) {
            return true;
        } else {
            return false;
        }
    }

    public void OnKeyDown(KeyDownEvent ev) {
        if (interactable) {
            Interact();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision) {
        interactable = true;
    }

    public void OnTriggerExit2D(Collider2D collision) {
        interactable = false;
    }
}
