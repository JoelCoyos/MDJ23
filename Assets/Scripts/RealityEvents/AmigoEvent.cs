using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmigoEvent : RealityEvent
{
    [SerializeField] private Collider2D amigoCollider;

    private bool isAmigoHappy;

    [SerializeField] private Animator animatorAmigo;

    private void Start()
    {
        
    }

    public override void Spawn()
    {
        isAmigoHappy = false;
    }

    private void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.name == "playerReality")
        {
            StartCoroutine(WaitForAmigo());
        }
    }

    private void OnTriggerExit2D(Collider2D coll)
    {
        if (isAmigoHappy)
        {
            GameManager.Instance.currentHealth++;
            print("amigo feliz :)");
        }
        else
        {
            print("noooo amigo triste");
            animatorAmigo.SetTrigger("IsSad");
        }
    }

    private IEnumerator WaitForAmigo()
    {
        yield return new WaitForSeconds(Random.Range(3, 5));
        animatorAmigo.SetTrigger("IsHappy");
        isAmigoHappy = true;
    }

}
