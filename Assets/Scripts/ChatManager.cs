using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ChatManager : MonoBehaviour
{
    public static ChatManager Instance;

    public GameObject MesaageItemLeft;
    public GameObject MesaageItemRight;
    public GameObject ChatPanel;
    public GameObject FriendsContent;
    public GameObject ChatPanelPrefab;
    public GameObject PanelToWork;

    public RectTransform content;
    public RectTransform ChatPanelsHead;

    public User SetUser;
    public bool IsPanelOpened = false;
    public string PrivateChannelName;
    public Scrollbar scroll;
    private float temp;



    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
        }
    }
    private void Start()
    {
        JWT_tokenDecoder();
    }
    private void JWT_tokenDecoder()
    {
        var parts = Auth0Manager.AccessToken.Split('.');
        if (parts.Length > 2)
        {
            var decode = parts[1];
            var padLength = 4 - decode.Length % 4;
            if (padLength < 4)
            {
                decode += new string('=', padLength);
            }
            var bytes = System.Convert.FromBase64String(decode);
            var userInfo = System.Text.ASCIIEncoding.ASCII.GetString(bytes);
            Debug.Log("userInfo " + userInfo);
        }

        //var Token = "[encoded jwt]";
        //var handler = new JwtSecurityTokenHandler();
        //var jwt = handler.ReadJwtToken(token);
        //var Name = jwt.Claims.First(claim => claim.Type == "Name").Value;
        //var User_Id = jwt.Claims.First(claim => claim.Type == "User_Id").Value;
    }
    public void Set_User(User user)
    {
        SetUser = user;
    }
    public void SetChannelName(string RecieverName)
    {
        PrivateChannelName = RecieverName;
        Debug.Log("SetChannelName " + PrivateChannelName);

    }
    public void CloseChatPanel()
    {
        ChatPanel.SetActive(false);
        PrivateChannelName = "";
    }
    public void GenerateChatPanelOnPrivateRecieved(User RecieverUser)
    {
        bool check = false;
        foreach (Transform ChildPanel in ChatPanel.transform)
        {
            if (ChildPanel.gameObject.name == RecieverUser.id.ToString())
            {
                check = true;
                break;
            }
            else
            {
                check = false;
            }
        }
        if (check == false)
        {
            GameObject panel;
            panel = Instantiate(ChatPanelPrefab, ChatPanelsHead);
            Debug.Log("recieverr name " + RecieverUser.id.ToString());
            Debug.Log("GenerateChatPanel " + RecieverUser.id.ToString());
            panel.name = RecieverUser.id.ToString();
            //Debug.Log(PrivateChannelName);
        }
    }
    public void GenerateChatPanel(User RecieverUser)
    {
        bool check = false;
        foreach (Transform ChildPanel in ChatPanel.transform)
        {
            if (ChildPanel.gameObject.name == PrivateChannelName)
            {
                check = true;
                break;
            }
            else
            {
                check = false;
            }
        }
        if (check == false)
        {
            GameObject panel;
            panel = Instantiate(ChatPanelPrefab, ChatPanelsHead);
            panel.GetComponent<ChatPanelManager>().PanelUser = SetUser;
            panel.GetComponent<ChatPanelManager>().GetChatUserImage();
//            panel.transform.GetChild(0).transform.GetChild(2).GetComponent<Text>().text = RecieverUser.username;
            //Debug.Log("recieverr name " + RecieverUser.username);
            //Debug.Log("GenerateChatPanel " + PrivateChannelName);
            panel.name = PrivateChannelName;
            //Debug.Log(PrivateChannelName);
        }
    }
    public void CheckPanelExistance()
    {
        foreach (Transform ChildPanel in ChatPanel.transform)
        {
            Debug.Log("childs");
            ChildPanel.gameObject.SetActive(false);
            if (ChildPanel.gameObject.name == PrivateChannelName)
            {
                Debug.Log("Panel Already exist");
                ChildPanel.gameObject.SetActive(true);
                PanelToWork = ChildPanel.gameObject;
                content = ChildPanel.GetChild(1).transform.GetChild(0).transform.GetChild(0).gameObject.transform.GetComponent<RectTransform>();
                scroll = PanelToWork.transform.GetChild(1).transform.GetChild(1).GetComponent<Scrollbar>();
            }
        }
    }

    public void PushChatToBottom()
    {
        temp = (scroll.value) / 10;
        StartCoroutine(PushToBottom());
    }
    public IEnumerator PushToBottom()
    {
        if (scroll.value > 0)
        {
            yield return new WaitForSeconds(0.01f);
            Debug.Log("value " + scroll.value);
            scroll.value = scroll.value - temp;
            StartCoroutine(PushToBottom());
        }
    }
    public void RefreshChat()
    {
        StartCoroutine(RetrieveChat(SetUser.id));
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
                //    RetrievedChatManager(RetrievedChat);
                //    Invoke(nameof(PushChatToBottom), 0.2f);
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
    

    public void RetrievedChatManager(RetrieveRoot RetrievedChat)
    {
        GenerateChatPanelOnPrivateRecieved(SetUser);
        //if (RetrievedChat.data.Count>0)
        //{
        //    ClearMessages();
            //foreach (Datum Chat in RetrievedChat.data)
            //{
            //    Debug.Log("Chat " + Chat.message);
            //    GameObject obj;
            //    if (SetUser.id != Chat.receiver_id)
            //    {
            //        // this is reciever
            //        obj = Instantiate(MesaageItemLeft, content);
            //        obj.SetActive(true);
            //        scroll = PanelToWork.transform.GetChild(1).transform.GetChild(1).GetComponent<Scrollbar>();
            //        obj.GetComponent<MessageGO>().SetMessageInfo("" + Chat.message, false);
            //    }
            //    else
            //    {
            //        // this is sender
            //        obj = Instantiate(MesaageItemRight, content);
            //        obj.SetActive(true);
            //        scroll = PanelToWork.transform.GetChild(1).transform.GetChild(1).GetComponent<Scrollbar>();
            //        //obj.GetComponent<MessageManager>().msg.text = InputFieldChat.text;
            //        obj.GetComponent<MessageGO>().SetMessageInfo(Chat.message, true);
            //        //PanelToWork.transform.GetChild(2).transform.GetChild(0).GetComponent<InputField>().text = "";
            //        //Invoke(nameof(PushChatToBottom), 0.2f);
            //    }
            //}
            //for (int i = RetrievedChat.data.Count-1; i >=0; i--)
            //{
            //    GameObject obj;
            //    if (SetUser.id != RetrievedChat.data[i].receiver_id)
            //    {
            //        obj = Instantiate(MesaageItemLeft, content);
            //        obj.SetActive(true);
            //        scroll = PanelToWork.transform.GetChild(1).transform.GetChild(1).GetComponent<Scrollbar>();
            //        obj.GetComponent<MessageGO>().SetMessageInfo("" + RetrievedChat.data[i].message, false);
            //    }
            //    else
            //    {
            //        // this is sender
            //        obj = Instantiate(MesaageItemRight, content);
            //        obj.SetActive(true);
            //        scroll = PanelToWork.transform.GetChild(1).transform.GetChild(1).GetComponent<Scrollbar>();
            //        //obj.GetComponent<MessageManager>().msg.text = InputFieldChat.text;
            //        obj.GetComponent<MessageGO>().SetMessageInfo(RetrievedChat.data[i].message, true);
            //        //PanelToWork.transform.GetChild(2).transform.GetChild(0).GetComponent<InputField>().text = "";
            //        //Invoke(nameof(PushChatToBottom), 0.2f);
            //    }
            //}
            //Invoke(nameof(PushChatToBottom), 0.2f);
        //}
    }
    private void ClearMessages()
    {
        foreach (Transform Message in content)
        {
            Destroy(Message.gameObject);
        }
    }
    public void SendMessage(User User,string Message)
    {
        StartCoroutine(SendMsg(User.id.ToString(), Message));
    }
    IEnumerator SendMsg(string receiver_id,string message)
    {
        WWWForm form = new WWWForm();
        form.AddField("receiver_id", receiver_id);
        form.AddField("message", message);

        string requestName = "api/v1/chats";
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
              //  UnFriendResponceRoot SentMsgResponce = JsonUtility.FromJson<UnFriendResponceRoot>(www.downloadHandler.text);
                //if (SentMsgResponce.success)
                //{
                //    SpawnSentMsg(message);
                //    Invoke(nameof(PushChatToBottom), 0.2f);
                //}
                //else
                //{
                    
                //}
                //LoadingManager.instance.loading.SetActive(false);
            }
        }
    }
    public void SpawnSentMsg(string message)
    {
        GameObject obj;
        obj = Instantiate(MesaageItemRight, content);
        obj.SetActive(true);
        scroll = PanelToWork.transform.GetChild(1).transform.GetChild(1).GetComponent<Scrollbar>();
        //obj.GetComponent<MessageManager>().msg.text = InputFieldChat.text;
        obj.GetComponent<MessageGO>().SetMessageInfo(message, true);
        PanelToWork.transform.GetChild(2).transform.GetChild(0).GetComponent<InputField>().text = "";
    }
}
