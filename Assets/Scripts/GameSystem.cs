using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    private float countdownSeconds = 3;
    public bool is_exist = false;

    // Prefab
    public GameObject testVisitor;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_exist && !Control.instance.is_open) // 外側に誰もいない & ドアが閉まっている
        {
            countdownSeconds -= Time.deltaTime;
            if (countdownSeconds <= 0)
            {
                // カウントを3秒に戻す
                countdownSeconds = 3;
                is_exist = true;

                // 来客を出現させる処理
                Encount();
            }
        }
    }

    // 来客出現させる
    void Encount()
    {
        // TODO: 敵か味方のいずれかがランダムに生成されるようにする
        Vector2 pos = new Vector2(0.0f, -1.0f);
        Instantiate(testVisitor, pos, Quaternion.identity);
    }
}
