using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
 
public class UserController : MonoBehaviour
{
    public Text nameText;
    public ImageController imageController;
    public Text addButtonText;

    public User user;
    public void Init(User user )
    {
        this.user = user;
   //     nameText.text = " " + user.username;
//        imageController.Init(user.id,user.prfile_image_url);
    }

    public void ResetData()
    {
        nameText.text = "";
        addButtonText.text = "Add";
        imageController.ResetImage();
    }
    public void Add()
    {
        LoadingManager.instance.loading.SetActive(true);
        StartCoroutine(SendFreindRequest(user.id.ToString()));
    }
    IEnumerator SendFreindRequest(string receiver_id)
    {
        string requestName = "/api/v1/friendship";
        string request = AuthManager.BASE_URL + requestName;
        WWWForm form = new WWWForm();
        form.AddField("receiver_id", receiver_id);
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
                    ConsoleManager.instance.ShowMessage("Request Sent");
                    addButtonText.text = "Sent";
                    //OneSignalManager.instance.SendNotificationTo(user.notification_id,(AuthManager.Username));
                    break;
            }
            LoadingManager.instance.loading.SetActive(false);
        }
    }
}
