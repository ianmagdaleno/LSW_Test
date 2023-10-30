using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    [SerializeField] private UIUpdater updateManager;

    [SerializeField] private Button buttonHome;
    [SerializeField] private Button buttonSettings;
    [SerializeField] private Button buttonInventary;

    [SerializeField] GameObject panelCharacterEditor;
    [SerializeField] GameObject panelInventary;
    [SerializeField] GameObject panelPreview;
    [SerializeField] GameObject panelShop;

    private void Start()
    {
        buttonHome.onClick.RemoveAllListeners();
        buttonSettings.onClick.RemoveAllListeners();
        buttonInventary.onClick.RemoveAllListeners();

        buttonHome.onClick.AddListener(() => ChangeScene("MainMenu"));
        buttonSettings.onClick.AddListener(() => UpdatePainel(panelCharacterEditor));
        buttonInventary.onClick.AddListener(() => UpdatePainel(panelInventary));
        buttonInventary.onClick.AddListener(() => updateManager.UpdateInventary());
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
    
    public void UpdateShop()
    {
        UpdatePainel(panelShop);
    }

    public void ActivePreview(Item data, bool isTrade)
    {
        UpdatePainel(panelPreview);
        panelPreview.GetComponent<ExchangeItem>().Setup(data, isTrade);

    }
    private void ChangeScene(string name)
    {
        SceneManager.LoadScene(name);
    }
}
