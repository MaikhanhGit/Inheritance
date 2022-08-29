using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invincibility : PowerUpBase
{
    [SerializeField] GameObject _currentColorObject;
    [SerializeField] GameObject _newColorObject;
    [SerializeField] AudioClip _deactivatedSFX;


    protected override void PowerUp(Player player)
    {
        // powerUp vfx
        _newColorObject.SetActive(true);
        _currentColorObject.SetActive(false);
        // setting invincibility
        player.InvincibilityActivated();
    }

    protected override void PowerDown(Player player)
    {
        // powerDown vfx
        _currentColorObject.SetActive(true);
        _newColorObject.SetActive(false);
        // setting back to normal & SFX
        player.InvincibilityDeactivated();
        AudioHelper.PlayClip2D(_deactivatedSFX, 1);

    }
}
   
