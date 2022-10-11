using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMovingState : BossStateBase
{
    [SerializeField] int _damageAmount = 2;
    IDamageable damageableObject;
    public override void EnterState(BossStateManager boss, ParticleSystem idleParticle, Patrol patrol, BossSpawnMinies spawnMinies)
    {
        // start movement
        patrol.enabled = true;
        spawnMinies.enabled = true;
    }    

    public override void UpdateState(BossStateManager boss)
    {
        // check health, if health is on half, start ArrackState
        
    }

    public override void OnTriggerEnter(BossStateManager boss, Collider collider, ParticleSystem idleParticle, Patrol patrol, BossSpawnMinies spawnMinies)
    {
        
    }
}
