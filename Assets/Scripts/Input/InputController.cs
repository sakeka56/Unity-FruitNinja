using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public static InputController instance;
    public static InputController Instance { get { return instance; } }

    public InputActionAsset InputActionAsset;
    public InputActionMap InputActionMap;

    private InputAction Click;
    private InputAction InteractPosition;


    public Action<Vector2> OnClick;
    public Action OnClickStart;
    public Action OnClickCancel;
    private void Awake()
    {


        instance = this;
        DontDestroyOnLoad(gameObject);




        InputActionMap = InputActionAsset.FindActionMap("Default");
        InputActionMap.Enable();

        Click = InputActionMap.FindAction("Click");
        InteractPosition = InputActionMap.FindAction("InteractPosition");

        Click.Enable();
        InteractPosition.Enable();

        Click.started += ctx => OnClickStart?.Invoke();
        Click.canceled += ctx => OnClickCancel?.Invoke();

    }

    private void Update()
    {
        if (Click.IsPressed())
        {
            OnClick?.Invoke(InteractPosition.ReadValue<Vector2>());
        }
    }

}
