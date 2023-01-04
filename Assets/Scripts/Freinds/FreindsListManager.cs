using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class FreindsListManager : MonoBehaviour
{
    public static FreindsListManager instance;

    public PendingUserController[] pendingusers;

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
       // GetFriendsList();
        //GetPendingFriendsLists();
    }

    public void GetFriendsList()
    {
        FriendListCreator.instance.ClearAll();
        StartCoroutine(PostGetFriendsList());
    }
    public void GetPendingFriendsLists()
    {
        foreach (PendingUserController pendingUser in pendingusers)
        {
            pendingUser.gameObject.SetActive(false);
        }
        LoadingManager.instance.loading.SetActive(true);
        StartCoroutine(PostGetPendingFriendsLists());
    }

    IEnumerator PostGetFriendsList()
    {
        string requestName = "api/v1/users/friend_list";
        string request = AuthManager.BASE_URL + requestName;
       // Debug.Log(request);

        using (UnityWebRequest webRequest = UnityWebRequest.Get(request))
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
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

                    //FriendsList friendsList = JsonUtility.FromJson<FriendsList>(webRequest.downloadHandler.text);
                    //FriendListCreator.instance.CreateList(friendsList);

                    break;
            }
        }
    }


    IEnumerator PostGetPendingFriendsLists()
    {
        string requestName = "api/v1/users/pending_requests";
        string request = AuthManager.BASE_URL + requestName;
       // Debug.Log(request);

        using (UnityWebRequest webRequest = UnityWebRequest.Get(request))
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

                    Debug.Log(webRequest.downloadHandler.text);
                   // PendingRequests pendingRequests = JsonUtility.FromJson<PendingRequests>(webRequest.downloadHandler.text);
                    //Debug.Log(pendingRequests.users.Count);
                    //int count = 0;
                    //if (pendingRequests.users.Count==1)
                    //{
                    //    count = 1;
                    //}
                    //else if (pendingRequests.users.Count >= 1)
                    //{
                    //    count = 2;
                    //}
                    //for (int i=0;i<count;i++)
                    //{
                    //    pendingusers[i].gameObject.SetActive(true);
                    //    pendingusers[i].ResetData();
                    //    pendingusers[i].Init(pendingRequests.users[i]);
                    //}

                    break;
            }
            LoadingManager.instance.loading.SetActive(false);
        }
    }
    
}
