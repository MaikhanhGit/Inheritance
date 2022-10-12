using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    UIManager _UIManager;    
    bool _gameEnded = false;
    TankController _tankController;
    private void Awake()
    {
        _UIManager = GetComponent<UIManager>();       
    }


    public void Won()
    {
        if (_gameEnded == false)
        {
            if (_UIManager)
            {
                _UIManager.EnableWonMenu();
            }
            _tankController = FindObjectOfType<Player>()?.GetComponent<TankController>();
            if (_tankController)
            {                
                _tankController.enabled = false;
            }
            
            _gameEnded = true;
        }

    }
    public void GameOver()
    {
        if (_gameEnded == false)
        {
            if (_UIManager)
            {
                _UIManager.EnableGameOverMenu();
            }
            _tankController = FindObjectOfType<Player>()?.GetComponent<TankController>();
            if (_tankController)
            {
                _tankController.enabled = false;
            }
            _gameEnded = true;

        }
    }
}
