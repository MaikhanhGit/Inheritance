using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killer : EnemyBase, IDamageable
{
    IDamageable _damagableObject;
    IFeedbackKilled _killedFeedback;

    [SerializeField] float _startSpeed = 150;
    [SerializeField] ParticleSystem _startParticle;
    [SerializeField] AudioClip _startSound;

    Rigidbody _rb;

    private void Awake()
    {
        _killedFeedback = GetComponent<IFeedbackKilled>();
        _rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        _rb.AddForce(transform.forward * _startSpeed * -1);
        ParticleSystem startParticle = Instantiate(_startParticle, transform.position, Quaternion.identity);
        startParticle.Play();
        Object.Destroy(startParticle, 2f);
        AudioHelper.PlayClip2D(_startSound, 1);
        
    }

    private void OnCollisionEnter(Collision other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            _damagableObject = player.GetComponent<IDamageable>();
            if (_damagableObject != null)
            {
                _damagableObject.Kill();
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
