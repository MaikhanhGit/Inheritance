using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedChangeOnTimer : MonoBehaviour
{
    [SerializeField] AudioClip _deactivatedSFX;

    TankController controller;
    float _currentSpeed;

    private void Awake()
    {
        controller = gameObject.GetComponent<TankController>();
        if (controller != null)
        {
            _currentSpeed = controller.MaxSpeed;            
        }
    }

    IEnumerator GoSlow(float slowSpeed, float slowSpeedDuration)
    {
        // set slow speed
        controller.MaxSpeed = slowSpeed;        
        // set timer for slow speed
        yield return new WaitForSeconds(slowSpeedDuration);
        // return normal speed & SFX
        controller.MaxSpeed = _currentSpeed;
        AudioHelper.PlayClip2D(_deactivatedSFX, 1);
    }

    IEnumerator GoFast(float fastSpeed, float fastSpeedDuration)
    {
        // set fast speed
        controller.MaxSpeed = fastSpeed;        
        // set timer for fast speed
        yield return new WaitForSeconds(fastSpeedDuration);
        // return normal speed & SFX
        controller.MaxSpeed = _currentSpeed;
        AudioHelper.PlayClip2D(_deactivatedSFX, 1);
    }

    public void SlowSpeed(float slowSpeed, float slowSpeedDuration)
    {
        // start slow Tank's speed
        if (controller != null)
        {
            StartCoroutine(GoSlow(slowSpeed, slowSpeedDuration));
        }

    }

    public void FastSpeed(float fastSpeed, float fastSpeedDuration)
    {
        // start increase Tank's speed
        if (controller != null)
        {
            StartCoroutine(GoFast(fastSpeed, fastSpeedDuration));
        }

    }
}
