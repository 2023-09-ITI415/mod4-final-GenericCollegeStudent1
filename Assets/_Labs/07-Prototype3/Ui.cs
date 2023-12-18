using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Timer timer;
    public TextMeshProUGUI resultsCanvas; // Reference to the canvas that displays results
    private bool gameFrozen = false;

    // Start is called before the first frame update
    void Start()
    {
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
        resultsCanvas.gameObject.SetActive(false); // Hide the results canvas initially
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!gameFrozen && other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count = count + 1;
            SetCountText();
        }
    }

    public void SetCountText()
    {
        countText.text = "Count: " + count.ToString();
        if (count >= 15)
        {
            WinGame();
        }
    }

    private void WinGame()
    {
        winTextObject.SetActive(true);
        timer.FreezeTimer();
        gameFrozen = true;
        DisplayResults();
    }

    private void DisplayResults()
    {
        resultsCanvas.gameObject.SetActive(true);
        TextMeshProUGUI resultsText = resultsCanvas.GetComponentInChildren<TextMeshProUGUI>();
        resultsText.text = "Results: " + (15 - count) + " pickups missing\nPress R to restart";

        // You can add additional logic here for restarting the game
    }

    // Update is called once per frame
    void Update()
    {
        if (gameFrozen)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                RestartGame();
            }
        }
    }

    private void RestartGame()
    {
        // Add logic here to reset the game state
        // For example, reload the scene or reset variables
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
