using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Log : MonoBehaviour
{
    public static Log Instance { get { return Instance; } }
    private int logCount = 0;

    [SerializeField] private Text text;
    public void Printlog(string message)
    {
        text.text += "[" + logCount + "] : " + message + "\n";
    }

}
