using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Networking;
using UnityEngine.UI;
using PedometerU.Tests;

public class DistanceManager : MonoBehaviour
{
    public static DistanceManager instance;

    //public Text TestingText;
    //public Text TestingText1;
    //public Text TestingText2;
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
    public string LastSavedDateTime
    {
        set
        {
            PlayerPrefs.SetString("LastSavedDateTime",value);
        }
        get
        {
            return PlayerPrefs.GetString("LastSavedDateTime", "1/17/2022 12:36:30 PM");
        }
    }

    public static int FeetWalkedWeekly;
    public static int FeetWalkedMonthly;

    public static int FeetWalked
    {
        set
        {
            PlayerPrefs.SetInt("FeetWalked", value);
        }
        get
        {
            return PlayerPrefs.GetInt("FeetWalked", 0);
        }
    }

    private void Start()
    {
        //TestingText.text = "" + FeetWalked;
        //Debug.Log(DateTimeToUnixTimeStamp(DateTime.UtcNow));
        SaveFeetWalked();
        //LoadingManager.instance.loading.SetActive(true);
        //StepCounter.instance.GetSteps();
        //TestingText2.text = "get steps " + FeetWalked;
    }

    public void SaveFeetWalked()
    {
        DateTime lastDate = DateTime.Parse(LastSavedDateTime);
        DateTime dateTimeNow = DateTime.Now;
        if (lastDate.Date != dateTimeNow.Date || lastDate.Year != dateTimeNow.Year || lastDate.Month != dateTimeNow.Month )
        {
            StartCoroutine(UploadFeetWalked(FeetWalked.ToString(), DateTimeToUnixTimeStamp(dateTimeNow.AddHours(-24)),true));
        }
        else
        {
            StartCoroutine(UploadFeetWalked(FeetWalked.ToString(), DateTimeToUnixTimeStamp(dateTimeNow)));
        }
    }

   

    IEnumerator UploadFeetWalked(string step, string timestamps , bool restFeet = false)
    {
        string requestName = "api/v1/steps";
        string request = AuthManager.BASE_URL + requestName;
        WWWForm form = new WWWForm();
        form.AddField("timestamps", timestamps);
        form.AddField("step", step);
        

        using (UnityWebRequest webRequest = UnityWebRequest.Post(request, form))
        {
            webRequest.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            // Request and wait for the desired page.
            yield return webRequest.SendWebRequest();

            string[] pages = request.Split('/');
            int page = pages.Length - 1;
            switch (webRequest.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(pages[page] + ": Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError(pages[page] + ": HTTP Error: " + webRequest.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(pages[page] + ":\nReceived: " + webRequest.downloadHandler.text);
//                    UnFriendResponceRoot StepsResponce = JsonUtility.FromJson<UnFriendResponceRoot>(webRequest.downloadHandler.text);
                    if (restFeet)
                    {
                        FeetWalked = 0;
                    }
                    //if (StepsResponce.success)
                    //{
                    //    FeetWalked = 0;
                    //    Debug.Log("FeetWalked " + FeetWalked);
                    //}
                    LastSavedDateTime = DateTime.Now.ToString();
                    break;
            }
            //TestingText1.text = "After upload " + FeetWalked;
        }
    }

    public string DateTimeToUnixTimeStamp(DateTime dateTime)
    {
        DateTime epochStart = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        int timeStamp = (int)(dateTime - epochStart).TotalSeconds;
        return timeStamp.ToString();
    }


    public static DateTime UnixTimeStampToDateTime(string timeStamp)
    {
        DateTime dtDateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, System.DateTimeKind.Utc);
        dtDateTime = dtDateTime.AddSeconds(double.Parse(timeStamp)).ToLocalTime();
        return dtDateTime;
    }


}
