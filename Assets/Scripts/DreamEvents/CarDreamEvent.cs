using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarDreamEvent : DreamEvent
{
    [SerializeField] private GameObject _car;
    private int _timeLeft;
    private Vector3[] screenDirections;
    private float distanceFromScreen;

    public override void Spawn()
    {
        screenDirections = new Vector3[4];
        screenDirections[0] = new Vector2(0, 1);
        screenDirections[1] = new Vector2(1, 0);
        screenDirections[2] = new Vector2(0, -1);
        screenDirections[3] = new Vector2(-1, 0);
        distanceFromScreen = 5.0f;
        StartCoroutine(CarSpawnRoutine());
        StartCoroutine(TimerDream());
    }

    private IEnumerator CarSpawnRoutine()
    {
        while(true)
        {
            yield return new WaitForSeconds(1.0f);
            GameObject car = Instantiate(_car);
            Vector2 direction = screenDirections[Random.Range(0, 4)];
            Vector3 positionCar = direction*distanceFromScreen;
            float offset = Random.Range(1,5);
            if(direction.x==0)
            {
                positionCar.x += Random.Range(0, 2) == 1 ? offset : -offset;
            }
            if (direction.y == 0)
            {
                positionCar.y += Random.Range(0, 2) == 1 ? offset : -offset;
            }
            car.transform.position = positionCar;
        }
    }

    private IEnumerator TimerDream()
    {
        yield return new WaitForSeconds(15.0f);
        DreamManager.DreamResultEvent.Invoke(true);
    }
}
