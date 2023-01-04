using System.Collections;
using System.Collections.Generic;
using Mapbox.Examples;
using Mapbox.Unity.Map;
using UnityEngine;
using UnityEngine.UI;

public class MapsManager : MonoBehaviour
{
    [Header("3D Map Data")]
    public GameObject Go_Environment;
    public GameObject Go_Environment_Camera;

    [Header("2D Map Data")]
    public GameObject Two_D_Map_Camera;
    public GameObject Two_D_Map;
    public Button Reset_Two_D_Map;
    public GameObject Map;

    [Header("Canvas Data")]
    public Text MapChangingButtonText;
    

    private bool Is_Two_D_Map_Enabled = false;
    // Start is called before the first frame update
    void Start()
    {
        LoadDefaultMapData();
    }

    public void ChangeMap()
    {
        if (!Is_Two_D_Map_Enabled)
        {
            Reset_Two_D_Map.gameObject.SetActive(true);
            MapChangingButtonText.text = "3D";
            //Map.enabled = true;
            Two_D_Map.SetActive(true);
            Two_D_Map.transform.position = new Vector3(0, 0, 0);
            Go_Environment.SetActive(false);
            Go_Environment_Camera.SetActive(false);
            Two_D_Map_Camera.SetActive(true);
            Is_Two_D_Map_Enabled = true;
            Map.GetComponent<QuadTreeCameraMovement>().enabled = true;
        }
        else
        {
            Two_D_Map.SetActive(false);
            Reset_Two_D_Map.gameObject.SetActive(false);
            MapChangingButtonText.text = "2D";
            Two_D_Map.transform.position = new Vector3(0, -4, 0);
            //Map.enabled = false;
            Go_Environment.SetActive(true);
            Go_Environment_Camera.SetActive(true);
            Two_D_Map_Camera.SetActive(false);
            Is_Two_D_Map_Enabled = false;
            Map.GetComponent<QuadTreeCameraMovement>().enabled = false;
        }
    }
    private void LoadDefaultMapData()
    {
        Two_D_Map.SetActive(true);
        Reset_Two_D_Map.gameObject.SetActive(false);
        MapChangingButtonText.text = "2D";
        Two_D_Map.transform.position = new Vector3(0, -4, 0);
        //Map.enabled = false;
        Is_Two_D_Map_Enabled = false;
        Go_Environment.SetActive(true);
        Go_Environment_Camera.SetActive(true);
        Two_D_Map_Camera.SetActive(false);
        Map.GetComponent<QuadTreeCameraMovement>().enabled = false;
    }
}
