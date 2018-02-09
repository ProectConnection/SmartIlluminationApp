using UnityEngine;

public class DeactiveAllFrame : MonoBehaviour{
    UnityEngine.UI.Button thisButton;
    [SerializeField]
    FrameUnlocker ref_FrameUnlocker;

    void Start()
    {
        thisButton = GetComponent<UnityEngine.UI.Button>();
        thisButton.onClick.AddListener(OnPress);
    }

    public void OnPress()
    {
        ref_FrameUnlocker.DeactiveAllFrame();
        ref_FrameUnlocker.UpdateFrame();
    }
}
