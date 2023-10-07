using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DreamManager : MonoBehaviour
{

    private bool _isDreaming;
    public enum DreamType
    {
        type1,
        type2,
    }

    private DreamType _currentDream;
    public static UnityEvent<bool> DreamResultEvent;

    private void Start()
    {
        GameManager.StartDreamEvent.AddListener(StartDream);
    }

    public void StartDream(DreamType type)
    {
        //Set up dream
    }
}

