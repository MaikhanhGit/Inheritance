using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class ProjectileBlaster : MonoBehaviour
{
    IMoveable _moveBehavior;

    [SerializeField] float _travelSpeed = 10;
    [SerializeField] int _damageAmount = 1;
    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        // establish initial projectile move behavior
        _moveBehavior = new LinearMoveBehavior(_rb, _travelSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player == null)
        {
            IDamageable damageableObject = other.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(_damageAmount);
                Destroy(gameObject);
            }
        }                
    }

    private void FixedUpdate()
    {
        _moveBehavior.Move();
        Object.Destroy(gameObject, 3f);
    }

    public void SetMoveBehavior(IMoveable newMoveBehavior)
    {
        // change move behavior
        _moveBehavior = newMoveBehavior;
    }
   
}
