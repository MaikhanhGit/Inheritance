using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class GravitySimulation : MonoBehaviour
{
    Rigidbody _rb;
    float _speed;
    float _angularSpeed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        _speed = _rb.velocity.magnitude;
        _angularSpeed = _rb.angularVelocity.magnitude;

        _rb.AddForce(Vector3.down * 100);
    }
}
