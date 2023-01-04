using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using Mapbox.Unity.Location;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;


public class DropMyLocation : MonoBehaviour
{
    public static DropMyLocation instance;
    public Text test;
    float latitude;
    float longitude;
    string path;
    string jsonString;
    public LocationRoot localLocstionList;
    string Location_type;
    
    public   string UserName;
    public int user_id;
    public int radius;


    private void Awake()
    {
        if (instance != null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance = this;
        }

        //  StartCoroutine(PlacementCoroutine());
        //path =  Application.persistentDataPath + "/locations.json";
        //   ReadFile();
    }

    public void ReadFile()
    {
        if (File.Exists(path))
        {
            jsonString = File.ReadAllText(path);
            Debug.Log(jsonString);
            Debug.Log(path);
            localLocstionList = JsonUtility.FromJson<LocationRoot>(jsonString);
        }
        else
        {
            localLocstionList = new LocationRoot
            {
                data = new List<Datum>()
            };
        }
        if (localLocstionList != null)
        {
            StartCoroutine(PlacementCoroutine());
        }
    }
    IEnumerator PlacementCoroutine()
    {
        yield return new WaitForSeconds(5);
        POIPlacement3DMap.instance.Init(localLocstionList);
        LoadingManager.instance.loading.SetActive(false);
    }


    public void DropMyLocationFunc()
    {
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        Datum localLocation = new Datum
        {
            lat = latitude,
            lng = longitude
        };
        localLocstionList.data.Add(localLocation);
        //File.WriteAllText(path, JsonUtility.ToJson(localLocstionList));
    }


    public void DropLocation()
    {
        UserName = "";
        radius = 50;
        latitude = Input.location.lastData.latitude;
        longitude = Input.location.lastData.longitude;
        AuthManager.instance.AddLocation(latitude, longitude, radius,UserName, Location_type.ToLower());
    }

    public void GetLocationType()
    {
        // Location_type = gameObject.tag.ToString();
        Location_type = EventSystem.current.currentSelectedGameObject.name;

        Debug.Log(Location_type);
    }



}
