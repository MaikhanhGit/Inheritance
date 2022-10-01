using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : EnemyBase, IDamageable
{
    IDamageable _damagableObject;
    IFeedbackKilled _killedFeedback;

    private void Awake()
    {
        _killedFeedback = GetComponent<IFeedbackKilled>();
    }
    private void OnCollisionEnter(Collision other)
    {
        // check if player
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            _damagableObject = player.GetComponent<IDamageable>();
            if(_damagableObject != null)
            {
                _damagableObject.TakeDamage(DamageAmount);
            }                      
        }
    }
    public void TakeDamage(int amount)
    {
        Kill();
    }

    public void Kill()
    {
        _killedFeedback?.StartFeedback();
        gameObject.GetComponent<Collider>().enabled = false;
        ObjectToDesTroy.SetActive(false);
    }
}
