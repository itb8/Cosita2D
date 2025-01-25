using UnityEngine;

public class Coin : MonoBehaviour
{
    public int points = 1;
    public GameManager gameMan;

    private void OnCollisionEnter(Collision collision)
    {
        //Debug.Log(collision.gameObject.layer);

        switch (collision.gameObject.layer)
        {
            case 9:
                Invoke(nameof(Despawn), 0.5f);
                break;
            case 10:
                gameMan.addCrabPoints(points);
                gameMan.coinSound();
                Invoke(nameof(Despawn), 0f);
                break;
            case 11:
                gameMan.addOctoPoints(points);
                gameMan.coinSound();
                Invoke(nameof(Despawn), 0f);
                break;
            default:
                break;
        }
    }

    private void Despawn()
    {
        this.gameObject.SetActive(false);
    }
}
