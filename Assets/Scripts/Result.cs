using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public GameObject gameScoreText;
    public GameObject bestScoreText;

    // Start is called before the first frame update
    void Start()
    {
        gameScoreText.GetComponent<Text>().text = GameManager.instance.score.ToString();
        bestScoreText.GetComponent<Text>().text = GameManager.instance.bestScore.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
