using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    [SerializeField] AudioClip _killSFX;
    [SerializeField] TextMeshProUGUI _healthDisplay;

    int _currentHealth;
    bool isInvincible = false;

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
        UpdateHealthDisplay(_maxHealth);
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }
        
    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);        
        _currentHealth += amount;
        // update Health display
        UpdateHealthDisplay(_currentHealth);
        Debug.Log("Current Health after Increase: " + _currentHealth);
    }

    public void DecreaseHealth(int amount)
    {
        if(isInvincible == false)
        {
            _currentHealth -= amount;
            // update Health display
            UpdateHealthDisplay(_currentHealth);
            Debug.Log("Current Health after Decrease: " + _currentHealth);
            if (_currentHealth <= 0)
            {
                Kill();
            }
        }             
    }

    public void Kill()
    {
        if(isInvincible == false)
        {
            gameObject.SetActive(false);
            //play Particles
            //play sounds
            AudioHelper.PlayClip2D(_killSFX, 1);
        }       
    }

    public void InvincibilityActivated()
    {
        isInvincible = true;
    }

    public void InvincibilityDeactivated()
    {
        isInvincible = false;
    }

    private void UpdateHealthDisplay(int currentHealth)
    {
        _healthDisplay.text = currentHealth.ToString();
    }

}
