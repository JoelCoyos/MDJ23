using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy1 : MonoBehaviour
{

    [SerializeField] Transform playerTransform;
    [SerializeField] GameObject projectile;
    [SerializeField] float projectileSpeed;
    Animator eyeAnimator;

    List<GameObject> eyes;
    void Start()
    {
        StartCoroutine(ShootPlayerRoutine());
        eyeAnimator = GetComponent<Animator>();
        eyes = new List<GameObject>();

        DreamManager.DreamResultEvent.AddListener(DestroyAllEyes);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void ShootProjectile()
    {
        GameObject gameObject =  Instantiate(projectile);
        gameObject.transform.position = transform.position;
        eyes.Add(gameObject);
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

    private void DestroyAllEyes(bool result)
    {
        foreach(GameObject gameObject in eyes)
        {
            Destroy(gameObject);
        }
    }
}
