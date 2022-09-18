using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class CollectibleBase : MonoBehaviour
{
    protected abstract void Collect(Player player);
        
    [SerializeField] float _movementSpeed = 1f;
    protected float MovementSpeed => _movementSpeed;

    [SerializeField] ParticleSystem _collectParticle = null;
    protected ParticleSystem CollectParticle => _collectParticle;

    [SerializeField] Transform _collectParticleSpawnPosition = null;
    protected Transform CollectParticleSpawnPosition => _collectParticleSpawnPosition;

    [SerializeField] AudioClip _collectSound = null;
    protected AudioClip CollectSound => _collectSound;
    Rigidbody _rb = null;
    protected Rigidbody ObjectRigidBody => _rb;

    Collider _collider = null;
    protected Collider ObjectCollider => _collider;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    private void FixedUpdate()
    {
        Move(_rb);
    }    

    protected virtual void Move(Rigidbody rb)
    {
        // calculate rotation
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }

}



