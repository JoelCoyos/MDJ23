using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DreamManager : MonoBehaviour
{

    private bool _isDreaming;

    [SerializeField] GameObject[] dreamEvents;
    private GameObject currentDream;

    public static UnityEvent<int> DamageDreamHealthEvent;

    private int dreamHealth;

    [SerializeField] private Material dreamMaterial;

    [SerializeField] private float VisionRadius;
    Animator dreamAnimator;

    public enum DreamType
    {
        eye,
        book
    }

    private DreamType _currentDream;
    public static UnityEvent<bool> DreamResultEvent;

    private void Awake()
    {
        DamageDreamHealthEvent = new UnityEvent<int>();
    }

    private void Update()
    {
        dreamMaterial.SetFloat("_DreamPlayerVisionRadius", VisionRadius);
    }

    private void Start()
    {
        GameManager.StartDreamEvent.AddListener(StartDream);
        DamageDreamHealthEvent.AddListener(damageDreamHealth);
        dreamHealth = 3;
        dreamAnimator = GetComponent<Animator>();
        StartDream(DreamType.eye);
    }

    public void StartDream(DreamType type)
    {
        currentDream =  Instantiate(dreamEvents[(int)type]);
    }

    public void damageDreamHealth(int points)
    {
        dreamHealth = dreamHealth - points > 0 ? dreamHealth - points : 0;
        dreamAnimator.SetTrigger("TakeDamage");
        if (dreamHealth == 0)
            Destroy(currentDream);
    }


}

