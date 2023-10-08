using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class DreamEvent : MonoBehaviour
{

    public UnityEvent<bool> DreamEventResult;
    public SpriteRenderer backgroundSprite;

    public abstract void Spawn();

    private void Start()
    {
        Spawn();
    }



}
