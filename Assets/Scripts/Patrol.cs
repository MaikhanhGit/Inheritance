using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] float _travelSpeed = 10;
    [SerializeField] Transform[] _moveSpots;
    [SerializeField] float _startWaitTime = 3;

    float _waitTime;
    int _randomSpot;
    public bool _startPatrol = false;

    private void Start()
    {
        _waitTime = _startWaitTime;
        _randomSpot = Random.Range(0, _moveSpots.Length);
    }

    private void Update()
    {        
            // moving randomly among locations
            transform.position = Vector3.MoveTowards(transform.position, _moveSpots[_randomSpot].position, _travelSpeed * Time.deltaTime);

            // delay before moving to another position
            if (Vector3.Distance(transform.position, _moveSpots[_randomSpot].position) < 0.7f)
            {
                if (_waitTime <= 0)
                {
                    _randomSpot = Random.Range(0, _moveSpots.Length);

                    _waitTime = _startWaitTime;
                }
                else
                {
                    _waitTime -= Time.deltaTime;
                }
            }
              

    }
    
}
