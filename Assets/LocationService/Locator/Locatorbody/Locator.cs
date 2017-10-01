using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Locator : MonoBehaviour
{
    LocationService locationService;
    [System.NonSerialized]
    public LocationCoordination locationCoordination;
    DistanceCalculator distanceCalculator;
    float locationAnalyzeCounter;
    [SerializeField]
    float locationAnalyzeTime;
    bool isMobilePlatform;
    bool isLocationUpdating;
    [SerializeField]
    double initlat = 35.513f;
    [SerializeField]
    double initlong = 139.619f;
    public UnityEvent OnLocationUpdate;

    // Use this for initialization
    void Start()
    {
        OnLocationUpdate = new UnityEvent();
        locationService = Input.location;
        locationCoordination = ScriptableObject.CreateInstance<LocationCoordination>();
        distanceCalculator = gameObject.GetComponent<DistanceCalculator>();
        //googleMapDrawer = GameObject.FindGameObjectWithTag("MapDrawer").GetComponent<GoogleMapDrawer>();
        //googleMapDrawer.Calculator = locationCoordination;
        //ロケーションサービスが無効、かつユーザーが許可しているなら
        //ロケーションサービスを有効化
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
            case RuntimePlatform.IPhonePlayer:
                isMobilePlatform = true;
                break;
        }
        if (isMobilePlatform)
        {
            switch (locationService.status)
            {
                case LocationServiceStatus.Stopped:
                    LocationUpdate();
                    break;
                default:
                    break;
            }
        }
        else
        {
            locationCoordination.SetCoordination(initlong, initlat);
        }

    }

    // Update is called once per frame
    void Update()
    {
            locationAnalyzeCounter += Time.deltaTime;
            if (!(isLocationUpdating) && locationAnalyzeCounter >= locationAnalyzeTime)
            {
                StartCoroutine(LocationUpdate());
                OnLocationUpdate.Invoke();
                
                locationAnalyzeCounter = 0.0f;
            }
    }

    IEnumerator LocationUpdate()
    {

        int retryCounter = 20;
        if (locationService.isEnabledByUser)
        {
            isLocationUpdating = true;
            locationService.Start();
            while (locationService.status == LocationServiceStatus.Initializing && retryCounter > 0)
            {
                retryCounter--;
                yield return new WaitForSeconds(1.0f);
            }
            
            if (locationService.status == LocationServiceStatus.Running)
            {
                locationCoordination.SetCoordination(locationService.lastData.longitude, locationService.lastData.latitude);
                //metricsCoordination.ConvertLongAndLetiToMetrics();
                distanceCalculator.DistanceCalculation();
            }
            else
            {
                Debug.Log("failed Location Service initiation");
            }
            //locationService.Stop();
            isLocationUpdating = false;
        }
        
        yield return null;
    }

    double CalculateDistanceOfNowCoordinationToSpot(SpotData targetSpotData)
    {
        DVector2 a = new DVector2(locationCoordination.GetLongitude, locationCoordination.GetLatitude);
        DVector2 b = new DVector2(targetSpotData.longitude, targetSpotData.letitude);
        return long_lati_calculator.GetInstance.CalculateLetiAndLongDistanceOfAtoB(a, b);
    }
}
