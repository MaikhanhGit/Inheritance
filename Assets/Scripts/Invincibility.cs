using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Invincibility : PowerUpBase
{
    [SerializeField] GameObject _currentColorObject;
    [SerializeField] GameObject _newColorObject;
    [SerializeField] float _selfMoveSpeed = 1000;

    IDamageable damageableObject;


    private void FixedUpdate()
    {
        ObjectRigidBody.velocity = (transform.forward * _selfMoveSpeed * Time.deltaTime * -1);
    }

    protected override void PowerUp(Player player)
    {
        // powerUp vfx
        _newColorObject.SetActive(true);
        _currentColorObject.SetActive(false);
        ParticleSystem burstParticle = Instantiate(PowerUpParticle, gameObject.transform.position, Quaternion.identity);
        burstParticle.Play();
        // play sfx
        AudioHelper.PlayClip2D(PowerUpSFX, 1);
        // setting invincibility        
        player.GetComponent<Health>().ActivateInvincibility();
    }

    protected override void PowerDown(Player player)
    {
        // powerDown vfx
        _currentColorObject.SetActive(true);
        _newColorObject.SetActive(false);        
        // SFX
        AudioHelper.PlayClip2D(PowerDownSFX, 1);

        // setting back to normal & SFX
        player.GetComponent<Health>().DeactivateInvincibility();        
    }

    IEnumerator powerUpActivated(Player player, float duration)
    {
        PowerUp(player);
        yield return new WaitForSeconds(duration);
        PowerDown(player);
        gameObject.SetActive(false);
    }
    

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            // disable powerUp visually
            ObjectToDisable.SetActive(false);
            // disable Collider
            gameObject.GetComponent<Collider>().enabled = false;
            // start timer
            StartCoroutine(powerUpActivated(player, PowerUpDuration));
        }
    }

    protected override void Movement(Rigidbody rb)
    {        
        // calculate rotation
        Quaternion turnOffset = Quaternion.Euler(MovementSpeed, MovementSpeed, MovementSpeed);
        rb.MoveRotation(rb.rotation * turnOffset);
    }
}
   
