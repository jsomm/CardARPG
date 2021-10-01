using Mirror;

using UnityEngine;

public class CapsuleCrash : NetworkBehaviour
{
    public GameObject Explosion;
    public GameObject Capsule;
    public float DestroyAfter = 3f;

    public override void OnStartServer() => Invoke(nameof(DestroySelf), DestroyAfter);

    public void Boom()
    {
        Capsule.SetActive(false);
        Explosion.SetActive(true);
    }

    // destroy for everyone on the server
    [Server]
    void DestroySelf() => NetworkServer.Destroy(gameObject);
}
