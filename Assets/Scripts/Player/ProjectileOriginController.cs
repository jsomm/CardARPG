using UnityEngine;
using Mirror;

class ProjectileOriginController : NetworkBehaviour
{
    [SerializeField] LayerMask _groundMask;
    [SerializeField] float _distanceFromPlayer = 0.5f;
    [SerializeField] Transform _originTransform;

    private void Update()
    {
        if (!hasAuthority)
            return;

        Ray ray = Utilities.CameraRaycast();
        if (Physics.Raycast(ray, out var hitInfo, Mathf.Infinity, _groundMask))
        {
            Vector3 direction = (hitInfo.point - transform.position).normalized;
            float angle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            float distance = Mathf.Clamp(Vector3.Distance(hitInfo.point, _originTransform.position), _distanceFromPlayer, _distanceFromPlayer);
            Vector3 targetPosition = transform.position + direction * distance;
            targetPosition.y = 1;

            _originTransform.position = targetPosition;
            _originTransform.eulerAngles = new Vector3(0, angle, 0);
        }
    }
}
