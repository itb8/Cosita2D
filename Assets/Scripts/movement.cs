using System.Collections.Generic;
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
    private bool invertedMovement;
    public int carringBubbles = 0;
    public int carringBubblesPower = 0;

    public List<GameObject> Bubbles;

    public GameManager gameMan;

    public void hideAllBubbles()
    {
        for (int i = 0; i < Bubbles.Count; i++)
        {
            Bubbles[i].SetActive(false);
        }
    }

    public void addBubbles()
    {
        carringBubbles++;
        if(Bubbles[0].activeSelf == false || Bubbles[2].activeSelf == false)
            Bubbles[0].SetActive(true);
        else if (Bubbles[0].activeSelf == true || Bubbles[2].activeSelf == true)
            Bubbles[1].SetActive(true);
    }

    public void addBubblesPower()
    {
        carringBubblesPower++;
        if (Bubbles[0].activeSelf == false || Bubbles[2].activeSelf == false)
            Bubbles[2].SetActive(true);
        else if (Bubbles[0].activeSelf == true || Bubbles[2].activeSelf == true)
            Bubbles[3].SetActive(true);
    }

    public int getBubblesPower()
    {
        return carringBubblesPower;
    }

    public int getBubbles()
    {
        return carringBubbles;
    }

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

    public void invertMovement()
    {
        invertedMovement = true;
        Invoke(nameof(desInvertMovement), 5f);
    }

    private void desInvertMovement()
    {
        invertedMovement = false;
    }

    private void FixedUpdate()
    {
        float direction = inputMove.ReadValue<Vector2>().x;
        if (invertedMovement)
            direction = direction * -1;

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
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            grounded = true;
        }
        if (crab && collision.gameObject.layer == 10)
        {
            gameMan.addCrabPoints(carringBubbles);
            carringBubbles = 0;
        }
        else if (!crab && collision.gameObject.layer == 11)
        {
            gameMan.addOctoPoints(carringBubbles);
            carringBubbles = 0;
        }
        if (crab && collision.gameObject.layer == 11)
        {
            gameMan.minusCrabPoints();
            carringBubbles++;
        }
        else if (!crab && collision.gameObject.layer == 10)
        {
            gameMan.minusOctoPoints();
            carringBubbles++;
        }

    }
}
