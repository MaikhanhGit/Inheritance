using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAngryVisual : MonoBehaviour
{
    [SerializeField] GameObject _bossArtCurrent;
    [SerializeField] GameObject _bossArtDamaged;
    [SerializeField] GameObject _bossArtAngry;       

    Boss _boss;

    private void Awake()
    {
        _boss = GetComponent<Boss>();
    }

    private void OnEnable()
    {
        _boss.AngryVisual += ExtraAngryVisual;
    }

    void ExtraAngryVisual()
    {
        StartChangeVisual();       

    }

    void StartChangeVisual()
    {
        _bossArtCurrent?.SetActive(false);
        _bossArtDamaged.SetActive(false);
        _bossArtAngry?.SetActive(true);
        
    }
    
}
