using UnityEngine;
using static Inventory;
using static CardUi;
using static CardData;
using System.Collections;

public class InventoryController : MonoBehaviour
{
    private bool isActive = false;
    [SerializeField] GameObject inventoryScreen;
    // Start is called once before the first execution of Update after the MonoBehaviour is created


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            if(!isActive)
            {
                inventoryScreen.SetActive(true);
                isActive = true;
            }
            if(isActive)
            {
                inventoryScreen.SetActive(false);
                isActive = false;
            }
        }

    }
}
