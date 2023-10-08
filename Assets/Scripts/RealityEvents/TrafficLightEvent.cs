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
        
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.name == "playerReality")
        {
            StartCoroutine(WaitForGreenLight());
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if(!isRedLight)
        {
            GameManager.Instance.currentHealth++;
            print("cruzaste en verde :)");
        }
        else
        {
            print("noooo cruzaste en rojo");
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
