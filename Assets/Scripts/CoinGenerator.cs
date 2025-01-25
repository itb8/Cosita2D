using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public float speedRate = 1.5f;
    public GameObject bubbles;
    public GameObject bubbles2;
    public GameObject coins;
    public GameObject coins2;
    public TimeManager TimeMan;
    public GameManager gameMan;
    bool changeSpeedMusic = false;

    public void StartSpawning()
    {
        InvokeRepeating(nameof(spawnBubbles), 0f, speedRate);
    }

    private void spawnBubbles()
    {
        for (int i = 0; i < bubbles.transform.childCount; i++)
        {
            if(bubbles.transform.GetChild(i).gameObject.activeSelf == false)
            {
                GameObject bubble = bubbles.transform.GetChild(i).gameObject;
                bubble.SetActive(true);
                //float randX = Random.Range(-Screen.width + (Screen.width / 10f), Screen.width - (Screen.width / 10f));
                float randX = Random.Range(-5.35f, 8.15f);

                bubble.transform.localPosition = new Vector3(randX, 6.85f, -25.70824f);
                break;
            }
        }
        if (TimeMan.seconds != 120 && speedRate>0.5f)
        {
            //Debug.Log(TimeMan.seconds % 10);

            if (TimeMan.seconds % 10 == 0)
            {
                newSpawn();
            }
        }
    }

    private void newSpawn()
    {
        CancelInvoke();
        speedRate -= 0.0333f;
        //Debug.Log(speedRate);
        if (speedRate <= 0.55f)
        {
            if(!changeSpeedMusic)
            {
                gameMan.changeMusicSpeed();
                changeSpeedMusic = true;
            }
            InvokeRepeating(nameof(spawnBubbles2), 0.2f, 0.5f);
            return;
        }
        InvokeRepeating(nameof(spawnBubbles), 0.2f, speedRate);
    }

    private void newSpawn2()
    {
        CancelInvoke();
        speedRate -= 0.0333f;
        if (speedRate < 0.15f)
            speedRate = 0.15f;
        InvokeRepeating(nameof(spawnBubbles2), 0.2f, speedRate);
    }

    private void spawnBubbles2()
    {
        if (TimeMan.seconds < 0)
        {
            CancelInvoke();
            return;
        }
            for (int i = 0; i < bubbles2.transform.childCount; i++)
        {
            if (bubbles2.transform.GetChild(i).gameObject.activeSelf == false)
            {
                GameObject bubble = bubbles2.transform.GetChild(i).gameObject;
                bubble.SetActive(true);
                //float randX = Random.Range(-Screen.width + (Screen.width / 10f), Screen.width - (Screen.width / 10f));
                float randX = Random.Range(-4.25f, 6.8f);

                bubble.transform.localPosition = new Vector3(randX, 6.85f, -25.70824f);
                break;
            }
        }
        if (TimeMan.seconds!= 0 && TimeMan.seconds % 10 == 0)
        {
            newSpawn2();
        }
    }
}
