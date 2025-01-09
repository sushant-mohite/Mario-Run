using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove1 : MonoBehaviour
{
    public Camera playerCamera;
    public float walkSpeed = 2f;
    public float runSpeed = 4f;
    public float jumpPower = 7f;
    public float gravity = 10f;
    public float lookSpeed = 1f;
    public float lookXLimit = 45f;

    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0f;
    private CharacterController characterController;

    AudioSource audioSource;
    public AudioClip jumpSound;

    private bool canMove = true;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();

        // Lock the cursor
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = true;

        // Initialize the camera's rotation to match the player's
        rotationX = playerCamera.transform.localEulerAngles.x;
        playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
    }

    void Update()
    {
        
        // Movement Logic
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

        float movementDirectionY = moveDirection.y;
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        if (Input.GetButton("Jump") && canMove && characterController.isGrounded)
        {
            moveDirection.y = jumpPower;
            audioSource.PlayOneShot(jumpSound);
        }
        else
        {
            moveDirection.y = movementDirectionY;
        }

        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }

        characterController.Move(moveDirection * Time.deltaTime);

        // Camera and Player Rotation
        if (canMove)
        {
            // Update vertical rotation and clamp
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);

            // Rotate player horizontally
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }
    }
}
