using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    float speed = 0;
    public float acceleration = 25f;
    public float jumpForce = 25f;
    float maximumVelocity = 0.1f;
    Vector3 velocity;
    private Controles controles;
    Rigidbody rigidBody;
    Vector3 direccion;
    InputAction inputMove;
    InputAction inputJump;
    PlayerInput playerInput;
    bool grounded = false;

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
        //float horizInput = Input.GetAxis("Horizontal");
        //float vertInput = Input.GetAxis("Vertical");
        //Vector3 inputs = new Vector3(horizInput, vertInput, 0);
        //this.transform.position = this.transform.position + inputs * speed * Time.deltaTime;

    }

    private void FixedUpdate()
    {
        // direccion = new Vector3(inputMove.ReadValue<Vector2>().x, 0, 0);
        float direction = inputMove.ReadValue<Vector2>().x;
        /*if (direction == 0)
        {
            // si el jugador no pulsa nada pierde velocidad
            if (speed > 0)
            {
                // si la velocidad es positiva le resto
                speed -= deacceleration * Time.fixedDeltaTime;
            }
            else
            if (speed < 0)
            {
                speed += deacceleration * Time.fixedDeltaTime;
            }
            // TODO qué pasa cuando la resta no da 0
        }
        else
        {
            speed += acceleration * direction * Time.fixedDeltaTime;
        }*/


        //speed = Mathf.Clamp(speed, -maximumVelocity, maximumVelocity);
        // print(speed);
        rigidBody.AddForce(new Vector3(acceleration * direction * Time.fixedDeltaTime, 0, 0), ForceMode.Impulse);

        if (inputJump.IsPressed() && grounded)
        {
            grounded = false;
            rigidBody.AddForce(new Vector3(0, jumpForce * Time.fixedDeltaTime, 0), ForceMode.Impulse);
        }
        // usar ForceMode.Impulse); para saltos esporádicos

        //rigid.linearVelocity = new Vecto3 speed;
        //transform.position += new Vector3(speed, 0, 0);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9)
        {
            grounded = true;
        }
    }
}
