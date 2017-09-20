using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ViewChanger : MonoBehaviour {

    VIEWPOSITIONSTATE NowVIEWPOSITIONSTATE = VIEWPOSITIONSTATE.behind;
    CompassRotator com_compassRotator;
    Camera ChangeTarget;
    //[SerializeField]
    //ViewPosition[] viewPositions;
    ViewPosition[] viewPositions = new ViewPosition[2];
    private void Start()
    {
        //for(int i = 0;i < viewPositions.Length; i++)
        //{
        //    //viewPositions[i] = (ViewPosition)ScriptableObject.CreateInstance(viewPositions.GetType());
        //}
        {
            viewPositions[0] = (ViewPosition)ScriptableObject.CreateInstance(typeof(ViewBehind));
            viewPositions[1] = (ViewPosition)ScriptableObject.CreateInstance(typeof(ViewLookDown));
        }
        
        ChangeTarget = gameObject.GetComponent<Camera>();
    }

    public void ViewChange()
    {
        NowVIEWPOSITIONSTATE++;
        if(NowVIEWPOSITIONSTATE == VIEWPOSITIONSTATE.ENDOFENUM)
        {
            NowVIEWPOSITIONSTATE = VIEWPOSITIONSTATE.behind;
        }
        UpdateViewPosition();
    }
    
    void ViewChange(VIEWPOSITIONSTATE nextView)
    {
        NowVIEWPOSITIONSTATE = nextView;
        UpdateViewPosition();
    }

    void UpdateViewPosition()
    {
        viewPositions[(byte)NowVIEWPOSITIONSTATE].ViewChange(ChangeTarget);
    }
}