using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

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

    string[] dialoguesFiles = { "1","3", "4", "5","6"};

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

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("Menu");
        }
        if(Input.GetKeyDown(KeyCode.Home))
        {
            SceneManager.LoadScene("BadEnding");
        }
        if (Input.GetKeyDown(KeyCode.End))
        {
            SceneManager.LoadScene("GoodEnding");
        }
    }

    public IEnumerator DreamAndDialogueRoutine()
    {
        while(true)
        {
            //yield return new WaitUntil(() => canStartDialogue);
            if(dialogueNumber<5)
            {
                isDialogue = true;
                DialogueManager.StartDialogueEvent.Invoke(dialoguesFiles[dialogueNumber]);
                dialogueNumber++;
                yield return new WaitUntil(() => !isDialogue);
            }
            print(DreamManager.dreamNumber);
            if(DreamManager.dreamNumber == 4 && canAttack)
            {

                //Trigerearcutscene
                if(currentHealth>=10)
                {
                    isDialogue = true;
                    DialogueManager.StartDialogueEvent.Invoke("7");
                    yield return new WaitUntil(() => !isDialogue);
                    print(" GOOD ENDING : DEJAS LA FACULTAD");
                    SceneManager.LoadScene("GoodEnding");
                }
                else
                {
                    print(" BAD ENDING: ESTUDIAS PSICOLOGIA");
                    SceneManager.LoadScene("BadEnding");
                }
            }
            yield return new WaitForSeconds(2.0f);
            StartDreamEvent.Invoke();
            yield return new WaitUntil(() => !isDream);
            yield return new WaitForSeconds(1.0f);
        }

    }

}
