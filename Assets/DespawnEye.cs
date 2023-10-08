using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnEye : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DreamManager.DreamResultEvent.AddListener(Despawn);
        StartCoroutine(SALIDEACA());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator SALIDEACA()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this.gameObject);
    }

    private void Despawn(bool result)
    {
        Destroy(this.gameObject);
    }
}
