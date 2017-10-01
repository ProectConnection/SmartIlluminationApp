using System.Collections;
using UnityEngine;

public abstract class MeterUITxt : MonoBehaviour {
    //protected LocationCoordination Ref_LocationCoordination;
    protected Locator Ref_Locator;
    protected UnityEngine.UI.Text TextUI;
    [SerializeField]
    protected float UpdateSecond = 1.0f;
    protected double Metrics;
    protected IEnumerator Coroutine;

    // Use this for initialization
    void Start()
    {
        //Ref_LocationCoordination = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>().locationCoordination;
        Ref_Locator = GameObject.FindGameObjectWithTag("Locator").GetComponent<Locator>();
        TextUI = gameObject.GetComponent<UnityEngine.UI.Text>();
        StartCoroutine(GetLocationCoordinationValueCorutine());
    }

    void Update()
    {
        TextUI.text = Metrics.ToString();
    }

    protected IEnumerator GetLocationCoordinationValueCorutine()
    {
        while (true)
        {
            GetLocationCoordinationValue();
            yield return new WaitForSeconds(UpdateSecond);
        }
    }

    public abstract void GetLocationCoordinationValue();
}
