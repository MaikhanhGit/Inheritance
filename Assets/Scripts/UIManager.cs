using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] GameObject _gameOverMenu;
    [SerializeField] GameObject _wonMenu;
        

    public void EnableGameOverMenu()
    {
        _gameOverMenu.SetActive(true);
    }
     public void EnableWonMenu()
    {
        _wonMenu.SetActive(true);
    }

        
}
