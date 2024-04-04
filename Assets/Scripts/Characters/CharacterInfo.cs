using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="New Character",menuName ="My Scriptables/New Character")]
public class CharacterInfo : ScriptableObject
{
    public string characterName;
    public Sprite characterSprite;
}
