using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SalesNPC : MonoBehaviour
{
    [SerializeField] private Character salesCharacter;
    [SerializeField] private Character playerCharacter;

    [SerializeField] private GameObject interactiveFlag;
    [SerializeField] private GameObject PanelOptions;
    [SerializeField] private Button buttonYes;
    [SerializeField] private Button buttonNo;
    [SerializeField] private UIUpdater updateManager;
    [SerializeField] private UIManager panelManager;
    [SerializeField] private bool isTrader = false;

    private bool nextToMe = false;

    private void Start()
    {
        if (isTrader)
        {
            buttonYes.onClick.RemoveAllListeners();
            buttonNo.onClick.RemoveAllListeners();

            buttonYes.onClick.AddListener(() => SelectedOption(true));
            buttonNo.onClick.AddListener(() => SelectedOption(false));
        }
    }
    private void Update()
    {
        if (nextToMe)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (!isTrader)
                {
                    SelectedOption(false);
                }
                else
                {
                    SelectOption();
                }
            }
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactiveFlag.SetActive(true);
            nextToMe = true;
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            interactiveFlag.SetActive(false);
            nextToMe = false;
        }
    }
    public void SelectOption()
    {
       PanelOptions.SetActive(true);
    }
    public void SelectedOption(bool isTrade)
    {
        PanelOptions.SetActive(false);
        if (isTrade)
        {
            panelManager.UpdateShop();
            updateManager.UpdateShop(playerCharacter.inventary, isTrade);
        }
        else
        {
            panelManager.UpdateShop();
            updateManager.UpdateShop(salesCharacter.inventary, isTrade);
        }
    }

}
