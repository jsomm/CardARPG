using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Projectile Card", menuName = "Cards/Ranged Projectile Card Data")]
class RangedProjectileCard : CardData
{
    public GameObject Projectile;
    public CardIndicatorType Indicator;

    public RangedProjectileCard()
    {
        IndicatorType = Indicator;
    }
}

