using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackImpactEnemy : MonoBehaviour, IFeedbackImpact
{
    [SerializeField] ParticleSystem _impactParticle;
    [SerializeField] AudioClip _impactSound;    

    public void StartFeedback()
    {
        // particles
        if (_impactParticle != null)
        {            
            ParticleSystem impactParticle = Instantiate
                (_impactParticle, transform.position, Quaternion.identity);
            impactParticle.Play();

            // delayed destroyed            
            Destroy(impactParticle, 3f);            
        }
        // Sound
        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }
}
