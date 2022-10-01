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

    IFeedbackImpact _impactFeedback;
    IFeedbackKilled _killedFeedback;

    int _currentHealth = 0;
    bool _isInvincible;

    public int CurrentHealth => _currentHealth;
    public int MaxHealth => _maxHealth;    

    private void Awake()
    {
        UpdateHealthDisplay(_maxHealth);
        _currentHealth = _maxHealth;        
        _isInvincible = false;
        _impactFeedback = GetComponent<IFeedbackImpact>();
        _killedFeedback = GetComponent<IFeedbackKilled>();
    }    

    void UpdateHealthDisplay(int currentHealth)
    {
        _healthDisplay.text = currentHealth.ToString();
    }
    
    public void TakeDamage(int amount)
    {        
        if(_isInvincible == false)
        {
            // damage behavior
            _currentHealth -= amount;            
            if (_currentHealth <= 0)
            {
                Kill();
            }
            // update health bar
            UpdateHealthDisplay(_currentHealth);
            // activate impact feedback
            _impactFeedback?.StartFeedback();
            
            
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
            _killedFeedback?.StartFeedback();
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
