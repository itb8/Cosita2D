using UnityEngine;

public class Box : MonoBehaviour
{
    public int enemyHand = 0;
    public GameManager gameMan;
    public bool invulnerable = false;
    private void OnCollisionEnter(Collision collision)
    {
       // Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == enemyHand)
        {
            switch (collision.gameObject.layer)
            {
                case 10:
                    if (invulnerable)
                        return;
                    if (gameMan.getCrab().getBubbles() >= 2)
                        return;
                    if (gameMan.getOctoPoints() > 1)
                        return;
                    gameMan.minusOctoPoints();
                    gameMan.addBubblesToCrab();
                    invulnerable = true;
                    Invoke(nameof(desInvulnerable), 2.5f);
                    break;
                case 11:
                    if (invulnerable)
                        return;
                    if (gameMan.getOcto().getBubbles() >= 2)
                        return;
                    if (gameMan.getCrabPoints() > 1)
                        return;
                    gameMan.minusCrabPoints();
                    gameMan.addBubblesToOcto();
                    invulnerable = true;
                    Invoke(nameof(desInvulnerable), 2.5f);
                    break;
                default:
                    break;
            }
        }

    }

    private void desInvulnerable()
    {
        invulnerable = false;
    }
}
