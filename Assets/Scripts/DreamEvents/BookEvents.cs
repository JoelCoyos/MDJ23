using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookEvents : DreamEvent
{
    public override void Spawn()
    {
        StartCoroutine(TimerDream());
    }

    private IEnumerator TimerDream()
    {
        yield return new WaitForSeconds(15.0f);
        DreamManager.DreamResultEvent.Invoke(true);
    }
}
