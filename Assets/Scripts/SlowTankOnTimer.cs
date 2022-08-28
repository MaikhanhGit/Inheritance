using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTankOnTimer : MonoBehaviour
{        
    TankController controller;
    float _currentSpeed;

    private void Awake()
    {
        controller = gameObject.GetComponent<TankController>();
        if(controller != null)
        {
            _currentSpeed = controller.MoveSpeed;
        }        
    }

    IEnumerator GoSlow(float _slowSpeed, float _slowSpeedDuration)
    {        
        // set slow speed
        controller.MoveSpeed = _slowSpeed;
        // set timer for slow speed
        yield return new WaitForSeconds(_slowSpeedDuration);
        // return normal speed
        controller.MoveSpeed = _currentSpeed;
    }

    public void SlowSpeed(float _slowSpeed, float _slowSpeedDuration)
    {
        // start slow Tank's speed
        if(controller != null)
        {
            StartCoroutine(GoSlow(_slowSpeed, _slowSpeedDuration));
        }
        
    }
}
