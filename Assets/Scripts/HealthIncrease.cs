using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : CollectibleBase
{
    IHealable healAbleObject;

    [SerializeField] int _healAmount = 3;
    [SerializeField] float _selfMoveSpeed = 1000;

    private void FixedUpdate()
    {
        ObjectRigidBody.velocity = (transform.forward * _selfMoveSpeed * Time.deltaTime * -1);
    }

    protected override void Collect(Player player)
    {
        // sfx
        AudioHelper.PlayClip2D(CollectSound, 1);
        // play particle
        CollectParticle.Play();

    }

    private void OnTriggerEnter(Collider other)
    {
        healAbleObject = other.GetComponent<IHealable>();
        if(healAbleObject != null)
        {
            healAbleObject.Heal(_healAmount);
        }
    }
}
