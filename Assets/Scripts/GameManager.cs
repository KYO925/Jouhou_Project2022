using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance = null;
    public int score;
    public int bestScore = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddScore(int s)
    {
        // “|‚µ‚½‘ŠŽè‚É‚æ‚Á‚ÄƒXƒRƒA‚ª•Ï‚í‚é‚æ‚¤‚É‚·‚é
        score += s;
    }

    public void UpdateBestScore()
    {
        if (score > bestScore)
        {
            bestScore = score;
        }
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
