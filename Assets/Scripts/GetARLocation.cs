using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetARLocation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
       AuthManager.instance.PlaceLocation();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
