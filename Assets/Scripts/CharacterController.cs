using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{

    [SerializeField] private float _speed;

    void Start()
    {
        _speed = 10.0f;
    }

    void Update()
    {
        transform.position += _speed * Time.deltaTime * new Vector3(-1, 0,0);

        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            //Action
        }
    }
}
