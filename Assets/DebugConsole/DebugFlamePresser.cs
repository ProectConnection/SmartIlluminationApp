﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DebugConsole
{
    public class DebugFlamePresser : MonoBehaviour
    {
        public Dropdown dropdownList;
        public string countList;
        public int gocountList;
        void Start()
        {
            dropdownList = GetComponent<Dropdown>();
            dropdownList.onValueChanged.AddListener(OnValueChanged);
        }
        public void OnValueChanged(int value)
        {
            //int.tryParse←Parseの使い方、詳しくはWEBで
            countList = dropdownList.options[value].text; //Labelからテキストを取得し格納
            Debug.Log("ラベルから摘出した歩数→" + countList);//出力
            bool result = int.TryParse(countList, out gocountList);//数値変換
            Debug.Log("摘出した内容を数値に変換したもの→" + gocountList);//数値変換後の値を出力

        }
    }
}