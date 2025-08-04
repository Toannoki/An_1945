using StarterAssets;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static LanguageManager;
using static UnityEngine.Rendering.DebugUI;

public class SetingsMenu : MonoBehaviour
{
    public TMP_Dropdown resDropdown;
    public Slider sensitivitySlider;

    private Resolution[] allResolutions;
    private int selectedResolutionIndex = 0;
    List<Resolution> SelectedResolutionList = new List<Resolution>();
    public FirstPersonController firstPersonController;

    public TMP_Dropdown languageDropdown;

    void Start()
    {
        // --- Xử lý độ phân giải ---
        allResolutions = Screen.resolutions;
        List<string> options = new List<string>();

        string newRes;
        for (int i = allResolutions.Length - 1; i >= 0; i--)
        {
            Resolution res = allResolutions[i];
            newRes = res.width.ToString() + " x " + res.height.ToString();
            if(!options.Contains(newRes))
            {
                options.Add(newRes);
                SelectedResolutionList.Add(res);
            } 
        }
        
        resDropdown.AddOptions(options);
        int resolution = PlayerPrefs.GetInt("Resolution", -1);
        if (resolution == -1)
        {
            Screen.SetResolution(SelectedResolutionList[selectedResolutionIndex].width, SelectedResolutionList[selectedResolutionIndex].height, true);
        }
        else
        {
            resDropdown.value = resolution;
            Screen.SetResolution(SelectedResolutionList[resolution].width, SelectedResolutionList[resolution].height, true);
        }

        // --- Cài đặt Language ---
        languageDropdown.ClearOptions();
        languageDropdown.AddOptions(new List<string> { "English","Tiếng Việt" });

        languageDropdown.value = (int)LanguageManager.Instance.currentLanguage;
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);

        // Gán listener
        languageDropdown.onValueChanged.AddListener(OnLanguageChanged);
        // --- Cài đặt thanh trượt sensitivity ---
        float savedSensitivity = PlayerPrefs.GetFloat("MouseSensitivity", 1.0f);
        sensitivitySlider.value = savedSensitivity;
        sensitivitySlider.onValueChanged.AddListener(OnSensitivityChanged);
    }

    public void ChangeResolution()
    {
        selectedResolutionIndex = resDropdown.value;
        Screen.SetResolution(SelectedResolutionList[selectedResolutionIndex].width, SelectedResolutionList[selectedResolutionIndex].height, true);
        PlayerPrefs.SetInt("Resolution", selectedResolutionIndex);
    }

    public void OnSensitivityChanged(float value)
    {
        PlayerPrefs.SetFloat("MouseSensitivity", value);
        PlayerPrefs.Save();
    }

    public void ExitGame()
    {
        Debug.Log("Thoát Game");
        Application.Quit();
    }
    public void BackToGame()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        gameObject.SetActive(false);
        if (firstPersonController!= null)
            firstPersonController.ActivateRotation(true);
        firstPersonController.RotationSpeed = PlayerPrefs.GetFloat("MouseSensitivity", 1.0f);
        Time.timeScale = 1f;
        AudioListener.pause = false;
    }
    public void Pause()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        if (firstPersonController != null)
            firstPersonController.ActivateRotation(false);
        gameObject.SetActive(true);
        Time.timeScale = 0f; // Dừng thời gian
        AudioListener.pause = true;
    }
    void OnDestroy()
    {
        languageDropdown.onValueChanged.RemoveListener(OnLanguageChanged);
    }

    private void OnLanguageChanged(int index)
    {
        Language selectedLang = (Language)index;
        LanguageManager.Instance.SetLanguage(selectedLang);
    }
}
