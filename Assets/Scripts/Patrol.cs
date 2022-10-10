using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] float _travelSpeed = 10;
    [SerializeField] Transform[] _moveSpots;
    [SerializeField] float _waitTime = 4;
    [SerializeField] ParticleSystem _spawnPositionSignal;
    [SerializeField] float _spawnDelayTime = 3.5f;

    float _currentWaitTime;
    int _randomSpot;
    int _newRandomSpot;
    public bool _startPatrol = false;
    bool _bossCanMove = true;
    bool _gotNewSpot = false;
    // get a location
    // spawn particle at the location
    // boss move toward the location
    // count time
    // get a new location...

    private void Start()
    {
        _currentWaitTime = _waitTime;
        _randomSpot = Random.Range(0, _moveSpots.Length);
        _newRandomSpot = _randomSpot;        
    }

    private void Update()
    {  
        BossMoveToNewLocation(_newRandomSpot);
       

        if (Vector3.Distance(transform.position, _moveSpots[_newRandomSpot].position) <= 0.2f)
        {            

            if (_currentWaitTime <= _spawnDelayTime && _currentWaitTime > 0 && _gotNewSpot == false)
            {                
                _bossCanMove = false;
                _newRandomSpot = Random.Range(0, _moveSpots.Length);
                Transform newSpot = _moveSpots[_newRandomSpot];
                // play signal particle before moving to new position
                ParticleSystem _signal = Instantiate
                (_spawnPositionSignal, newSpot.position, Quaternion.identity);
                _signal.Play();
                Object.Destroy(_signal, _spawnDelayTime + 1);
                _gotNewSpot = true;
            }

            else if(_currentWaitTime <= 0   
                
                )
            {                
                _bossCanMove = true;
                _gotNewSpot = false;
                _currentWaitTime = _waitTime;
            }
            else
            {
                _currentWaitTime -= Time.deltaTime;
                Debug.Log(_currentWaitTime);
            }
                               
                    
        }
        
    }

    private void BossMoveToNewLocation(int newLocation)
    { 
            transform.position = Vector3.MoveTowards
            (transform.position, _moveSpots[newLocation].position, _travelSpeed * Time.deltaTime);       
                        
    }

}
