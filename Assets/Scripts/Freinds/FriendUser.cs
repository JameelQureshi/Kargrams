using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FriendUser : MonoBehaviour
{
    public Text nameText;
    public ImageController imageController;
    private string ImageLocalPath;

    public User user;
    public void Init(User user)
    {
        this.user = user;
        //nameText.text = " " + user.username;
        //imageController.Init(user.id, user.prfile_image_url);
    }

    public void Unfriend()
    {
        Debug.Log("Unfriend  clicked");
        FriendListCreator.instance.OpenConfirmUnfriendPanel(this);
    }
}
