using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenuController : MonoBehaviour
{
    public GameObject PauseMenu;
    public TextMeshProUGUI ContinueText;

    private bool _isPaused;
    private bool _isGameOver;

    private void Start()
    {
        PauseMenu.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (_isPaused)
            {
                ContinueGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        _isPaused = true;
        PauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ContinueGame()
    {
        Time.timeScale = 1;
        if (_isGameOver)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            _isPaused = false;
            PauseMenu.SetActive(false);
        }
    }

    public void ExiToMainMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    public void ShowGameOverMenu()
    {
        ContinueText.text = "Restart?";
        _isGameOver = true;
        PauseMenu.SetActive(true);
    }
}