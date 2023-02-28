using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownlaodImg : MonoBehaviour
{

    public Datum Button_user;

    private void Start()
    {
        //string uri = ARItem.instance.ARuser.image;
        //StartCoroutine(GetTexture(uri));
    }
    IEnumerator GetTexture(string url)
    {
        WWW www = new WWW(url);
        yield return www;
        Texture2D texture = new Texture2D(1, 1);
        www.LoadImageIntoTexture(texture);
        gameObject.GetComponent<Renderer>().material.mainTexture = texture;
    }
}
