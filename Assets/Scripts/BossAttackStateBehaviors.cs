using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttackStateBehaviors : MonoBehaviour
{    
    [SerializeField] GameObject[] _objectsToSpawn;
    [SerializeField] Transform _spawnPosition;
    [SerializeField] float _spawnInterval = 2;
    [SerializeField] ParticleSystem _auraSphere;

    float _spawnCurrentTime;
    int _randomRange;
    GameObject _player;

    private void Awake()
    {
        _spawnCurrentTime = _spawnInterval;
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Start()
    {
        _randomRange = Random.Range(0, _objectsToSpawn.Length);
        ParticleSystem aurora = Instantiate(_auraSphere, transform.position, Quaternion.identity);
        aurora.Play();
        if (_player)
        {            
            transform.LookAt(_player.transform);
        }        

    }

    private void Update()
    {
        if (_player)
        {
            transform.LookAt(_player.transform);
        }

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
