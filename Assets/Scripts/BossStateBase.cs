using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BossStateBase
{    

    public abstract void EnterState (BossStateManager boss, ParticleSystem idleParticle, Patrol patrol, BossSpawnMinies spawnMinies);

    public abstract void UpdateState(BossStateManager boss);

    public abstract void OnTriggerEnter(BossStateManager boss, Collider collider, ParticleSystem idleParticle, Patrol patrol, BossSpawnMinies spawnMinies);
}

