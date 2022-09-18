using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Rigidbody))]
public class Enemy : MonoBehaviour
{
    [SerializeField] int _damageAmountOnCollision = 1;
    [SerializeField] ParticleSystem _impactParticles;
    [SerializeField] AudioClip _impactSound;

    Rigidbody _rb;
    IDamageable damageableObject;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision other)
    {        
        Player player = other.gameObject.GetComponent<Player>();
        if(player != null)
        {
            damageableObject = player.GetComponent<IDamageable>();
            damageableObject.TakeDamage(_damageAmountOnCollision);
            ImpactFeedback();
        }
    }    

    private void ImpactFeedback()
    {
        // particles
        if(_impactParticles != null)
        {
            ParticleSystem impactParticle = Instantiate
                (_impactParticles, transform.position, Quaternion.identity);
            if (impactParticle)
            {
                Object.Destroy(impactParticle, 3f);
            }
            
        }
        // audio. TOD - consider Object Pooling for performance
        if(_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }    
   
}
