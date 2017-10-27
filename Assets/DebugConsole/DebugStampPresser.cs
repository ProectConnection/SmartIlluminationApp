using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace DebugConsole
{
    public class DebugStampPresser : MonoBehaviour
    {
        StampID CheatStampId;
        public StampID cheatStampId
        {
            get { return CheatStampId; }
        }
        Dropdown dropdownList;

        // Use this for initialization
        void Start()
        {
            dropdownList = GetComponent<Dropdown>();


            dropdownList.onValueChanged.AddListener(OnValueChange);
        }

        void OnValueChange(int value)
        {
            CheatStampId = (StampID)value;
        }
    }
}