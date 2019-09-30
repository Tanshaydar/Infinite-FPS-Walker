using System;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private GameController _gameController;

    private void Awake()
    {
        _gameController = FindObjectOfType<GameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        _gameController.GameOverByObstacle();
    }
}