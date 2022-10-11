using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BossDamagedVisual : MonoBehaviour
{
    [SerializeField] GameObject _bossArtCurrent;
    [SerializeField] GameObject _bossArtDamaged;
    [SerializeField] float _delay = .5f;

    Boss _boss;
    
    private void Awake()
    {
        _boss = GetComponent<Boss>();
    }

    private void OnEnable()
    {        
        _boss.DamagedVisual += ExtraDamageVisual;
    }

    void ExtraDamageVisual()
    {
        StartChangeVisual();                        
    }
    
    void StartChangeVisual()
    {
        _bossArtCurrent?.SetActive(false);
        _bossArtDamaged.SetActive(true);
        StartCoroutine(StopChangeVisual(_delay));
    }

    IEnumerator StopChangeVisual(float delay)
    {
        yield return new WaitForSeconds(delay);
        _bossArtCurrent?.SetActive(true);
        _bossArtDamaged.SetActive(false);
    }
}
