using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossStateBase
{
    [SerializeField] int _damageAmount = 3;
    public override void EnterState(BossStateManager boss, ParticleSystem idleParticle, Patrol patrol, BossSpawnMinies spawnMinies)
    {
        // stop patrolling
        patrol.enabled = false;
        // stop spawnMinies
        spawnMinies.enabled = false;
        // move Boss to the middle
        boss.transform.position = new Vector3 (0, 2, 0);
        // turn on Boss Angry visual
        
        // play animation of Boss bouncing down in the middle
        // Start Attacking mode
    }

    public override void UpdateState(BossStateManager boss)
    {
        
    }

    public override void OnTriggerEnter(BossStateManager boss, Collider collider, ParticleSystem idleParticle, Patrol patrol, BossSpawnMinies spawnMinies)
    {
        
    }
}
