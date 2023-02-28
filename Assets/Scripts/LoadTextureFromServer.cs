using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadTextureFromServer : MonoBehaviour

{   public static LoadTextureFromServer instance;

    public string URL;

    private void Awake()
    {
        if (instance != null)
        {
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            instance = this;
        }
    }
   public void fetchTexture()
    {
        URL = ARItem.instance.ARuser.image;
        StartCoroutine(GetTexture());
    }

    IEnumerator GetTexture()
    {
        WWW www = new WWW(URL);
        yield return www;

        Texture2D texture = new Texture2D(1, 1);
        www.LoadImageIntoTexture(texture);
        gameObject.GetComponent< Renderer>().material.mainTexture = texture;
    }
}
