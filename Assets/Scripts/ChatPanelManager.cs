using System.Collections;
using System.Collections.Generic;
using System.IO;
using Photon.Chat.Demo;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ChatPanelManager : MonoBehaviour
{
    public InputField MessageInputField;
    public Image UserImage;
    public User PanelUser;
    private string localURL;
    void Start()
    {
        GetChatUserImage();
    }
    public void GetChatUserImage()
    {
//        Debug.Log("id and URL " + PanelUser.id + ", " + PanelUser.prfile_image_url);
        localURL = string.Format("{0}/{1}.jpg", Application.persistentDataPath, "" + PanelUser.id);

        if (File.Exists(localURL))
        {
            LoadLocalFile();
        }
        else
        {
         //   StartCoroutine(GetThumbnail(PanelUser.prfile_image_url));
        }
        //if (PanelUser.prfile_image_url != "" || PanelUser.prfile_image_url != null)
        //{
        //    LoadingManager.instance.loading.SetActive(true);
        //    StartCoroutine(GetThumbnail(PanelUser.prfile_image_url));
        //}
    }
    public void LoadLocalFile()
    {
        byte[] bytes;
        bytes = File.ReadAllBytes(localURL);
        Texture2D texture = new Texture2D(1, 1);
        texture.LoadImage(bytes);
        Sprite thumbnail = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        UserImage.sprite = thumbnail;
    }
    public void CloseChat()
    {
        ChatManager.Instance.IsPanelOpened = false;
        ChatManager.Instance.CloseChatPanel();
    }
    public void Refresh_Chat()
    {
        LoadingManager.instance.loading.SetActive(true);
        ChatManager.Instance.RefreshChat();
    }
    public void SendPrivateMsg()
    {
        if (MessageInputField.text != "")
        {
            //ChatGui.instance.InputMessage = MessageInputField.text;
            LoadingManager.instance.loading.SetActive(true);
            //ChatGui.instance.sendDirectMsg_();
            ChatManager.Instance.SendMessage(PanelUser, MessageInputField.text);
        }
    }
	IEnumerator GetThumbnail(string uri)
	{
		Debug.Log(uri);
		UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri);
		www.SetRequestHeader("Content-type", "application/json");
		//www.SetRequestHeader("Authorization", "Bearer " + AuthManager.Token);
		yield return www.SendWebRequest();

		if (www.isNetworkError || www.isHttpError)
		{
			LoadingManager.instance.loading.SetActive(false);
			Debug.Log(www.responseCode);
		}
		else
		{
			Texture2D texture = DownloadHandlerTexture.GetContent(www);
			Sprite thumbnail = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
			UserImage.sprite = thumbnail;
            LoadingManager.instance.loading.SetActive(false);
        }
	}
}
