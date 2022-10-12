using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{
    [SerializeField] GameObject _objecToBeDisable;
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
            if (_objecToBeDisable != null)
            {
                _objecToBeDisable.SetActive(false);
            }
            _tankController.enabled = false;
            FindObjectOfType<Manager>()?.GameOver();           
        }        
    }
   
}
