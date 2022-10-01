using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackState : BossStateBase
{    
    public override void EnterState(BossStateManager boss, ParticleSystem idleParticle, Patrol patrol)
    {
        // stop patrolling
        patrol.enabled = false;
        // move Boss to the middle
        boss.transform.position = new Vector3 (0, 2, 0);
        // play animation of Boss bouncing down in the middle
        // Start Attacking mode
    }

    public override void UpdateState(BossStateManager boss)
    {
        
    }

    public override void OnTriggerEnter(BossStateManager boss, Collider collider, ParticleSystem idleParticle, Patrol patrol)
    {
        
    }
}
