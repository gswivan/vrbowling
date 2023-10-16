using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameManager : MonoBehaviour
{

    public UnityEvent<GameObject> TakeBallEvent;
    public UnityEvent ReleaseBallEvent;
    public UnityEvent ResetPinsEvent;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    public void TakeBall(GameObject ball)
    {
        TakeBallEvent.Invoke(ball);
    }

    public void ReleaseBall()
    {
        ReleaseBallEvent.Invoke();
    }

    public void ResetPins()
    {
        ResetPinsEvent.Invoke();
    }

    public static GameManager Get()
    {
        return FindFirstObjectByType<GameManager>();
    }

}
