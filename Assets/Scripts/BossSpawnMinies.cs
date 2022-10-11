using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSpawnMinies : MonoBehaviour
{
    [SerializeField] GameObject _firstObjectToSpawn;
    [SerializeField] GameObject _secondObjectToSpawn;
    [SerializeField] Transform _spawnPosition;   
    [SerializeField] float _spawnDamagerInterval = 1;
    [SerializeField] float _spawnKillerInterval = 5;

    float _spawnDamagerCurrentTime;
    float _spawnKillerCurrentTime;    

    private void Awake()
    {
        _spawnDamagerCurrentTime = _spawnDamagerInterval;        
        _spawnKillerCurrentTime = _spawnKillerInterval;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (_spawnDamagerCurrentTime <= 0)
        {
            SpawnMini(_firstObjectToSpawn);            
            _spawnDamagerCurrentTime = _spawnDamagerInterval;
        }
        else
        {
            _spawnDamagerCurrentTime -= Time.deltaTime;
        }
               
        if (_spawnKillerCurrentTime <= 0)
        {
            SpawnMini(_secondObjectToSpawn);
            _spawnKillerCurrentTime = _spawnKillerInterval;
        }
        else
        {
            _spawnKillerCurrentTime -= Time.deltaTime;
        }        

    }

    void SpawnMini(GameObject mini)
    {
        GameObject spawnedObject = Instantiate(mini, _spawnPosition.position, Quaternion.identity);        
    }
   
}
