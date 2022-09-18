using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowField : MonoBehaviour
{
    [SerializeField] float _accelerateAmount = .2f;

    private void OnTriggerEnter(Collider other)
    {
        Projectile incomingProjectile =
            other.GetComponent<Projectile>();
        // if it's a valid projectile, apply new movement behavior
        if(incomingProjectile != null)
        {
            AccelerateMoveBehavior slowStart = new AccelerateMoveBehavior
                (other.attachedRigidbody, _accelerateAmount);
            incomingProjectile.SetMoveBehavior(slowStart);
        }
    }
}
