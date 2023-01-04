
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using UnityEngine.Networking;
// ReSharper disable CollectionNeverQueried.Local
// ReSharper disable MemberCanBePrivate.Global

namespace ARLocation
{
    /// <summary>
    /// This class instantiates a prefab at the given GPS locations. Must
    /// be in the `ARLocationRoot` GameObject with a `ARLocatedObjectsManager`
    /// Component.
    /// </summary>
    
    [AddComponentMenu("AR+GPS/Place At Locations")]
    [HelpURL("https://http://docs.unity-ar-gps-location.com/guide/#placeatlocations")]
    public class PlaceAtLocations : MonoBehaviour
    {

       public static PlaceAtLocations instance;
        public double Latitude;
        public double longitude ;
        public string[] LocationType;
        public GameObject[] Models;
        private GameObject SelectedModel;
        public List<string> LocationList = new List<string>();

        private void Awake()
        {
            UsersCounter = 0;
            if (instance != null)
            {
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                instance = this;
            }
           
        }
        [Serializable]
        public class Entry
        {
            public LocationData ObjectLocation;
            public OverrideAltitudeData OverrideAltitude = new OverrideAltitudeData();
        }

        [Tooltip("The locations where the objects will be instantiated.")]
        public List<PlaceAtLocation.LocationSettingsData> Locations;

        public PlaceAtLocation.PlaceAtOptions PlacementOptions;

        /// <summary>
        /// The game object that will be instantiated.
        /// </summary>
        [FormerlySerializedAs("prefab")]
        [Tooltip("The game object that will be instantiated.")]
        public string[] BountiesForRocket;
        public string[] DexiBounties;
        public GameObject[] Rockets;
        public GameObject[] DexiCrates;
        public GameObject[] Prefabs;
        private GameObject GameobjectToSpawn;
        public static int UsersCounter;
        private int RocketIndex = 0;
        private int DexiCrateIndex = 0;
        Root UsersARLocation;
        //public Text pinLocationsText;
        //public Text currentLocText;
        public bool canCalculateDistance = false;
        public int RadiusToPlaceInAR;
        private Mapbox.Unity.Location.Location currentLocation;
        private void Update()
        {

        }

        //private void Awake()
        //{
        //    UsersCounter = 0;
        //}
        [Space(4.0f)]

        [Header("Debug")]
        [Tooltip("When debug mode is enabled, this component will print relevant messages to the console. Filter by 'PlateAtLocations' in the log output to see the messages.")]
        public bool DebugMode;

        [Space(4.0f)]

        private readonly List<Location> locations = new List<Location>();
        public  List<GameObject> instances = new List<GameObject>();
        public List<GameObject> Instances => instances;


        public void Init(LocationRoot localLocationList)
        { 
            DebugMode = true;

            Debug.Log("Count" + localLocationList.data.Count);

            for (int i = 0; i < localLocationList.data.Count; i++)
            {
                PlaceAtLocation.LocationSettingsData locations = new PlaceAtLocation.LocationSettingsData();

                locations.LocationInput.Location.Latitude = localLocationList.data[i].lat;
                locations.LocationInput.Location.Longitude = localLocationList.data[i].lng;

                Latitude  = locations.LocationInput.Location.Latitude;
                longitude  = locations.LocationInput.Location.Longitude;
                
                //location.LocationInput.Location.Latitude = Lati[i];
                //location.LocationInput.Location.Longitude = Lon[i];
                Locations.Add(locations);
            }

            foreach (Datum userData in localLocationList.data)
            {
                Debug.Log("Data = " + userData.location_type);
                LocationList.Add(userData.location_type);
            }

            int index = 0;
            foreach (var entry in Locations)
            {
                //for (int i = 0; i < LocationType.Length; i++)
                //    {
                //    foreach (Datum userData in localLocationList.data)
                //    {
                //        if (userData.location_type == LocationType[i])
                //        {
                //            SelectedModel = Models[i];
                //            Debug.Log("check");
                //        }
                //        else
                //        {
                //            SelectedModel = Models[0];
                //            Debug.Log("checknot");
                //        }
                //    }
                //        //index++;
                //         }
                //for (int i = 0; i < LocationType.Length; i++)
                //{

                  //  Debug.Log();
                //    foreach (Datum userData in localLocationList.data)
                //    {
                //        if (userData.location_type == "car")
                //        {
                //            SelectedModel = Models[0];
                //            Debug.Log("check" + SelectedModel.name);
                //        }

                //        if (userData.location_type == "bike")
                //        {
                //            SelectedModel = Models[1];
                //            Debug.Log("check" + SelectedModel.name);
                //        }

                //        if (userData.location_type == "bus")
                //        {
                //            SelectedModel = Models[2];
                //            Debug.Log("check" + SelectedModel.name);
                //        }

                //        if (userData.location_type == "cycle")
                //        {
                //            SelectedModel = Models[3];
                //            Debug.Log("check" + SelectedModel.name);
                //        }
                //        //else
                //        //{
                //        //    SelectedModel = Models[0];
                //        //    Debug.Log("checknot");
                //        //}
                //   // }
                //    //index++;
                //}
                var newLoc = entry.GetLocation();
                AddLocation(newLoc, index);
                UsersCounter++;
                Debug.Log(" UsersCounter" + UsersCounter);
            }
            canCalculateDistance = true;
            //DebugLocationOnCanvas();
        }

        private void DebugLocationOnCanvas()
        {
            foreach (GameObject item in instances)
            {
               // pinLocationsText.text = pinLocationsText.text + "Pin: " + item.GetComponent<ARItem>().ARuser.lat + " " + item.GetComponent<ARItem>().ARuser.lng + "\n";
            }
        }

        public void AddLocation(Location location, int index)
        {
                int prefabIndex = 1;
                GameobjectToSpawn = Prefabs[prefabIndex];
               // var instance = PlaceAtLocation.CreatePlacedInstance(SelectedModel, location, PlacementOptions, DebugMode);
                 var instance = PlaceAtLocation.CreatePlacedInstance(GameobjectToSpawn, location, PlacementOptions, DebugMode);
                 //Debug.Log("check name"+SelectedModel.name);
                instance.name = $"{gameObject.name} - {locations.Count}";
                locations.Add(location);
                instances.Add(instance);
        }
    }
}