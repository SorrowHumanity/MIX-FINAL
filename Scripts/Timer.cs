using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerField;
    public float TimeLeft { get; set; } = 5;
    public bool TimerEnded { get; set; }

    void Update()
    {
        if (TimerEnded)
        {
            return;
        }

        TimeLeft -= Time.deltaTime;

        timerField.text = $"{TimeLeft:n1}";

        if (TimeLeft <= 0)
        {
            TimerEnded = true;
        }
    }
}
