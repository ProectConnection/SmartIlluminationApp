using UnityEngine;
using UnityEngine.UI;

public abstract class DebugDropDownButtonBase : MonoBehaviour {
    [SerializeField]
    GameObject AttachedDropDownListGO;
    [SerializeField]
    GameObject AttachedConformButtonGO;
    protected Dropdown AttachedDropDownList;
	// Use this for initialization
	void Start () {
        AttachedConformButtonGO.GetComponent<Button>().onClick.AddListener(OnClick);
        AttachedDropDownList = AttachedDropDownListGO.GetComponent<Dropdown>();
	}

    public abstract void OnClick();
}
