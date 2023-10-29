using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Button buttonHome;
    [SerializeField] private Button buttonSettings;

    [SerializeField] GameObject painelCharacterEditor;
    [SerializeField] GameObject painelInventary;
    [SerializeField] GameObject painelPreview;

    private void Start()
    {
        buttonHome.onClick.RemoveAllListeners();
        buttonSettings.onClick.RemoveAllListeners();

        buttonHome.onClick.AddListener(() => ChangeScene("MainMenu"));
        buttonSettings.onClick.AddListener(() => UpdatePainel(painelCharacterEditor));
    }
    private void UpdatePainel(GameObject painel)
    {
        if(painel.activeSelf) 
        {
            painel.SetActive(false);
        }
        else
        {
            painel.SetActive(true);
        }
    }
    
    private void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
