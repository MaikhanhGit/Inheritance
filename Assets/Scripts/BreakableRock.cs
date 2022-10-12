using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableRock : DestroyableBase, IDamageable
{
    public void TakeDamage(int amount)
    {
        Kill();
    }
    public void Kill()
    {
        if (DestroyParticle)
        {
            ParticleSystem destroyParticle = Instantiate
                (DestroyParticle, ParticleSpawnPosition.position, Quaternion.identity);
            destroyParticle.Play();
            
        }
        
        if(DestroySFX)
        {
            AudioHelper.PlayClip2D(DestroySFX, 1);
        }

        ObjectToBeDestroyed.SetActive(false);
    }

    
}
