using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
//using TcpClient = NetCoreServer.TcpClient;


public class Client : MonoBehaviour
{
    public TMP_InputField inputMessage;
    public TMP_InputField inputNickname;

    public void SendMessageToServer()
    {
        string message = inputMessage.text;
        if (message != "")
        {
            //chatClient.SendAsync(nickname + ": " + message);
            MessageController.singleton.SpawnMessage(true,message);
            // EventSystem.current.SetSelectedGameObject(inputMessage.gameObject);
            inputMessage.ActivateInputField();
            inputMessage.text = "";
        }
    }

    public void EnterSendMessageToServer()
    {
        if(Input.GetKey(KeyCode.KeypadEnter) || Input.GetKey(KeyCode.Return))
        {
            SendMessageToServer();
        }
    }
}