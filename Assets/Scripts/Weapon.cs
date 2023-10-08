using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private Collider2D collider2d;
    private bool isAttacking;
    private Animator weaponAnimator;
    [SerializeField] private Transform player;
    private Vector2 direction;
    float horizontal;
    float vertical;
    float angle;
    float distance = 1.5f;

    AudioSource source;

    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        collider2d = GetComponent<Collider2D>();
        weaponAnimator = GetComponent<Animator>();
        collider2d.enabled = false;
        isAttacking = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isAttacking = true;
        }
        weaponAnimator.SetBool("isAttacking", isAttacking);

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction.x = horizontal;
        direction.y = vertical;
        angle = Mathf.Rad2Deg*Mathf.Atan2(vertical, horizontal);

        transform.localPosition = new Vector3(Mathf.Cos(angle) * distance, Mathf.Sin(angle) * distance, 0);
        transform.localEulerAngles = new Vector3(0, 0, angle - 90);
    }

    private void StartAttack()
    {
        source.Play();
        collider2d.enabled = true;
    }

    private void FinishAttack()
    {
        isAttacking = false;
        collider2d.enabled = false;

    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        GameObject enemy = other.gameObject;
        print(enemy.name);
        if (enemy.tag=="Enemy")
        {
            Destroy(enemy);
            DreamManager.DreamResultEvent.Invoke(true);
        }
    }
}
