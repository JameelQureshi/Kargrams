using System.Collections;
using System.Collections.Generic;
using System.IO;
using ARLocation;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class AuthManager : MonoBehaviour
{

    public static AuthManager instance;
    public static Root root;
    public static int Loc_Count;
    public LocationRoot LocationRoot;


    //List<Transform> listOfTransforms = new List<Transform>();

    public static string Token
    {
        set
        {
            PlayerPrefs.SetString("Token", value);
        }
        get
        {
            return PlayerPrefs.GetString("Token");
        }
    }
    private void Awake()
    {
        if (instance != null)
        {
            // Destroy(gameObject);
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(this);
        }
    }
    public static string IsLogged
    {
        set
        {
            PlayerPrefs.SetString("IsLogged", value);
        }
        get
        {
            return PlayerPrefs.GetString("IsLogged", "false");
        }
    }

    public static string BASE_URL = "http://ec2-3-93-231-128.compute-1.amazonaws.com";

    public void CreateUser(string username, string password)
    {
        Debug.Log("Creating User");
        StartCoroutine(CreateUserStCoroutine(username, password));
    }

    public void AddLocation(float lat, float lng, int radius, string name, string location_type)
    {
        Debug.Log("Adding Location");

        StartCoroutine(CreateLocationStCoroutine(lat.ToString(), lng.ToString(), radius,  name, location_type));
    }
    public void PlaceLocation()
    {
        Debug.Log("Get LOC");

        StartCoroutine(GetLocationStCoroutine());
    }
    public void LoginUser(string username, string password)
    {
        Debug.Log("Login User");
        StartCoroutine(LoginUserCoroutine(username, password));
    }
    IEnumerator CreateUserStCoroutine(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("user[email]", username);
        form.AddField("user[password]", password);

        string requestName = "/signup";
        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
        {
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                InputUIManager.instance.LoadingPanel.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                InputUIManager.instance.LoadingPanel.SetActive(false);
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
    IEnumerator LoginUserCoroutine(string username, string password)
    {
        WWWForm form = new WWWForm();
        form.AddField("user[email]", username);
        form.AddField("user[password]", password);

        string requestName = "/login";
     
        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
        {
            Root Result1 = JsonUtility.FromJson<Root>(www.downloadHandler.text);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                InputUIManager.instance.LoadingPanel.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                OnSuccess(www.downloadHandler.text);
                SceneManager.LoadScene("DexiMap");
            }
        }
    }

    IEnumerator CreateLocationStCoroutine(string lat, string lng, int radius, string name, string location_type)
    {

        WWWForm form = new WWWForm();
        form.AddField("lat", Input.location.lastData.latitude.ToString());
        form.AddField("lng", Input.location.lastData.longitude.ToString());
        form.AddField("radius", "60");
        form.AddField("name", name);
        form.AddField("location_type", location_type);

        string requestName = "/api/v1/locations";
        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Token);
            Debug.Log(Token);
            yield return www.SendWebRequest();
   
            if (www.isNetworkError || www.isHttpError)
            {
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log(www.downloadHandler.text);
                SceneManager.LoadScene("DexiMap");
            }
        }
    }

 IEnumerator GetLocationStCoroutine()
    {
        LoadingManager.instance.loading.SetActive(true);
        WWWForm form = new WWWForm();
        form.AddField("lat", Input.location.lastData.latitude.ToString());
        form.AddField("lng", Input.location.lastData.longitude.ToString());
        form.AddField("radius", "60");

        string requestName = "/api/v1/locations/get_location";
        using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Token);

            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                LocationRoot allLocationRot = JsonUtility.FromJson<LocationRoot>(www.downloadHandler.text);
                LoadingManager.instance.loading.SetActive(false);
                PlaceAtLocations.instance.Init(allLocationRot);
               
                Debug.Log(www.downloadHandler.text);
                foreach(var item in allLocationRot.data)
                {
                    Debug.Log("location type  = "+item.location_type);

                }
            }
        }
    }





    private void OnSuccess(string json)
    {
        Debug.Log(json);
        root = JsonUtility.FromJson<Root>(json);
        IsLogged = "true";
        Debug.Log("Login Success Function");
        Debug.Log("Name = "+ root.data.email);
        Token = root.token;
        Debug.Log("token" + Token);
       // int locationcount = root.locations.Count;

    }
}

