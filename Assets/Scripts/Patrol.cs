using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    [SerializeField] float _travelSpeed = 10;
    [SerializeField] Transform[] _moveSpots;
    [SerializeField] float _startWaitTime = 3;
    [SerializeField] ParticleSystem _spawnPositionSignal;
    [SerializeField] float _spawnDelayTime = 2;

    float _waitTime;
    int _randomSpot;
    int _newRandomSpot;
    public bool _startPatrol = false;     
    
    IEnumerator coroutine;

    private void Start()
    {
        _waitTime = _startWaitTime;
        _randomSpot = Random.Range(0, _moveSpots.Length);
        _newRandomSpot = _randomSpot;        

    }

    private void Update()
    {
        // moving randomly among locations
        coroutine = StartAfterDelay(_newRandomSpot, _spawnDelayTime);
        StartCoroutine(coroutine);

        // delay before moving to another position
        if (Vector3.Distance(transform.position, _moveSpots[_newRandomSpot].position) <= 0.7f)
        {
            _waitTime -= Time.deltaTime;

            if (_waitTime <= _spawnDelayTime && _waitTime >= (_spawnDelayTime - 0.1f))
            {
                _newRandomSpot = Random.Range(0, _moveSpots.Length);
                Transform newSpot = _moveSpots[_newRandomSpot];
                // play signal particle before moving to new position
                ParticleSystem _signal = Instantiate
                (_spawnPositionSignal, newSpot.position, Quaternion.identity);
                _signal.Play();
                Object.Destroy(_signal, _spawnDelayTime + 1);
                _waitTime = _spawnDelayTime - 0.1f;                
            }

            _waitTime -= Time.deltaTime;

            if (_waitTime <= 0.2f)
            {
                // reset timer
                _waitTime = _startWaitTime;
            }
                                 
        }
              
    }

    IEnumerator StartAfterDelay(int randomSpot, float time)
    {
        yield return new WaitForSeconds(time);
        transform.position = Vector3.MoveTowards
            (transform.position, _moveSpots[randomSpot].position, _travelSpeed * Time.deltaTime);
    }
       
}
