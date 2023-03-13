using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UsersFromLocation : MonoBehaviour
{
    private int counter = 0;
    public static string message;
    private void Update()
    {
    }

    void Start()
    {
        LoadingManager.instance.loading.SetActive(true);
        Invoke(nameof(GetUserByLocations), 2 );
    }
  
    public void GetUserByLocations()
    {
        LoadingManager.instance.loading.SetActive(true);
        StartCoroutine(GetLocations());
    }

    public void CalculateRange()
    {

        Invoke(nameof(CalculateRange), 5);
    }

    IEnumerator GetLocations()
    {
        WWWForm form = new WWWForm();
        form.AddField("lat", Input.location.lastData.latitude.ToString());
        form.AddField("lng", Input.location.lastData.longitude.ToString());
        form.AddField("radius", "60");


        string requestName = "/api/v1/locations/get_location";

        using UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form);
        www.SetRequestHeader("Authorization", "Bearer " + AuthManager.Token);
      
        yield return www.SendWebRequest();
        if (www.isNetworkError || www.isHttpError)
        {

            Root allLocationRot = JsonUtility.FromJson<Root>(www.downloadHandler.text);
            //Debug.Log(allLocationRot.data);
            if (allLocationRot.data == "Locations not found")
            {
                LoadingManager.instance.loading.SetActive(false);
                ConsoleManager.instance.ShowMessage("Locations not found");
            }
            else
            {
                PlayerPrefs.DeleteAll();
                ConsoleManager.instance.ShowMessage("Error " + www.error);
                LoadingManager.instance.loading.SetActive(false);
                SceneManager.LoadScene("Auth");
            }


        }
        else
        {
            try
            {
                Debug.Log(www.downloadHandler.text);
                Debug.Log(" 3D pins placement function!");
                LocationDataManager.instance.PlacePoints(www.downloadHandler.text);
            }
            catch (Exception e)
            {
        
            }
            LoadingManager.instance.loading.SetActive(false);
            ConsoleManager.instance.ShowMessage("Location Found!");
        }
    }
}
