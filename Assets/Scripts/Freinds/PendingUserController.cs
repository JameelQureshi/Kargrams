using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PendingUserController : MonoBehaviour
{
    public Text nameText;
    public ImageController imageController;

    public User user;
    public void Init(User user)
    {
        this.user = user;
        //nameText.text = " " + user.username;
        //imageController.Init(user.id, user.prfile_image_url);
    }

    public void ResetData()
    {
        nameText.text = "";
        imageController.ResetImage();
    }

    public void AcceptRequest()
    {
        LoadingManager.instance.loading.SetActive(true);
        AddFreinds.instance.FreindRequestResponse(user, "accepted");
    }

    public void RejectRequest()
    {
        LoadingManager.instance.loading.SetActive(true);
        AddFreinds.instance.FreindRequestResponse(user, "canceled");
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
