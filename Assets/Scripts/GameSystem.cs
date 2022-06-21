using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    private float countdownSeconds = 3;
    public bool is_exist = false;
    public bool is_open = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_exist && !is_open)
        {
            countdownSeconds -= Time.deltaTime;
            if (countdownSeconds <= 0)
            {
                // カウントを3秒に戻す
                countdownSeconds = 3;
                is_exist = true;
            }
        }
    }
}
