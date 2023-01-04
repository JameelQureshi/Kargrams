using System.Collections;
using System.Collections.Generic;
using PedometerU.Tests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HunterProfile : MonoBehaviour
{
    public static HunterProfile instance;


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

    //private TopUser topUser;
    //private FriendsList FriendsList;
    public Button AddFriendButton;

    public GameObject hunterProfileScreen;
    public Image profileImage;
    public Text userNameText;
    public Text all_bounty_count;
    public Text all_steps_count;

    public Button inviteToHunt;

    //private void Start()
    //{
    //    LoadingManager.instance.loading.SetActive(true);
    //    StartCoroutine(PostGetFriendsList());
    //}
    //public void Open(TopUser user, Sprite profileSprite)
    //{
    //    Debug.Log("user.username " + user.username);
    //   // Debug.Log("AuthManager.Username " + AuthManager.Username);
    //    topUser = user;

    //    hunterProfileScreen.SetActive(true);
    //    profileImage.sprite = profileSprite;
    //    userNameText.text = "@" + topUser.username;
    //    all_bounty_count.text = topUser.bounty_count.ToString();
    //    all_steps_count.text = StepCounter.StepsToKilometers(topUser.month_steps_count);
    //    inviteToHunt.GetComponentInChildren<Text>().text = "Invite to hunt";
    //    inviteToHunt.interactable = true;
    //    if (FriendsList.users.Count>0)
    //    {
    //        foreach (var Friend in FriendsList.users)
    //        {
    //            //if (Friend.username == user.username)
    //            //{
    //            //    AddFriendButton.interactable = false;
    //            //    inviteToHunt.interactable = true;
    //            //    Debug.Log("You are friends");
    //            //    break;
    //            //}
    //            //else
    //            //{
    //            //    AddFriendButton.interactable = true;
    //            //    inviteToHunt.interactable = false;
    //            //}
    //        }
    //    }
    //    else
    //    {
    //        AddFriendButton.interactable = true;
    //        inviteToHunt.interactable = false;
    //    }
        //if (AuthManager.Username == user.username)
        //{
        //    AddFriendButton.interactable = false;
        //    inviteToHunt.interactable = false;
        //}


  //  }
    //public void Add_Friend()
    //{
    //    Debug.Log("User " + topUser.id + ", name " + topUser.username);
    //    StartCoroutine(SendFreind_Request(topUser.id.ToString()));
    //}
    //public void InviteToHunt()
    //{
    //  //  Debug.Log(topUser.ToString() + AuthManager.Username + " invited you to hunt together");

    //    //OneSignalManager.instance.SendNotificationTo(topUser.notification_id, AuthManager.Username, " invited you to hunt together.");
    //    StartCoroutine(SendHuntingNotification(topUser.id, " invited you to hunt together."));
    //    inviteToHunt.GetComponentInChildren<Text>().text = "Invited";
    //    inviteToHunt.interactable = false;
    //    //ConsoleManager.instance.ShowMessage("Invitation Sent");
    //}
    //public void ResetAddFriendButton()
    //{
    //    AddFriendButton.interactable = true;
    //    AddFriendButton.GetComponentInChildren<Text>().text = "Add Friend";
    //}
    //IEnumerator SendHuntingNotification(int receiver_id, string message)
    //{
    //    WWWForm form = new WWWForm();
    //    form.AddField("message", message);
    //    form.AddField("receiver_id", receiver_id);


    //    string requestName = "api/v1/friendship/send_notification";
    //    using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
    //    {
    //        www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
    //        yield return www.SendWebRequest();

    //        if (www.isNetworkError || www.isHttpError)
    //        {
    //            ConsoleManager.instance.ShowMessage("Sending Error!");
    //            Debug.Log(www.error);
    //            LoadingManager.instance.loading.SetActive(false);
    //        }
    //        else
    //        {
    //            Debug.Log("chat " + www.downloadHandler.text);
    //            UnFriendResponceRoot SentMsgResponce = JsonUtility.FromJson<UnFriendResponceRoot>(www.downloadHandler.text);
    //            if (SentMsgResponce.success)
    //            {
    //                ConsoleManager.instance.SendMessage("Notification Sent");
    //            }
    //            else
    //            {
    //                ConsoleManager.instance.SendMessage("Notification not Sent");
    //            }
    //            LoadingManager.instance.loading.SetActive(false);
    //        }
    //    }
    //}
    //IEnumerator SendFreind_Request(string receiver_id)
    //{
    //    string requestName = "/api/v1/friendship";
    //    string request = AuthManager.BASE_URL + requestName;
    //    WWWForm form = new WWWForm();
    //    form.AddField("receiver_id", receiver_id);
    //    //Debug.Log(request);

    //    using (UnityWebRequest webRequest = UnityWebRequest.Post(request, form))
    //    {
    //        webRequest.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
    //        // Request and wait for the desired page.
    //        yield return webRequest.SendWebRequest();

    //        //  string[] pages = request.Split('/');
    //        //  int page = pages.Length - 1;

    //        switch (webRequest.result)
    //        {
    //            case UnityWebRequest.Result.ConnectionError:
    //            case UnityWebRequest.Result.DataProcessingError:
    //                //Debug.LogError(pages[page] + ": Error: " + webRequest.error);
    //                break;
    //            case UnityWebRequest.Result.ProtocolError:
    //                //Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
    //                break;
    //            case UnityWebRequest.Result.Success:
    //                Debug.Log(webRequest.downloadHandler.text);
    //                ConsoleManager.instance.ShowMessage("Request Sent");
    //                AddFriendButton.GetComponentInChildren<Text>().text = "Sent";
    //                AddFriendButton.interactable = false;
    //                //OneSignalManager.instance.SendNotificationTo(topUser.notification_id, (AuthManager.Username));
    //              //  Debug.Log("Username " + AuthManager.Username);
    //                break;
    //        }
    //        LoadingManager.instance.loading.SetActive(false);
    //    }
    //}

    //IEnumerator PostGetFriendsList()
    //{
    //    string requestName = "api/v1/users/friend_list";
    //    string request = AuthManager.BASE_URL + requestName;
    //    // Debug.Log(request);

    //    using (UnityWebRequest webRequest = UnityWebRequest.Get(request))
    //    {
    //        webRequest.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
    //        // Request and wait for the desired page.
    //        yield return webRequest.SendWebRequest();

    //        string[] pages = request.Split('/');
    //        int page = pages.Length - 1;

    //        switch (webRequest.result)
    //        {
    //            case UnityWebRequest.Result.ConnectionError:
    //            case UnityWebRequest.Result.DataProcessingError:
    //                Debug.LogError(pages[page] + ": Error: " + webRequest.error);
    //                break;
    //            case UnityWebRequest.Result.ProtocolError:
    //                Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
    //                break;
    //            case UnityWebRequest.Result.Success:
    //                Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);

    //                FriendsList = JsonUtility.FromJson<FriendsList>(webRequest.downloadHandler.text);
    //                LoadingManager.instance.loading.SetActive(false);
    //                break;
    //        }
    //    }
    //}
}