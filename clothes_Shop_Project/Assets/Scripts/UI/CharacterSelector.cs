using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using TMPro;

public class CharacterSelector : MonoBehaviour
{
    [SerializeField] private Character character;
    [SerializeField] private BodyPartSelection[] bodyPartSelections;

    private void Start()
    {
        for (int i = 0; i < bodyPartSelections.Length; i++)
        {
            LoadOptions(bodyPartSelections[i]);
            GetCurrentBodyParts(i);
        }
    }
    public void LoadOptions(BodyPartSelection option)
    {
        option.bodyPartOptions = Resources.LoadAll<BodyPart>($"Scriptable Objects/{option.bodyPartName}");
    }
    public void NextBodyPart(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (bodyPartSelections[partIndex].bodyPartCurrentIndex < bodyPartSelections[partIndex].bodyPartOptions.Length - 1)
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex++;
            }
            else
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex = 0;
            }

            UpdateCurrentPart(partIndex);
        }
    }

    public void PreviousBody(int partIndex)
    {
        if (ValidateIndexValue(partIndex))
        {
            if (bodyPartSelections[partIndex].bodyPartCurrentIndex > 0)
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex--;
            }
            else
            {
                bodyPartSelections[partIndex].bodyPartCurrentIndex = bodyPartSelections[partIndex].bodyPartOptions.Length - 1;
            }

            UpdateCurrentPart(partIndex);
        }
    }

    private bool ValidateIndexValue(int partIndex)
    {
        if (partIndex > bodyPartSelections.Length || partIndex < 0)
        {
            return false;
        }
        else
        {
            return true;
        }
    }

    private void GetCurrentBodyParts(int partIndex)
    {
        bodyPartSelections[partIndex].PartNameText.text = character.characterParts[partIndex].bodyPart.partName;
        bodyPartSelections[partIndex].bodyPartCurrentIndex = character.characterParts[partIndex].bodyPart.animationID;
    }

    private void UpdateCurrentPart(int partIndex)
    {
        bodyPartSelections[partIndex].PartNameText.text = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex].partName;
        character.characterParts[partIndex].bodyPart = bodyPartSelections[partIndex].bodyPartOptions[bodyPartSelections[partIndex].bodyPartCurrentIndex];
    }
}

[System.Serializable]
public class BodyPartSelection
{
    public string bodyPartName;
    public BodyPart[] bodyPartOptions;
    public TMP_Text PartNameText;
    [HideInInspector] public int bodyPartCurrentIndex;
}
