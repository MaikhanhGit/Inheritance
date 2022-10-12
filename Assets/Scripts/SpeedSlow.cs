using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SpeedSlow : CollectibleBase
{
    [SerializeField] float _speedAmount = 1f;
    [SerializeField] float _duration = 5f;
    [SerializeField] float _selfMoveSpeed = 1000;
    [SerializeField] GameObject _artToDisable;
    GameObject _player;
    Rigidbody _rb;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _rb = GetComponent<Rigidbody>();
        transform.LookAt(_player?.transform);
    }

    private void Start()
    {        
        _rb.AddForce(transform.forward * _selfMoveSpeed );
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Collect(player);
            
            
        }
    }

    protected override void Collect(Player player)
    {
        _artToDisable.SetActive(false);
        gameObject.GetComponent<Collider>().enabled = false;
        AudioHelper.PlayClip2D(CollectSound, 1);
        ParticleSystem collectParticle = Instantiate
            (CollectParticle, CollectParticleSpawnPosition.position, Quaternion.identity);
        collectParticle.Play();
        
        SpeedChangeOnTimer speedChangeOnTimer;
        speedChangeOnTimer = player.GetComponent<SpeedChangeOnTimer>();
        if(speedChangeOnTimer != null)
        {
            speedChangeOnTimer.SlowSpeed(_speedAmount, _duration);
        }        
    }

    protected override void Move(Rigidbody rb)
    {
        
    }
}
