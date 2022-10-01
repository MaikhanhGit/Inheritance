using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemyBase: MonoBehaviour
{    
    [SerializeField] int _damageAmountOnCollision = 0;
    protected int DamageAmount => _damageAmountOnCollision;
    
   
    [SerializeField] GameObject _objectToDestroy;
    protected GameObject ObjectToDesTroy => _objectToDestroy;                   
}
