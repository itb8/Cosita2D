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
    InputAction inputJumpInverted;

    PlayerInput playerInput;
    public bool crab;
    private bool invertedMovement = false;
    public int carringBubbles = 0;
    public int carringBubblesPower = 0;

    public List<GameObject> Bubbles;
    public GameObject Rubbish;

    public GameManager gameMan;

    public bool gameStarted = false;

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
        if(Bubbles[0].activeSelf == false && Bubbles[2].activeSelf == false)
            Bubbles[0].SetActive(true);
        else if (Bubbles[0].activeSelf == true || Bubbles[2].activeSelf == true)
            Bubbles[1].SetActive(true);
    }

    public void addBubblesPower()
    {
        carringBubblesPower++;
        if (Bubbles[0].activeSelf == false && Bubbles[2].activeSelf == false)
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
            inputJumpInverted = playerInput.actions.FindAction("JumpCrabInverted");
        }
        else 
        {
            inputMove = playerInput.actions.FindAction("MoveOctopus");
            inputJump = playerInput.actions.FindAction("JumpOctopus");
            inputJumpInverted = playerInput.actions.FindAction("JumpOctopusInverted");
        }
    }

    public void invertMovement()
    {
        if (!invertedMovement)
        {
            invertedMovement = true;
            Rubbish.SetActive(true);
            Invoke(nameof(desInvertMovement), 5f);
        }       
    }

    private void desInvertMovement()
    {
        invertedMovement = false;
        Rubbish.SetActive(false);
    }

    public void setGameStarted(bool started)
    {
        gameStarted = started;
    }

    private void FixedUpdate()
    {
        if (!gameStarted)
            return;
        float direction = inputMove.ReadValue<Vector2>().x;
        if (invertedMovement)
            direction = direction * -1;

        rigidBody.AddForce(new Vector3(movementForce * direction * Time.fixedDeltaTime, 0, 0), ForceMode.Impulse);
        rigidBody.linearVelocity = Vector3.ClampMagnitude(rigidBody.linearVelocity, maximumVelocity);
        if (invertedMovement && inputJumpInverted.IsPressed() && grounded)
        {
            grounded = false;

            rigidBody.AddForce(new Vector3(0, jumpForce * Time.fixedDeltaTime, 0), ForceMode.Impulse);
        }
        else if (!invertedMovement && inputJump.IsPressed() && grounded)
        {
            grounded = false;

            rigidBody.AddForce(new Vector3(0, jumpForce * Time.fixedDeltaTime, 0), ForceMode.Impulse);
        }

        //moveShadow();
    }

    /*private void moveShadow()
    {
        Ray ray = new Ray(transform.position + (Vector3.up * 40f), Vector3.down * 40f);
        if (Physics.Raycast(ray, out var hit))
        {
            transform.position = hit.point + (Vector3.up * upDecalFromFloor);
            transform.LookAt(transform.position + hit.normal);

            Debug.DrawLine(hit.point, hit.point + (hit.normal * 5));
        }
    }*/

    public bool invulnerable = false;

    private void desInvulnerable()
    {
        invulnerable = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 10 || collision.gameObject.layer == 11)
        {
            grounded = true;
        }
        if (crab && collision.gameObject.layer == 10)
        {
            gameMan.addCrabPoints(carringBubbles+carringBubblesPower);
            carringBubbles = 0;
            carringBubblesPower = 0;
            hideAllBubbles();
            gameMan.coinSound();
        }
        else if (!crab && collision.gameObject.layer == 11)
        {
            gameMan.addOctoPoints(carringBubbles+carringBubblesPower);
            carringBubbles = 0;
            carringBubblesPower = 0;
            hideAllBubbles();
            gameMan.coinSound();
        }
        if (crab && collision.gameObject.layer == 11)
        {
            if (invulnerable)
                return;
            if (gameMan.getCrab().getBubbles() >= 2)
                return;
            if (gameMan.getOctoPoints() <= 0)
                return;
            gameMan.minusOctoPoints();
            gameMan.coinLoseSound();
            addBubbles();
            invulnerable = true;
            Invoke(nameof(desInvulnerable), 2.5f);
        }
        else if (!crab && collision.gameObject.layer == 10)
        {
            if (invulnerable)
                return;
            if (gameMan.getOcto().getBubbles() >= 2)
                return;
            if (gameMan.getCrabPoints() <= 0)
                return;
            gameMan.minusCrabPoints();
            gameMan.coinLoseSound();
            addBubbles();
            invulnerable = true;
            Invoke(nameof(desInvulnerable), 2.5f);
            
        }

    }
}
