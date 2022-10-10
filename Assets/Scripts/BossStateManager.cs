using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStateManager : MonoBehaviour
{
    BossStateBase _currentState;
    public BossIdleState _idleState = new BossIdleState();
    public BossMovingState _movingState = new BossMovingState();
    public BossAttackState _attackState = new BossAttackState();

    [SerializeField] public ParticleSystem _bossIdleParticle;
    Patrol _patrol;
    Health _bossHealth;
    float _bossCurrentHealth;
    float _bossMaxHealth;

    private void Start()
    {
        // starting state
        _currentState = _idleState;
        _currentState.EnterState(this, _bossIdleParticle, _patrol);

        _patrol = GetComponent<Patrol>();
        // get boss Health
        _bossHealth = GetComponent<Health>();
        _bossMaxHealth = _bossHealth.MaxHealth;
    }

    private void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();
        ProjectileBlaster blasterProjectile = collider.gameObject.GetComponent<ProjectileBlaster>();
        ProjectileLauncher launcherProjectile = collider.gameObject.GetComponent<ProjectileLauncher>();

        if (player || blasterProjectile || launcherProjectile)
        {            
            _currentState.OnTriggerEnter(this, collider, _bossIdleParticle, _patrol);
        }
        
    }

    private void Update()
    {
        _currentState.UpdateState(this);
        // check boss current health
        _bossCurrentHealth = _bossHealth.CurrentHealth;
        
        if (_bossCurrentHealth < (_bossMaxHealth/2))
        {            
            SwitchState(_attackState);
        }        
    }

    public void SwitchState(BossStateBase state)
    {
        _currentState = state;
        _currentState.EnterState(this, _bossIdleParticle, _patrol);
    }

}
