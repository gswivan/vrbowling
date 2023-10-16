
using UnityEngine;
using UnityEngine.InputSystem;

public class LeftControllerMenu : MonoBehaviour
{
    public Canvas Menu;
    public InputActionProperty MenuAction;

    private GameManager manager;

    void Awake()
    {
        manager = GameManager.Get();
        Menu.enabled = false;
    }

    private void OnEnable()
    {
        MenuAction.action.performed += OnEnableMenu;
        MenuAction.action.canceled += OnDisableMenu;
    }

    private void OnDisable()
    {
        MenuAction.action.performed -= OnEnableMenu;
        MenuAction.action.canceled -= OnDisableMenu;
    }

    void OnEnableMenu(InputAction.CallbackContext Context_)
    {
        Menu.enabled = true;
    }

    void OnDisableMenu(InputAction.CallbackContext Context_)
    {
        Menu.enabled = false;
    }

    public void RequestBall(GameObject ball)
    {
        manager.TakeBall(ball);
    }

}
