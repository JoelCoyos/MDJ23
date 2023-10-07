using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed;
    Animator eyeAnimator;
    void Start()
    {
        StartCoroutine(ShootPlayerRoutine());
        eyeAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShootProjectile()
    {
        GameObject gameObject =  Instantiate(projectile);
        gameObject.transform.position = transform.position;
        StartCoroutine(UpdateProjectile(gameObject.transform, playerTransform.position));
    }

    private IEnumerator ShootPlayerRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(Random.Range(3, 5));
            ShootProjectile();
            eyeAnimator.SetTrigger("AtaqueTrigger");
        }
    }

    private IEnumerator UpdateProjectile(Transform projectileTransform,Vector2 target )
    {
        float timeElapsed = 0;
        float lerpDuration = 3.0f;
        while(timeElapsed < lerpDuration)
        {
            projectileTransform.position = Vector3.Lerp(projectileTransform.position, target,timeElapsed/lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        projectileTransform.position = target;
    }
}
