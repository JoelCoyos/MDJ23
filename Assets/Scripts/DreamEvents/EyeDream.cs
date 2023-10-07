using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeDream : DreamEvent
{
    [SerializeField] private GameObject _eye;
    private int _timeLeft;

    public override void Spawn()
    {
        StartCoroutine(TimerDream());
    }

    private IEnumerator TimerDream()
    {
        yield return new WaitForSeconds(60.0f);
        DreamManager.DreamResultEvent.Invoke(true);
    }

}
