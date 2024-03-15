using System;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class OptionsMenu : MonoBehaviour
{
    [SerializeField] private GameSettings gameSettings;
    [SerializeField] private TMP_Dropdown resolutionDropdown;
    [SerializeField] private Toggle fullScreenToggle;
    [SerializeField] private Button saveButton;
    private Resolution[] resolutions;

    private void Start()
    {
        SaveSettings();
        SetupResolutionDropDown();
        SetupFullScreenToggle();
        SetupSaveButton();
    }

    private void SetupResolutionDropDown()
    {
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();

        var options = resolutions.Select(r => $"{r.width} x {r.height} @ {r.refreshRateRatio}Hz").ToList();
        resolutionDropdown.AddOptions(options);

        int currentResolutionIndex = Array.IndexOf(resolutions, Screen.currentResolution);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();

        resolutionDropdown.onValueChanged.AddListener(SetResolution);
    }

    private void SetResolution(int resolutionIndex)
    {
        Screen.SetResolution(resolutions[resolutionIndex].width, resolutions[resolutionIndex].height, Screen.fullScreen);
    }

    private void SetupFullScreenToggle()
    {
        fullScreenToggle.isOn = Screen.fullScreen;
        fullScreenToggle.onValueChanged.AddListener(SetFullScreen);
    }

    private void SetFullScreen(bool isOn)
    {
        Screen.fullScreen = isOn;
    }

    private void SetupSaveButton()
    {
        saveButton.onClick.AddListener(SaveSettings);
    }

    private void SaveSettings()
    {
        gameSettings.Resolution = new Vector2(Screen.currentResolution.width, Screen.currentResolution.height);
        gameSettings.FullScreen = Screen.fullScreen;
    }

    private void OnDisable()
    {
        resolutionDropdown.onValueChanged.RemoveListener(SetResolution);
        fullScreenToggle.onValueChanged.RemoveListener(SetFullScreen);
    }
}