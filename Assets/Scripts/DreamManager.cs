using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DreamManager : MonoBehaviour
{

    private bool _isDreaming;

    [SerializeField] GameObject[] dreamEvents;

    public static UnityEvent<int> DamageDreamHealthEvent;

    private int dreamHealth;

    public enum DreamType
    {
        enemies,
        cars,
        type3
    }

    private DreamType _currentDream;
    public static UnityEvent<bool> DreamResultEvent;

    private void Start()
    {
        GameManager.StartDreamEvent.AddListener(StartDream);
        DamageDreamHealthEvent.AddListener(damageDreamHealth);
        dreamHealth = 3;
    }

    public void StartDream(DreamType type)
    {
        Instantiate(dreamEvents[(int)type]);
    }

    public void damageDreamHealth(int points)
    {
        dreamHealth = dreamHealth - points > 0 ? dreamHealth - points : 0;
    }


}

