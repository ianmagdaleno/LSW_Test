using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FramePreviewPlayer : MonoBehaviour
{
    [SerializeField] private Character character;

    [SerializeField] private Image body;
    [SerializeField] private Image hair;
    [SerializeField] private Image outfit;
    [SerializeField] private Image acessory;

    private void Start()
    {
        UpdateFrame();
    }
    public void UpdateFrame()
    {
        body.sprite = character.characterParts[0].bodyPart.icon;
        hair.sprite = character.characterParts[1].bodyPart.icon;
        outfit.sprite = character.characterParts[2].bodyPart.icon;
        //acessory.sprite = character.characterParts[3].bodyPart.icon;
    }
}
