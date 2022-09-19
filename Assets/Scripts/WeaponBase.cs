using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    public abstract void Shoot();
        

    [SerializeField] ParticleSystem _shootParticle = null;
    protected ParticleSystem ShootParticle => _shootParticle;

    [SerializeField] AudioClip _shootSound = null;
    protected AudioClip ShootSound => _shootSound;
}
