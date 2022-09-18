using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileImpact : MonoBehaviour
{
    
    private void OnTriggerEnter(Collider other)
    {
        other.enabled = false;
    }
}
