using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    public float movementForce = 20f;
    public float jumpForce = 1000f;
    public float maximumVelocity = 7.5f;
    bool grounded = true;
    Rigidbody rigidBody;
    InputAction inputMove;
    InputAction inputJump;
    PlayerInput playerInput;
    public bool crab;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody>();
        playerInput = this.GetComponent<PlayerInput>();
        if(crab){
            inputMove = playerInput.actions.FindAction("MoveCrab");
            inputJump = playerInput.actions.FindAction("JumpCrab");
        } else 
        {
            inputMove = playerInput.actions.FindAction("MoveOctopus");
            inputJump = playerInput.actions.FindAction("JumpOctopus");
        }
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
