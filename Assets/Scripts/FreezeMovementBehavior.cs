using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FreezeMovementBehavior : IMoveable
{
    Rigidbody _rb;

    public FreezeMovementBehavior(Rigidbody rb)
    {
        _rb = rb;
        _rb.velocity = Vector3.zero;
    }

    public void Move()
    {
        // no movement
    }
}

