using UnityEngine;

using static CardData;

public struct CardNetworkData
{
    public string Title, DescriptionText;
    public int Cost;
    public float RangeModifier;
    public CardType Type;
    public CardIndicatorType IndicatorType;
    public int ProjectileID; // networkID of spawnable prefab
}
