using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(Collider))]
public abstract class PowerUpBase : MonoBehaviour    
{
    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);
    

    [SerializeField] float _powerUpDuration = 5f;
    [SerializeField] float _powerUpAmount = 1f;
    [SerializeField] float _movementSpeed = 1f;
    [SerializeField] ParticleSystem _powerUpParticles;
    protected ParticleSystem PowerUpParticle => _powerUpParticles;

    [SerializeField] AudioClip _powerUpSFX = null;
    protected AudioClip PowerUpSFX => _powerUpSFX;

    [SerializeField] AudioClip _powerDownSFX = null;
    protected AudioClip PowerDownSFX => _powerDownSFX = null  ;

    [SerializeField] GameObject _objectVisualToDisable;

    Rigidbody _rb = null;
    protected Rigidbody ObjectRigidBody => _rb;
    Collider _collider = null;
    protected Collider ObjectCollider => _collider;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Movement(_rb);
    }    

    protected virtual void Movement(Rigidbody rb)
    {
        // movement of the pickUp object
        Quaternion turnOffset = Quaternion.Euler(0, _movementSpeed, 0);
        rb.MoveRotation(_rb.rotation * turnOffset);
    }

    IEnumerator powerUpActivated(Player player, float duration)
    {        
        PowerUp(player);
        yield return new WaitForSeconds(duration);
        PowerDown(player);
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();
        
        if(player != null) 
        {            
            // disable powerUp visually
            _objectVisualToDisable.SetActive(false);
            // disable Collider
            gameObject.GetComponent<Collider>().enabled = false;
            // start timer
            StartCoroutine(powerUpActivated(player, _powerUpDuration));            
        }
    }
    
}
