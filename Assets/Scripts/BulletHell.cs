using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHell : MonoBehaviour
{
    private float angle = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Fire", 0f, 0.1f);
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

}
