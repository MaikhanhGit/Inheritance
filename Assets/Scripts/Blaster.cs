using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blaster : WeaponBase
{
    [SerializeField] ProjectileBlaster _blasterProjectile;
    [SerializeField] Transform _projectileSpawnLocation;
    public override void Shoot()
    {
        ProjectileBlaster newProjectile = Instantiate
            (_blasterProjectile, _projectileSpawnLocation.position, _projectileSpawnLocation.rotation);
        // play particles
        if (ShootParticle)
        {
            ParticleSystem burstParticle = Instantiate
            (ShootParticle, _projectileSpawnLocation.position, Quaternion.identity);
            burstParticle.Play();
            if (burstParticle)
            {
                Object.Destroy(burstParticle, 3f);                
            }           
        }

        // play audio
        if (ShootSound)
        {
            AudioSource.PlayClipAtPoint(ShootSound, _projectileSpawnLocation.position);
        }
        
    }
}

