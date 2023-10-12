using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public abstract class DreamEvent : MonoBehaviour
{

    public UnityEvent<bool> DreamEventResult;
    public SpriteRenderer backgroundSprite;
    [SerializeField] Sprite[] fasesBackground;
    private AudioSource source;

    public abstract void Spawn();

    private void Start()
    {
        source = GetComponent<AudioSource>();
        Spawn();
        source.loop = true;
        StartCoroutine(FadeInMusic());


        if (GameManager.Instance.currentHealth < 4)
            backgroundSprite.sprite = fasesBackground[0];
        else if(GameManager.Instance.currentHealth >= 6 && GameManager.Instance.currentHealth < 10)
            backgroundSprite.sprite = fasesBackground[1];
        else if (GameManager.Instance.currentHealth >= 10)
            backgroundSprite.sprite = fasesBackground[2];
    }

    private IEnumerator FadeInMusic()
    {
        float timeElapsed = 0;
        float lerpDuration = 1.0f;
        float startValue, endValue;
        startValue = 0.0f;
        endValue = 1.0f;
        while (timeElapsed < lerpDuration)
        {
            source.volume = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        source.volume = endValue;
    }

    private IEnumerator FadeOutMusic(bool result)
    {
        float timeElapsed = 0;
        float lerpDuration = 1.0f;
        float startValue, endValue;
        startValue = 1.0f;
        endValue = 0.0f;
        while (timeElapsed < lerpDuration)
        {
            source.volume = Mathf.Lerp(startValue, endValue, timeElapsed / lerpDuration);
            timeElapsed += Time.deltaTime;
            yield return null;
        }
        source.volume = endValue;
    }



}
