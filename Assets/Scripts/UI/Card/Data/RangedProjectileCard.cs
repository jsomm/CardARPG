using Mirror;

using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged Projectile Card", menuName = "Cards/Ranged Projectile Card Data")]
class RangedProjectileCard : CardData
{
    public GameObject Projectile;

    public override CardNetworkData GetNetworkData(CardNetworkData data)
    {
        data.ProjectileID = NetworkManager.singleton.spawnPrefabs.IndexOf(Projectile);
        return base.GetNetworkData(data);
    }
}

