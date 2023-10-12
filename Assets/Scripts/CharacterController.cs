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

        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.LeftShift) || Input.GetKeyDown(KeyCode.C) || Input.GetKeyDown(KeyCode.J))
        {
            currentSpeed = 0.0f;
            playerRealityAnimator.SetBool("isIdle", true);
        }
        if (Input.GetKeyUp(KeyCode.LeftControl) || Input.GetKeyUp(KeyCode.LeftShift) || Input.GetKeyUp(KeyCode.C) || Input.GetKeyUp(KeyCode.J))
        {
            currentSpeed = _speed;
            playerRealityAnimator.SetBool("isIdle", false);
        }
        if(Input.GetKeyDown(KeyCode.P))
        {
            GameManager.Instance.currentHealth++;
            print(GameManager.Instance.currentHealth);
        }
        transform.position += currentSpeed * Time.deltaTime * new Vector3(1, 0,0);
        playerRealityAnimator.SetFloat("Health", GameManager.Instance.currentHealth);
    }
}
