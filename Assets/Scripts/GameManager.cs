using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public GameObject StartScreen;
    public GameObject FinishSceneCrab;
    public GameObject FinishSceneOcto;
    public GameObject FinishSceneNoWinner;

    public TMP_Text CrabText;
    private int CrabPoints = 0;
    public TMP_Text OctoText;
    private int OctoPoints = 0;

    public CoinGenerator generator;
    public SoundManager sounMan;
    public TimeManager timeMan;

    public Movement crab;
    public Movement Octo;

    public bool gameFinished = false;
   

    void Start()
    {
        StartScreen.SetActive(true);
    }

    public int getOctoPoints()
    {
        return OctoPoints;
    }

    public int getCrabPoints()
    {
        return CrabPoints;
    }

    public void HideStartScreen()
    {
        StartScreen.SetActive(false);
        generator.StartSpawning();
        timeMan.startCountdown();
        crab.setGameStarted(true);
        Octo.setGameStarted(true);
    }
    public void ShowFinishScreenCrab()
    {
        FinishSceneCrab.SetActive(true);
        sounMan.WinSound();
        crab.setGameStarted(false);
        Octo.setGameStarted(false);
    }
    public void ShowFinishScreenOcto()
    {
        FinishSceneOcto.SetActive(true);
        sounMan.WinSound();
        crab.setGameStarted(false);
        Octo.setGameStarted(false);
    }
    public void ShowFinishScreenNoWinner()
    {
        FinishSceneNoWinner.SetActive(true);
        sounMan.NoWinSound();
        crab.setGameStarted(false);
        Octo.setGameStarted(false);
    }
    public void checkPoints()
    {
        if (CrabPoints > OctoPoints)
        {
            ShowFinishScreenCrab();
            return;
        }   
        else if (CrabPoints < OctoPoints)
        {
            ShowFinishScreenOcto();
            return;
        }
        ShowFinishScreenNoWinner();
    }

    public void FinishGame()
    {
        StartCoroutine(nameof(Ending));        

    }

    public void reloadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void addCrabPoints(int points)
    {
        if (gameFinished)
            return;
        CrabPoints +=points;
        CrabText.text = CrabPoints + "";
    }
    public void addOctoPoints(int points)
    {
        if (gameFinished)
            return;
        OctoPoints +=points;
        OctoText.text = OctoPoints + "";
    }
    public void minusCrabPoints()
    {
        if (gameFinished)
            return;
        CrabPoints--;
        CrabText.text = CrabPoints + "";
    }
    public void minusOctoPoints()
    {
        if (gameFinished)
            return;
        OctoPoints--;
        OctoText.text = OctoPoints + "";

    }

    public void bubbleSound()
    {
        sounMan.PopSound();
    }

    public void coinSound()
    {
        sounMan.CoinSound();
    }

    public void coinLoseSound()
    {
        sounMan.CoinSound();
    }

    public void rubbishSound()
    {
        sounMan.RubbishSound();
    }

    public void changeMusicSpeed()
    {
        sounMan.accelerateMusic();
    }

    public void addBubblesToCrab()
    {
        crab.addBubbles();
    }

    public void addBubblesToOcto()
    {
        Octo.addBubbles();
    }

    public void addBubblesToCrabPower()
    {
        crab.addBubblesPower();
    }

    public void addBubblesToOctoPower()
    {
        Octo.addBubblesPower();
    }

    public Movement getCrab()
    {
        return crab;
    }

    public Movement getOcto()
    {
        return Octo;
    }

    IEnumerator Ending()
    {
        gameFinished = true;
        sounMan.FinishSound();
            
        yield return new WaitForSeconds(1.25f);
        checkPoints();
    }
}
