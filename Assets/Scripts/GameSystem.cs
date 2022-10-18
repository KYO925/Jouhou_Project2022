using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    private float countdownSeconds = 3;
    public bool is_exist = false;
    public GameObject alertMessage;
    public GameObject startMessage;
    public bool is_gameStart = false;
    public GameObject scoreText;
    public static GameSystem instance;

    // Prefab
    public GameObject testVisitor;
    Stack<GameObject> visitors = new Stack<GameObject>();
    public GameObject visitor;

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
        // 来客をスタックに入れる
        int v = 10;
        for (int i = 0; i < v; i++)
        {
            // TODO: 敵味方がランダムに入るようにする
            visitors.Push(testVisitor);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!startMessage.activeSelf)
        {
            TimeCounter.instance.timerStop = false;
        }

        if (!is_exist) // 外側に誰もいない
        {
            if (Control.instance.is_open) //ドアが開いている
            {
                if (!startMessage.activeSelf)
                {
                    alertMessage.SetActive(true);
                }
            }
            else if (!Control.instance.is_open) //ドアが閉まっている
            {
                startMessage.SetActive(false);
                alertMessage.SetActive(false);
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
        Vector2 pos = new Vector2(0.0f, -1.0f);
        visitor = Instantiate(visitors.Pop(), pos, Quaternion.identity);
    }

    // 来客への攻撃
    public void Attack()
    {
        if (is_exist && Control.instance.is_open)
        {
            GameManager.instance.score = visitor.GetComponent<Visitor>().score;
            scoreText.GetComponent<Text>().text = GameManager.instance.score.ToString();
            Destroy(visitor);
            is_exist = false;
            TimeCounter.instance.AddSeconds(10.0f);
        }
    }
}
