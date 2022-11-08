//https://zenn.dev/fujimiya/articles/5775dd0824031d を参考にしています。

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    // 画面上部のタイマー

    public static TimeCounter instance = null;
    public float countdownSeconds = 60;
    private Text timeText;
    public bool timerStop = true;

    private void Start()
    {
        timeText = GetComponent<Text>();
    }

    void Update()
    {
        if (!timerStop)
        {
            countdownSeconds -= Time.deltaTime;
            var span = new TimeSpan(0, 0, 0, 0, (int)(countdownSeconds * 1000));
            timeText.text = string.Format("{0:f}", span.TotalSeconds);
        }

        if (countdownSeconds <= 0)
        {
            // 0秒になったときの処理 ゲームオーバーとか
            countdownSeconds = 0;
            StartCoroutine(GameSystem.instance.JumpResult());
        }
    }

    public void Switch()
    {
        timerStop = !timerStop;
    }

    public void AddSeconds(float s)
    {
        countdownSeconds += s;
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }
}