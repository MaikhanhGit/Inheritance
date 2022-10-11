using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public abstract class CollectibleBase : MonoBehaviour
{
    protected abstract void Collect(Player player);
        
    [SerializeField] float _movementSpeed = 1f;
    protected float MovementSpeed => _movementSpeed;

    [SerializeField] ParticleSystem _collectParticle = null;
    protected ParticleSystem CollectParticle => _collectParticle;

    [SerializeField] Transform _collectParticleSpawnPosition = null;
    protected Transform CollectParticleSpawnPosition => _collectParticleSpawnPosition;

    [SerializeField] AudioClip _collectSound = null;
    protected AudioClip CollectSound => _collectSound;
    

   

    private void Awake()
    {
       
    }

    private void FixedUpdate()
    {
      
    }    

    protected virtual void Move(Rigidbody rb)
    {
        
    }

}



