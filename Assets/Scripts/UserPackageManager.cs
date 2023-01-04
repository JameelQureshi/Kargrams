using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class UserPackageManager : MonoBehaviour
{
    public Text AvalaibleRedemptionsProfilePanel;
    public Text AvalaibleRedemptionsAssetsPanel;


    void Start()
    {
        //LoadingManager.instance.loading.SetActive(true);
        //StartCoroutine(GetAvalaiblePackage());
    }

    public void UpgradePackage(string PackageName)
    {
        LoadingManager.instance.loading.SetActive(true);
        StartCoroutine(UpgradePackage(0, PackageName, true));
    }

    public void UpgradeBountyCount(int BountyCount)
    {
        LoadingManager.instance.loading.SetActive(true);
        StartCoroutine(UpgradePackage(BountyCount, "", false));
    }

    private IEnumerator GetAvalaiblePackage()
    {
        string requestName = "api/v1/packages";

        using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {
                ConsoleManager.instance.ShowMessage("Network Error!");
                Debug.Log(www.error);
            }
            else
            {
               // BountyPackageRoot PackageData= JsonUtility.FromJson<BountyPackageRoot>(www.downloadHandler.text);
                //if (PackageData.success)
                //{
                //    Debug.Log("Package "+ www.downloadHandler.text);
                //    AvalaibleRedemptionsProfilePanel.text = "" + PackageData.count;
                //    AvalaibleRedemptionsAssetsPanel.text = "" + PackageData.count;
                //    Debug.Log("AvalaibleRedemptionsProfilePanel "+ AvalaibleRedemptionsProfilePanel.text);
                //}
                //else
                //{
                //    ConsoleManager.instance.ShowMessage("Package Error!");
                //}
                //LoadingManager.instance.loading.SetActive(false);
            }
        }
    }

    IEnumerator UpgradePackage(int count,string name, bool Package)
    {
        Debug.Log("count " + count);
        Debug.Log("name " + name);
        Debug.Log("Package " + Package);
        WWWForm form = new WWWForm();
        if (Package)
        {
            form.AddField("name", name);
        }
        else
        {
            form.AddField("count", count);
        }
        string requestName = "api/v1/packages";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + Auth0Manager.AccessToken);
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.ConnectionError || www.result == UnityWebRequest.Result.ProtocolError)
            {

                Debug.Log(www.downloadHandler.text);
                Debug.Log(www.error);
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log("No Crypto for Retrieve");
            }
            else
            {
                LoadingManager.instance.loading.SetActive(false);
             //   PackageResponceRoot PackageResponce = JsonUtility.FromJson<PackageResponceRoot>(www.downloadHandler.text);
                //if (PackageResponce.success)
                //{
                //    ConsoleManager.instance.ShowMessage("Package upgraded");
                //}
                //else
                //{
                //    ConsoleManager.instance.ShowMessage("Package not upgraded");
                //}
            }
        }
    }
}
