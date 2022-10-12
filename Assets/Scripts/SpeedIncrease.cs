using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : PowerUpBase
{   
    [SerializeField] float _increasedSpeed = 10f;
    [SerializeField] float _duration = 5f;
       
    protected override void Movement(Rigidbody rb)
    {
        base.Movement(rb);
    }


    protected override void PowerDown(Player player)
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Player _player = other.GetComponent<Player>();
        if (_player)
        {
            Debug.Log("player");
            PowerUp(_player);
        }
    }

    protected override void PowerUp(Player player)
    {
        SpeedChangeOnTimer speedChangeOnTimer;
        speedChangeOnTimer = player.GetComponent<SpeedChangeOnTimer>();
        if (speedChangeOnTimer != null)
        {
            speedChangeOnTimer.FastSpeed(_increasedSpeed, _duration);
        }
    }
}
