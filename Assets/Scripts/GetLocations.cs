using System.Collections;
using System.Collections.Generic;
using Mapbox.Unity.Map;
using UnityEngine;
using UnityEngine.Networking;

public class GetLocations : MonoBehaviour
{
    public static GetLocations instance;
    public static LocationRoot fetched_Locations;
    public static  List<string> listOfTransforms = new List<string>();

    public AbstractMap goMap;

    private void Awake()
    {
        if (instance != null)
        {
            // Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
       
        PlaceLocation();
    }
    public void PlaceLocation()
    {
        StartCoroutine(GetLocationStCoroutine());
    }
    IEnumerator GetLocationStCoroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("lat", Input.location.lastData.latitude.ToString());
        form.AddField("lng", Input.location.lastData.longitude.ToString());
        form.AddField("radius", "60");

        string requestName = "/api/v1/locations/get_location";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + AuthManager.Token);

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                LocationRoot allLocationRot = JsonUtility.FromJson<LocationRoot>(www.downloadHandler.text);
                LoadingManager.instance.loading.SetActive(false);


                POIPlacement3DMap.instance.Init(allLocationRot);

               // MapPointsPlacement.instance.PlacePoints(allLocationRot);

                Debug.Log(www.downloadHandler.text);
                foreach (var item in allLocationRot.data)
                {
                    Debug.Log("lat" + item.lat);
                  //listOfTransforms.Add(item.name);
                }
                fetched_Locations = allLocationRot;
            }
        }
    }
}
