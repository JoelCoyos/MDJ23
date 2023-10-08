using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static UnityEvent StartDreamEvent;
    public int currentHealth;
    public bool canAttack;

    public bool canStartDream;
    public bool canStartDialogue;
    public bool isDialogue;
    public bool isDream;


    private int dialogueNumber;

    string[] dialoguesFiles = { "1", "2", "3", "4", "5"};

    private void Awake()
    {
        StartDreamEvent = new UnityEvent();

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        canStartDream = false;
        canStartDialogue = true;
        isDialogue = false;
        dialogueNumber = 0;
        canAttack = false;
        StartCoroutine(DreamAndDialogueRoutine());
    }

    public IEnumerator DreamAndDialogueRoutine()
    {
        while(true)
        {
            //yield return new WaitUntil(() => canStartDialogue);
            if(dialogueNumber<4)
            {
                isDialogue = true;
                DialogueManager.StartDialogueEvent.Invoke(dialoguesFiles[dialogueNumber]);
                dialogueNumber++;
                yield return new WaitUntil(() => !isDialogue);
            }
            yield return new WaitForSeconds(2.0f);
            StartDreamEvent.Invoke();
            yield return new WaitUntil(() => !isDream);
            yield return new WaitForSeconds(1.0f);
        }

    }

}
