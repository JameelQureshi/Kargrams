using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class FriendListCreator : MonoBehaviour
{
    public static FriendListCreator instance;
    public Image sizeRef;
    public GameObject friendUser;

    public GameObject confirmPanel;
    public Text message;
    FriendUser friend;

    public List<FriendUser> friendUsers;

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
    public void ClearAll()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        friendUsers.Clear();
    }
    //public void CreateList(FriendsList friendsList)
    //{
    //    friendUsers = new List<FriendUser>();

    //    foreach (User user in friendsList.users)
    //    { 
    //        GameObject refUser = Instantiate(friendUser,this.transform);
    //        refUser.GetComponent<FriendUser>().Init(user);
    //        friendUsers.Add(refUser.GetComponent<FriendUser>());
    //    }
    //    AdjustSize();
    //}

    private void AdjustSize()
    {
        Vector2 cellSize = new Vector2(sizeRef.rectTransform.rect.size.x,400);
        GetComponent<GridLayoutGroup>().cellSize = cellSize;
    }

    
    public void OpenConfirmUnfriendPanel(FriendUser friendUser)
    {
        friend = friendUser;
        message.text = "Remove "+friend.nameText.text+  "\n from friendlist";
        confirmPanel.SetActive(true);
    }

    public void ConfrimUnfriend()
    {
        StartCoroutine(PostUnfriendRequest());
    }
    public void CancelUnfriend()
    {
        confirmPanel.SetActive(false);
    }

    private IEnumerator PostUnfriendRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("", "");

        string requestName = "api/v1/friendship/"+friend.user.id+"/unfriend_user";
        string request = AuthManager.BASE_URL + requestName;
        // Debug.Log(request);

        using (UnityWebRequest webRequest = UnityWebRequest.Post(request,form))
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
                    LoadingManager.instance.loading.SetActive(false);
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    LoadingManager.instance.loading.SetActive(false);
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
                 //  UnFriendResponceRoot Responce = JsonUtility.FromJson<UnFriendResponceRoot>(webRequest.downloadHandler.text);
                    //if (Responce.success)
                    //{
                    //    Destroy(friend.gameObject);
                    //    confirmPanel.SetActive(false);
                    //    LoadingManager.instance.loading.SetActive(false);
                    //    ConsoleManager.instance.ShowMessage("Friend Removed");
                    //}
                    //else
                    //{
                    //    //confirmPanel.SetActive(false);
                    //    LoadingManager.instance.loading.SetActive(false);
                    //    ConsoleManager.instance.ShowMessage("Error! try again later");
                    //}
                    break;
            }
        }
    }
}
