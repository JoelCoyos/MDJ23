using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomMovement : MonoBehaviour
{
    public float speed; // Enemy movement speed
    public float minWaitTime; // Minimum wait time before changing direction
    public float maxWaitTime; // Maximum wait time before changing direction

    private Vector2 target;
    private float waitTime;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the initial target and wait time
        target = GenerateRandomPosition();
        waitTime = Random.Range(minWaitTime, maxWaitTime);
    }

    // Update is called once per frame
    void Update()
    {
        // Move towards the target
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        // If the enemy reaches the target, generate a new one and wait
        if ((Vector2)transform.position == target)
        {
            target = GenerateRandomPosition();
            waitTime = Random.Range(minWaitTime, maxWaitTime);
        }

        // Count down the wait time
        waitTime -= Time.deltaTime;

        // If wait time runs out, generate a new target
        if (waitTime <= 0)
        {
            target = GenerateRandomPosition();
            waitTime = Random.Range(minWaitTime, maxWaitTime);
        }
    }
    Vector2 GenerateRandomPosition()
    {
        // Generate a random position within the movement boundaries
        float x = Random.Range(-3.25f, 3f); // Adjust these values based on your movement boundaries
        float y = Random.Range(-2.5f, 2f); // Adjust these values based on your movement boundaries
        return new Vector2(x, y);
    }
}
