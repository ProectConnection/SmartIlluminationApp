using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
namespace DebugConsole
{
    public class DebugConsoleText : MonoBehaviour
    {
        Text textComp;
        // Use this for initialization
        void Start()
        {
            textComp = GetComponent<Text>();
            Application.logMessageReceived += OnLogMessgeCatched;

        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnLogMessgeCatched(string logString, string stackTrace, LogType type)
        {
            if (string.IsNullOrEmpty(logString))
            {
                return;
            }
            textComp.text += logString + "\n";

        }

    }
}