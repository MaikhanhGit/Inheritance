using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopField : MonoBehaviour
{
    [SerializeField] AudioClip _sfxClip;
    private void OnTriggerEnter(Collider other)
    {
        ProjectileBlaster blasterProjectile = other.GetComponent<ProjectileBlaster>();
        ProjectileLauncher launcherProjectile = other.GetComponent<ProjectileLauncher>();
        if(blasterProjectile)
        {
            FreezeMovementBehavior noMoveBehavior = new FreezeMovementBehavior(other.attachedRigidbody);
            blasterProjectile.SetMoveBehavior(noMoveBehavior);
            AudioHelper.PlayClip2D(_sfxClip, 1);

        }else if (launcherProjectile)
        {
            FreezeMovementBehavior noMoveBehavior = new FreezeMovementBehavior(other.attachedRigidbody);
            launcherProjectile.SetMoveBehavior(noMoveBehavior);
            AudioHelper.PlayClip2D(_sfxClip, 1);


        }
    }
}
