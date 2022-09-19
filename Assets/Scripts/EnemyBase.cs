using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemyBase: MonoBehaviour
{    
    [SerializeField] int _damageAmountOnCollision = 0;
    protected int DamageAmount => _damageAmountOnCollision;
    [SerializeField] ParticleSystem _impactParticle;
    protected ParticleSystem ImpactParticle => _impactParticle;
    [SerializeField] AudioClip _impactSound;
    protected AudioClip ImpactSound => _impactSound;
    [SerializeField] GameObject _objectToDestroy;
    protected GameObject ObjectToDesTroy => _objectToDestroy;
        
    public abstract void ImpactFeedback();
               
}
