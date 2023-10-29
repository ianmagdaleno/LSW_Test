using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item to buy")]
public class Item : ScriptableObject
{
    public string partName;
    public float value;

    public BodyPart newPart;
}
