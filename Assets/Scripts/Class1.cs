using UnityEngine;

[CreateAssetMenu(fileName ="Dialogo",menuName ="ScriptableObject/Dialogo",order =1)]
public class DialogueObject:ScriptableObject
{
    public int ID;
    public string[] dialogue;
}