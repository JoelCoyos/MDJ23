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

    public enum DreamType
    {
        eye,
        book
    }

    private DreamType _currentDream;
    public static UnityEvent<bool> DreamResultEvent;

    private void Awake()
    {
        DamageDreamHealthEvent = new UnityEvent<int>();
    }

    private void Start()
    {
        GameManager.StartDreamEvent.AddListener(StartDream);
        DamageDreamHealthEvent.AddListener(damageDreamHealth);
        dreamHealth = 3;
        StartDream(DreamType.eye);
    }

    public void StartDream(DreamType type)
    {
        currentDream =  Instantiate(dreamEvents[(int)type]);
    }

    public void damageDreamHealth(int points)
    {
        dreamHealth = dreamHealth - points > 0 ? dreamHealth - points : 0;
        if(dreamHealth == 0)
            Destroy(currentDream);
    }


}

