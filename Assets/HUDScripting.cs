using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;

public class HUDScripting : MonoBehaviour
{
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
        InputUIManager.instance.LoadingPanel.SetActive(true);
        DeleteUserCoroutine();
    }
    IEnumerator DeleteUserCoroutine()
    {
        WWWForm form = new WWWForm();

        string requestName = "api/v1/users/delete";
        using (UnityWebRequest www = UnityWebRequest.Post(AuthManager.BASE_URL + requestName, form))
        {
            www.SetRequestHeader("Authorization", "Bearer " + AuthManager.Token);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {

                ConsoleManager.instance.ShowMessage("Network Error");
                LoadingManager.instance.loading.SetActive(false);
                Debug.Log(www.error);
            }
            else
            {
                PlayerPrefs.DeleteAll();
            }
        }
    }


}
