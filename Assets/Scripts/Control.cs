using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Control : MonoBehaviour
{
    public static Control instance = null;
    public bool is_open = true;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // 扉操作（仮）スペースキーで開閉
        if (Input.GetKeyDown(KeyCode.Space))
        {
            is_open = !is_open;
            Debug.Log(is_open);
        }
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            GameSystem.instance.Attack();
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
