using UnityEngine;
using UnityEditor;

public class SpotDataRegister : EditorWindow{
    string spotUrl;
    string spotName;
    string fileName;
    string savePass;
    StampID newStampId;
    SpotType newSpotType;
    int spotInteractRange;
    Sprite[] NextAddPhotoFrame;
    bool isAdvancedSetting;
    int photoLength;
    int prevPhotoLength;
    const string DefaultParentSavePass = "Assets/Resources/SpotDatas";
    string ParentSavePass = DefaultParentSavePass;
    [MenuItem("Window/SpotDataRegister")]

    public static void ShowWindow()
    {
        EditorWindow.GetWindow(typeof(SpotDataRegister));
    }
    private void OnEnable()
    {
        spotUrl = "";
        spotName = "";
        fileName = "";
        savePass = "";
        newStampId = StampID.undefined;
        isAdvancedSetting = false;
        ParentSavePass = DefaultParentSavePass;
        spotInteractRange = 75;
    }

    private void OnGUI()
    {
        //基本的な設定
        //スポットデータのデータを変更するような基本的な設定
        /* ・スポットURL
         * ・スポット名
         * ・保存フォルダ
         * ・スポット種別
         * ・スタンプID
         * ・写真に追加するフレーム
         */
        EditorGUILayout.BeginVertical();
        GUILayout.Label("Basic Setting",EditorStyles.boldLabel);
        GUILayout.Label("Basic SpotDatas(Required)", EditorStyles.boldLabel);
        
        //最小限設定しなければならない場所
        spotUrl = EditorGUILayout.TextField("Spot URL",spotUrl);
        if (!GoogleMapUrlLibrary.IsGoogleMapUrl(spotUrl))
        {
            EditorGUILayout.HelpBox("Google Map形式のURLではありません！\nスポットデータ変換に必ず失敗します", MessageType.Error);
        }
        spotName = EditorGUILayout.TextField("Spot Name", spotName);
        if (spotName.Length <= 0)
        {
            EditorGUILayout.HelpBox("スポット名を入力して下さい！", MessageType.Error);
        }
        fileName = EditorGUILayout.TextField("File Name", fileName);
        if (fileName.Length <= 0)
        {
            EditorGUILayout.HelpBox("ファイル名を入力してください！", MessageType.Error);
        }
        savePass = EditorGUILayout.TextField("Save Pass", savePass);
        if (savePass.Length <= 0)
        {
            EditorGUILayout.HelpBox("保存先を指定してください！", MessageType.Error);
        }
        EditorGUILayout.Separator();
        GUILayout.Label("Spot Attributes(Optional)", EditorStyles.boldLabel);
        //スポット属性指定系
        newSpotType = (SpotType)EditorGUILayout.EnumPopup("SpotType", newSpotType);
        switch (newSpotType)
        {
            case SpotType.Undefined:
                EditorGUILayout.HelpBox("スポットタイプが未定義です。", MessageType.Warning);
                break;
            case SpotType.CheckPoint:
                CheckPointStampParts();
                break;
            case SpotType.Photo:
                PhotoFrameParts();
                break;
            case SpotType.PhotoCheck:
                CheckPointStampParts();
                PhotoFrameParts();
                break;
            default:
                break;
        }
        EditorGUILayout.Separator();
        GUILayout.Label("Other Setting(Optional)", EditorStyles.boldLabel);
        spotInteractRange = EditorGUILayout.IntField("Spot Interact Range", spotInteractRange);
        
        EditorGUILayout.EndVertical();
        EditorGUILayout.Separator();
        //高度な設定
        //基本的には使用されないオプション
        //・スポットデータ保存パスの親を変える
        isAdvancedSetting = EditorGUILayout.Toggle("Advanced Setting", isAdvancedSetting);
        if (isAdvancedSetting)
        {
            ParentSavePass = EditorGUILayout.TextField("Parent SavePass", ParentSavePass);
            if(ParentSavePass != DefaultParentSavePass)
            {
                EditorGUILayout.HelpBox("Parent SavePassが変更されています！\n変更後のパスが存在しない場合、アセット保存エラーが起こる可能性があります",MessageType.Warning);
            }
        }
        else
        {
            ParentSavePass = DefaultParentSavePass;
        }
        EditorGUILayout.Separator();

        if (GUILayout.Button("Generate SpotData"))
        {
            CreateSpotAsset.GenerateSpotData(new SpotRegisterData(spotUrl, spotName, ParentSavePass, savePass,fileName,newSpotType, newStampId,spotInteractRange ,NextAddPhotoFrame));
        }
    }

    void CheckPointStampParts()
    {
        newStampId = (StampID)EditorGUILayout.EnumPopup("StampID", newStampId);
    }

    void PhotoFrameParts()
    {
        EditorGUILayout.LabelField("Photo Frame");
        prevPhotoLength = photoLength;
        photoLength = EditorGUILayout.IntField("Length", photoLength);
        if (photoLength != prevPhotoLength)
        {
            NextAddPhotoFrame = new Sprite[photoLength];
        }
        for (int i = 0; i < NextAddPhotoFrame.Length; i++)
        {
            NextAddPhotoFrame[i] = (Sprite)EditorGUILayout.ObjectField("PhotoFrame[" + i + "]", NextAddPhotoFrame[i], typeof(Texture2D), false);
        }
    }
}