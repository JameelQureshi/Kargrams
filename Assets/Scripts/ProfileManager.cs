using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ProfileManager : MonoBehaviour
{
    public static ProfileManager instance;

    [Header("PROFILE INFO")]
    public Image Profile_Image;
    public Text FullName;
    public Text Username;
    public Image EditPanelProfile_Image;

    [Header("HOME SCREEN")]
    public Text First_Name;
    public Text userNameText;
    public Image Profile_ImageSquare;

    [Header("STAT SCREEN")]
    public Text stat_First_Name;
    public Text stat_userNameText;
    public Image stat_Profile_ImageSquare;

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

    void Start()
    {
        Initialize_User_Info();
    }
    public void Initialize_User_Info()
    {
        //Debug.Log("First Name "+AuthManager.First_Name);
        //if (AuthManager.First_Name == "Default_Name" || AuthManager.First_Name == "default_name")
        //{
        //   // First_Name.text = "Hello";
        //    FullName.text = "";
        //}
        //else
        //{
        //    First_Name.text =  AuthManager.First_Name;
        //    FullName.text = AuthManager.Name;
        //    stat_First_Name.text= AuthManager.First_Name;
        //}
        //userNameText.text = AuthManager.Username;
        //Username.text = "@"+AuthManager.Username;
        //stat_userNameText.text= AuthManager.Username;
        //try
        //{
        //    string destination = Application.persistentDataPath + "/capture" + ".png";
        //    Debug.Log("Uploading");
        //    byte[] bytes = File.ReadAllBytes(destination);
        //    Texture2D texture = new Texture2D(2,2);
        //    texture.LoadImage(bytes);
        //    Sprite thumbnail = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        //    Profile_Image.sprite = thumbnail;
        //    Profile_ImageSquare.sprite = thumbnail;
        //    EditPanelProfile_Image.sprite = thumbnail;
        //    stat_Profile_ImageSquare.sprite = thumbnail;
        //}
        //catch
        //{

        //}
       
        
    }
}
