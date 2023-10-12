using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float startTime;
    private bool isRunning = false;

    void Start()
    {
        // 게임 시작 시간 기록
        startTime = Time.time;
        isRunning = true;
    }

    void Update()
    {
        if (isRunning)
        {
            float currentTime = Time.time - startTime;
            int minutes = (int)(currentTime / 60);
            int seconds = (int)(currentTime % 60);
            timerText.text = "Time \n" + minutes.ToString("00") + ":" + seconds.ToString("00");
        }
    }

    // 게임 종료 시 호출
    public void GameOver()
    {
        isRunning = false;
    }
}
