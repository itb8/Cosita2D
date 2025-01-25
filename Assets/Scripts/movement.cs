using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float movementForce = 20f;
    public float jumpForce = 1000f;
    public float maximumVelocity = 7.5f;
    bool grounded = true;
    private Controles controles;
    Rigidbody rigidBody;
    InputAction inputMove;
    InputAction inputJump;
    PlayerInput playerInput;

    public int personaje;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        playerInput = this.GetComponent<PlayerInput>();
        controles = new();
        inputMove = playerInput.actions.FindAction("Move");
        inputJump = playerInput.actions.FindAction("Jump");
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        float direction = inputMove.ReadValue<Vector2>().x;

        rigidBody.AddForce(new Vector3(movementForce * direction * Time.fixedDeltaTime, 0, 0), ForceMode.Impulse);
        rigidBody.linearVelocity = Vector3.ClampMagnitude(rigidBody.linearVelocity, maximumVelocity);

        if (inputJump.IsPressed() && grounded)
        {
            grounded = false;
            rigidBody.AddForce(new Vector3(0, jumpForce * Time.fixedDeltaTime, 0), ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            grounded = true;
        }
    }
}
