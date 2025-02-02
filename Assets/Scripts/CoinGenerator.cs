using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    public float speedRate = 1.5f;
    int rubbishProb = 9;
    public GameObject bubbles;
    public GameObject bubbles2;
    public GameObject rubbish;
    public GameObject coins;
    public GameObject coins2;
    public TimeManager TimeMan;
    public GameManager gameMan;
    bool changeSpeedMusic = false;
    bool bajar = false;
    public void StartSpawning()
    {
        InvokeRepeating(nameof(spawnBubbles), 0f, speedRate);
    }

    private void spawnBubbles()
    {
        float bubbleOrNot = Random.Range(0, 10);
        if (bubbleOrNot >= rubbishProb)
        {
            for (int i = 0; i < bubbles.transform.childCount; i++)
            {
                if (rubbish.transform.GetChild(i).gameObject.activeSelf == false)
                {
                    GameObject rubbis = rubbish.transform.GetChild(i).gameObject;
                    rubbis.SetActive(true);
                    //float randX = Random.Range(-Screen.width + (Screen.width / 10f), Screen.width - (Screen.width / 10f));
                    float randX = Random.Range(-5.35f, 8.15f);

                    rubbis.transform.localPosition = new Vector3(randX, 6.85f, -9.74f);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < bubbles.transform.childCount; i++)
            {
                if (bubbles.transform.GetChild(i).gameObject.activeSelf == false)
                {
                    GameObject bubble = bubbles.transform.GetChild(i).gameObject;
                    bubble.SetActive(true);
                    //float randX = Random.Range(-Screen.width + (Screen.width / 10f), Screen.width - (Screen.width / 10f));
                    float randX = Random.Range(-5.35f, 8.15f);

                    bubble.transform.localPosition = new Vector3(randX, 6.85f, -9.7f);
                    break;
                }
            }
        }

        //if (TimeMan.seconds != 120 && speedRate>0.5f)
        if (Mathf.RoundToInt(TimeMan.seconds) != 60 && speedRate > 0.5f)
        {
            //Debug.Log(Mathf.RoundToInt(TimeMan.seconds) % 10 == 0);
            switch (Mathf.RoundToInt(TimeMan.seconds))
            {
                case 30:
                    if(rubbishProb>8)
                    rubbishProb--;
                    break;
                default:
                    break;
            }
            //if (TimeMan.seconds % 10 == 0)
            if (Mathf.RoundToInt(TimeMan.seconds) % 6 == 0)
            {
                bajar = false;
                newSpawn();
            }
            
        }
    }

    private void newSpawn()
    {
        if (!bajar)
        {
            bajar = true;
            CancelInvoke();
            speedRate -= 0.0333f;
            //Debug.Log(speedRate);
            if (speedRate <= 0.55f)
            {
                if (!changeSpeedMusic)
                {
                    gameMan.changeMusicSpeed();
                    changeSpeedMusic = true;
                }
                InvokeRepeating(nameof(spawnBubbles2), 0.2f, 0.5f);
                return;
            }
            InvokeRepeating(nameof(spawnBubbles), 0.2f, speedRate);
        }   
    }

    private void newSpawn2()
    {
        if (!bajar)
        {
            bajar = true;
            CancelInvoke();
            speedRate -= 0.0333f;
            if (speedRate < 0.5f)
                speedRate = 0.5f;
            InvokeRepeating(nameof(spawnBubbles2), 0.2f, speedRate);
        }       
    }

    private void spawnBubbles2()
    {
        if (TimeMan.seconds < 0)
        {
            CancelInvoke();
            return;
        }
        float bubbleOrNot = Random.Range(0, 10);
        if (bubbleOrNot >= rubbishProb)
        {
            for (int i = 0; i < rubbish.transform.childCount; i++)
            {
                if (rubbish.transform.GetChild(i).gameObject.activeSelf == false)
                {
                    GameObject rubbis = rubbish.transform.GetChild(i).gameObject;
                    rubbis.SetActive(true);
                    //float randX = Random.Range(-Screen.width + (Screen.width / 10f), Screen.width - (Screen.width / 10f));
                    float randX = Random.Range(-5.35f, 8.15f);

                    rubbis.transform.localPosition = new Vector3(randX, 6.85f, -9.7f);
                    break;
                }
            }
        }
        else
        {
            for (int i = 0; i < bubbles2.transform.childCount; i++)
            {
                if (bubbles2.transform.GetChild(i).gameObject.activeSelf == false)
                {
                    GameObject bubble = bubbles2.transform.GetChild(i).gameObject;
                    bubble.SetActive(true);
                    //float randX = Random.Range(-Screen.width + (Screen.width / 10f), Screen.width - (Screen.width / 10f));
                    float randX = Random.Range(-4.25f, 6.8f);

                    bubble.transform.localPosition = new Vector3(randX, 6.85f, -9.7f);
                    break;
                }
            }
        }
        switch (Mathf.RoundToInt(TimeMan.seconds))
        {
            case 15:
                if (rubbishProb > 7)
                    rubbishProb--;
                break;
            default:
                break;
        }
        //if (TimeMan.seconds!= 0 && TimeMan.seconds % 10 == 0)
        if (Mathf.RoundToInt(TimeMan.seconds) != 0 && Mathf.RoundToInt(TimeMan.seconds) % 6 == 0)
        {
            bajar = false;
            newSpawn2();
        }
    }
}
