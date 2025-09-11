using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Text TimerText;

    private float elapsedTime = 0f;

    void Update()
    {
        elapsedTime += Time.deltaTime;

        int totalMilliseconds = (int)(elapsedTime * 1000f);
        int minutes = totalMilliseconds / 60000;
        int seconds = (totalMilliseconds % 60000) / 1000;
        int milliseconds = totalMilliseconds % 1000;

        TimerText.text = string.Format("{0:00}:{1:00}:{2:000}", minutes, seconds, milliseconds);
    }
}
