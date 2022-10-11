using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSlow : CollectibleBase
{
    [SerializeField] float _speedAmount = 1f;
    [SerializeField] float _duration = 5f;
    [SerializeField] float _selfMoveSpeed = 1000;

    GameObject _player;

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        transform.LookAt(_player?.transform);
    }

    private void Start()
    {        
        ObjectRigidBody?.AddForce(transform.forward * _selfMoveSpeed);
    }

    private void FixedUpdate()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Collect(player);

            gameObject.SetActive(false);
        }
    }

    protected override void Collect(Player player)
    {
        AudioHelper.PlayClip2D(CollectSound, 1);
        ParticleSystem collectParticle = Instantiate
            (CollectParticle, CollectParticleSpawnPosition.position, Quaternion.identity);
        collectParticle.Play();
        Object.Destroy(collectParticle, 3f);
        SpeedChangeOnTimer speedChangeOnTimer;
        speedChangeOnTimer = player.GetComponent<SpeedChangeOnTimer>();
        if(speedChangeOnTimer != null)
        {
            speedChangeOnTimer.SlowSpeed(_speedAmount, _duration);
        }        
    }

    protected override void Move(Rigidbody rb)
    {
        base.Move(rb);
    }
}
