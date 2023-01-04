using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class HuntWithFriends : MonoBehaviour
{
    public Image sizeRef;
    public GameObject huntWithFriendUser;
    public List<HuntWithFriendUser> huntWithFriendUsers;
    public GameObject huntWithFriendsPanel;

    public void ClearAll()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
        huntWithFriendUsers.Clear();

    }

    public void CreateList()
    {
        ClearAll();
        huntWithFriendUsers = new List<HuntWithFriendUser>();

        foreach (FriendUser user in FriendListCreator.instance.friendUsers)
        {
            GameObject refUser = Instantiate(huntWithFriendUser, this.transform);
            refUser.GetComponent<HuntWithFriendUser>().Init(user.user);
            huntWithFriendUsers.Add(refUser.GetComponent<HuntWithFriendUser>());
        }
        AdjustSize();
    }


    private void AdjustSize()
    {
        Vector2 cellSize = new Vector2(sizeRef.rectTransform.rect.size.x, 400);
        GetComponent<GridLayoutGroup>().cellSize = cellSize;
    }

    public void InviteToHunt()
    {
        List<string> listForInvite = new List<string>();
        foreach (HuntWithFriendUser user in huntWithFriendUsers)
        {
            if (user.selected.isOn)
            {
               // listForInvite.Add(user.user.notification_id);
            }
        }
        if (listForInvite.Count == 0)
        {
            ConsoleManager.instance.ShowMessage("Nothing Selected");
        }
        else
        {
            //            Debug.Log(AuthManager.NotificationId);
            foreach (string list in listForInvite)
            {
                Debug.Log(list);
            }

            //OneSignalManager.instance.SendNotificationToList(listForInvite, AuthManager.First_Name, " Invited you for Hunt");
            huntWithFriendsPanel.SetActive(false);
        }
    }

}
