using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public Rigidbody body;

    private Vector3 previousPosition;
    private Vector3 velocity;

    public void OnEnable()
    {
        velocity = Vector3.zero;
        previousPosition = transform.position;
    }

    public void Attach(Transform parent_)
    {
        body.isKinematic = true;
        gameObject.transform.SetParent(parent_);
        gameObject.transform.localPosition = Vector3.zero;
        gameObject.transform.localRotation = Quaternion.identity;
        previousPosition = transform.position;
    }

    public void Detach()
    {
        body.isKinematic = false;
        body.velocity = velocity;
        gameObject.transform.SetParent(null);
        Destroy(gameObject, 20.0f);
    }

    private void Update()
    {
        velocity = (transform.position - previousPosition) / Time.deltaTime;
        previousPosition = transform.position;
    }

}
