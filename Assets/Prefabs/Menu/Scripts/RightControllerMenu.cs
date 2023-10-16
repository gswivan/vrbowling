
using System;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class RightControllerMenu : MonoBehaviour
{

    public InputActionProperty GrabAction;
    public InputActionProperty ResetAction;

    private GameObject ball;
    private GameManager manager;
    private void Awake()
    {
        manager = FindFirstObjectByType<GameManager>();
    }

    private void OnEnable()
    {
        GrabAction.action.performed += OnGrabPressed;
        GrabAction.action.canceled += OnGrabReleased;
        ResetAction.action.performed += OnResetPressed;
        ResetAction.action.canceled += OnResetReleased;
        manager.TakeBallEvent.AddListener(OnTakeBall);
        manager.ReleaseBallEvent.AddListener(OnReleaseBall);
    }

    private void OnDisable()
    {
        manager.ReleaseBallEvent.RemoveListener(OnReleaseBall);
        manager.TakeBallEvent.RemoveListener(OnTakeBall);
        ResetAction.action.performed -= OnResetPressed;
        ResetAction.action.canceled -= OnResetReleased;
        GrabAction.action.performed -= OnGrabPressed;
        GrabAction.action.canceled -= OnGrabReleased;
    }

    void OnGrabPressed(InputAction.CallbackContext context)
    {
    }

    void OnGrabReleased(InputAction.CallbackContext context)
    {
        manager.ReleaseBall();
    }

    void OnResetPressed(InputAction.CallbackContext context)
    {
        manager.ResetPins();
    }

    void OnResetReleased(InputAction.CallbackContext context)
    {
    }

    void OnTakeBall(GameObject obj)
    {
        if (ball != null) return;
        ball = Instantiate(obj);
        ball.GetComponent<Ball>().Attach(transform);
    }

    void OnReleaseBall()
    {
        if (ball == null) return;
        ball.GetComponent<Ball>().Detach();
        ball = null;
    }

}
