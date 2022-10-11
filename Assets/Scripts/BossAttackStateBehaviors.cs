using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackStateBehaviors : MonoBehaviour
{    
    [SerializeField] GameObject[] _objectsToSpawn;
    [SerializeField] Transform _spawnPosition;
    [SerializeField] float _spawnInterval = 3;    

    float _spawnCurrentTime;
    int _randomRange;

    private void Awake()
    {
        _spawnCurrentTime = _spawnInterval;        
    }

    private void Start()
    {
        _randomRange = Random.Range(0, _objectsToSpawn.Length);
    }

    private void Update()
    {
        if (_spawnCurrentTime <= 0)
        {
            _randomRange = Random.Range(0, _objectsToSpawn.Length);
            SpawnMini(_objectsToSpawn[_randomRange]);           
            _spawnCurrentTime = _spawnInterval;
        }
        else
        {
            _spawnCurrentTime -= Time.deltaTime;
        }
    }

    void SpawnMini(GameObject mini)
    {
        GameObject spawnedObject = Instantiate(mini, _spawnPosition.position, Quaternion.identity);
    }
}
