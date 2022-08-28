using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangeOnTimer : MonoBehaviour
{
    TankController controller;
    float _currentSpeed;

    private void Awake()
    {
        controller = gameObject.GetComponent<TankController>();
        if (controller != null)
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

    IEnumerator GoFast(float _fastSpeed, float _fastSpeedDuration)
    {
        // set fast speed
        controller.MoveSpeed = _fastSpeed;
        // set timer for fast speed
        yield return new WaitForSeconds(_fastSpeedDuration);
        // return normal speed
        controller.MoveSpeed = _currentSpeed;
    }

    public void SlowSpeed(float _slowSpeed, float _slowSpeedDuration)
    {
        // start slow Tank's speed
        if (controller != null)
        {
            StartCoroutine(GoSlow(_slowSpeed, _slowSpeedDuration));
        }

    }

    public void FastSpeed(float _fastSpeed, float _fastSpeedDuration)
    {
        // start increase Tank's speed
        if (controller != null)
        {
            StartCoroutine(GoFast(_fastSpeed, _fastSpeedDuration));
        }

    }
}
