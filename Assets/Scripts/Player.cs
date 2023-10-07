using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody2D body;
    Animator playerAnimator;
    SpriteRenderer spriteRenderer;

    float horizontal;
    float vertical;

    bool canTakeDamage;

    public float runSpeed = 20.0f;
    public float thrust=100.0f;

    Vector2 movement;

    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        canTakeDamage = true;
        playerAnimator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        movement = new Vector2(0, 0);
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        movement.x = horizontal;
        movement.y = vertical;

        playerAnimator.SetFloat("Horizontal", horizontal);
        playerAnimator.SetFloat("Vertical", -vertical);
        playerAnimator.SetFloat("Speed",movement.sqrMagnitude);
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, vertical * runSpeed);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Rigidbody2D enemy = other.gameObject.GetComponent<Rigidbody2D>();
        if(enemy!=null && canTakeDamage)
        {
            print("enemigo");
            Vector2 difference = transform.position - enemy.gameObject.transform.position;
            difference = difference.normalized * thrust;
            body.AddForce(difference, ForceMode2D.Impulse);
            DreamManager.DamageDreamHealthEvent.Invoke(1);
            StartCoroutine(IFramesTime());
        }
    }

    IEnumerator IFramesTime()
    {
        canTakeDamage = false;
        yield return new WaitForSeconds(1);
        canTakeDamage = true;
    }


}
