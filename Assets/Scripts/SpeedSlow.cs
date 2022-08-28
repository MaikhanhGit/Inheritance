using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedSlow : CollectibleBase
{
    [SerializeField] float _speedAmount = .05f;
    [SerializeField] float _duration = 1.5f;
    

    protected override void Collect(Player player)
    {
        SpeedChangeOnTimer speedChangeOnTimer;
        speedChangeOnTimer = player.GetComponent<SpeedChangeOnTimer>();
        if(speedChangeOnTimer != null)
        {
            speedChangeOnTimer.SlowSpeed(_speedAmount, _duration);
        }        
    }
   
}
