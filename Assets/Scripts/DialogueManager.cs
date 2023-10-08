using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;


public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialogueBox;

    public static UnityEvent<string> StartDialogueEvent;


    float charactersPerSecond = 10;
    bool finishWriting;


    private void Awake()
    {
        StartDialogueEvent = new UnityEvent<string>();
    }

    private void Start()
    {
        finishWriting = false;
        StartDialogueEvent.AddListener(StartDialogue);
    }

    private void StartDialogue(string fileName)
    {
        TextAsset text = Resources.Load(fileName) as TextAsset;
        StartCoroutine(ShowDialogue(TextAssetToList(text)));
    }

    private List<string> TextAssetToList(TextAsset ta)
    {
        return new List<string>(ta.text.Split('\n'));
    }

    public IEnumerator ShowDialogue(List<string> text)
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
        GameManager.Instance.isDialogue = false;
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
