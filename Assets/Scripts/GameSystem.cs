using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    private float countdownSeconds = 3;
    public bool is_exist = false;
    public GameObject StartMessage;
    public static GameSystem instance;
    Stack<GameObject> visitors = new Stack<GameObject>();
    public GameObject visitor;

    // Prefab
    public GameObject testVisitor;

    public void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        int v = 10;
        for (int i = 0; i < v; i++)
        {
            visitors.Push(testVisitor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!is_exist) // 外側に誰もいない
        {
            if (Control.instance.is_open) //ドアが開いている
            {
                //ドアを閉じるように促す
            }
            else if (!Control.instance.is_open) //ドアが閉まっている
            {
                StartMessage.SetActive(false);
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
    }

    // 来客出現させる
    void Encount()
    {
        // TODO: 敵か味方のいずれかがランダムに生成されるようにする
        Vector2 pos = new Vector2(0.0f, -1.0f);
        visitor = Instantiate(visitors.Pop(), pos, Quaternion.identity) as GameObject;
    }

    public void Attack()
    {
        if (is_exist && Control.instance.is_open)
        {
            Destroy(visitor);
            is_exist = false;
        }
    }
}
