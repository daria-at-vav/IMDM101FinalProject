using UnityEngine;
using static CardController;

// this holds all of the data for a card like its name, moves, type, hp, and art
[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    [SerializeField] public string cardName;
    [SerializeField] public int baseHp;
    [SerializeField] public MonType type;
    [SerializeField] public MoveScriptableObject move1;
    [SerializeField] public MoveScriptableObject move2;
    [SerializeField] public Sprite image;
}
