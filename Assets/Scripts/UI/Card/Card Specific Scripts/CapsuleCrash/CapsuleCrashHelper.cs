using UnityEngine;

public class CapsuleCrashHelper : MonoBehaviour
{
    CapsuleCrash _capsuleCrash;

    private void Awake() => _capsuleCrash = transform.parent.GetComponent<CapsuleCrash>();
    public void BoomHelp() => _capsuleCrash.Boom();
}
