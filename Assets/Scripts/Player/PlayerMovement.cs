using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    //private InputManager controls;
    private Vector2 moveInput;
    public float movespeed = 2f;
    public float jumpForce = 3f;
    public bool isGrounded = false;
    [Range(1,4)]
    public int characterSelection;
    public RuntimeAnimatorController[] animController;
    private Animator animator;

    private AudioSource audioSource;
    public AudioClip walkSound;
    public AudioClip jumpSound;
    public AudioClip landSound;

    // see https://www.youtube.com/watch?v=Pzd8NhcRzVo
    // and https://docs.unity3d.com/Packages/com.unity.inputsystem@1.0/manual/Components.html

    private void Start()
    {
        // Move Player to top right at start
        gameObject.transform.position = new Vector2(1, 3);

        animator = GetComponent<Animator>();
        animator.runtimeAnimatorController = animController[characterSelection - 1];
        audioSource = GetComponent<AudioSource>();

    }

    private void Update()
    {
        Move();

        if (animator.runtimeAnimatorController != animController[characterSelection - 1]) animator.runtimeAnimatorController = animController[characterSelection - 1];

    }

    private void Awake()
    {
        //controls = new InputManager();
        //controls.Player.Jump.performed += ctx => Jump();
        //controls.Player.Move.performed += ctx => OnMove(ctx.ReadValue<Vector2>());
    }

    private void Move()
    {
        float currentMovespeed = movespeed * (gameObject.GetComponent<PlayerCharge>().batteryCharge * 0.01f) + 1f;
        Vector3 pos = gameObject.transform.position;
        pos.x += moveInput.x * Time.deltaTime * currentMovespeed;
        gameObject.transform.position = pos;
       
    }

    public void PlayLandingSound()
    {
        audioSource.PlayOneShot(landSound);
    }

    void OnJump()
    {
        // Debug.Log("Jumped");
        if (isGrounded)
        {
            float currentjumpForce = jumpForce * (gameObject.GetComponent<PlayerCharge>().batteryCharge * 0.01f) + 2f;
            Vector2 gravity = -Physics2D.gravity;
            gameObject.GetComponent<Rigidbody2D>().AddForce(gravity.normalized * currentjumpForce, ForceMode2D.Impulse);
            audioSource.PlayOneShot(jumpSound);
        }
        
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();

        if(moveInput.x != 0)
        {
            animator.SetBool("isWalking", true);
            if(moveInput.x < 0)
            {
                transform.localRotation = Quaternion.Euler(0, 180, 0);
            }
            else
            {
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            audioSource.PlayOneShot(walkSound);
        }
        else
        {
            animator.SetBool("isWalking", false);
            audioSource.Stop();
        }
    }

    //private void OnEnable()
    //{
    //    controls.Enable();
    //}

    //private void OnDisable()
    //{
    //    controls.Disable();
    //}
}
