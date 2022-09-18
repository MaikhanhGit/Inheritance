using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossStateBase
{
    [SerializeField] int _damageAmount = 3;
    public override void EnterState(BossStateManager boss, ParticleSystem idleParticle, Patrol patrol)
    {
        // start attacking behavior
    }

    public override void UpdateState(BossStateManager boss)
    {
        
    }

    public override void OnTriggerEnter(BossStateManager boss, Collider collider, ParticleSystem idleParticle, Patrol patrol)
    {
        
    }
}
