using System.Collections;
using System.Collections.Generic;
using SimpleJSON;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;


public class AddFreinds : MonoBehaviour
{
    public static AddFreinds instance;


    public InputField usernameInput;
    public GameObject searchedUserObj;

    private bool UsernameStatus = true;


    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        Invoke("SetNotidicationId", 1.5f);
    }

    public void CloseSearchPanel()
    {
        searchedUserObj.SetActive(false);
        usernameInput.text = "";
    }

    public void OpenSearchPanel()
    {
        searchedUserObj.GetComponent<UserController>().ResetData();
    }

    public void SearchUser()
    {
        if (usernameInput.text != null)
        {
            LoadingManager.instance.loading.SetActive(true);
            StartCoroutine(PostSearchUser(usernameInput.text));
        }
    }

    public void ClearSearchBar()
    {
        usernameInput.text = "";
    }
    public void FreindRequestResponse(User user , string response)
    {
        StartCoroutine(SendFreindRequestResponse(user,response));
    }

    public void Unfreind()
    {
        StartCoroutine(SendUnfreind("user_22"));
    }


    IEnumerator SendUnfreind(string status)
    {
        string requestName = "api/v1/users/search_user";
        string request = AuthManager.BASE_URL + requestName;
        WWWForm form = new WWWForm();
        form.AddField("status", status);
        //Debug.Log(request);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(request, form))
        {
            webRequest.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

          //  string[] pages = request.Split('/');
          //  int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    //Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    //Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(webRequest.downloadHandler.text);
                    break;
            }
        }
    }

    IEnumerator SendFreindRequestResponse(User user, string status)
    {
        string requestName = "api/v1/friendship/"+user.id+"/update_status";
        string request = AuthManager.BASE_URL + requestName;
        WWWForm form = new WWWForm();
        form.AddField("status", status);
        //Debug.Log(request);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(request, form))
        {
            webRequest.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = request.Split('/');
            int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    if (status == "accepted")
                    {
                        //OneSignalManager.instance.SendNotificationTo(user.notification_id, (AuthManager.Username), " is now your freind");
                    }
                    else
                    {
                        //OneSignalManager.instance.SendNotificationTo(user.notification_id, (AuthManager.Username), " rejected your request");
                    }

                    Debug.Log(webRequest.downloadHandler.text);
                    FreindsListManager.instance.GetPendingFriendsLists();
                    FreindsListManager.instance.GetFriendsList();
                    break;
            }
            LoadingManager.instance.loading.SetActive(false);
        }
    }


    IEnumerator PostSearchUser(string username)
    {
        string requestName = "api/v1/users/search_user";
        string request = AuthManager.BASE_URL + requestName;
        WWWForm form = new WWWForm();
        form.AddField("username", username);
        //Debug.Log(request);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(request,form))
        {
            webRequest.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            //string[] pages = request.Split('/');
            //int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    // Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    LoadingManager.instance.loading.SetActive(false);
                    ConsoleManager.instance.ShowMessage("Internet Error");
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    //  Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    LoadingManager.instance.loading.SetActive(false);
                    ConsoleManager.instance.ShowMessage("Internet Error");
                    break;
                case UnityWebRequest.Result.Success:
                    //Debug.Log("Friend Status"+webRequest.downloadHandler.text);
                    //SearchedUserResult searchedUser = JsonUtility.FromJson<SearchedUserResult>(webRequest.downloadHandler.text);
                    var dict = JSONNode.Parse(webRequest.downloadHandler.text);
                    foreach (KeyValuePair<string, JSONNode> N in dict)
                    {
                        Debug.Log("Key "+N.Key+", Value "+N.Value);
                        if (N.Key=="success")
                        {
                            
                            UsernameStatus = false;
                            Debug.Log("UsernameStatus " + UsernameStatus);
                            break;
                        }
                        else
                        {
                            UsernameStatus = true;
                        }
                    }
                    Debug.Log("UsernameStatus1 " + UsernameStatus);
                    if (UsernameStatus)
                    {
                        //SearchedUserResult searchedUser = JsonUtility.FromJson<SearchedUserResult>(webRequest.downloadHandler.text);
                        LoadingManager.instance.loading.SetActive(false);
                        ConsoleManager.instance.ShowMessage("User Found");
                        Debug.Log(webRequest.downloadHandler.text);
                        searchedUserObj.SetActive(true);
                       // searchedUserObj.GetComponent<UserController>().Init(searchedUser.user);
                    }
                    else
                    {
                        searchedUserObj.SetActive(false);
                        LoadingManager.instance.loading.SetActive(false);
                        ConsoleManager.instance.ShowMessage("User Not Found");
                    }
                    //if (searchedUser.user.username != ""  || searchedUser.user.username != null)
                    //{
                    //    LoadingManager.instance.loading.SetActive(false);
                    //    ConsoleManager.instance.ShowMessage("User Found");
                    //    Debug.Log(webRequest.downloadHandler.text);
                    //    searchedUserObj.SetActive(true);
                    //    searchedUserObj.GetComponent<UserController>().Init(searchedUser.user);
                    //}
                    //else
                    //{
                    //    LoadingManager.instance.loading.SetActive(false);
                    //    ConsoleManager.instance.ShowMessage("User Not Found");
                    //}
                    break;
            }
        }
        
    }
    public void SetNotidicationId()
    {
//        if (AuthManager.NotificationId == "")
//        {
////            Debug.Log("Setting up: " + AuthManager.NotificationId);
//            //StartCoroutine(PostNotificationId(OneSignalManager.notificationId));
//        }
    }

    public IEnumerator PostNotificationId(string notification_id)
    {
        string requestName = "api/v1/users/store_notification_id";
        string request = AuthManager.BASE_URL + requestName;
        WWWForm form = new WWWForm();
        form.AddField("notification_id", notification_id);
        //Debug.Log(request);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(request, form))
        {
            webRequest.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            //  string[] pages = request.Split('/');
            //  int page = pages.Length - 1;

            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    //Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    //Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(webRequest.downloadHandler.text);
                  ///  AuthManager.NotificationId = notification_id;
                    break;
            }
        }
    }
}
