using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public class NewBehaviourScript : MonoBehaviour
{

    private int count;
    public TextMeshProUGUI countText;
    public GameObject winTextObject;
    public Timer timer;

    // Start is called before the first frame update

    void Start()
    {
        
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
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
            winTextObject.SetActive(true);
            timer.FreezeTimer();

        }
    }

}
