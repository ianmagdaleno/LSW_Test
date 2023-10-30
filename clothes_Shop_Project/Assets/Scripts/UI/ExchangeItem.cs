using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class ExchangeItem : MonoBehaviour
{
    [Header("Item")]
    [SerializeField] private Item currentItem;
    [SerializeField] private bool isTrade = false;

    [Header("View")]
    [SerializeField] private Character character;
    [SerializeField] private Character npc;
    [SerializeField] private Image body;
    [SerializeField] private Image hair;
    [SerializeField] private Image outfit;
    [SerializeField] private Image accessory;

    [Header("Info")]
    [SerializeField] private TMP_Text textName;
    [SerializeField] private TMP_Text textValue;
    [SerializeField] private UIUpdater managerUI;

    [Header("Interactive")]
    [SerializeField] private Button buttonBack;
    [SerializeField] private Button buttonBuy;

    private void Start()
    {
        buttonBack.onClick.RemoveAllListeners();
        buttonBuy.onClick.RemoveAllListeners();

        buttonBack.onClick.AddListener(() => gameObject.SetActive(false));
        buttonBuy.onClick.AddListener(ConfirmExchange);
    }

    public void Setup(Item item, bool istrade)
    {
        currentItem = item;
        isTrade = istrade;
        textValue.text = item.value.ToString();
        textName.text = item.partName;
        CheckType(item.partType, item);
    }
    public void CheckType(string type, Item item)
    {
        switch (type)
        {
            case "Body":
                body.sprite = item.newPart.icon;
                hair.sprite = character.characterParts[1].bodyPart.icon;
                outfit.sprite = character.characterParts[2].bodyPart.icon;
                break;
            case "Hair":
                body.sprite = character.characterParts[0].bodyPart.icon;
                hair.sprite = item.newPart.icon;
                outfit.sprite = character.characterParts[2].bodyPart.icon;
                break;
            case "Outfit":
                body.sprite = character.characterParts[0].bodyPart.icon;
                hair.sprite = character.characterParts[1].bodyPart.icon;
                outfit.sprite = item.newPart.icon;
                break;
            case "Accessory":
                Debug.Log("Check accessory");
                break;
        }
    }

    public void ConfirmExchange()
    {
        Debug.Log(isTrade);
        if (isTrade)
        {
            if (character.inventary.Contains(currentItem))
            {
                character.inventary.Remove(currentItem);
                character.coins += currentItem.value;
                managerUI.UpdateShop(character.inventary, true);
                ConfirmTrade();
            }
            else
            {
                Debug.Log("Failed! Item not found in inventory.");
            }
        }
        else
        {
            if (character.coins >= currentItem.value)
            {
                character.inventary.Add(currentItem);
                character.coins -= currentItem.value;
                ConfirmTrade();
            }
            else
            {
                Debug.Log("Failed! No funds");
            }
        }
    }

    public void ConfirmTrade()
    {
        managerUI.UpdateCoins();
        managerUI.UpdateInventary();
        gameObject.SetActive(false);
    }
}