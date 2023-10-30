using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] UIManager panelManager;

    [SerializeField] GameObject prefabSlot;
    [SerializeField] Transform contentInventary;
    [SerializeField] TMP_Text textCoin;

    [SerializeField] GameObject prefabSlotShop;
    [SerializeField] Transform contentShop;

    private List<GameObject> pooledSlots = new List<GameObject>();
    private List<GameObject> pooledShopSlots = new List<GameObject>();

    private void Start()
    {
        UpdateCoins();
        InitializeObjectPool();
        UpdateInventary();
    }

    public void UpdateCoins()
    {
        textCoin.text = character.coins.ToString();
    }

    private void InitializeObjectPool()
    {
        int initialPoolSize = 10;
        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject slot = Instantiate(prefabSlot, contentInventary);
            slot.SetActive(false);
            pooledSlots.Add(slot);
        }

        for (int i = 0; i < initialPoolSize; i++)
        {
            GameObject shopSlot = Instantiate(prefabSlotShop, contentShop);
            shopSlot.SetActive(false);
            pooledShopSlots.Add(shopSlot);
        }
    }

    public void UpdateInventary()
    {
        for (int i = 0; i < character.inventary.Count; i++)
        {
            if (i >= pooledSlots.Count)
            {
                GameObject slot = Instantiate(prefabSlot, contentInventary);
                slot.SetActive(true);
                pooledSlots.Add(slot);
            }

            GameObject currentSlot = pooledSlots[i];

            currentSlot.SetActive(true);
            Image slotImage = currentSlot.transform.GetChild(0).GetComponent<Image>();
            slotImage.sprite = character.inventary[i].newPart.icon;
        }

        for (int i = character.inventary.Count; i < pooledSlots.Count; i++)
        {
            pooledSlots[i].SetActive(false);
        }
    }

    public void UpdateShop(List<Item> listItens, bool isTrade)
    {
        for (int i = 0; i < listItens.Count; i++)
        {
            if (i >= pooledShopSlots.Count)
            {
                GameObject shopSlot = Instantiate(prefabSlotShop, contentShop);
                shopSlot.SetActive(true);
                pooledShopSlots.Add(shopSlot);
            }

            GameObject currentShopSlot = pooledShopSlots[i];

            currentShopSlot.SetActive(true);
            Item data = listItens[i];

            Image slotImage = currentShopSlot.transform.GetChild(0).GetComponent<Image>();
            slotImage.sprite = data.newPart.icon;

            TMP_Text itemInfoText = currentShopSlot.transform.GetChild(1).GetComponent<TMP_Text>();
            itemInfoText.text = $"$ {data.value}";

            Button buttonPreview = currentShopSlot.GetComponent<Button>();
            buttonPreview.onClick.RemoveAllListeners();
           
            buttonPreview.onClick.AddListener(() => panelManager.ActivePreview(data, isTrade));
        }

        for (int i =listItens.Count; i < pooledShopSlots.Count; i++)
        {
            pooledShopSlots[i].SetActive(false);
        }
    }
}