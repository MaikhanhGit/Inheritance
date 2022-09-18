using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class DestroyableBase : MonoBehaviour
{    
    [SerializeField] GameObject _objectToBeDestroyed = null;
    protected GameObject ObjectToBeDestroyed => _objectToBeDestroyed;

    [SerializeField] ParticleSystem _destroyParticle = null;
    protected ParticleSystem DestroyParticle => _destroyParticle;

    [SerializeField] Transform _particleSpawnPosition = null;
    protected Transform ParticleSpawnPosition => _particleSpawnPosition;

    [SerializeField] AudioClip _destroySFX = null;
    protected AudioClip DestroySFX => _destroySFX;

}
