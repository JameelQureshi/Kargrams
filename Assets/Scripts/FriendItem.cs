using System.Collections;
using System.Collections.Generic;
using Photon.Chat.Demo;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FriendItem : MonoBehaviour
{
    public User ChatUser;
    public ImageController imageController;
    public GameObject ImageStatus;
    public GameObject UnreadMsgImage;
    public GameObject OnlineFriendItem;
    public Text ChatUsername;
    public string ChatChannel;
    public string Tempusername;

    public void Init(User user)
    {
        //Debug.Log(" FriendItem id and URL " + ChatUser.id + ", " + ChatUser.prfile_image_url);
        //imageController.Init(ChatUser.id, ChatUser.prfile_image_url);
    }
    public void SetRecieverName()
    {
        //ChatGui.instance.TempRecieverName = Tempusername;
        ChatManager.Instance.ChatPanel.SetActive(true);
        ChatManager.Instance.SetChannelName(ChatUser.id.ToString());
        ChatManager.Instance.Set_User(ChatUser);
        ChatManager.Instance.GenerateChatPanel(ChatUser);
        ChatManager.Instance.CheckPanelExistance();
        OnlineFriendItem.gameObject.transform.GetChild(1).gameObject.SetActive(false);
        LoadingManager.instance.loading.SetActive(true);
        ChatManager.Instance.IsPanelOpened = true;
        //StartCoroutine(RetrieveChat(ChatUser.id));
        ChatManager.Instance.RefreshChat();
    }

    public IEnumerator RetrieveChat(int id)
    {
        string requestName = "api/v1/chats?receiver_id=" + id;
        //string requestName = "api/v1/users/get_consumed_points?onbases=all&userid=72";
        using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
            }
            else
            {
                Debug.Log("chat " + www.downloadHandler.text);
                RetrieveRoot RetrievedChat = JsonUtility.FromJson<RetrieveRoot>(www.downloadHandler.text);
                //if (RetrievedChat.success)
                //{
                //    ChatManager.Instance.RetrievedChatManager(RetrievedChat);
                //    //Invoke(nameof(ChatManager.Instance.PushChatToBottom), 0.2f);
                //    StartCoroutine(PushChatToBottom(0.2f));
                //    LoadingManager.instance.loading.SetActive(false);
                //}
                //else
                //{
                //    ConsoleManager.instance.ShowMessage("No Messages");
                //}
                //LoadingManager.instance.loading.SetActive(false);
            }
        }
    }
    private IEnumerator PushChatToBottom(float time)
    {
        yield return new WaitForSeconds(time);
        ChatManager.Instance.PushChatToBottom();
    }
}
