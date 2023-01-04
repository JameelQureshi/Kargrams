using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DexiDXG_Selector : MonoBehaviour
{
    public GameObject dexi;
    public GameObject dxg;


    public void LoadObject(string type)
    {
        if (type== "DEXI")
        {
            Destroy(dxg);
        }
        if(type == "DXG")
        {
            Destroy(dexi);
        }
    }
    
}
