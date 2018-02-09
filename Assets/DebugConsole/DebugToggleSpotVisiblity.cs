using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DebugConsole
{
    public class DebugToggleSpotVisiblity : MonoBehaviour
    {
        public void ToggleSpotRangeVisiblity()
        {
            GameObject[] tranges = GameObject.FindGameObjectsWithTag("SpotRange");
            foreach (GameObject tgo in tranges)
            {
                Renderer trend = tgo.GetComponent<Renderer>();
                trend.enabled = !trend.enabled;
            }
        }
    }
}