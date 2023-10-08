using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityManager : MonoBehaviour
{

    [SerializeField] private Transform _playerTranform;
    [SerializeField] private float _farPoint;
    private float spriteLenght;

    AudioSource source;

    [SerializeField] AudioClip loopIntro;
    [SerializeField] AudioClip loopA;
    [SerializeField] AudioClip loopB;

    private void Start()
    {
        _farPoint = 30;
        SpawnNewEvent();

        source = GetComponent<AudioSource>();

        source.clip = loopIntro;
        source.loop = false;
        source.Play();

        GameManager.StartDreamEvent.AddListener(EnterDream);
        DreamManager.DreamResultEvent.AddListener(LeaveDream);

    }

    private void Update()
    {
        if(_playerTranform.position.x > _farPoint - spriteLenght)
        {
            SpawnNewEvent();
        }
        if(!source.isPlaying)
        {
            source.clip = loopA;
            source.loop = true;
            source.Play();
        }
    }

    [SerializeField] GameObject[] RealityEvents;

    private void SpawnNewEvent()
    {
        RealityEvent realityEvent =  Instantiate(RealityEvents[Random.Range(0,3)]).GetComponent<RealityEvent>();
        realityEvent.transform.position = new Vector3(_farPoint,0,0);
        realityEvent.Spawn();
        spriteLenght = realityEvent.backgroundSprite.bounds.extents.x * 2;
        _farPoint += spriteLenght;
    }

    private void EnterDream()
    {
        StartCoroutine(FadeOutMusic());
    }
    private void LeaveDream(bool result)
    {
        StartCoroutine(FadeInMusic());
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

    private IEnumerator FadeOutMusic()
    {
        float timeElapsed = 0.0f;
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
