using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Body Part", menuName = "new Part")]
public class BodyPart : ScriptableObject
{
    public string partName;
    public int animationID;
    public Sprite icon;

    public List<AnimationClip> allAnimations = new List<AnimationClip>();
}
