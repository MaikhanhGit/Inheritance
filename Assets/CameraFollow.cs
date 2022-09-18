using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] Transform _objectToFollow;
    [SerializeField] float smoothSpeed = 0.125f;
    [SerializeField] Vector3 offset;

    private void LateUpdate()
    {
        // smooth following/not snap
        Vector3 desirePosition = _objectToFollow.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desirePosition, smoothSpeed);
        transform.position = smoothedPosition;
        // camera follow player        

    }
}
