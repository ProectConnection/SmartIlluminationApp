using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SpotDataRegister : EditorWindow{
    string spotUrl;
    string spotName;
    string savePass;
    [MenuItem("Window/SpotDataRegister")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SpotDataRegister));
    }

    private void OnGUI()
    {
        GUILayout.Label("Basic Setting",EditorStyles.boldLabel);
        spotUrl = EditorGUILayout.TextField("Spot URL",spotUrl);
        spotName = EditorGUILayout.TextField("Spot Name", spotName);
        savePass = EditorGUILayout.TextField("Save Pass", savePass);

        if (GUILayout.Button("Generate SpotData")) CreateSpotAsset.GenerateSpotData(spotUrl,spotName,savePass);
    }

    
}
