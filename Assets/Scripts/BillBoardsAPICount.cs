using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class BillBoardsAPICount : MonoBehaviour
{

    public static BillBoardsAPICount instance;
    public static LocationRoot fetched_Locations;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }

    }

    void Start()
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
              
                Debug.Log(www.error);
            }
            else
            {
                LocationRoot allLocationRot = JsonUtility.FromJson<LocationRoot>(www.downloadHandler.text);
               

                Debug.Log(www.downloadHandler.text);
                foreach (var item in allLocationRot.data)
                {
                    Debug.Log("location type  = " + item.location_type);

                }
            }
        }
    }
}