using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        float mass = gameObject.GetComponent<Rigidbody>().mass;
        _rb.AddForce(0, mass * -9.81f, 0);
        MoveTank();
        TurnTank();
    }

    public void MoveTank()
    {
        // calculate the move amount
        //float moveAmountThisFrame = Input.GetAxis("Vertical") * _maxSpeed * 200;
        // create a vector from amount and direction
        //Vector3 moveOffset = transform.forward * moveAmountThisFrame;
        // apply vector to the rigidbody
        //_rb.MovePosition(_rb.position + moveOffset);
        // technically adjusting vector is more accurate! (but more complex)
        
        float vertical = Input.GetAxis("Vertical");
        _rb.velocity = (transform.forward * vertical) * 200 * _maxSpeed * Time.fixedDeltaTime;


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
