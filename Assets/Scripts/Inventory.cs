using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Inventory : MonoBehaviour
{
    int collectiblesCount = 0;
    [SerializeField] TextMeshProUGUI countVisual;

    public void IncreaseCollectiblesCount()
    {
        collectiblesCount += 1;        
        if(countVisual != null)
        {
            // change visual to show updated collectibles count
            countVisual.text = collectiblesCount.ToString();            
        }
    } 
}
