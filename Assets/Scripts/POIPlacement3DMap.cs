using System.Collections;
using System.Collections.Generic;
using GoShared;
using UnityEngine;
using GoMap;
using UnityEngine.UI;
using Mapbox.Unity.Map;

public class POIPlacement3DMap : MonoBehaviour
{
    //public GOMap goMap;
    public GameObject prefabs;

    // public Text debugText;
    public AbstractMap goMap;

    public static POIPlacement3DMap instance; 

    private void Awake()
    {
        if (instance != null)
        {
          //  Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
       // DontDestroyOnLoad(this.gameObject);
    }

    // Start is called before the first frame update

    private void Start()
    {
        //Invoke("PlacePOIs", 1);
        Debug.Log(" lat " + Input.location.lastData.latitude.ToString()+ " long "+ Input.location.lastData.longitude.ToString());
    }

    public void Init(LocationRoot localLocationList)
    {
        Debug.Log("Count" + localLocationList.data.Count);

        for (int i = 0; i < localLocationList.data.Count; i++)
        {
            Debug.Log(" Location placing!");

            double lat = localLocationList.data[i].lat;
            double lng = localLocationList.data[i].lng;

            GameObject poi = null;

            poi = Instantiate(prefabs);

            //2) make a Coordinate class with your desired latitude longitude
            Coordinates coordinates = new Coordinates(lat, lng);

            // debugText.text = debugText.text + "\n" + coordinates.latitude +" | "+coordinates.longitude;

            //3) call drop pin passing the coordinates and your gameobject
              //goMap.dropPin(coordinates, poi);

        }

    }

}
