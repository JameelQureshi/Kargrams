using System.Collections;
using System.Collections.Generic;
using ImaginationOverflow.UniversalDeepLinking;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class Auth0Manager : MonoBehaviour
{
    

    public GameObject usernamePanel;
    public InputField usernameInput;
    public string token;

    public static bool usernameScreen;
    void Start()
    {
       

    }


    public static string AccessToken
    {
        set
        {
            PlayerPrefs.SetString("AccessToken", value);
        }
        get
        {
            return PlayerPrefs.GetString("AccessToken");
        }
    }

    private void Instance_LinkActivated(LinkActivation linkActivation)
    {
        AnalyseURL(linkActivation.Uri);
    }


    public void AnalyseURL(string url)
    {
        string[] split2 = url.Split('&');

        AccessToken = split2[0].Remove(0, 53);
        Debug.Log(AccessToken);

        CheckUsername();


    }
    
    public void OpenLoginURL()
    {
        
        //webView.Frame = new Rect(0, 0, Screen.width, Screen.height);
        //webView.Load("https://dev-x8a-qve9.us.auth0.com/authorize?audience=http://uat.dexigas.com:3330/api/v1&response_type=token&client_id=R9aHdBg5EBYddV8TvEydocP5n1C8YR2R&redirect_uri=app.dexihunter.com://app.dexihunter.com&scope=scope=openid%20profile%20email&state=STATE");
        //webView.Show();
        //Application.OpenURL("https://dev-x8a-qve9.us.auth0.com/authorize?audience=http://uat.dexigas.com:3330/api/v1&response_type=token&client_id=R9aHdBg5EBYddV8TvEydocP5n1C8YR2R&redirect_uri=app.dexihunter.com://app.dexihunter.com&scope=scope=openid%20profile%20email&state=STATE");
    }


    public void CheckUsername()
    {
        LoadingManager.instance.loading.SetActive(true);
        StartCoroutine(CheckUsernameRequest());
    }
    IEnumerator CheckUsernameRequest()
    {

        string requestName = "/api/v1/users/check_username";
        using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + AccessToken);
            yield return www.SendWebRequest();

            if ( www.result == UnityWebRequest.Result.ProtocolError || www.result == UnityWebRequest.Result.ConnectionError)
            {
                ConsoleManager.instance.ShowMessage("Error in Request");
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
               // SceneController.LoadScene(1);
            }
            else
            {
                //webView.CleanCache();
                //CloseWebView();
              //  UsernameStatus usernameStatus = JsonUtility.FromJson<UsernameStatus>(www.downloadHandler.text);
                //if (usernameStatus.username_exists)
                //{
                //   // AuthManager.Username = usernameStatus.data;
                //    LoadingManager.instance.loading.SetActive(false);
                //  //  SceneController.LoadScene(1);
                //}
                //else
                //{
                //    usernameScreen = true;
                //    LoadingManager.instance.loading.SetActive(false);
                // //   SceneController.LoadScene(0);
                //}
            }
        }
    }
    void CloseWebView()
    {
        
    }

    void OnDestroy()
    {
        CloseWebView();
    }
    public void CreateUsername()
    {
        if (usernameInput.text.Length < 3)
        {
            ConsoleManager.instance.ShowMessage("Please enter proper username.");
        }
        else
        {
            StartCoroutine(CreateUsernameRequest());
        }
        LoadingManager.instance.loading.SetActive(true);
    }
    IEnumerator CreateUsernameRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("username", usernameInput.text);

        string requestName = "/api/v1/users/update_username";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + AccessToken);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ProtocolError || www.result == UnityWebRequest.Result.ConnectionError)
            {
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
           //     SceneController.LoadScene(1);
            }
            else
            {
                LoadingManager.instance.loading.SetActive(false);
               // AuthManager.Username = usernameInput.text;
             // ..  SceneController.LoadScene(1);
            }
        }
    }

}
