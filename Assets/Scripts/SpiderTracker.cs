using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpiderTracker : MonoBehaviour
{
    public TextMeshProUGUI statusText;
    private int spiderCount;

    void Start()
    {
        spiderCount = GameObject.FindGameObjectsWithTag("Spider").Length;
        UpdateStatusText();
    }

    void Update()
    {
        int currentCount = GameObject.FindGameObjectsWithTag("Spider").Length;
        if (currentCount != spiderCount)
        {
            spiderCount = currentCount;
            UpdateStatusText();
        }

        if (spiderCount == 0)
        {
            statusText.text = "All spiders have been cleared! Get to the exit!";
        }
    }

    private void UpdateStatusText()
    {
        statusText.text = "Spiders remaining: " + spiderCount;
    }
}
