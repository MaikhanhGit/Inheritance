using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Damager : EnemyBase, IDamageable
{
    IDamageable damagableObject;

    public void Kill()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int amount)
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {
            damagableObject = player.GetComponent<IDamageable>();
            damagableObject.TakeDamage(DamageAmount);
            ImpactFeedback();
        }
    }
    public override void ImpactFeedback()
    {
        // particles
        if (ImpactParticle != null)
        {
            ParticleSystem impactParticle = Instantiate
                (ImpactParticle, transform.position, Quaternion.identity);
            if (impactParticle)
            {
                Object.Destroy(impactParticle, 3f);
            }

        }
        // audio. TOD - consider Object Pooling for performance
        if (ImpactSound != null)
        {
            AudioHelper.PlayClip2D(ImpactSound, 1f);
        }
    }
}
