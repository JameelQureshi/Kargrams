using System;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MessageController : MonoBehaviour
{
    public GameObject myMessagePrefab;
    public GameObject otherMessagePrefab;
    public static MessageController singleton;

    public TMP_InputField inputMessage;

    void Awake() 
    {
        singleton = this;
    }
    public void SendMessageToServer()
    {
        string message = inputMessage.text;
        if (message != "")
        {
            SpawnMessage(true, message);
            inputMessage.ActivateInputField();
            inputMessage.text = "";
        }
    }
    public void SpawnMessage(bool mine, string message)
    {
        GameObject messageGameObject = Instantiate(myMessagePrefab, this.transform);
        messageGameObject.GetComponent<MessageGO>().SetMessageInfo(message, true);
    }
}
