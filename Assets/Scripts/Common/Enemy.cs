using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int _damageAmountOnCollision = 1;
        
    IDamageable damageableObject;
<<<<<<< HEAD
    Rigidbody _rb;    
=======
    Rigidbody _rb;
>>>>>>> main
    
    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();        
    }

    private void OnCollisionEnter(Collision other)
    {
<<<<<<< HEAD
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null)
        {
            damageableObject = other.gameObject.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(_damageAmountOnCollision);
            }
        }        
=======
        damageableObject = other.gameObject.GetComponent<IDamageable>();
        if (damageableObject != null)
        {
            damageableObject.TakeDamage(_damageAmountOnCollision);
        }
>>>>>>> main
    }        
   
}
