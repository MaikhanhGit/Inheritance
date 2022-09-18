using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossStateBase
{    

    public abstract void EnterState (BossStateManager boss, ParticleSystem idleParticle);

    public abstract void UpdateState(BossStateManager boss);

    public abstract void OnTriggerEnter(BossStateManager boss, Collider collider, ParticleSystem idleParticle);
}

