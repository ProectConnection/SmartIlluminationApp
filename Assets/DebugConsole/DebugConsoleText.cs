using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace DebugConsole
{
    public class DebugConsoleText : MonoBehaviour
    {
        string[] m_debugHundlingString = new string[5];
        int listIndex = 0;
        //List<string> m_debugHundlingString;
        Text textComp;
        // Use this for initialization
        void Start()
        {
            UpdateDebugString();
            //m_debugHundlingString = new List<string>();
            textComp = GetComponent<Text>();
            Application.logMessageReceived += OnLogMessgeCatched;
            StartCoroutine(UpdateRender());
        }

        IEnumerator UpdateRender()
        {
            while (true)
            {
                string ttext = "";
                for (int loopcnt = 0, i = listIndex;loopcnt < m_debugHundlingString.Length; i--,loopcnt++)
                {
                    if (!(string.IsNullOrEmpty(m_debugHundlingString[i]))) ttext += m_debugHundlingString[i];

                    if(i - 1 < 0)
                    {
                        i = m_debugHundlingString.Length;
                    }
                }
                textComp.text = ttext;
                UpdateDebugString();

                yield return new WaitForSeconds(3f);
            }
            
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

            m_debugHundlingString[listIndex] += logString + "\n";

        }

        void UpdateDebugString()
        {
            if (!(listIndex + 1 == m_debugHundlingString.Length)) listIndex++;
            else
            {
                listIndex = 0;
            }
            m_debugHundlingString[listIndex] = "";
        }

        int GetInclimentlistIndex()
        {
            if (listIndex + 1 == m_debugHundlingString.Length) return 0;
            else return listIndex + 1;
        }
    }
}