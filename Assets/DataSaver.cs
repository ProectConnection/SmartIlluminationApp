using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataSaver : MonoBehaviour {

    string DataPath;
    List<StampID> pressedStamp = new List<StampID>();
    List<NotiID> pednoti = new List<NotiID>();

    int pedocount = 0;
    public int Pedocount
    {
        get { return pedocount + cheatPedoCount; }
    }
    int initialPedoCount = 0;
    int cheatPedoCount = 0;

    
    static string filename = "SIWSaveData";
    const string FileType = ".sav";
    bool IsAlreadyLoadMap = false;
    public bool isAlreadyLoadMap
    {
        get { return IsAlreadyLoadMap; }
        set { IsAlreadyLoadMap = value; }
    }
    bool IsUnlocked;
    public bool isUnlocked
    {
        get { return IsUnlocked; }
    }

    System.Text.Encoding encodeType = System.Text.Encoding.UTF8;
    
    public bool UnlockApp()
    {
        IsUnlocked = true;
        DataSave();
        return true;
    }

    public static DataSaver GetDataSaver()
    {
        return GameObject.FindGameObjectWithTag("DataSaver").GetComponent<DataSaver>();
    }


    public int SetNewPedocount(string newPedocount,PEDOCOUNTSETMODE pedocountsetmode)
    {
        switch (pedocountsetmode)
        {
            case PEDOCOUNTSETMODE.ADDCITIVE:
                float t_pedocount = 0;
                float.TryParse(newPedocount, out t_pedocount);
                pedocount = initialPedoCount + (int)t_pedocount;
                break;
            case PEDOCOUNTSETMODE.OVERWRITE:
                int.TryParse(newPedocount, out pedocount);
                break;
        }

        return 0;
    }

    public void AddInitialPedocount(int addInitPedocount)
    {
        cheatPedoCount += addInitPedocount;
    }

    public List<StampID> PressedStamp
    {
        get { return pressedStamp; }
    }

    public List<NotiID> Pednoti
    {
        get { return pednoti; }
    }

    public int DataSave()
    {
        List<string> jsonstring = new List<string>();
        foreach(StampID t in pressedStamp)
        {
            jsonstring.Add(JsonUtility.ToJson(new JsonDataSaveClass("PressedStamp", (int)t)));
        }

        foreach (NotiID t in pednoti)
        {
            jsonstring.Add(JsonUtility.ToJson(new JsonDataSaveClass("PedNoti", (int)t)));
        }

        jsonstring.Add(JsonUtility.ToJson(new JsonDataSaveClass("pedoCount", pedocount)));
        jsonstring.Add(JsonUtility.ToJson(new JsonDataSaveClass("IsUnlocked", IsUnlocked)));
        jsonstring.Add(JsonUtility.ToJson(new JsonDataSaveClass("CheatPedo", cheatPedoCount)));
        Debug.Log("call DataSave");
        File.WriteAllLines(DataPath + "/" + filename + FileType, jsonstring.ToArray(),encodeType);
        return 0;
    }

    public int DataLoad()
    {
        if (!File.Exists(DataPath + "/" + filename + FileType))
        {
            Debug.LogWarning("セーブデータが存在しません！");
            return 1;
        }
        string[] jsonReadRes = File.ReadAllLines(DataPath + "/" + filename + FileType, encodeType);
        List<JsonDataSaveClass> ReadResObject = new List<JsonDataSaveClass>();
        foreach(string st in jsonReadRes)
        {
             ReadResObject.Add(JsonUtility.FromJson<JsonDataSaveClass>(st));
        }
        foreach(JsonDataSaveClass tjdsc in ReadResObject)
        {
            switch (tjdsc.key)
            {
                case "PressedStamp":
                    pressedStamp.Add((StampID)(int.Parse(tjdsc.saveObject)));
                    break;
                case "pedoCount":
                    pedocount = int.Parse(tjdsc.saveObject);
                    initialPedoCount = pedocount;
                    break;
                case "IsUnlocked":
                    IsUnlocked = bool.Parse(tjdsc.saveObject);
                    break;
                case "CheatPedo":
                    int.TryParse(tjdsc.saveObject,out cheatPedoCount);
                    break;
                case "PedNoti":
                    pednoti.Add((NotiID)(int.Parse(tjdsc.saveObject)));
                    break;
            }
        }
        
        
        return 0;
    }

    public int SetDataPressedStamp(List<StampID> newPressedStamp)
    {
        pressedStamp = newPressedStamp;
        DataSave();
        
        return 0;
    }

    public int SetDataPedNoti(List<NotiID> newPedNoti)
    {
        pednoti = newPedNoti;
        DataSave();

        return 0;
    }

    private void Awake()
    {
        DataPath = Application.persistentDataPath;
        DataLoad();
        StartCoroutine(AutoSave());
    }

    IEnumerator AutoSave(float autoSaveTiming = 30)
    {
        while (true)
        {
            yield return new WaitForSeconds(autoSaveTiming);
            DataSave();
        }
    }
}

public class JsonDataSaveClass{
    public string key;
    public string saveObject;
    public string type;

    public JsonDataSaveClass(string tkey,object tobject)
    {
        key = tkey;
        saveObject = tobject.ToString();
        type = tobject.GetType().ToString();
    }
}

public enum PEDOCOUNTSETMODE {
    ADDCITIVE,  //加算モード
    OVERWRITE,   //上書きモード
};