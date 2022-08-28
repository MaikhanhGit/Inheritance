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
    }
}
