using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PedometeriOS : MonoBehaviour {
    //************

#if UNITY_IOS && !UNITY_EDITOR
	[DllImport("__Internal")]
	private static extern void _ex_callSwiftMethod(string CMPedmeter);
#endif

    public static void _ex_CallSwiftMethod(string CMPedmeter)
    {
#if UNITY_IOS && !UNITY_EDITOR
        _ex_callSwiftMethod(CMPedmeter);
#endif
    }

}
