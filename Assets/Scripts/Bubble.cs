using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject coins;
    public GameManager gameMan;
    public int points = 1;
    public bool colliding = false;

    private void OnEnable()
    {
        colliding = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 16)
            return;

        switch (collision.gameObject.layer)
        {
            case 9:
                gameMan.bubbleSound();
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
        /*for (int i = 0; i < coins.transform.childCount; i++)
        {
            if (colliding)
                return;
            GameObject coin = coins.transform.GetChild(i).gameObject;
            if (coin.activeSelf == false)
            {
                gameMan.bubbleSound();
                coin.transform.localPosition = this.transform.localPosition;
                coin.SetActive(true);
                colliding = true;
                this.gameObject.SetActive(false);
            }
        }*/
    }
    private void Despawn()
    {
        this.gameObject.SetActive(false);
    }
}
