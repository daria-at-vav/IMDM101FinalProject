using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCollection : ScriptableObject
{
    [field: SerializeField] public List<SciptableCard> CardsInCollection { get; private set; }

    public void RemoveCardFromCollection(ScriptableCard card) //to reduce deck size 
    {
        if (CardsInCollection.Contains(card))
        {
            CardsInCollection.Remove(card);
        }
        else{
            Debug.LogWarning("Carddata not present - cannot remove");
        }
    }
    public void AddCardToCollection(ScriptableCard card) // to increase deck size, probably when finding card objects,
    {
        if (CardsInCollection.Contains(card))
        {
            Debug.LogWarning("Carddata already present - cannot add");
        }
        else{
           CardsInCollection.Add(card);
        }
    }
}
