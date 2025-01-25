using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject coins;
    public GameManager gameMan;
    public bool colliding = false;

    private void OnEnable()
    {
        colliding = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.layer == 16)
            return;
        for (int i = 0; i < coins.transform.childCount; i++)
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
        }
    }
}
