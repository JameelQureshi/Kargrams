
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using ARLocation.UI;

public class ARLinksPanel : MonoBehaviour
{
    public static ARLinksPanel instance;
    
    public Text RayResponce;
    private int LinksCounter;
   
    private void Awake()
    {
        RayResponce.text = "Looking";
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    public void OpenURL(string url)
    {
        Application.OpenURL(url);
    }


    public void LoadMapScene()
    {
        LinksCounter = 0;
        DebugDistance.Dist = 0;
        SceneManager.LoadScene(1);
    }
}