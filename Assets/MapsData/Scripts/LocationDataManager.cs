
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mapbox.Unity.Location;
using UnityEngine;


public class LocationDataManager : MonoBehaviour
{
    public static LocationDataManager instance;

    public string[] m_locationsData;

    public Datum[] users;
    private bool isPlaceable;
    public static int LocationCounter;
    // public MapRoot UserLocation;
    public LocationRoot UserLocation;

    public void AssignMapRoot(string json)
    {
        UserLocation = JsonUtility.FromJson<LocationRoot>(json);

    }

    public void PlacePoints(string json)
    {
        Array.Clear(m_locationsData, 0, m_locationsData.Length);
        Array.Clear(users, 0, users.Length);
        UserLocation = JsonUtility.FromJson<LocationRoot>(json);
       //Debug.Log(json);
        int count = UserLocation.data.Count();
        m_locationsData = new string[count];
        LocationCounter = count;
        users = new Datum[count];
        for (int i = 0; i < count; i++)
        {
            m_locationsData[i] = UserLocation.data[i].lat + "+" + UserLocation.data[i].lng;
            users[i] = UserLocation.data[i];
        }
        MapPointsPlacement.instance.PlacePoints(m_locationsData);
        print("size = " + UserLocation.data.Count());
        // foreach (MapData userData in UserLocation.data)
        {
            // Debug.Log("Lat: " + userData.lat + " Long: " + userData.lng);
            //  Debug.Log("Type of Asset: " + userData.location_type);
        }

    }


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
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        isPlaceable = false;
        LocationProviderFactory.Instance.DeviceLocationProvider.OnLocationUpdated += OnUpdateLocationCalled;
    }

    private void OnUpdateLocationCalled(Location location)
    {
        if (m_locationsData != null)
        {
            if (isPlaceable)
            {
                isPlaceable = false;
            }

        }
    }

    private void OnDestroy()
    {
        LocationProviderFactory.Instance.DeviceLocationProvider.OnLocationUpdated -= OnUpdateLocationCalled;
    }





}

