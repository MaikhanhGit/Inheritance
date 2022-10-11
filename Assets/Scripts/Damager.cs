using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damager : EnemyBase, IDamageable
{
    IDamageable _damagableObject;
    IFeedbackKilled _killedFeedback;
        
    [SerializeField] float _distanceToStartFollow = 5;
    [SerializeField] float _moveSpeed = 1;
    [SerializeField] float _startSpeed = 700;
    [SerializeField] ParticleSystem _startParticle;
    [SerializeField] AudioClip _startSound;

    float _distance;    
    Rigidbody _rb;
    GameObject _player;    

    private void Awake()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _killedFeedback = GetComponent<IFeedbackKilled>();
        _rb = GetComponent<Rigidbody>();        

    }

    private void Start()
    {
        transform.LookAt(_player?.transform);
        _rb.AddForce(transform.forward * _startSpeed);        
        ParticleSystem startParticle = Instantiate(_startParticle, transform.position, Quaternion.identity);
        startParticle.Play();
        Object.Destroy(startParticle, 2f);
        AudioHelper.PlayClip2D(_startSound, 1);
    }
    private void Update()
    {
        if(_player != null)
        {
            transform.LookAt(_player.transform); 

            _distance = Vector3.Distance(_player.transform.position, transform.position);
            if (_distance <= _distanceToStartFollow)
            {                
                _rb.AddForce(transform.forward * _moveSpeed);
            }
        }
       
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
