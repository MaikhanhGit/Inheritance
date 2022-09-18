using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : CollectibleBase
{
    Inventory inventory;    
    
    protected override void Collect(Player player)
    {
        // get Inventory count from player
        inventory = player.GetComponent<Inventory>();
        // increase inventory count
        inventory.IncreaseCollectiblesCount();
        // sfx, vfx
        AudioHelper.PlayClip2D(CollectSound, 1);
        ParticleSystem collectParticle = Instantiate
            (CollectParticle, CollectParticleSpawnPosition.position, Quaternion.identity);
        collectParticle.Play();
        Object.Destroy(collectParticle, 3f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.gameObject.GetComponent<Player>();
        if (player != null)
        {
            Collect(player);

            gameObject.SetActive(false);
        }
    }
}
