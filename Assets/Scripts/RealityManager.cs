using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RealityManager : MonoBehaviour
{

    [SerializeField] private Transform _playerTranform;
    [SerializeField] private float _farPoint;
    private float spriteLenght;

    private void Start()
    {
        _farPoint = 30;
        SpawnNewEvent();
    }

    private void Update()
    {
        if(_playerTranform.position.x > _farPoint - spriteLenght)
        {
            SpawnNewEvent();
        }
    }

    [SerializeField] GameObject[] RealityEvents;

    private void SpawnNewEvent()
    {
        RealityEvent realityEvent =  Instantiate(RealityEvents[0]).GetComponent<RealityEvent>();
        realityEvent.transform.position = new Vector3(_farPoint,0,0);
        realityEvent.Spawn();
        spriteLenght = realityEvent.backgroundSprite.bounds.extents.x * 2;
        print(spriteLenght);
        _farPoint += spriteLenght;

    }
}
