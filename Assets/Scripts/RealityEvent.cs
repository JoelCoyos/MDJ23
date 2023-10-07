using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  abstract class RealityEvent : MonoBehaviour
{

    public UnityEvent<bool> RealityEventResult;
    public SpriteRenderer backgroundSprite;

    public abstract void Spawn();

    private void Start()
    {
        backgroundSprite.size = new Vector2(Camera.current.pixelHeight,Camera.current.pixelWidth);
    }
}
