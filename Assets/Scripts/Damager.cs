using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public class Damager : EnemyBase
{
    Rigidbody _rb;

    private void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    public override void DoDamage(Player player)
    {
        Health health = player.GetComponent<Health>();
        health.TakeDamage(DoDamageAmount);
    }

   
    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        if(player != null)
        {
            DoDamage(player);
        }
    }
}
