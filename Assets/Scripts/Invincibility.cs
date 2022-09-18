using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Invincibility : PowerUpBase
{
    [SerializeField] GameObject _currentColorObject;
    [SerializeField] GameObject _newColorObject;
        

    protected override void PowerUp(Player player)
    {
        // powerUp vfx
        _newColorObject.SetActive(true);
        _currentColorObject.SetActive(false);
        ParticleSystem burstParticle = Instantiate(PowerUpParticle, gameObject.transform.position, Quaternion.identity);
        burstParticle.Play();
        AudioClip powerUpSFX = PowerUpSFX;
        AudioHelper.PlayClip2D(powerUpSFX, 1);
        // setting invincibility        
        player.GetComponent<Health>().ActivateInvincibility();
    }

    protected override void PowerDown(Player player)
    {
        // powerDown vfx
        _currentColorObject.SetActive(true);
        _newColorObject.SetActive(false);
        AudioClip powerDownSFX = PowerDownSFX;
        AudioHelper.PlayClip2D(powerDownSFX, 1);
        // setting back to normal & SFX
        player.GetComponent<Health>().DeactivateInvincibility();        
    }

    protected override void Movement(Rigidbody rb)
    {
        base.Movement(rb);
    }

   
}
   
