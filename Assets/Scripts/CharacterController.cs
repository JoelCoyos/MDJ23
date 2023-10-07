using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private float _speed;
    private float currentSpeed;
    Animator playerRealityAnimator;

    void Start()
    {
        currentSpeed = _speed;
        playerRealityAnimator = GetComponent<Animator>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentSpeed = 0.0f;
        }
        else if(Input.GetKeyUp(KeyCode.Space))
        {
            currentSpeed = _speed;
        }
        transform.position += currentSpeed * Time.deltaTime * new Vector3(1, 0,0);
        playerRealityAnimator.SetInteger("currentHealth", GameManager.Instance.currentHealth);
    }
}
