using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    public AudioClip sound1;
    public AudioClip sound2;
    public AudioClip sound3;
    public AudioClip sound4;
    public AudioClip sound5;

    AudioSource audioSource;

    void Start()
    {
        //Componentを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // スペ―ス
        if (Input.GetKey(KeyCode.Space))
        {
            audioSource.PlayOneShot(sound1);
        }
        // 右
        if (Input.GetKey(KeyCode.RightArrow))
        {
            audioSource.PlayOneShot(sound2);
        }
        // 上
        if (Input.GetKey(KeyCode.UpArrow))
        {
            audioSource.PlayOneShot(sound3);
        }
        // 下
        if (Input.GetKey(KeyCode.DownArrow))
        {
            audioSource.PlayOneShot(sound4);
        }
        // 左
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            audioSource.PlayOneShot(sound5);
        }
    }

}