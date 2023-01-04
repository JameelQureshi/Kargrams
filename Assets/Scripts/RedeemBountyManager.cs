using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class RedeemBountyManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    IEnumerator RequestAssetRequest(string transaction_hash, string dxg_amount, string walle_adresse, string use_in_future, string count, string location_id)
    {
        WWWForm form = new WWWForm();
        form.AddField("transection_hash", transaction_hash);
        form.AddField("dxg_amount", dxg_amount);
        form.AddField("walle_adress", walle_adresse);
        form.AddField("use_in_future", use_in_future); // this field is used to show wallet address in Consume location api when it's value is true.
        form.AddField("count", count);
        form.AddField("id", location_id);
        

        string requestName = "api/v1/locations/redeem_bounties";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();
            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log("Error");
                ConsoleManager.instance.ShowMessage("Network Error");
            }
            else
            {
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log(www.downloadHandler.text);
            }
        }
    }
}
