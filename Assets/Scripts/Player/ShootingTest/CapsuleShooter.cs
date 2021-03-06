using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class CapsuleShooter : NetworkBehaviour
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] Animator _animator;
    [SerializeField] Transform _projectileOrigin;

    Controls _controls;
    public Controls Controls => _controls ??= new Controls();

    public override void OnStartAuthority()
    {
        enabled = true;

        Controls.PlayerControls.Shoot.performed += ctx => CmdFire();
    }

    [ClientCallback]
    private void OnEnable() => Controls.Enable();
    [ClientCallback]
    private void OnDisable() => Controls.Disable();

    // this is called on the server
    [Command]
    public void CmdFire()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _projectileOrigin.position, _projectileOrigin.rotation);
        NetworkServer.Spawn(projectile);
        RpcOnFire();
    }

    [ClientRpc]
    void RpcOnFire()
    {
        // animate here
        //_animator.SetTrigger("Jump");
    }
}
