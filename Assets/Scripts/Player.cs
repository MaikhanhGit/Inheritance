using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] int _maxHealth = 3;
    [SerializeField] AudioClip _killSFX;
    int _currentHealth;

    TankController _tankController;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }

    private void Start()
    {
        _currentHealth = _maxHealth;
    }

    public void IncreaseHealth(int amount)
    {
        _currentHealth = Mathf.Clamp(_currentHealth, 0, _maxHealth);        
        _currentHealth += amount;        
    }

    public void DecreaseHealth(int amount)
    {
        _currentHealth -= amount;        
        if(_currentHealth <= 0)
        {
            Kill();
        }        
    }

    public void Kill()
    {
        gameObject.SetActive(false);
        //play Particles
        //play sounds
        AudioHelper.PlayClip2D(_killSFX, 1);

    }

}
