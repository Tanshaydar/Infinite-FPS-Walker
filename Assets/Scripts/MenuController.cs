using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuController : MonoBehaviour
{
    [Header("UI Components")] public TMP_Dropdown QualitySelection;
    public TMP_Dropdown ResolutionSelection;
    public Toggle FullScreenSelection;
    public Slider LoadingSlider;

    private static readonly float MinimumLoadingScreenSeconds = 4f;
    private List<string> _qualityList;
    private List<string> _resolutionList;

    private void Awake()
    {
        _qualityList = new List<string>(QualitySettings.names.Length);
        foreach (string s in QualitySettings.names)
        {
            _qualityList.Add(s);
        }

        QualitySelection.ClearOptions();
        QualitySelection.AddOptions(_qualityList);
        QualitySelection.value = QualitySelection.name.Length;
        QualitySelection.RefreshShownValue();
        QualitySelection.onValueChanged.AddListener(OnQualityChanged);


        _resolutionList = new List<string>(Screen.resolutions.Length);
        foreach (Resolution resolution in Screen.resolutions)
        {
            string r = resolution.width + "x" + resolution.height + " " + resolution.refreshRate + "Hz";
            _resolutionList.Add(r);
        }

        ResolutionSelection.ClearOptions();
        ResolutionSelection.AddOptions(_resolutionList);
        ResolutionSelection.value = Screen.resolutions.Length;
        ResolutionSelection.RefreshShownValue();
        ResolutionSelection.onValueChanged.AddListener(OnResolutionChanged);

        FullScreenSelection.isOn = true;
        FullScreenSelection.onValueChanged.AddListener(UpdateFullScreen);

        LoadingSlider.direction = Slider.Direction.LeftToRight;
        LoadingSlider.minValue = 0.0f;
        LoadingSlider.maxValue = 0.91f;
    }

    private void OnResolutionChanged(int resolutionSelection)
    {
        Resolution resolution = Screen.resolutions[resolutionSelection];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen, resolution.refreshRate);
    }

    private void OnQualityChanged(int qualitySelection)
    {
        QualitySettings.SetQualityLevel(qualitySelection, true);
    }

    public void UpdateFullScreen(bool fullScreenChange)
    {
        Screen.fullScreen = fullScreenChange;
    }

    public void StartGame()
    {
        StartCoroutine(LoadGame());
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(0.2f);

        float startTime = Time.unscaledTime;

        AsyncOperation asyncOperation =
            SceneManager.LoadSceneAsync("GameScene", LoadSceneMode.Single);

        asyncOperation.allowSceneActivation = false;

        while (asyncOperation.progress < 0.9f)
        {
            LoadingSlider.value = asyncOperation.progress;
            yield return null;
        }

        while (Time.unscaledTime - startTime < MinimumLoadingScreenSeconds)
        {
            yield return null;
        }

        asyncOperation.allowSceneActivation = true;

        while (!asyncOperation.isDone)
        {
            yield return null;
        }
    }

    public void ExitGame()
    {
        Application.Quit();
    }
}