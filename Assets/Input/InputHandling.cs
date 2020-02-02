using UnityEngine;
using UnityEngine.InputSystem;

public class InputHandling : MonoBehaviour
{
    private InputManager controls;
    private Vector2 moveInput;
    public float movespeed = 1.5f;
    public float jumpForce = 3f;
    public bool isGrounded = false;
    [Range(1,4)]
    public int characterSelection;
    public RuntimeAnimatorController[] animController;
    private Animator animator;

    // see https://www.youtube.com/watch?v=Pzd8NhcRzVo
    // and https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Components.html

    private void Start()
    {
        /*
        Debug.Log(Gamepad.all);
        Debug.Log(Keyboard.all);
        */

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animController[characterSelection - 1];
    }
     
    private void Update()
    {
        HandleInput();

        if (animator.runtimeAnimatorController != animController[characterSelection - 1]) animator.runtimeAnimatorController = animController[characterSelection - 1];

    }

    private void Awake()
    {
        controls = new InputManager();
        controls.Player.Jump.performed += ctx => Jump();
        controls.Player.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
        //controls.Player.Interact.performed += ctx => Interact();
    }

    private void HandleInput()
    {
        /*
        // this is the alternative way
        Debug.Log(Gamepad.current.leftStick.ReadValue());
        moveInput = Gamepad.current.leftStick.ReadValue();
        */
        float currentMovespeed = movespeed * (gameObject.GetComponent<PlayerCharge>().batteryCharge * 0.01f) + 0.5f;
        Vector3 pos = gameObject.transform.position;
        pos.x += moveInput.x * Time.deltaTime * movespeed * currentMovespeed;
        gameObject.transform.position = pos;
       
    }

    private void Jump()
    {
        // Debug.Log("Jumped");
        if (isGrounded)
        {
            float currentjumpForce = jumpForce * (gameObject.GetComponent<PlayerCharge>().batteryCharge * 0.01f) + 2f;
            Vector2 gravity = -Physics2D.gravity;
            gameObject.GetComponent<Rigidbody2D>().AddForce(gravity.normalized * currentjumpForce, ForceMode2D.Impulse);
        }
        
    }

    private void OnMove(Vector2 value)
    {
        moveInput = value;

        if(value.x != 0)
        {
            animator.SetBool("isWalking", true);
            if(value.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
        }
        else
        {
            animator.SetBool("isWalking", false);
        }
    }

    private void OnEnable()
    {
        controls.Enable();
    }

    private void OnDisable()
    {
        controls.Disable();
    }
}
