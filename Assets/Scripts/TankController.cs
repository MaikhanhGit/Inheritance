using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 3f;
    [SerializeField] float _turnSpeed = 1.5f;
    
    public float MaxSpeed
    {
        get => _maxSpeed;
        set => _maxSpeed = value;        
    }

    Rigidbody _rb = null;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        MoveTank();
        TurnTank();
    }

    public void MoveTank()
    {
        // calculate the move amount
        //float moveAmountThisFrame = Input.GetAxis("Vertical") * _maxSpeed;
        // create a vector from amount and direction
        //Vector3 moveOffset = transform.forward * moveAmountThisFrame;
        // apply vector to the rigidbody
        //_rb.MovePosition(_rb.position + moveOffset);

        // move tank using velocity        
        float vertical = Input.GetAxis("Vertical");        
        _rb.velocity = (transform.forward * vertical) * 200 * _maxSpeed * Time.fixedDeltaTime;
        
        // technically adjusting vector is more accurate! (but more complex)
    }
    
    public void TurnTank()
    {
        // calculate the turn amount
        //float turnAmountThisFrame = Input.GetAxis("Horizontal") * _turnSpeed;
        // create a Quaternion from amount and direction (x,y,z)
        //Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        // apply quaternion to the rigidbody
        //_rb.MoveRotation(_rb.rotation * turnOffset);

        // turn using velocity
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate((transform.up * horizontal) * 100 * _turnSpeed * Time.fixedDeltaTime);
    }
}
