using System;
using System.Collections;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private ArrayList inventory;
    private ArrayList deck;
    int deckSizeLimit = 10;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    //initializes arrays
    //deck holds the equipped cards for battles
    //inventory stores all available cards that can be added to deck
    //so the ones that have been picked up etc
    {
        deck = new ArrayList();
        inventory = new ArrayList();
    }

    public Boolean addCardToInventory(CardData card)
    //returns true if added, false if inventory contains this card
    //i don't think we will need an equivalent remove method
    {
       if(inventory.Contains(card))
        {
            return false;
        }
        inventory.Add(card);
        return true;
    }

    public Boolean addCardToDeck(CardData card)
        //returns true if added, false if not (i.e. deck full)
        //could be called after ui element interactions
        //add external indicator/check of if a card is in deck already to prevent dupes?
    {
        if(deck.Count < deckSizeLimit)
        {
            deck.Add(card);
            return true;
        }
        return false;
    }

    public Boolean removeCardFromDeck(CardData card)
        //returns true if removed, false if not (i.e. does not contain)
        //which probably shouldn't happen but just in case
    {
        if(deck.Contains(card))
        {
            deck.Remove(card);
            return true;
        }
        return false;
    }

}
