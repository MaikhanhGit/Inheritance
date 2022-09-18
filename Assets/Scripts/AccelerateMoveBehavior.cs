using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccelerateMoveBehavior : IMoveable
{
    float _currentSpeed;
    float _accelerateSpeed;
    Rigidbody _rb;
    Transform _objectTransform;

    public AccelerateMoveBehavior(Rigidbody rb, float accelerateSpeed)
    {
        _currentSpeed = 0;
        _rb = rb;
        _accelerateSpeed = accelerateSpeed;
        _objectTransform = _rb.transform;
    }

    public void Move()
    {
        // this assume we're calling Move in FixedUpdate
        _currentSpeed += _accelerateSpeed;
        _rb.velocity = _objectTransform.forward * _currentSpeed;
    }
}
