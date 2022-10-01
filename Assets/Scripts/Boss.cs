using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{
    [SerializeField] int _damageAmountOnCollision = 1;

    IDamageable damageableObject;
    Rigidbody _rb;    

    public event Action DamagedVisual = delegate { };

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();        
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if (player != null)
        {
            damageableObject = other.GetComponent<IDamageable>();
            if (damageableObject != null)
            {
                damageableObject.TakeDamage(_damageAmountOnCollision);
            }
        }

        ProjectileBlaster _projectileBlaster = other.GetComponent<ProjectileBlaster>();
        ProjectileLauncher _projectileLauncher = other.GetComponent<ProjectileLauncher>();       
        
        if(_projectileBlaster != null || _projectileLauncher != null)
        {            
            StartDamagedVisual();
        }
    }
    
    public void StartDamagedVisual()
    {
        DamagedVisual?.Invoke();
        
    }

}
