using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BountiesCollector : MonoBehaviour
{

    public static BountiesCollector instance;



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

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void CollectBounty()
    {
        StartCoroutine(PostCollectBounty("742"));
    }

    public void GetBountiesCollected()
    {
        StartCoroutine(BountiesCollectedRequest());
 
    }

    IEnumerator BountiesCollectedRequest()
    {
        WWWForm form = new WWWForm();
        form.AddField("onbasess", "");
        form.AddField("id", "");

        string requestName = "api/v1/users/get_consumed_points";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleManager.instance.ShowMessage("User not created!");
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                // Bounty Collected!

            }
        }
    }

    IEnumerator PostCollectBounty(string id)
    {
        WWWForm form = new WWWForm();
        form.AddField("id", id);

        string requestName = "api/v1/location/location_consumed";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleManager.instance.ShowMessage("User not created!");
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log(www.downloadHandler.text);
                // Bounty Collected!
                
            }
        }
    }
}
