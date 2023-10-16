using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Pin : MonoBehaviour
{

    private Vector3 startPosition;
    private Quaternion startRotation;

    private GameManager manager;

    private void Awake()
    {
        manager = GameManager.Get();
    }

    private void OnEnable()
    {
        manager.ResetPinsEvent.AddListener(OnResetPin);
    }

    private void OnDisable()
    {
        manager.ResetPinsEvent.RemoveListener(OnResetPin);
    }

    void Start()
    {
        startPosition = transform.position;
        startRotation = transform.rotation;
    }

    void OnResetPin()
    {
        transform.position = startPosition;
        transform.rotation = startRotation;
        GetComponent<Rigidbody>().velocity = Vector3.zero;
        GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
    }

}
