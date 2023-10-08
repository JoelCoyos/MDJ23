using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DreamManager : MonoBehaviour
{

    private bool _isDreaming;

    [SerializeField] GameObject[] dreamEvents;
    private GameObject currentDream;

    public static UnityEvent<int> DamageDreamHealthEvent;

    private int dreamHealth;
    private bool secondPhase;

    private int dreamNumber;

    [SerializeField] private Material dreamMaterial;

    [SerializeField] private float VisionRadius;
    Animator dreamAnimator;

    public enum DreamType
    {
        book,
        shadows,
        eye,
        car
    }

    private DreamType _currentDream;
    public static UnityEvent<bool> DreamResultEvent;

    private void Awake()
    {
        DamageDreamHealthEvent = new UnityEvent<int>();
        DreamResultEvent = new UnityEvent<bool>();
    }


    private void Start()
    {
        GameManager.StartDreamEvent.AddListener(StartDream);
        DamageDreamHealthEvent.AddListener(damageDreamHealth);
        DreamResultEvent.AddListener(DreamResult);
        dreamHealth = 3;
        dreamNumber = 0;
        secondPhase = false;
        dreamAnimator = GetComponent<Animator>();
        //StartDream();

        
    }

    private void Update()
    {
        dreamMaterial.SetFloat("_DreamPlayerVisionRadius", VisionRadius);
    }

    public void StartDream()
    {
        
        dreamHealth = 3;
        dreamAnimator.SetTrigger("EnterDream");
        GameManager.Instance.isDream = true;
        if(dreamNumber==4 && !secondPhase)
        {
            dreamNumber = 0;
            secondPhase=true;
            GameManager.Instance.canAttack = true;
        }
        currentDream =  Instantiate(dreamEvents[dreamNumber]);
        dreamNumber++;
    }

    public void DreamResult(bool result)
    {
        if (result)
        {
            dreamHealth++;
        }
        dreamAnimator.SetTrigger("EndDream");
        StartCoroutine(DestroyDreamRoutine());
        //ResetAllTriggers();
        dreamAnimator.ResetTrigger("TakeDamage"); //horrible
        dreamAnimator.ResetTrigger("EnterDream");
        GameManager.Instance.isDream = false;
    }

    private IEnumerator DestroyDreamRoutine()
    {
        yield return new WaitForSeconds(1.5f);
        Destroy(currentDream);

    }

    public void damageDreamHealth(int points)
    {
        dreamHealth = dreamHealth - points > 0 ? dreamHealth - points : 0;
        
        if (dreamHealth == 0)
        {
            dreamAnimator.SetTrigger("EndDream");
            DreamResult(false);
        }
        else
        {
            dreamAnimator.SetTrigger("TakeDamage");
        }
        

    }

    private void ResetAllTriggers()
    {
        foreach (var param in dreamAnimator.parameters)
        {
            if (param.type == AnimatorControllerParameterType.Trigger)
            {
                dreamAnimator.ResetTrigger(param.name);
            }
        }
    }


}

