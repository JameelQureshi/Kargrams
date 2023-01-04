 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class API_Testing : MonoBehaviour
{
    public LocationRoot LocationRoot;

    void Start()
    {
        StartCoroutine(PlaceLocationStCoroutine());
        check();
    }

    public void check()
    {
        StartCoroutine(wait(LocationRoot));
    
    }
    IEnumerator wait(LocationRoot location)
    {
        yield return new WaitForSeconds(5f);
        Debug.Log("why" + location.data.Count);
    }


    IEnumerator PlaceLocationStCoroutine()
    {
        WWWForm form = new WWWForm();
        form.AddField("lat", Input.location.lastData.latitude.ToString());
        form.AddField("lng", Input.location.lastData.longitude.ToString());
        form.AddField("radius", "60");

        string requestName = "http://ec2-3-93-231-128.compute-1.amazonaws.com/api/v1/locations/get_location?lat=47.1&lng=36.2&radius=50";

        using (UnityWebRequest www = UnityWebRequest.Post(requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + "eyJhbGciOiJIUzI1NiJ9.eyJzdWIiOiIxMiIsInNjcCI6InVzZXIiLCJhdWQiOm51bGwsImlhdCI6MTY3MjMyNzEyMSwiZXhwIjoxNjczNjIzMTIxLCJqdGkiOiJkOWFhODdiMC00NDc4LTQwNWQtODczNy01MGFjNmZjY2QzMzEifQ.Mx7_KSIkCSkcNc1AzRW4oAp93rCkU984kzk5Sq1c210");
       

            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                LocationRoot allLocationRot = JsonUtility.FromJson<LocationRoot>(www.downloadHandler.text);
                Debug.Log("Locationroot" + allLocationRot.data.Count);
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
