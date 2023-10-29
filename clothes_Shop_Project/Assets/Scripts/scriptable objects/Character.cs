using UnityEngine;

[CreateAssetMenu(fileName = "New Character", menuName = "Character")]
public class Character : ScriptableObject
{
    public CharacterPart[] characterParts;
}

[System.Serializable]
public class CharacterPart
{
    public string name;
    public BodyPart bodyPart;
}
