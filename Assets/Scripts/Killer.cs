using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : EnemyBase, IDamageable
{
    IDamageable damagableObject;

    
    public void Kill()
    {
        ImpactFeedback();
        gameObject.GetComponent<Collider>().enabled = false;
        ObjectToDesTroy.SetActive(false);
    }

    public void TakeDamage(int amount)
    {
        ImpactFeedback();
        Kill();
    }

    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player)
        {            
            damagableObject = player.GetComponent<IDamageable>();
            if(damagableObject != null)
            {
                damagableObject.Kill();
                ImpactFeedback();
            }            
        }
    }
     

    public override void ImpactFeedback()
    {
        // particles
        if (ImpactParticle  != null)
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
