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
                    gameMan.minusCrabPoints();
                    invulnerable = true;
                    Invoke(nameof(desInvulnerable), 1f);
                    break;
                case 11:
                    if (invulnerable)
                        return;
                    gameMan.minusOctoPoints();
                    invulnerable = true;
                    Invoke(nameof(desInvulnerable), 1f);
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
