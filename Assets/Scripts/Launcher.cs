using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : WeaponBase
{
    [SerializeField] ProjectileLauncher _launcherProjectile;
    [SerializeField] Transform _projectileSpawnLocation;
    public override void Shoot()
    {
        ProjectileLauncher newProjectile = Instantiate
            (_launcherProjectile, _projectileSpawnLocation.position, _projectileSpawnLocation.rotation);


        // particle system
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
