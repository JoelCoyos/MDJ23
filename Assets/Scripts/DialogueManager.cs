using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;


public class DialogueManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private GameObject dialogueBox;

    [SerializeField] private Sprite clemHappy;
    [SerializeField] private Sprite clemNormal;
    [SerializeField] private Sprite clemSad;
    [SerializeField] private Sprite clemSorpresa;

    [SerializeField] private Sprite daniEstresado;
    [SerializeField] private Sprite daniLlorando;
    [SerializeField] private Sprite daniNormal;
    [SerializeField] private Sprite daniSad;
    [SerializeField] private Sprite daniHappy;

    [SerializeField] Image portraitImage;

    public static UnityEvent<string> StartDialogueEvent;


    float charactersPerSecond = 500;
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
            if (line[1]=='H')
                portraitImage.sprite = clemHappy;
            else if (line[1] == 'N')
                portraitImage.sprite = clemNormal;
            else if (line[1] == 'S')
                portraitImage.sprite = clemSad;
            else if (line[1] == 'A')
                portraitImage.sprite = clemSorpresa;
        }
        else if (line[0]=='D')
        {
            if (line[1] == 'E')
                portraitImage.sprite = daniEstresado;
            else if (line[1] == 'L')
                portraitImage.sprite = daniLlorando;
            else if (line[1] == 'N')
                portraitImage.sprite = daniNormal;
            else if (line[1] == 'S')
                portraitImage.sprite = daniSad;
            else if (line[1] == 'H')
                portraitImage.sprite = daniHappy;
        }
        line = line.Substring(3);
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
