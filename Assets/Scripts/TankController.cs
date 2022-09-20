using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankController : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 3;
    [SerializeField] float _turnSpeed = 1.5f;

    Rigidbody _rb = null;
    Vector3 moveDirection;

    public float MaxSpeed
    {
        get => _maxSpeed;
        set => _maxSpeed = value;
    }

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }
   
    private void FixedUpdate()
    {
        float mass = _rb.mass;
        _rb.AddForce(Physics.gravity*mass);
        MoveTank();
        TurnTank();
    }
    
    public void MoveTank()
    {        
        float moveAmountThisFrame = Input.GetAxis("Vertical") * _maxSpeed; 
        Vector3 moveOffset = transform.forward * moveAmountThisFrame;
        _rb.MovePosition(_rb.position + moveOffset * Time.fixedDeltaTime);
        
    }

    public void TurnTank()
    {
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate((transform.up * horizontal) * 100 * _turnSpeed * Time.fixedDeltaTime);
        
    }
    
}
