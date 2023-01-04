using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;


public class AuthManagerAuth : MonoBehaviour
{
    //public static AuthManagerAuth instance;
    //public static baseRoot root;


    //public static string Token
    //{
    //    set
    //    {
    //        PlayerPrefs.SetString("Token", value);
    //        Debug.Log(Token);
    //    }
    //    get
    //    {
    //        return PlayerPrefs.GetString("Token");
    //    }
    //}

    //private void Awake()
    //{
    //    if (instance != null)
    //    {
    //    // Destroy(gameObject);
    //    }
    //    else
    //    {
    //        instance = this;
    //        //DontDestroyOnLoad(this);
    //    }
    //}
   
    //public static string BASE_URL = "http://ec2-3-93-231-128.compute-1.amazonaws.com";


    //public void CreateUser(string username, string password)
    //{
    //    Debug.Log("Creating User");
    //    StartCoroutine(CreateUserStCoroutine(username, password));
    //}
    //public void LoginUser(string username, string password)
    //{
    //    Debug.Log("Login User");
    //    StartCoroutine(LoginUserCoroutine(username, password));
    //}
    //IEnumerator CreateUserStCoroutine(string username, string password)
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("user[email]", username);
    //    form.AddField("user[password]", password);

    //    string requestName = "/signup";
    //    using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.isNetworkError || www.isHttpError)
    //        {
    //            InputUIManager.instance.LoadingPanel.SetActive(false);
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            InputUIManager.instance.LoadingPanel.SetActive(false);
    //            Debug.Log(www.downloadHandler.text);
    //        }
    //    }
    //}
    //IEnumerator LoginUserCoroutine(string username, string password)
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("user[email]", username);
    //    form.AddField("user[password]", password);

    //    string requestName = "/login";
        
    //    using (UnityWebRequest www = UnityWebRequest.Post(BASE_URL + requestName, form))
    //    {
    //        yield return www.SendWebRequest();

    //        if (www.isNetworkError || www.isHttpError)
    //        {
    //            InputUIManager.instance.LoadingPanel.SetActive(false);
    //            Debug.Log(www.error);
    //        }
    //        else
    //        {
    //            OnSuccess(www.downloadHandler.text);
    //            SceneManager.LoadScene("Map");
      
    //        }
    //    }
    //}

    //private void OnSuccess(string json)
    //{
    //    Debug.Log(json);
    //    root = JsonUtility.FromJson<Root>(json);
    //    Debug.Log("Login Success Function");
    //    Token = root.meta.token;
    //    Debug.Log(root.meta.token);
    //    Debug.Log("ok so token is  = " + Token);
    //}

}