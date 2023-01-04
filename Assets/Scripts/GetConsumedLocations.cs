using System.Collections;
using System.Collections.Generic;
using PedometerU.Tests;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class GetConsumedLocations : MonoBehaviour
{
    
    public int TotalBounties=0;

    public GameObject ButtonPrefab;
    public GameObject ParentPanel;

    public GameObject TransectionButtonPrefab;
    public GameObject TransectionParentPanel;

    void Start()
    {
        GetTopCollectorsFunc();
    }
    public void GetConsumed_Locations()
    {
        LoadingManager.instance.loading.SetActive(true);
   //    StartCoroutine(GetConsumenLocationsCoroutine("all",AuthManager.UserId));
    }
    public void GetTopCollectorsFunc()
    {
        LoadingManager.instance.loading.SetActive(true);
        StartCoroutine(GetTopCollectors());
    }
    public void GetTransections()
    {
        LoadingManager.instance.loading.SetActive(true);
        StartCoroutine(GetTransectionsCoroutine());
    }
    public IEnumerator GetConsumenLocationsCoroutine(string amount,int id)
    {
        string requestName = "api/v1/users/get_consumed_points?onbases="+ amount +"&userid="+ id;
        //string requestName = "api/v1/users/get_consumed_points?onbases=all&userid=72";
        using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
            }
            else
            {
               // ConsumedLocationsRoot ConsumedLocationsData = JsonUtility.FromJson<ConsumedLocationsRoot>(www.downloadHandler.text);
             //   TotalBounties = ConsumedLocationsData.date.Crypto + ConsumedLocationsData.date.dexiCash + ConsumedLocationsData.date.NFTs + ConsumedLocationsData.date.QR;
                
                Debug.Log("///////////////////////////");
//                Debug.Log("AuthManager.UserId " + AuthManager.UserId);
                Debug.Log(www.downloadHandler.text);
                GetTopCollectorsFunc();
            }
        }
    }
    
    public IEnumerator GetTopCollectors()
    {
        string requestName = "api/v1/stats/top_collectors";
        using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
            }
            else
            {
               //TopHunters TopCollectors = JsonUtility.FromJson<TopHunters>(www.downloadHandler.text);
                Debug.Log("Top collectors "+www.downloadHandler.text);
                GameObject temp;
                //foreach (var i in TopCollectors.users)
                //{
                //    temp = Instantiate(ButtonPrefab, ParentPanel.transform);
                //    temp.transform.GetChild(1).GetComponent<Text>().text = ""+i.username;
                //    temp.transform.GetChild(2).GetComponent<Text>().text = ""+ StepCounter.StepsToKilometers(i.month_steps_count);
                //    temp.transform.GetChild(3).GetComponent<Text>().text = "" + i.bounty_count;
                //    //temp.gameObject.GetComponent<ButtonItem>().user = i;

                    
                //}
                ////Destroy(ButtonPrefab);
            }
        }
    }
    public IEnumerator GetTransectionsCoroutine()
    {
        Debug.Log("GetTransectionsCoroutine ");
        string requestName = "api/v1/locations/last_transactions?=";
        using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();
            if (www.isNetworkError || www.isHttpError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
            }
            else
            {
               // LastTransectionsRoot LastTransections = JsonUtility.FromJson<LastTransectionsRoot>(www.downloadHandler.text);
                Debug.Log("GetTransectionsCoroutine " + www.downloadHandler.text);
                GameObject temp1;
                string[] x;
                string time;
                //foreach (var i in LastTransections.locations)
                //{
                    temp1 = Instantiate(TransectionButtonPrefab, TransectionParentPanel.transform);
                    //time = i.updated_at.ToString();
                    //x = time.Split(' ');
                    //Debug.Log("Time ||" + x[0]);
                   // temp1.gameObject.GetComponent<TransectionItem>().Transection = i;
              //  }
                //Destroy(TransectionButtonPrefab);
                LoadingManager.instance.loading.SetActive(false);
            }
        }
    }
    //public static implicit operator JsonDateTime(DateTime dt)
    //{
    //    Debug.Log("Converted to JDT");
    //    JsonDateTime jdt = new JsonDateTime();
    //    jdt.value = dt.ToFileTimeUtc();
    //    return jdt;
    //}

}