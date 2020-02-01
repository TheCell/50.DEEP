using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandling : MonoBehaviour
{
    private InputManager controls;
    private Vector2 moveInput;

    private void Start()
    {
        /*
        Debug.Log(Gamepad.all);
        Debug.Log(Keyboard.all);
        */
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        /*
        Debug.Log(Gamepad.current.leftStick.ReadValue());
        moveInput = Gamepad.current.leftStick.ReadValue();
        */

        Vector3 pos = gameObject.transform.position;
        pos.x += moveInput.x * Time.deltaTime;
        pos.y += moveInput.y * Time.deltaTime;
        gameObject.transform.position = pos;
    }

    private void Awake()
    {
        controls = new InputManager();
        controls.Player.Jump.performed += ctx => Jump();
        controls.Player.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }

    private void Jump()
    {
        Debug.Log("Jumped");
    }

    private void OnMove(Vector2 value)
    {
        moveInput = value;
        Debug.Log(moveInput);
    }
}
