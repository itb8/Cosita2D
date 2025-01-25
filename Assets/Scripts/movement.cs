using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    float speed = 0;
    public float movementForce = 20f;
    public float jumpForce = 100f;
    public float maximumVelocity = 5f;
    private Controles controles;
    Rigidbody rigidBody;
    Vector3 direccion;
    InputAction inputMove;
    InputAction inputJump;
    PlayerInput playerInput;
    bool grounded = true;

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
        print(rigidBody.linearVelocity);

        print(grounded);
        if (inputJump.IsPressed() && grounded)
        {
            grounded = false;
            rigidBody.AddForce(new Vector3(0, jumpForce, 0), ForceMode.Impulse);
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
