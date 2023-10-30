using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public CharacterPart[] characterParts;
    public List<Item> inventary;
    public float coins;
}

[System.Serializable]
public class CharacterPart
{
    public string name;
    public BodyPart bodyPart;
}
