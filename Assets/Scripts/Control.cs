using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using UnityEngine;

public class Control : MonoBehaviour
{
    public static Control instance = null;
    public bool is_open = true;
    private string data;

    public string portName = "\\\\.\\COM7";
    public int baudRate = 9600;

    private SerialPort serialPort_;

    // Start is called before the first frame update
    void Start()
    {
        serialPort_ = new SerialPort(portName, baudRate);
        serialPort_.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort_.IsOpen)
        {
            data = serialPort_.ReadLine();
        }

        // 扉操作
        if (data == "open")
        {
            is_open = true;
        } else if (data == "close")
        {
            is_open = false;
        }
        // 扉操作 デバッグ用
        if (Input.GetKeyDown(KeyCode.Space) && !serialPort_.IsOpen)
        {
            is_open = !is_open;
            Debug.Log(is_open);
        }
        // 攻撃
        if (data == "ON")
        {
            GameSystem.instance.Attack();
        }
        // 攻撃 デバッグ用
        if (Input.GetKeyDown(KeyCode.Mouse0) && !serialPort_.IsOpen)
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
