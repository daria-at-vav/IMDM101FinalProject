using UnityEngine;
using UnityEngine.UI;
using TMPro;
using static CardController;
using UnityEngine.InputSystem.LowLevel;

public class CardUi : MonoBehaviour
{
    // script that controlls the cards actions and holds it's data
    private CardController card;

    // the actual text elements in the ui prefab
    [SerializeField] private TextMeshProUGUI cardName;
    [SerializeField] private TextMeshProUGUI baseHp;
    [SerializeField] private TextMeshProUGUI currHp;
    [SerializeField] private TextMeshProUGUI move1Name;
    [SerializeField] private TextMeshProUGUI move1Dmg;
    [SerializeField] private TextMeshProUGUI move1Description;
    [SerializeField] private TextMeshProUGUI move2Name;
    [SerializeField] private TextMeshProUGUI move2Dmg;
    [SerializeField] private TextMeshProUGUI move2Description;

    // actual images in the ui prefab
    [SerializeField] private Image cardTypeIcon;
    [SerializeField] private Image cardBackground;
    [SerializeField] private Image cardImageBorder;
    [SerializeField] private Image cardImage;

    // general sprite assets we're referencing
    [SerializeField] private Sprite normalBg;
    [SerializeField] private Sprite fireBg;
    [SerializeField] private Sprite waterBg;
    [SerializeField] private Sprite grassBg;
    [SerializeField] private Sprite electricBg;
    [SerializeField] private Sprite groundBg;

    [SerializeField] private Sprite normalBorder;
    [SerializeField] private Sprite fireBorder;
    [SerializeField] private Sprite waterBorder;
    [SerializeField] private Sprite grassBorder;
    [SerializeField] private Sprite electricBorder;
    [SerializeField] private Sprite groundBorder;

    [SerializeField] private Sprite normalIcon;
    [SerializeField] private Sprite fireIcon;
    [SerializeField] private Sprite waterIcon;
    [SerializeField] private Sprite grassIcon;
    [SerializeField] private Sprite electricIcon;
    [SerializeField] private Sprite groundIcon;



    // gets the card controller and sets the ui
    private void Awake()
    {
        card = GetComponent<CardController>();
        SetCardUi();
    }
    
    // Update is called once per frame
    void Update()
    {
        // im sure theres a better way to do this if you can think of anything pls lmk
        UpdateCurrHp(card.currHp);
    }

    // sets up card ui (changes it from prefab base)
    private void SetCardUi()
    {
        if (card != null && card.cardData != null) 
        {
            SetCardText();
            SetCardImages();
        }
        
    }

    // sets all of the text on the card according to the data in the cards data
    private void SetCardText()
    {
        cardName.text = card.cardData.cardName;
        baseHp.text = "/" + card.cardData.baseHp.ToString(); // is here because the set up is [curr hp] / [base hp]
        currHp.text = baseHp.text;
        move1Name.text = card.cardData.move1.moveName;
        move1Dmg.text = card.cardData.move1.dmg.ToString();
        move1Description.text = card.cardData.move1.flavorText;
        move2Name.text = card.cardData.move2.moveName;
        move2Dmg.text = card.cardData.move2.dmg.ToString();
        move2Description.text = card.cardData.move2.flavorText;


    }

    // sets all the images
    private void SetCardImages()
    {
        // sets the background, border, and type icon according to the cards type
        switch (card.cardData.type)
        {
            case MonType.Fire:
                cardBackground.sprite = fireBg;
                cardImageBorder.sprite = fireBorder;
                cardTypeIcon.sprite = fireIcon;
                break;
            case MonType.Water:
                cardBackground.sprite = waterBg;
                cardImageBorder.sprite = waterBorder;
                cardTypeIcon.sprite = waterIcon;
                break;
            case MonType.Grass:
                cardBackground.sprite = grassBg;
                cardImageBorder.sprite = grassBorder;
                cardTypeIcon.sprite = grassIcon;
                break;
            case MonType.Ground:
                cardBackground.sprite = groundBg;
                cardImageBorder.sprite = groundBorder;
                cardTypeIcon.sprite = groundIcon;
                break;
            case MonType.Electric:
                cardBackground.sprite = electricBg;
                cardImageBorder.sprite = electricBorder;
                cardTypeIcon.sprite = electricIcon;
                break;
            case MonType.Normal:
                break;
        }


        // sets the card art to the specific art from card data
        cardImage.sprite = card.cardData.image;
    }

    // updates the text for the current Hp
    public void UpdateCurrHp(int newHp)
    {
        currHp.text = newHp.ToString();
    }
}
