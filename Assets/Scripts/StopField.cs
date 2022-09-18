using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StopField : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Projectile incomingProjectile = other.GetComponent<Projectile>();
        if(incomingProjectile != null)
        {
            FreezeMovementBehavior noMoveBehavior = new FreezeMovementBehavior(other.attachedRigidbody);
            incomingProjectile.SetMoveBehavior(noMoveBehavior);
        }
    }
}
