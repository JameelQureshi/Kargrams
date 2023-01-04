using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class ButtonItem : MonoBehaviour
{
//    public TopUser user;
    public Image UserIcon;
    public Sprite DefualtImage;
    private void Start()
    {
        //if (user.prfile_image_url != "" || user.prfile_image_url != null)
        //{
        //    StartCoroutine(GetImageFromUrl(user.prfile_image_url));
        //}
        //else
        //{
        //    UserIcon.sprite = DefualtImage;
        //}

       // GetComponent<Button>().onClick.AddListener(delegate { HunterProfile.instance.Open(user,UserIcon.sprite); });
    }



    IEnumerator GetImageFromUrl(string uri)
    {
        Debug.Log(uri);
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(uri);
        www.SetRequestHeader("Content-type", "application/json");
        //www.SetRequestHeader("Authorization", "Bearer " + AuthManager.Token);
        yield return www.SendWebRequest();

        if (www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.responseCode);
        }
        else
        {
            Texture2D texture = DownloadHandlerTexture.GetContent(www);
            Debug.Log("Image Downloaded!");
            UserIcon.sprite = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            //Sprite thumbnail = Sprite.Create(texture, new Rect(0.0f, 0.0f, texture.width, texture.height), new Vector2(0.5f, 0.5f));
            //AR_User_Image.GetComponent<Image>().sprite = thumbnail;
        }
    }
}
