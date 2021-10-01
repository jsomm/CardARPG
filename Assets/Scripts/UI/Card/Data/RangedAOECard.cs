using Mirror;

using UnityEngine;

[CreateAssetMenu(fileName = "New Ranged AOE Card", menuName = "Cards/Ranged AOE Card Data")]
class RangedAOECard : CardData
{
    public GameObject AOEPrefab;

    public override CardNetworkData GetNetworkData(CardNetworkData data)
    {
        data.ProjectileID = NetworkManager.singleton.spawnPrefabs.IndexOf(AOEPrefab);
        return base.GetNetworkData(data);
    }
}

