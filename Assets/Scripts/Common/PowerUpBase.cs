using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PowerUpBase : MonoBehaviour    
{
    protected abstract void PowerUp(Player player);
    protected abstract void PowerDown(Player player);

    [SerializeField] float _powerUpDuration = 5f;
    [SerializeField] float _powerUpAmount = 1f;
    [SerializeField] float _movementSpeed = 1f;
    [SerializeField] ParticleSystem _powerUpParticles;
    [SerializeField] AudioClip _powerUpSFX;
    [SerializeField] GameObject _objectVisualToDisable;

    Rigidbody _rb;

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
        // calculate rotation
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
            FeedBack();
            // disable powerUp visually
            _objectVisualToDisable.SetActive(false);
            // disable Collider
            gameObject.GetComponent<Collider>().enabled = false;
            // start timer
            StartCoroutine(powerUpActivated(player, _powerUpDuration));            
        }
    }
    
    private void FeedBack()
    {
        // VFS
        if(_powerUpParticles != null)
        {
            _powerUpParticles = Instantiate(_powerUpParticles, transform.position, Quaternion.identity);            
        }
        // SFX
        if(_powerUpSFX != null)
        {
            AudioHelper.PlayClip2D(_powerUpSFX, 1);
        }        
    }
}
