using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    float speed = 5f;
    private Controles controles;
    Rigidbody rigid;
    Vector3 direccion;
    InputAction inputaction;
    PlayerInput playerinput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rigid = this.GetComponent<Rigidbody>();
        playerinput = this.GetComponent<PlayerInput>();
        inputaction = playerinput.actions.FindAction("Move");
        controles = new();
    }

    // Update is called once per frame
    void Update()
    {
        //float horizInput = Input.GetAxis("Horizontal");
        //float vertInput = Input.GetAxis("Vertical");
        //Vector3 inputs = new Vector3(horizInput, vertInput, 0);
        //this.transform.position = this.transform.position + inputs * speed * Time.deltaTime;

        direccion = new Vector3(inputaction.ReadValue<Vector2>().x, inputaction.ReadValue<Vector2>().y, 0);        
    }

    private void FixedUpdate()
    {
        transform.position += (direccion * Time.fixedDeltaTime * speed);
    }
}
