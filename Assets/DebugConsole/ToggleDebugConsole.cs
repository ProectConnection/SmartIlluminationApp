using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DebugConsole
{
    public class ToggleDebugConsole : MonoBehaviour
    {
        UnityEngine.Canvas DebugConsoleCanvas;
        bool IsContinued = false;
        bool IsMoveswitchActive = false;
        Vector3 prevTouchposition;
        int movableFingerId;
        // Use this for initialization
        void Start()
        {
            DebugConsoleCanvas = GetComponent<Canvas>();
        }

        // Update is called once per frame
        void Update()
        {
            if(Input.touchCount >= 4)
            {
                bool[] touchFlg = new bool[4];

                foreach(Touch ttouch in Input.touches)
                {
                    int touchSwitchRet;
                       Vector3 touchCoord = Camera.main.ScreenToViewportPoint(ttouch.position);
                    if (ttouch.fingerId == movableFingerId && ttouch.phase != TouchPhase.Began)
                    {
                        IsMoveswitchActive = ((touchCoord.y - prevTouchposition.y) * (touchCoord.y - prevTouchposition.y) >= 0.3f);
                    }
                    else if((touchSwitchRet = IsTouchSwitch(touchCoord)) >= 0 ){
                        touchFlg[touchSwitchRet] = true;
                        if (touchSwitchRet == 2 && ttouch.fingerId != movableFingerId)
                        {
                            if(ttouch.phase == TouchPhase.Began)
                            {
                                prevTouchposition = touchCoord;
                            }
                            movableFingerId = ttouch.fingerId;
                        }
                    }
                }

                if(touchFlg[0] && touchFlg[1]  && touchFlg[3] && !IsContinued && IsMoveswitchActive)
                {
                    DebugConsoleCanvas.enabled = !DebugConsoleCanvas.enabled;
                    IsContinued = true;
                }
                
            }
            else
            {
                IsContinued = false;
            }
        }

        int IsTouchSwitch(Vector3 ViewPortTouchPosition)
        {
            bool[] TouchDelegate = {((ViewPortTouchPosition.x >= 0.0f) && (ViewPortTouchPosition.x <= 0.2f) &&
                                     (ViewPortTouchPosition.y >= 0.0f) && (ViewPortTouchPosition.y <= 0.2f)),
                                    ((ViewPortTouchPosition.x >= 0.8f) && (ViewPortTouchPosition.x <= 1.0f) &&
                                     (ViewPortTouchPosition.y >= 0.0f) && (ViewPortTouchPosition.y <= 0.2f)),
                                    ((ViewPortTouchPosition.x >= 0.0f) && (ViewPortTouchPosition.x <= 0.2f) &&
                                     (ViewPortTouchPosition.y >= 0.8f) && (ViewPortTouchPosition.y <= 1.0f)),
                                    ((ViewPortTouchPosition.x >= 0.8f) && (ViewPortTouchPosition.x <= 1.0f) &&
                                     (ViewPortTouchPosition.y >= 0.8f) && (ViewPortTouchPosition.y <= 1.0f))
                                   };

            for(int i = 0; i < TouchDelegate.Length; i++)
            {
                if (TouchDelegate[i]) return i;
            }
            return -1;
        }
    }
}
