using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Dialog", menuName = "My Scriptables/Scenario/New Dialog")]
public class DialogInfo : ScriptableObject
{
    public string dialogName;
    public List<DialogLine> dialogLines;
}

[Serializable]
public class DialogLine
{
    public CharacterInfo character;
    public string text;
}
