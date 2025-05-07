using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// i'm making this to try the deck script, may need to be changed/deleted to merge properly
// tutorial says for connecting card data & behaviors

[RequireCommponent(typeof(CardUI))]
public class Card: MonoBehaviour
{
    #region Fields and Properties
    [field:SerializeField] public ScriptableCard CardData { get; private set;}
    #endregion
   
    #region Methods
    //relevant cardData at runtime
    public void SetUp(ScriptableCard data)
    {
        CardData = data;
    }
    #endregion
    //tbd
}