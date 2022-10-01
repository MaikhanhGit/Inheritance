using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TankController))]
public class Player : MonoBehaviour
{    
    TankController _tankController;
    IDamageable _damageableObject;

    private void Awake()
    {
        _tankController = GetComponent<TankController>();
    }
    
}
