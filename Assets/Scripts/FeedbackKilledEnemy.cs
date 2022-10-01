using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FeedbackKilledEnemy : MonoBehaviour, IFeedbackKilled
{
    [SerializeField] ParticleSystem _killedParticle;
    [SerializeField] AudioClip _killedSound;    

    public void StartFeedback()
    {
        // particles
        if (_killedParticle != null)
        {
            ParticleSystem killedParticle = Instantiate
                (_killedParticle, transform.position, Quaternion.identity);
            killedParticle.Play();

            // delayed destroyed
            Destroy(killedParticle, 3f);
        }
        // Sound
        if (_killedSound != null)
        {
            AudioHelper.PlayClip2D(_killedSound, 1f);
        }
    }
}
