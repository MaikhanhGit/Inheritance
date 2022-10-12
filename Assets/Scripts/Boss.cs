using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Boss : MonoBehaviour
{
    [SerializeField] int _damageAmountOnCollision = 1;
    [SerializeField] GameObject _endGameArtToDisable;

    IDamageable damageableObject;
    Rigidbody _rb;
    Health _health;
    BossAttackStateBehaviors _bossAttackStateBehaviors;
    BossAngryVisual _bossAngryVisual;
    BossSpawnMinies _bossSpawnMinies;
    BossStateManager _bossStateManager;
        
    public event Action DamagedVisual = delegate { };
    public event Action AngryVisual = delegate { };

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _health = GetComponent<Health>();
        _bossAttackStateBehaviors = GetComponent<BossAttackStateBehaviors>();
        _bossAngryVisual = GetComponent<BossAngryVisual>();
        _bossSpawnMinies = GetComponent<BossSpawnMinies>();
        _bossStateManager = GetComponent<BossStateManager>();
    }

    private void Update()
    {
        if(_health.CurrentHealth < ((_health.MaxHealth) / 2))
        {
            StartAngryVisual();
        }

        if (_health.IsDead() == true)
        {            
            if (_bossStateManager || _bossSpawnMinies || _bossAngryVisual || _bossAttackStateBehaviors)
            {                
                _bossStateManager.enabled = false;
                _bossSpawnMinies.enabled = false;
                _bossAngryVisual.enabled = false;
                _bossAttackStateBehaviors.enabled = false;
            }            
            _endGameArtToDisable?.SetActive(false);
            
            
            FindObjectOfType<Manager>()?.Won();
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
