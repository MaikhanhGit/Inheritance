using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] float _travelSpeed = 25;
    [SerializeField] Transform[] _moveSpots;
    [SerializeField] float _waitTime = 1;
    [SerializeField] ParticleSystem _spawnPositionSignal;
    [SerializeField] float _spawnDelayTime = 2;

    float _currentSpawnDelayTime;
    float _currentWaitTime;
    int _randomSpot;
    int _newRandomSpot;
    public bool _startPatrol = false;
    bool _bossCanMove = true;
    bool _gotNewSpot = false;

    // get a location
    // spawn particle at the location
    // set timer
    // time up, boss move toward the location
    // boss near location, get a new location...

    private void Start()
    {
        // get a location
        GetNewRandomSpot();
        
        // set wait time
        _currentSpawnDelayTime = _spawnDelayTime;
        _currentWaitTime = _waitTime;

        /*
        _currentWaitTime = _waitTime;
        _randomSpot = Random.Range(0, _moveSpots.Length);
        _newRandomSpot = _randomSpot;        
        */
    }

    private void Update()
    {
        BossMoveToNewLocation(_newRandomSpot);        
        
        if (Vector3.Distance(transform.position, _moveSpots[_newRandomSpot].position) <= 0.2f)
        {
            if (_currentSpawnDelayTime <= 0)
            {
                _currentSpawnDelayTime = _spawnDelayTime;
                GetNewRandomSpot();
            }
            else
            {
                _currentSpawnDelayTime -= Time.deltaTime;
            }            

        }                        
        
        /*
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

            }                               
                    
        }
        */
        
    }
    
    private void GetNewRandomSpot()
    {
        _newRandomSpot = Random.Range(0, _moveSpots.Length);        
        // spawn particle
        Transform newSpot = _moveSpots[_newRandomSpot];
        ParticleSystem _signal = Instantiate
        (_spawnPositionSignal, newSpot.position, Quaternion.identity);
        _signal.Play();
                
    }
     private void BossMoveToNewLocation(int newLocation)
    { 
            transform.position = Vector3.MoveTowards
            (transform.position, _moveSpots[newLocation].position, _travelSpeed * Time.deltaTime);       
                        
    }
    

}
