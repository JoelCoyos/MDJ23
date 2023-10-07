using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    public static UnityEvent<DreamManager.DreamType> StartDreamEvent;
    public int currentHealth;

    private void Awake()
    {
        StartDreamEvent = new UnityEvent<DreamManager.DreamType>();

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
        
    }

}
