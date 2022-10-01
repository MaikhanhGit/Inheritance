using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int _damageAmountOnCollision = 1;
        
    IDamageable damageableObject;
    Rigidbody _rb;
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();        
    }

    private void OnCollisionEnter(Collision other)
    {
        damageableObject = other.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(_damageAmountOnCollision);
        }
    }        
   
}
