
using ARLocation;
using ARLocation.UI;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Networking;

public class ARLocationsManager : MonoBehaviour
{
    public static ARLocationsManager instance;
 
//    public PlaceAtLocations placeAtLocations;

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
        
       
    }

    // Start is called before the first frame update
    

    public void AugmentLocations()
    {
       
        // placeAtLocations.Init(DropMyLocation.instance.localLocstionList);
    }


}