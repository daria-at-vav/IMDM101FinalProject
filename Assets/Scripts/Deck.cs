using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// card deck, discard pile, working with Hand script?, CardContents
//tutorial from Endocrine gamedev on ytube
public class Deck: MonoBehaviour
{
    #region Fields and Properties
    public static Deck Instance { get; private set; }//singleton, need to ref deck contents
// one deck for now
    [SerializeField] private CardCollection playerDeck;
    //replace terms cardPrefab with actual prefab name?
    [SerializeField] private Card cardPrefab; //our prefab to make copies with diff card data?
    [SerializeField] private Canvas cardCanvas;

    private List<Card> deckPile;
    private List<Card> discardPile;

    public List<Card> HandCards { get; private set;}

    #endregion

    #region Methods
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else{
            Destroy(gameObject);
        }
    }
    
    private void Start()
    {//Inst. deck once at game start, loop through playerdeck & inst for each new cardData/ use controller
        InstantiateDeck();
    }
    private void InstantiateDeck()
    {

    }
    #endregion
}
