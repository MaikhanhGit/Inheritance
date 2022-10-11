using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class FeedbackImpact : MonoBehaviour, IFeedbackImpact
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
                          
        }
        // Sound
        if (_impactSound != null)
        {
            AudioHelper.PlayClip2D(_impactSound, 1f);
        }
    }
    
}
