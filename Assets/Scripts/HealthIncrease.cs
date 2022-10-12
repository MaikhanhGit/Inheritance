using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthIncrease : CollectibleBase
{
    IHealable healAbleObject;

    [SerializeField] int _healAmount = 5;
    [SerializeField] float _selfMoveSpeed = 700;
    [SerializeField] GameObject _artToDisable;

    Rigidbody _rb;
    GameObject _player;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(_player?.transform);
    }

    private void Start()
    {
        _rb.AddForce(transform.forward * _selfMoveSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        healAbleObject = other.GetComponent<IHealable>();
        Player _player = other.GetComponent<Player>();

        if (healAbleObject != null && _player)
        {
            Collect(_player);
        }
    }

    protected override void Collect(Player player)
    {
        healAbleObject.Heal(_healAmount);

        _artToDisable.SetActive(false);
        gameObject.GetComponent<Collider>().enabled = false;        
        // sfx
        AudioHelper.PlayClip2D(CollectSound, 1);
        // play particle
        ParticleSystem collectParticle = Instantiate
            (CollectParticle, CollectParticleSpawnPosition.position, Quaternion.identity);
        collectParticle.Play();

    }

    
}
