using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    private int currentScore;

    public static UnityEvent<DreamManager.DreamType> StartDreamEvent;

}
