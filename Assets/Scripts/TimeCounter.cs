//https://zenn.dev/fujimiya/articles/5775dd0824031d ���Q�l�ɂ��Ă��܂��B

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeCounter : MonoBehaviour
{
    // ��ʏ㕔�̃^�C�}�[

    public float countdownSeconds = 60;
    private int countdownMSeconds;
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

        if (countdownMSeconds <= 0)
        {
            // 0�b�ɂȂ����Ƃ��̏��� �Q�[���I�[�o�[�Ƃ�
            // ���U���g�V�[���Ɉړ�
        }
    }
}