using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    private float angle = 0f;

    AudioSource source;

    [SerializeField] AudioClip[] attacksAudio;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 1f, 0.1f);
        source = GetComponent<AudioSource>();
        StartCoroutine(PlayAttackSound());
    }

   
    private void Fire()
    {
        for (int i = 0; i <= 10; i++)
        {
            Vector2 bulDir = new Vector2(Mathf.Sin(((angle + 180f * i) * Mathf.PI) / 180f), Mathf.Cos(((angle + 180f * i) * Mathf.PI) / 180f));

            GameObject bul = BulletPool.instance.GetBullet();

            if(bul != null)
            {
                bul.transform.position = transform.position;
                bul.transform.rotation = transform.rotation;
                bul.SetActive(true);
                bul.GetComponent<Bullet>().SetMoveDirection(bulDir);
            }
            
        }
        angle += 10f;

        if (angle >= 360f)
        {
            angle = 0f;
        }
    }

    private IEnumerator PlayAttackSound()
    {
        while(true)
        {
            yield return new WaitForSeconds(Random.Range(1, 3));
            source.clip = attacksAudio[Random.Range(0,attacksAudio.Length-1)];
            source.loop = false;
            source.Play();
        }
    }

}
