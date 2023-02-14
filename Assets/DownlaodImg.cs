using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class DownlaodImg : MonoBehaviour
{
    public GameObject cube;
   
    private void Start()
    {
        string uri = "https://kargram-production.s3.us-west-1.amazonaws.com/mbiify8j62nf5s7i3izj16nn1hrl?response-content-disposition=inline%3B%20filename%3D%22image.jpeg%22%3B%20filename%2A%3DUTF-8%27%27image.jpeg&response-content-type=image%2Fjpeg&X-Amz-Algorithm=AWS4-HMAC-SHA256&X-Amz-Credential=ASIA4NXW2SAAB3OYDE4P%2F20230214%2Fus-west-1%2Fs3%2Faws4_request&X-Amz-Date=20230214T074955Z&X-Amz-Expires=300&X-Amz-Security-Token=IQoJb3JpZ2luX2VjEHgaCXVzLWVhc3QtMSJGMEQCIGiR0JHullxkJ7SNZU10TD8VhhhiA2oVjSiV9F%2BEYMOLAiBIpZw%2FILfI7dj%2BWEDMO0fqs7ws%2F0TxzQF8%2F6YN3LfPQyrNBAgQEAAaDDg1NDE0MjM5MDI3MiIMj3XPecVQBAfj6cG9KqoE0pG7J0UgH6p2E%2Biu0XimMVF7BDIpML3vWaWJ%2BmohVHnOsoskuA4mbrq%2BBqwwJLUYay%2FZrFUsXWK%2BIHoYgOjyc2ZkALS%2FBdv15J9Jq7nGjceB7ZMMnmz0TWob3%2Faqkvn%2FOBYk6DkIcoXLH8dPL9%2B%2BmBcc1BSPi%2B%2BXB38AqyyWGnFXkphHlvjaKfM2sLLeXfx%2B2WtVOT9%2FPEr7FePCIBqIRaK%2B09VNVGx5R5oriKvNbIYFJ0HPOU99QIqLQKk4GlDvk19MzBTSIkCanGLySGLjdA9J7FkOn388GjhIM8YORSFPkA8NRzINkHGYNpRL1evBno9fGNyXCoKreVF48f1J3TZot1496QL5Bxlclytqikiz9aX7sEOIfwRX9m0%2FEimZ%2Fkb169UYa84w754fcdgdk9vbnS4ng8wPKSjGXlbfNMZkVpNsjtnYDEktZ%2BdjMpuSWLXeqTezQIZow3As%2F4%2FmHmyze5sL37ZsNXeI%2Bsh2lutdVtV5zMsOyFX4PgjWriM2cE7sufI8z3ZGwMADHvcgbXK6UAgpKRjzb6qyNdqp0g%2FCCaojVaGlwQ3zlYJNkbquJiznj%2FeFIMco4FLnq4GyM3%2FMPpUZs8sAxfg%2F9mp5tKP2pru%2BEZrRMtTjIbcud4x5LFKOmOEST9F%2F97ka5duQzQ11qRcEU3QsFjAekGw3%2Bfngt6gIat%2Fmk%2BKX8p8bNkuqGNoqFlPbXJ33zJNmm8PMYNGqCITZOUJACkIwz%2BusnwY6qgEQ2yBARzZld0fD9XkWS8J2clb4Xb3Y12rAqIWMgyHitCxVU8pk6AC62xTRDSRsY8d9nQSwPLHu6yAvvsq0njZKH2ET%2FBBhOyzowATNPAFgzGe3XzxRWdKwTrXfF6i%2F4kvP77tv7Fjt6GfIMsdNqXcq6P4tpFaEmQEfqoiUaZdOyBoMbLESj%2BYUD9lS76c2m07JHtwu9zPyBjQ1OogSpAoSn3AtxYAtNfc9rw%3D%3D&X-Amz-SignedHeaders=host&X-Amz-Signature=88d71579ab4dd94b521de63b8915db98074174689fef64eba8317226ba867c7c";
        StartCoroutine(GetTexture(uri));
    }
    IEnumerator GetTexture(string url)
    {

        WWW www = new WWW(url);
        yield return www;
        Texture2D texture = new Texture2D(1, 1);
        www.LoadImageIntoTexture(texture);
        
        cube.GetComponent<Renderer>().material.mainTexture = texture;
        //UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        //yield return www.SendWebRequest();

        //if (www.result == UnityWebRequest.Result.Success)
        //{
        //    Texture2D texture = DownloadHandlerTexture.GetContent(www);
        //    GetComponent<Renderer>().material.mainTexture = texture;

        //    cube.GetComponent<Renderer>().material.mainTexture = texture;
        //}
        //else
        //{
        //    Debug.Log("error" + www.error);
        //}
    }
}
