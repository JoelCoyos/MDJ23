using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShadowBuller : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 3.0f;
    public GameObject bullyingPrefab;
    public float shootDistance = 5.0f;
    public float timeBetweenShots = 2.0f;
    private float lastShotTime;

    [SerializeField] Animator shadowAnimator;

    // Update is called once per frame
    void Update()
    {
        Vector3 moveDirection = (player.position - transform.position).normalized;
        transform.Translate(moveDirection *  moveSpeed * Time.deltaTime);

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (moveDirection.magnitude <= shootDistance) 
        { 
            if (Time.time -  lastShotTime >= timeBetweenShots) 
            {
                Shoot();
            }
        }

    }
    void Shoot()
    {
        shadowAnimator.SetTrigger("ShadowAttack");
        lastShotTime = Time.time;

        GameObject newProjectile = Instantiate(bullyingPrefab, transform.position, Quaternion.identity);

        Vector3 moveDirection = (player.position - transform.position).normalized;

        Rigidbody2D rb = newProjectile.GetComponent<Rigidbody2D>();
        rb.velocity = moveDirection * moveSpeed;
    }
}
