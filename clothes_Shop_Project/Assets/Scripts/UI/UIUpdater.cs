using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIUpdater : MonoBehaviour
{
    [SerializeField] Character character;
    [SerializeField] GameObject prefabSlot;
    [SerializeField] Transform contentInventary;
    [SerializeField] TMP_Text textCoin;

    private List<GameObject> pooledSlots = new List<GameObject>();

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
            Image slotImage = currentSlot.transform.GetChild(0).GetComponent<Image>();
            slotImage.sprite = character.inventary[i].bodyPart.icon;
        }

        for (int i = character.inventary.Count; i < pooledSlots.Count; i++)
        {
            pooledSlots[i].SetActive(false);
        }
    }
}