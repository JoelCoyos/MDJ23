using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialogueBox;


    float charactersPerSecond = 10;
    bool finishWriting;

    private void Start()
    {
        finishWriting = false;
        TextAsset text = Resources.Load("test") as TextAsset;
        StartCoroutine(StartDialogue(TextAssetToList(text)));
    }

    private List<string> TextAssetToList(TextAsset ta)
    {
        return new List<string>(ta.text.Split('\n'));
    }

    public IEnumerator StartDialogue(List<string> text)
    {
        dialogueBox.SetActive(true);
        int dialogueNum=0;
        StartCoroutine(TypeText(text[dialogueNum]));
        dialogueNum++;
        while(dialogueNum < text.Count) 
        {
            yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) && finishWriting);
            finishWriting = false;
            yield return StartCoroutine(TypeText(text[dialogueNum]));
            dialogueNum++;
        }
        yield return new WaitUntil(() => Input.GetKeyDown(KeyCode.Space) && finishWriting);
        dialogueBox.SetActive(false);
    }

    IEnumerator TypeText(string line)
    {
        if (line[0]=='C')
        {

        }
        else if (line[0]=='D')
        {

        }
        line = line.Substring(2);
        string textBuffer = null;
        foreach (char c in line)
        {
            textBuffer += c;
            dialogueText.text = textBuffer;
            yield return new WaitForSeconds(1 / charactersPerSecond);
        }
        finishWriting = true;
    }
}
