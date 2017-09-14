using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public class SpotDataRegister : EditorWindow{
    string spotUrl;
    string spotName;
    string savePass;
    StampID newStampId;
    Texture2D[] NextAddPhotoFrame;
    bool isAdvancedSetting;
    int photoLength;
    int prevPhotoLength;
    string ParentSavePass = "Assets/Resources/SpotDatas/";
    [MenuItem("Window/SpotDataRegister")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SpotDataRegister));
    }
    private void OnEnable()
    {
        newStampId = StampID.undefined;
        isAdvancedSetting = false;
        ParentSavePass = "Assets/Resources/SpotDatas/";
    }

    private void OnGUI()
    {
        //基本的な設定
        //スポットデータのデータを変更するような基本的な設定
        /* ・スポットURL
         * ・スポット名
         * ・保存フォルダ
         * ・スタンプID
         * ・写真に追加するフレーム
         */
        GUILayout.Label("Basic Setting",EditorStyles.boldLabel);
        EditorGUILayout.BeginVertical();
        spotUrl = EditorGUILayout.TextField("Spot URL",spotUrl);
        spotName = EditorGUILayout.TextField("Spot Name", spotName);
        savePass = EditorGUILayout.TextField("Save Pass", savePass);

        //NextAddPhotoFrame = (Texture2D[])EditorGUILayout.ObjectField("Photo Frame",null, typeof(Texture2D[]));
        newStampId = (StampID)EditorGUILayout.EnumPopup("StampID", newStampId);
        EditorGUILayout.LabelField("Photo Frame");
        prevPhotoLength = photoLength;
         photoLength = EditorGUILayout.IntField("Length", photoLength);
        if(photoLength != prevPhotoLength)
        {
            NextAddPhotoFrame = new Texture2D[photoLength];
        }
        for(int i = 0; i < NextAddPhotoFrame.Length; i++)
        {
            NextAddPhotoFrame[i]  = (Texture2D)EditorGUILayout.ObjectField("PhotoFrame[" + i + "]",NextAddPhotoFrame[i], typeof(Texture2D), false);
        }
        EditorGUILayout.EndVertical();
        EditorGUILayout.Separator();
        //高度な設定
        //基本的には使用されないオプション
        //・スポットデータ保存パスの親を変える
        isAdvancedSetting = EditorGUILayout.Toggle("Advanced Setting", isAdvancedSetting);
        if (isAdvancedSetting)
        {
            ParentSavePass = EditorGUILayout.TextField("Parent SavePass", ParentSavePass);
            if(ParentSavePass != "Assets/Resources/SpotDatas/")
            {
                EditorGUILayout.HelpBox("Parent SavePassが変更されています！\n変更後のパスが存在しない場合、アセット保存エラーが起こる可能性があります",MessageType.Warning);
            }
        }
        else
        {
            ParentSavePass = "Assets/Resources/SpotDatas/";
        }
        EditorGUILayout.Separator();

        if (GUILayout.Button("Generate SpotData"))
        {
            CreateSpotAsset.GenerateSpotData(spotUrl, spotName,ParentSavePass, savePass, newStampId,NextAddPhotoFrame);
        }
    }

    
}
