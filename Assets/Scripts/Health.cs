using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class Health : MonoBehaviour, IDamageable, IHealable
{
    [SerializeField] int _maxHealth = 100;
    [SerializeField] int _damageAmount = 1;
    [SerializeField] TextMeshProUGUI _healthDisplay;
    [SerializeField] GameObject _objectToBeDestroyed;
    [SerializeField] AudioClip _killSound;
    [SerializeField] AudioClip _damageSound;
    [SerializeField] ParticleSystem _killParticle;
    [SerializeField] ParticleSystem _damageParticle;
    [SerializeField] Transform _particleSpawnLocation;

    int _currentHealth = 0;
    bool _isInvincible;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;    

    private void Awake()
    {
        _currentHealth = _maxHealth;
        UpdateHealthDisplay(_maxHealth);
        _isInvincible = false;
    }    

    void UpdateHealthDisplay(int currentHealth)
    {
        _healthDisplay.text = currentHealth.ToString();
    }
    
    public void TakeDamage(int amount)
    {        
        if(_isInvincible == false)
        {
            // damage
            _currentHealth -= amount;            
            if (_currentHealth <= 0)
            {
                Kill();
            }
            // update health bar
            UpdateHealthDisplay(_currentHealth);
            // playsound
            AudioHelper.PlayClip2D(_damageSound, 1);
            // play particle

            ParticleSystem damageParticle = Instantiate
                (_damageParticle, _particleSpawnLocation.position, Quaternion.identity);
            damageParticle.Play();
            if (damageParticle)
            {
                Destroy(damageParticle, 3f);
            }
            
        }
        
    }


    public void Kill()
    {
        if(_isInvincible == false)
        {
            UpdateHealthDisplay(0);
            // destroy object
            if (_objectToBeDestroyed != null)
            {
                Destroy(gameObject);
            }
            // play sound
            AudioHelper.PlayClip2D(_killSound, 1);
            // play particle
            ParticleSystem killParticle = Instantiate
                (_killParticle, _particleSpawnLocation.position, Quaternion.identity);
            killParticle.Play();
            if (killParticle)
            {
                Destroy(killParticle, 3f);
            }
        }        
    }

    public void ActivateInvincibility()
    {
        _isInvincible = true;
    }

    public void DeactivateInvincibility()
    {
        _isInvincible = false;        
    }

    public void Heal(int healAmount)
    {
        _currentHealth += healAmount;
    }
}
