using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public float timerDuration = 3f * 60f;
    [HideInInspector]  public float timer;
    [SerializeField] private TextMeshProUGUI firstMinute;
    [SerializeField] private TextMeshProUGUI secondMinute;
    [SerializeField] private TextMeshProUGUI seperator;
    [SerializeField] private TextMeshProUGUI firstSecond;
    [SerializeField] private TextMeshProUGUI secondSecond;
    void Start()
    {
        ResetTimer();
    }
    void Update()
    {
        if(timer > 0)
        {
            timer -= Time.deltaTime;
            UpdateTimeDisplay(timer);
        }
        else
        {
            StopTimer();
        }
        
    }

    private void ResetTimer()
    {
        timer = timerDuration;
    }

    private void UpdateTimeDisplay(float time)
    {
        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);
        string currentTime = string.Format("{00:00}{1:00}", minutes, seconds);
        firstMinute.text = currentTime[0].ToString();
        secondMinute.text = currentTime[1].ToString();
        firstSecond.text = currentTime[2].ToString();
        secondSecond.text = currentTime[3].ToString();

    }

    private void StopTimer()
    {
        if (timer != 0)
        {
            timer = 0;
            UpdateTimeDisplay(timer);
        }
    }
}
