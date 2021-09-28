using UnityEngine;

[CreateAssetMenu(fileName = "New Card Data", menuName = "Cards/Card Data")]
public partial class CardData : ScriptableObject
{
    public string Title, DescriptionText;
    public int Cost;
    public Sprite CardArt;
    public float RangeModifier = 1;

    public CardIndicatorType IndicatorType { get; protected set; }
    public CardType Type { get; protected set; }
}
