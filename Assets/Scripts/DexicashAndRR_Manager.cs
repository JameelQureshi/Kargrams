using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using Mapbox.Json;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class DexicashAndRR_Manager : MonoBehaviour
{
    public Text RewardRedemptionText_1;
    public Text RewardRedemptionText_2;
    public Text Dexicash;
    public static string UserID;
    public static int RewardRedemptions;

    
    void Start()
    {
        UserID = JsonConvert.DeserializeObject<Dictionary<string, object>>(Encoding.UTF8.GetString(Convert.FromBase64String(Auth0Manager.AccessToken.Split('.')[1])))["https://dexioprotocol.com/userId"].ToString();
        LoadingManager.instance.loading.SetActive(true);
        Debug.Log("UserID "+ UserID);
        StartCoroutine(GetDexicash(UserID));
        StartCoroutine(GetRewardRedemptions(UserID));
    }
    private IEnumerator GetDexicash(string UserID)
    {
        string requestName = "https://api.dexioprotocol.com/dexicash/"+UserID+"/balance?";

        using (UnityWebRequest www = UnityWebRequest.Get( requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                Debug.Log(www.error);
                Debug.Log("Dexicash Error");
            }
            else
            {
                Debug.Log("Dexicash Data "+ www.downloadHandler.text);
//                RR_And_DexicashRoot DexicashData = JsonUtility.FromJson<RR_And_DexicashRoot>(www.downloadHandler.text);
             //   Dexicash.text = DexicashData.Balance.balance.ToString();
                LoadingManager.instance.loading.SetActive(false);
                
            }
        }
    }
    private IEnumerator GetRewardRedemptions(string UserID)
    {
        Debug.Log("GetRewardRedemptions");
        string requestName = "https://api.dexioprotocol.com/redemptions/"+UserID+"/balance?";

        using (UnityWebRequest www = UnityWebRequest.Get(requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                Debug.Log("Redemption Error");
                Debug.Log(www.error);
            }
            else
            {
                Debug.Log("RewardRedemptions Data " + www.downloadHandler.text);
              //  RR_And_DexicashRoot RewardRedemptionData = JsonUtility.FromJson<RR_And_DexicashRoot>(www.downloadHandler.text);
                //RewardRedemptions = int.Parse( RewardRedemptionData.Balance.balance);
                //RewardRedemptionText_1.text = RewardRedemptionData.Balance.balance.ToString();
                //RewardRedemptionText_2.text = RewardRedemptionData.Balance.balance.ToString();
                LoadingManager.instance.loading.SetActive(false);
            }
        }


    }

}
