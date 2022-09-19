using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TankController : MonoBehaviour
{
    [SerializeField] float _maxSpeed = 3;
    [SerializeField] float _turnSpeed = 1.5f;

    Rigidbody _rb = null;

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
        MoveTank();
        TurnTank();        
    }

    
    public void MoveTank()
    {
        /*
        // calculate the move amount
        float moveAmountThisFrame = Input.GetAxis("Vertical") * _maxSpeed;
        // create a vector from amount and direction
        Vector3 moveOffset = transform.forward * moveAmountThisFrame;
        // apply vector to the rigidbody
        _rb.MovePosition(_rb.position + moveOffset*Time.fixedDeltaTime);
        // technically adjusting vector is more accurate! (but more complex)        
        */
        
        float vertical = Input.GetAxis("Vertical");
        _rb.velocity = (transform.forward * vertical) * 200 * _maxSpeed * Time.fixedDeltaTime;
        // add gravity force
        float mass = _rb.mass;
        _rb.AddForce(Physics.gravity);        

    }

    public void TurnTank()
    {
        // calculate the turn amount
        //float turnAmountThisFrame = Input.GetAxis("Horizontal") * _turnSpeed;
        // create a Quaternion from amount and direction (x,y,z)
        //Quaternion turnOffset = Quaternion.Euler(0, turnAmountThisFrame, 0);
        // apply quaternion to the rigidbody
        //_rb.MoveRotation(_rb.rotation * turnOffset);
        float horizontal = Input.GetAxis("Horizontal");
        transform.Rotate((transform.up * horizontal) * 100 * _turnSpeed * Time.fixedDeltaTime);
    }
    
}
