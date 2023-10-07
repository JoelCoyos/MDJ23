using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private float _speed;
    private float currentSpeed;

    void Start()
    {
        currentSpeed = _speed;
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
    }
}
