using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossIdleState : BossStateBase
{ 

    public override void EnterState(BossStateManager boss, ParticleSystem idleParticle)
    {
        idleParticle.Play();        
    }

    public override void UpdateState(BossStateManager boss)
    {
        
    }

    public override void OnTriggerEnter(BossStateManager boss, Collider collider, ParticleSystem idleParticle)
    {
        if (idleParticle)
        {
            idleParticle.Stop();
        }
            
    }
   

    
}
