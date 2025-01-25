using UnityEngine;

public class Bubble : MonoBehaviour
{
    public GameObject coins;
    public bool colliding = false;

    private void OnEnable()
    {
        colliding = false;
    }
    private void OnCollisionEnter(Collision collision)
    {
        for (int i = 0; i < coins.transform.childCount; i++)
        {
            if (colliding)
                return;
            GameObject coin = coins.transform.GetChild(i).gameObject;
            if (coin.activeSelf == false)
            {
                coin.transform.localPosition = this.transform.localPosition;
                coin.SetActive(true);
                colliding = true;
                this.gameObject.SetActive(false);
            }
        }
    }
}
