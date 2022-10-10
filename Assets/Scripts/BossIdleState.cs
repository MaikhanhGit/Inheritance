using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossStateBase
{ 

    public override void EnterState(BossStateManager boss, ParticleSystem idleParticle, Patrol patrol)
    {
        idleParticle.Play();        
    }

    public override void UpdateState(BossStateManager boss)
    {
        
    }

    public override void OnTriggerEnter(BossStateManager boss, Collider collider, ParticleSystem idleParticle, Patrol patrol)
    {
        if (idleParticle)
        {
            idleParticle.Stop();
            boss.SwitchState(boss._movingState);
        }
            
    } 
    
}
