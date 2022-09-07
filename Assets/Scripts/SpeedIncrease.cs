using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedIncrease : CollectibleBase
{   
    [SerializeField] float _increasedSpeed = 10f;
    [SerializeField] float _duration = 5f;    

    protected override void Collect(Player player)
    {
        SpeedChangeOnTimer speedChangeOnTimer;
        speedChangeOnTimer = player.GetComponent<SpeedChangeOnTimer>();
        if (speedChangeOnTimer != null)
        {
            speedChangeOnTimer.FastSpeed(_increasedSpeed, _duration);
        }

    }
    protected override void Movement(Rigidbody rb)
    {
        // calculate rotation
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
