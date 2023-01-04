using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class ChatFriendsManager : MonoBehaviour
{
    //    public GameObject ChatFriendPrefab;
    //    public Transform ChatFriendListContent;
    //    private GameObject TempUser;
    //    void Start()
    //    {
    //        LoadingManager.instance.loading.SetActive(true);
    //        StartCoroutine(PostGetFriendsList());
    //    }
    //    public void GetFriendsList()
    //    {
    //        LoadingManager.instance.loading.SetActive(true);
    //        StartCoroutine(PostGetFriendsList());
    //    }
    //    private IEnumerator PostGetFriendsList()
    //    {
    //        string requestName = "api/v1/users/friend_list";
    //        string request = AuthManager.BASE_URL + requestName;
    //        // Debug.Log(request);

    //        using (UnityWebRequest webRequest = UnityWebRequest.Get(request))
    //        {
    //            webRequest.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
    //            // Request and wait for the desired page.
    //            yield return webRequest.SendWebRequest();

    //            string[] pages = request.Split('/');
    //            int page = pages.Length - 1;

    //            switch (webRequest.result)
    //            {
    //                case UnityWebRequest.Result.ConnectionError:
    //                case UnityWebRequest.Result.DataProcessingError:
    //                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
    //                    break;
    //                case UnityWebRequest.Result.ProtocolError:
    //                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
    //                    break;
    //                case UnityWebRequest.Result.Success:
    //                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

    //                    FriendsList ChatFriendsList = JsonUtility.FromJson<FriendsList>(webRequest.downloadHandler.text);
    //                    LoadingManager.instance.loading.SetActive(false);
    //                    GenerateChatfriendList(ChatFriendsList);
    //                    break;
    //            }
    //        }
    //    }
    //    public void GenerateChatfriendList(FriendsList ChatFriendsList)
    //    {
    //        ClearChatFriendsList();
    //        foreach (var i in ChatFriendsList.users)
    //        {
    //            //TempUser = Instantiate(ChatFriendPrefab, ChatFriendListContent);
    //            //TempUser.GetComponent<FriendItem>().Tempusername = i.username;
    //            //TempUser.GetComponent<FriendItem>().ChatUsername.text = i.username;
    //            //TempUser.GetComponent<FriendItem>().ChatUser = i;
    //            //TempUser.name = i.id.ToString();
    //            //TempUser.GetComponent<FriendItem>().Init(i);
    //        }
    //    }
    //    private void ClearChatFriendsList()
    //    {
    //        foreach (Transform ChatFriendItem in ChatFriendListContent.transform)
    //        {
    //            GameObject.Destroy(ChatFriendItem.gameObject);
    //        }
    //    }
}
