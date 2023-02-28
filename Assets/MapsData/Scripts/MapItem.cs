using ARLocation.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class MapItem : MonoBehaviour
{
    public static MapItem instance;
    public Datum ARuser;
    public GameObject DeletePlacementpanel;

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
    private void OnMouseDown()
    {
        DeletePlacementpanel.SetActive(true);
    }

    public void DeletePlacement()
    {
        StartCoroutine(GetDeletePlacement());
    }

    IEnumerator GetDeletePlacement()
    {
        string requestName = "/api/v1/locations/destroy?loc_id=" + ARuser.id ;

        using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + AuthManager.Token);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                SceneManager.LoadScene("Auth");
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                SceneManager.LoadScene("DexiMap");
            }
        }
    }

}

