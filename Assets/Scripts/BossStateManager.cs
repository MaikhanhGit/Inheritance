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

    private void Start()
    {
        // starting state
        _currentState = _idleState;
        _currentState.EnterState(this, _bossIdleParticle, _patrol);

        _patrol = GetComponent<Patrol>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        Player player = collider.GetComponent<Player>();
        if(player != null)
        {            
            _currentState.OnTriggerEnter(this, collider, _bossIdleParticle, _patrol);
        }
        
    }

    private void Update()
    {
        _currentState.UpdateState(this);
    }

    public void SwitchState(BossStateBase state)
    {
        _currentState = state;
        _currentState.EnterState(this, _bossIdleParticle, _patrol);
    }

}
