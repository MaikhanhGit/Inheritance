using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowField : MonoBehaviour
{
    [SerializeField] float _accelerateAmount = .2f;
    [SerializeField] AudioClip _sfxClip;

    private void OnTriggerEnter(Collider other)
    {
        ProjectileBlaster blasterProjectile = other.GetComponent<ProjectileBlaster>();
        ProjectileLauncher launcherProjectile = other.GetComponent<ProjectileLauncher>();
        
        // if it's a valid projectile, apply new movement behavior
        
        if (blasterProjectile)
        {
            AccelerateMoveBehavior slowStart = new AccelerateMoveBehavior
                 (other.attachedRigidbody, _accelerateAmount);

            blasterProjectile.SetMoveBehavior(slowStart);
            AudioHelper.PlayClip2D(_sfxClip, 1);
        }
        else if (launcherProjectile)
        {
            AccelerateMoveBehavior slowStart = new AccelerateMoveBehavior
                (other.attachedRigidbody, _accelerateAmount);
            
            launcherProjectile.SetMoveBehavior(slowStart);
            AudioHelper.PlayClip2D(_sfxClip, 1);
        }
    }
}
