using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    bool _gameEnded = false;
    public void Won()
    {
        if (_gameEnded == false)
        {
            _gameEnded = true;
            Debug.Log("You've Won");
        }

    }
    public void GameOver()
    {        
        if (_gameEnded == false)
        {
            _gameEnded = true;
            Debug.Log("GameOver");

        }
    }
}