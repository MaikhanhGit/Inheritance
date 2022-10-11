using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossStateBase
{    

    GameObject _player;    

    public override void EnterState(BossStateManager boss, ParticleSystem idleParticle, Patrol patrol, BossSpawnMinies spawnMinies, BossAttackStateBehaviors attackStateBehaviors)
    {
        // stop patrolling
        patrol.enabled = false;
        // stop spawnMinies
        spawnMinies.enabled = false;
        // move Boss to the middle
        boss.transform.position = new Vector3 (0, 2, 0);

        attackStateBehaviors.enabled = true;
        
        

    }

    public override void UpdateState(BossStateManager boss)
    {
        
    }

    public override void OnTriggerEnter(BossStateManager boss, Collider collider, ParticleSystem idleParticle, Patrol patrol, BossSpawnMinies spawnMinies)
    {
        
    }
}
