using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    [SerializeField] private Button buttonPlay;
    [SerializeField] private Button buttonCredits;
    [SerializeField] private Button buttonExit;
    [SerializeField] private Button buttonSettings;

    [SerializeField] private GameObject panelCredits;
    [SerializeField] private GameObject panelSettings;

    private void Start()
    {
        buttonPlay.onClick.RemoveAllListeners();
        buttonCredits.onClick.RemoveAllListeners();
        buttonExit.onClick.RemoveAllListeners();
        //buttonSettings.onClick.RemoveAllListeners();

        
        buttonPlay.onClick.AddListener(() => LoadNextScene());
        buttonCredits.onClick.AddListener(() => ActivePanel(panelCredits));
        buttonExit.onClick.AddListener(() => ExitApp());
        //buttonSettings.onClick.AddListener(() => ActivePanel(panelSettings));
    }
    public void ActivePanel(GameObject panel)
    {
        panelCredits.SetActive(false);
        panelSettings.SetActive(false);

        panel.SetActive(true);
    }
    public void LoadNextScene()
    {
        SceneManager.LoadScene("Game");
    }
    public void ExitApp()
    {
        Application.Quit();
    }
}
