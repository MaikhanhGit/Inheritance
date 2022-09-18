using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public abstract class EnemyBase: MonoBehaviour
{    public abstract void DoDamage(Player player);

    IMoveable _moveBehavior;

    [SerializeField] int _doDamageAmount = 0;
    protected int DoDamageAmount => _doDamageAmount;
    [SerializeField] float _travelSpeed = 10;

    Transform _objectTransform;
    Rigidbody _rb;
    Rigidbody ObjectRigidBody => _rb;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
        _moveBehavior = new LinearMoveBehavior(_rb, _travelSpeed);
    }

    private void FixedUpdate()
    {
        _moveBehavior.Move();
    }

    public void SetEnemyMovement(IMoveable newMoveBehavior)
    {
        newMoveBehavior.Move();
    }
   
}
