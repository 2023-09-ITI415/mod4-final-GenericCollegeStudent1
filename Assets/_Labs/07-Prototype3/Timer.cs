using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float totalTime = 120f;  // Total time in seconds (2 minutes)
    private float currentTime;
    private bool isGameOver = false;
    private bool isTimerFrozen = false;  // Controls whether the timer should update

    public TextMeshProUGUI counterText;


    void Start()
    {
        currentTime = totalTime;
        UpdateCounterText();
    }

    void Update()
    {
        if (!isGameOver && !isTimerFrozen)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateCounterText();
            }
            else
            {
                currentTime = 0;
                isGameOver = true;
                counterText.text = "Game Over";
                Time.timeScale = 0;  // Freeze the game
            }
        }
    }

    void UpdateCounterText()
    {
        int minutes = Mathf.FloorToInt(currentTime / 60);
        int seconds = Mathf.FloorToInt(currentTime % 60);
        counterText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    // Call this method to freeze the timer
    public void FreezeTimer()
    {
        isTimerFrozen = true;
    }

    // Call this method to unfreeze the timer
    public void UnfreezeTimer()
    {
        isTimerFrozen = false;
    }
}
