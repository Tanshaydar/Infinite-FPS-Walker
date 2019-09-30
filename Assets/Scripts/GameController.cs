using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("UI Related")] public TextMeshProUGUI IndicatorText;
    public GameObject Panel;

    private int startingWait = 3;
    private PlayerController _playerController;
    private Vector3 _distanceCovered;

    private void Awake()
    {
        _playerController = FindObjectOfType<PlayerController>();
    }

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(1);
        while (startingWait > 0)
        {
            IndicatorText.text = startingWait.ToString();
            yield return new WaitForSeconds(1);
            startingWait--;
        }
        Panel.SetActive(false);
        IndicatorText.text = "";
        
        _playerController.StartMoving();
        _distanceCovered = _playerController.transform.position;
    }

    public void GameOverByObstacle()
    {
        _playerController.Die();
        Panel.SetActive(true);
        IndicatorText.text = "Death by Obstacle...";
        float distance = Vector3.Distance(_distanceCovered, _playerController.transform.position);
    }
}