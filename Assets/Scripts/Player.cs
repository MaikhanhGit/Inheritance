using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    TankController _tankController;
    Health _health;        

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
        _health = GetComponent <Health>();
    }

    private void Update()
    {        
        if(_health.IsDead() == true)
        {
            _tankController.enabled = false;
            FindObjectOfType<GameManager>()?.GameOver();           
        }        
    }
   
}
