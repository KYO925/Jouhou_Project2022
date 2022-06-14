//https://zenn.dev/fujimiya/articles/5775dd0824031d ÇéQçlÇ…ÇµÇƒÇ¢Ç‹Ç∑ÅB

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    public float countdownSeconds = 60;
    private int countdownMSconds;
    private Text timeText;

    private void Start()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        countdownSeconds -= Time.deltaTime;
        var span = new TimeSpan(0, 0, 0, 0, (int)(countdownSeconds * 1000));
        timeText.text = string.Format("{0:f}", span.TotalSeconds);

        if (countdownMSconds <= 0)
        {
            // 0ïbÇ…Ç»Ç¡ÇΩÇ∆Ç´ÇÃèàóù
        }
    }
}