using UnityEngine;
using TMPro;

public class TimeManager : MonoBehaviour
{
    public TMP_Text timeText;
    public GameManager gameManager;
    public int seconds = 120;

    public void startCountdown()
    {
        InvokeRepeating(nameof(deleteSecond), 1, 1);
    }

    private void deleteSecond()
    {
        seconds--;
        if (seconds < 0)
        {
            timeText.text = "0";
            CancelInvoke(nameof(deleteSecond));
            gameManager.FinishGame();
            return;
        }

        timeText.text = seconds+"";
    }
}
