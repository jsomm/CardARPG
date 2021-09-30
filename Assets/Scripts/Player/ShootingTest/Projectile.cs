using UnityEngine;
using Mirror;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : NetworkBehaviour
{
    public float DestroyAfter = 5;
    public float Force = 1000;

    Rigidbody _rb;

    private void Awake() => _rb = GetComponent<Rigidbody>();

    public override void OnStartServer() => Invoke(nameof(DestroySelf), DestroyAfter);

    // set velocity for server and client. this way we don't have to sync the
    // position, because both the server and the client simulate it.
    void Start()
    {
        _rb.AddForce(transform.forward * Force);
        transform.rotation *= Quaternion.Euler(90, 0, 0);
    }

    // destroy for everyone on the server
    [Server]
    void DestroySelf() => NetworkServer.Destroy(gameObject);

    // ServerCallback because we don't want a warning if OnTriggerEnter is
    // called on the client
    [ServerCallback]
    void OnTriggerEnter(Collider co) => NetworkServer.Destroy(gameObject);
}

