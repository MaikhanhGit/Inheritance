using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{
    [SerializeField] int _damageAmountOnCollision = 1;
    

    IDamageable damageableObject;
    Rigidbody _rb;
    Health _health;

    public event Action DamagedVisual = delegate { };
    public event Action AngryVisual = delegate { };

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _health = GetComponent<Health>();
    }

    private void Update()
    {
        if(_health.CurrentHealth < ((_health.MaxHealth) / 2))
        {
            StartAngryVisual();
        }
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

    public void StartAngryVisual()
    {
        AngryVisual?.Invoke();
    }

}
