using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HUDScripting : MonoBehaviour
{

    public GameObject LoadingPanel;

    public void drawerPrivacyPolicy()
    {
        Application.OpenURL("https://euphoriaxr.com/privacy-policy-2/");
    }
    public void drawerTermsAndCondition()
    {
        Application.OpenURL("https://jameelqureshi.xyz/terms-and-conditions-kargram/");
    }

    public void Scene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void Logout()
    {
        PlayerPrefs.DeleteAll();
    }

    public void DeleteAccount()
    {
        StartCoroutine(DeleteUserCoroutine());
        LoadingPanel.SetActive(true);

    }
    IEnumerator DeleteUserCoroutine()
    { 
        string requestName = "/api/v1/locations/delete_user";
        using (UnityWebRequest www = UnityWebRequest.Get(AuthManager.BASE_URL + requestName))
        {
            www.SetRequestHeader("Authorization", "Bearer " + AuthManager.Token);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {

                ConsoleManager.instance.ShowMessage("Network Error");
                LoadingPanel.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                LoadingPanel.SetActive(false);
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene("Auth");
            }
        }
    }


}
