using UnityEngine;
using UnityEngine.InputSystem;
using Mirror;

public class CapsuleShooter : NetworkBehaviour
{
    [SerializeField] GameObject _projectilePrefab;
    [SerializeField] Animator _animator;
    [SerializeField] Transform _projectileOrigin;

    Controls _controls;
    public Controls Controls
    {
        get
        {
            if (_controls != null) { return _controls; }
            return _controls = new Controls();
        }
    }

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
    void CmdFire()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _projectileOrigin.position, _projectileOrigin.rotation);
        NetworkServer.Spawn(projectile);
        RpcOnFire();
    }

    [ClientRpc]
    void RpcOnFire()
    {
        _animator.SetTrigger("Jump");
    }
}
