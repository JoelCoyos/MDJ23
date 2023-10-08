using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    private Vector3 _movementDirection;

    [SerializeField] private float _speed;
    [SerializeField] Animator carAnimator;
    [SerializeField] SpriteRenderer _spriteRenderer;

    private void Start()
    {
        Vector2 carPosition = transform.position;
        if(carPosition.x < 0 && carPosition.y>0) //Cuadrante 1
        {
            _movementDirection = new Vector3(1, -1);
        }
        else if (carPosition.x > 0 && carPosition.y > 0) //Cuadrante 2
        {
            _movementDirection = new Vector3(-1, -1);
        }
        else if (carPosition.x < 0 && carPosition.y < 0) //Cuadrante 3
        {
            _movementDirection = new Vector3(1, 1);
        }
        else if (carPosition.x > 0 && carPosition.y < 0) //Cuadrante 4
        {
            _movementDirection = new Vector3(-1, 1);
        }
        carAnimator.SetFloat("yDic", _movementDirection.y);
        if (_movementDirection.x > 0)
            _spriteRenderer.flipX = true;

        StartCoroutine(Despawn());
    }

    private void Update()
    {
        this.transform.position += _movementDirection * _speed * Time.deltaTime;
    }

    IEnumerator Despawn()
    {
        yield return new WaitForSeconds(5.0f);
        Destroy(this);
    }


}
