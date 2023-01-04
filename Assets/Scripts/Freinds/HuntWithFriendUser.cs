

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HuntWithFriendUser : MonoBehaviour
{
    public Toggle selected;
    public Button inviteButton;
    public Text nameText;
    public ImageController imageController;

    public User user;
    public void Init(User user)
    {
        this.user = user;
      //  nameText.text = " " + user.username;
        inviteButton.onClick.AddListener(InviteFriend);
//        imageController.Init(user.id, user.prfile_image_url);

    }
    void InviteFriend()
    {
        StartCoroutine(SendHuntingNotification(user.id, " invited you to hunt together."));
        //OneSignalManager.instance.SendNotificationTo(user.notification_id, AuthManager.Username, " invited you to hunt together.");
        inviteButton.GetComponentInChildren<Text>().text = "Invited";
        inviteButton.interactable = false;
    }
    IEnumerator SendHuntingNotification(int receiver_id, string message)
    {
        WWWForm form = new WWWForm();
        form.AddField("message", message);
        form.AddField("receiver_id", receiver_id);


        string requestName = "api/v1/friendship/send_notification";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleManager.instance.ShowMessage("Sending Error!");
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
            }
            else
            {
                Debug.Log("chat " + www.downloadHandler.text);
               // UnFriendResponceRoot SentMsgResponce = JsonUtility.FromJson<UnFriendResponceRoot>(www.downloadHandler.text);
                //if (SentMsgResponce.success)
                //{
                //    ConsoleManager.instance.SendMessage("Notification Sent");
                //}
                //else
                //{
                //    ConsoleManager.instance.SendMessage("Notification not Sent");
                //}
                LoadingManager.instance.loading.SetActive(false);
            }
        }
    }
}
