using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSystem : MonoBehaviour
{
    private float countdownSeconds = 3;
    public int player_hp = 3;
    public GameObject[] playerHearts;
    public bool is_exist = false;
    public GameObject alertMessage;
    public GameObject startMessage;
    public bool is_gameStart = false;
    public GameObject scoreText;
    public static GameSystem instance;

    // Prefab
    public GameObject[] visitorList;
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
            int index = Random.Range(0, visitorList.Length);
            visitors.Push(visitorList[index]);
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
                    countdownSeconds = 3;
                    is_exist = true;

                    Encount();
                }
            }
        }

        if (is_exist) // 外側に誰かがいる
        {
            if (Control.instance.is_open) //ドアが開いている
            {
                countdownSeconds -= Time.deltaTime;
                Vector2 tmp = visitor.transform.position;
                Vector2 tms = visitor.transform.localScale;
                visitor.transform.position = new Vector2(tmp.x, tmp.y - Time.deltaTime*4);
                visitor.transform.localScale = new Vector2(tms.x + Time.deltaTime * 2, tms.y + Time.deltaTime * 2);
                if (countdownSeconds <= 0)
                {
                    int safetyValue = visitor.GetComponent<Visitor>().safetyValue;
                    countdownSeconds = 3;
                    if (safetyValue < 0) // 敵の場合
                    {
                        // プレイヤーのライフが1減ってvisitorが居なくなる
                        PlayerDamage(1);
                        Destroy(visitor);
                        is_exist = false;
                    }
                    else // 味方の場合
                    {
                        // スコアが増えてvisitorが居なくなる
                        UpdateScore(visitor.GetComponent<Visitor>().score);
                        Destroy(visitor);
                        is_exist = false;
                    }
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
        int safetyValue = visitor.GetComponent<Visitor>().safetyValue;
        bool openAndExist = is_exist && Control.instance.is_open;
        if (openAndExist && safetyValue < 0)
        {
            UpdateScore(visitor.GetComponent<Visitor>().score);
            Destroy(visitor);
            is_exist = false;
            TimeCounter.instance.AddSeconds(10.0f);
        }
        else if (openAndExist)
        {
            PlayerDamage(1);
            Destroy(visitor);
            is_exist = false;
            TimeCounter.instance.AddSeconds(-10.0f);
        }
    }

    void PlayerDamage(int dmg)
    {
        player_hp -= dmg;
        UpdatePlayerHP();
    }

    void UpdateScore(int s)
    {
        GameManager.instance.score += s;
        scoreText.GetComponent<Text>().text = GameManager.instance.score.ToString();
    }

    void UpdatePlayerHP()
    {
        for (int i = 0; i < playerHearts.Length; i++)
        {
            if (player_hp-1 >= i)
            {
                playerHearts[i].SetActive(true);
            }
            else
            {
                playerHearts[i].SetActive(false);
            }
        }
    }
}
