using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TransectionItem : MonoBehaviour
{
//    public LastTransectionsLocation Transection;
    public Text TransectionText;
    public Text updatedAtText;
    void Start()
    {
        //TransectionText.text = "Collected " + Transection.location_type.ToUpper();
        //updatedAtText.text = ""+DistanceManager.UnixTimeStampToDateTime(Transection.updated_at);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
