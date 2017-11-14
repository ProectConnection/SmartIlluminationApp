using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrameUnlocker : MonoBehaviour {
    SpotManager ref_SpotManager;
    DataSaver ref_DataSaver;
    bool[] AviliableFrames;
    bool[] UsedFrames;
    [SerializeField]
    Imagedraw ref_ImageDraw;
    [SerializeField]
    Sprite[] FrameSprites;

	// Use this for initialization
	void Start () {
        ref_SpotManager = GameObject.FindGameObjectWithTag("SpotManager").GetComponent<SpotManager>();
        ref_DataSaver = DataSaver.GetDataSaver();
        AviliableFrames = new bool[5];
        UsedFrames = new bool[5];
        CheckAviliableFrame();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void CheckAviliableFrame()
    {
        int[] PedometerUnlocktables = { 2000, 3000, 4000, 5000 };
        if (ref_SpotManager.nearestSpotData != null)
        {
            AviliableFrames[(int)FrameId.SpotFrame] = true;
            FrameSprites[0] = ref_SpotManager.nearestSpotData.GetPhotoFrame(0);
            //ref_SpotManager.nearestSpotData.photoFrames
        }
        for (int i = 0; i < PedometerUnlocktables.Length; i++)
        {
            if (ref_DataSaver.Pedocount >= PedometerUnlocktables[i])
            {
                AviliableFrames[(int)(i) + 1] = true;
            }

        }
    }

    public bool IsAviliableFrame(FrameId frameId)
    {
        return AviliableFrames[(int)frameId];
    }

    public void AcriveFrame(FrameId frameId,bool nextActive)
    {
        switch (frameId)
        {
            case FrameId.SpotFrame:
                for(int i = 0; i < UsedFrames.Length; i++)
                {
                    UsedFrames[(int)frameId] = false;
                }
                break;
        }
        UsedFrames[(int)frameId] = nextActive;
        UpdateFrame();
    }

    public bool GetActiveFrame(FrameId frameId)
    {
        return UsedFrames[(int)frameId];
    }

    public void UpdateFrame()
    {
        List<Sprite> t_PhotoSprite = new List<Sprite>();
        for(int i = 0; i < UsedFrames.Length; i++)
        {
            if(UsedFrames[i])
            {
                t_PhotoSprite.Add(FrameSprites[i]);
            }
            
        }
        ref_ImageDraw.GeneratePhotoFrame(t_PhotoSprite.ToArray());
    }
}

public enum FrameId
{
    SpotFrame = 0,
    walkMeter1,
    walkMeter2,
    walkMeter3,
    walkMeter4,
};
