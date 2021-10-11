using Mirror;

using UnityEngine;

[CreateAssetMenu(fileName = "New Card Data", menuName = "Cards/Card Data")]
public partial class CardData : ScriptableObject
{
    public string Title, DescriptionText, DetailText;
    public int Cost;
    public Sprite CardArt;
    public float RangeModifier = 1;
    public CardType Type;
    public CardIndicatorType IndicatorType = CardIndicatorType.None;

    public virtual CardNetworkData GetNetworkData(CardNetworkData data)
    {
        data.Title = Title;
        data.DescriptionText = DescriptionText;
        data.Cost = Cost;
        data.RangeModifier = RangeModifier;
        data.IndicatorType = IndicatorType;
        data.Type = Type;
        return data;
    }
}
