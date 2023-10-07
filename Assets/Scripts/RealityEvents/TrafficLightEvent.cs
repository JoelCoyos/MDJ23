using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightEvent : RealityEvent
{

    [SerializeField] private Collider2D calleCollider;
    [SerializeField] private GameObject redLight;
    [SerializeField] private GameObject greenLight;

    private bool isRedLight;

    public override void Spawn()
    {
        redLight.SetActive(true);
        greenLight.SetActive(false);
        isRedLight = true;
        StartCoroutine(WaitForGreenLight());
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "playerReality")
        {
            if(isRedLight)
            {
                print("daño");
            }
            else
            {
                GameManager.Instance.currentHealth++;
            }
        }
    }

    private IEnumerator WaitForGreenLight()
    {
        yield return new WaitForSeconds(Random.Range(5, 7));

        redLight.SetActive(false);
        greenLight.SetActive(true);
        isRedLight = false;
    }


}
