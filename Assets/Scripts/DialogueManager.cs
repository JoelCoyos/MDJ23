using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    private TextMeshProUGUI dialogueText;


    float charactersPerSecond = 5;

    private void Start()
    {
        
    }

    public IEnumerator StartDialogue(DialogueObject dialogueObject)
    {
        int dialogueNum=0;
        StartCoroutine(TypeText(dialogueObject.dialogue[dialogueNum]));
        yield return null;
    }

    IEnumerator TypeText(string line)
    {
        string textBuffer = null;
        foreach (char c in line)
        {
            textBuffer += c;
            dialogueText.text = textBuffer;
            yield return new WaitForSeconds(1 / charactersPerSecond);
        }
    }
}
